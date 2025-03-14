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
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { CursoDisciplina } from '../../../../shared/models/cursoDisciplina';
import { Disciplina } from '../../../../shared/models/disciplina';
import { CursoService } from '../../../../core/services/curso.service';
import { DisciplinaService } from '../../../../core/services/disciplina.service';
import { Curso } from '../../../../shared/models/curso';

@Component({
  selector: 'app-modal-cadastrar-curso-disciplina',
  templateUrl: './modal-cadastrar-curso-disciplina.component.html',
  styleUrls: ['./modal-cadastrar-curso-disciplina.component.css'],
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
export class ModalCadastrarCursoDisciplinaComponent implements OnInit {
  public formCadastro: FormGroup;

  @Output() cursoAdicionado: EventEmitter<void> = new EventEmitter<void>();

  public listaDisciplinas: Disciplina[] = [];
  public listaCursos: Curso[] = [];

  constructor(
    public dialogRef: MatDialogRef<ModalCadastrarCursoDisciplinaComponent>,
    private fb: FormBuilder,
    private readonly cursoService: CursoService,
    private toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) public curso: CursoDisciplina,
    private readonly disciplinaService: DisciplinaService
  ) {
    this.formCadastro = this.fb.group({
      id: [this.curso ? this.curso.id : 0],
      cursoId: null,
      disciplinaId: null,
      disciplina: [null, Validators.required],
      curso: [null, Validators.required],
    });
  }

  ngOnInit(): void {
    console.log(this.curso);
    this.preencherFormulario();
    this.recuperarDisciplinas();
    this.recuperarCursos()
    this.formCadastro.valueChanges.subscribe((value) => {
      console.log('Formulário alterado:', value);
    });
  }

  preencherFormulario(): void {
    if (this.curso) {
      this.formCadastro.patchValue({
        id: this.curso.id,
        curso: this.curso.curso,
        disciplina: this.curso.disciplina,
        cursoId: this.curso.curso.id,
        disciplinaId: this.curso.disciplina.id,
      });
    }
  }
  recuperarCursos(): void {
    this.cursoService.obterTodos().subscribe((response) => {
      this.listaCursos = response;

      this.preencherFormulario();
    });
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

      const curso: CursoDisciplina = {
        id: formValue.id?? 0,
        curso: formValue.curso,
        cursoId: formValue.curso.id,
        disciplina: formValue.disciplina,
        disciplinaId: formValue.disciplina.id,
      };

        const request = curso.id
        ? this.cursoService.atualizarCursoDisciplina(curso.id, curso)
        : this.cursoService.inserirCursoDisciplina(curso);

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

  trackByCurso(index: number, curso: Curso): number {
    return curso.id;
  }

  compareCurso(curso1: Curso, curso2: Curso) {
    return curso1 && curso2 ? curso1.id === curso2.id : curso1 === curso2;
  }
}
