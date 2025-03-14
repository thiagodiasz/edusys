import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Curso } from '../../../shared/models/curso';
import { CursoService } from '../../../core/services/curso.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { Professor } from '../../../shared/models/professor';
import { ProfessorService } from '../../../core/services/professor.service';
import { DisciplinaService } from '../../../core/services/disciplina.service';
import { Disciplina } from '../../../shared/models/disciplina';

@Component({
  selector: 'app-modal-cadastrar-curso',
  templateUrl: './modal-cadastrar-curso.component.html',
  styleUrls: ['./modal-cadastrar-curso.component.scss'],
  standalone: true,
  imports: [
    MatButtonModule,
    MatDividerModule,
    MatDialogActions,
    MatDialogClose,
    MatDialogTitle,
    MatDialogContent,
    ReactiveFormsModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    CommonModule,
    MatSelectModule,
  ],
})
export class ModalCadastrarCursoComponent implements OnInit {
  public formCadastro: FormGroup;

  @Output() cursoAdicionado: EventEmitter<void> = new EventEmitter<void>();

  public listaDisciplinas: Disciplina[] = [];

  constructor(
    public dialogRef: MatDialogRef<ModalCadastrarCursoComponent>,
    private fb: FormBuilder,
    private readonly cursoService: CursoService,
    private toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) public curso: Curso,
    private readonly disciplinaService: DisciplinaService
  ) {
    this.formCadastro = this.fb.group({
      nome: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    console.log(this.curso);
    this.preencherFormulario();
    this.recuperarDisciplinas();
    this.formCadastro.valueChanges.subscribe((value) => {
      console.log('Formulário alterado:', value);
    });
  }
  preencherFormulario(): void {
    if (this.curso) {
      this.formCadastro.patchValue({
        id: this.curso.id,
        nome: this.curso.nome,
      });
    }
  }
  compareFn(v1: Disciplina, v2: Disciplina): boolean {
    return v1 && v2 ? v1.id === v2.id : v1 === v2;
  }
  recuperarDisciplinas(): void {
    this.disciplinaService.obterTodos().subscribe((response) => {
      this.listaDisciplinas = response;

      this.preencherFormulario();
    });
  }

  onSubmit() {
    if (this.formCadastro.valid) {
      const formValue = this.formCadastro.value;

      const curso: Curso = {
        id: this.curso ? this.curso.id : 0,
        nome: formValue.nome,
      };

      const request = curso.id
        ? this.cursoService.atualizar(curso.id, curso)
        : this.cursoService.inserir(curso);

      request.subscribe({
        next: () => {
          this.toastr.success('Curso cadastrado com sucesso!');
          this.cursoAdicionado.emit();
          this.dialogRef.close(true);
        },
        error: (error) => {
          console.error('Erro ao cadastrar curso:', error);
          this.toastr.error(error.error || error.message);
        },
      });
    }
  }

  trackByDisciplina(index: number, disciplina: Disciplina): number {
    return disciplina.id;
  }

  compareDisciplina(disciplina1: Disciplina, disciplina2: Disciplina) {
    return disciplina1 && disciplina2
      ? disciplina1.id === disciplina2.id
      : disciplina1 === disciplina2;
  }
}
