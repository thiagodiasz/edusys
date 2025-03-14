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
import { Disciplina } from '../../../shared/models/disciplina';
import { DisciplinaService } from '../../../core/services/disciplina.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { Professor } from '../../../shared/models/professor';
import { ProfessorService } from '../../../core/services/professor.service';

@Component({
  selector: 'app-modal-cadastrar-disciplina',
  templateUrl: './modal-cadastrar-disciplina.component.html',
  styleUrls: ['./modal-cadastrar-disciplina.component.scss'],
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
export class ModalCadastrarDisciplinaComponent implements OnInit {
  public formCadastro: FormGroup;

  @Output() disciplinaAdicionado: EventEmitter<void> = new EventEmitter<void>();

  public listaProfessores: Professor[] = [];

  constructor(
    public dialogRef: MatDialogRef<ModalCadastrarDisciplinaComponent>,
    private fb: FormBuilder,
    private readonly disciplinaService: DisciplinaService,
    private toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) public disciplina: Disciplina,
    private readonly professorService: ProfessorService
  ) {
    this.formCadastro = this.fb.group({
      nome: ['', Validators.required],
      professorId: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    console.log(this.disciplina);
    this.preencherFormulario();
    this.recuperarProfessores();
    // this.formCadastro.valueChanges.subscribe((value) => {
    //   console.log('Formulário alterado:', value);
    // });
  }
  preencherFormulario(): void {
    if (this.disciplina) {
      this.formCadastro.patchValue({
        nome: this.disciplina.nome,
        professorId: this.disciplina.professorId,
      });
    }
  }

  recuperarProfessores(): void {
    this.professorService.obterTodos().subscribe((response) => {
      this.listaProfessores = response;
    });
  }

  onSubmit() {
    if (this.formCadastro.valid) {
      const formValue = this.formCadastro.value;

      const disciplina: Disciplina = {
        id: this.disciplina ? this.disciplina.id : 0,
        nome: formValue.nome,
        professorId: formValue.professorId
      };

      const request = disciplina.id
        ? this.disciplinaService.atualizar(disciplina.id, disciplina)
        : this.disciplinaService.inserir(disciplina);

      request.subscribe({
        next: () => {
          this.toastr.success('Disciplina cadastrado com sucesso!');
          this.disciplinaAdicionado.emit();
          this.dialogRef.close(true);
        },
        error: (error) => {
          console.error('Erro ao cadastrar disciplina:', error);
          this.toastr.error(error.error || error.message);
        },
      });
    }
  }
}
