import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { MatriculaService } from '../../../core/services/matricula.service';
import { AlunoService } from '../../../core/services/aluno.service';
import { CursoService } from '../../../core/services/curso.service';
import { Aluno } from '../../../shared/models/aluno';
import { Curso } from '../../../shared/models/curso';
import { InserirAlunoComMatriculaRequest, Matricula } from '../../../shared/models/matricula';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';

@Component({
  selector: 'app-modal-cadastrar-matricula',
  templateUrl: './modal-cadastrar-matricula.component.html',
  styleUrls: ['./modal-cadastrar-matricula.component.scss'],
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
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' }, // ou o locale desejado
  ],
})
export class ModalCadastrarMatriculaComponent implements OnInit {
  public formCadastro: FormGroup;
  public listaCursos: Curso[] = [];
  public listaAlunos: Aluno[] = [];

  public sexoOptions = [
    { value: 'Masculino', label: 'Masculino' },
    { value: 'Feminino', label: 'Feminino' },
  ];

  @Output() matriculaAdicionado: EventEmitter<void> = new EventEmitter<void>();

  constructor(
    public dialogRef: MatDialogRef<ModalCadastrarMatriculaComponent>,
    private fb: FormBuilder,
    private readonly matriculaService: MatriculaService,
    private toastr: ToastrService,
    private readonly cursoService: CursoService,
    private readonly alunoService: AlunoService,
    @Inject(MAT_DIALOG_DATA) public matricula: Matricula


  ) {
    this.formCadastro = this.fb.group({
      id: null,
      aluno: [null, Validators.required],
      curso: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    this.recuperarCursos();
    this.recuperarAlunos();
    this.preencherFormulario()
  }

  preencherFormulario(): void {
    if (this.matricula) {
      this.formCadastro.patchValue({
        id: this.matricula.id,
        aluno: this.listaAlunos.find(aluno => aluno.id === this.matricula.alunoId),
        curso: this.listaCursos.find(curso => curso.id === this.matricula.cursoId),
      });
      console.log("value",this.formCadastro.value);
    }
  }
  recuperarAlunos(): void {
    this.alunoService.obterTodos().subscribe((response) => {
      this.listaAlunos = response;
      this.preencherFormulario();
    });
  }
  recuperarCursos(): void {
    this.cursoService.obterTodos().subscribe((response) => {
      this.listaCursos = response;
      this.preencherFormulario();
    });
  }

  onSubmit() {
    if (this.formCadastro.valid) {
      
      const formValue = this.formCadastro.value;

      const alunoMatricula: InserirAlunoComMatriculaRequest = {
        id: formValue.id,
        alunoId: formValue.aluno.id,
        cursoId: formValue.curso.id,
      };

      let alunoAtualizar:any ={};
      if(this.matricula){
        alunoAtualizar = {
          id: this.matricula.id,
          alunoId: formValue.aluno.id,
          cursoId: formValue.curso.id,
          numero: this.matricula.numero
        }
      }
     
      console.log(alunoAtualizar)
      const request = alunoAtualizar.id
      ? this.matriculaService.atualizar(this.matricula.id, alunoAtualizar)
      : this.matriculaService.inserirAlunoComMatricula(alunoMatricula);

      request.subscribe({
        next: (mensagem) => {
          this.toastr.success('Matrícula cadastrada com sucesso!');
          this.matriculaAdicionado.emit();
          this.dialogRef.close(mensagem);
        },
        error: (error) => {
          console.error('Erro ao cadastrar matrícula:', error);
          this.toastr.error(error.error || error.message);
        },
      });
    }
  }
}

