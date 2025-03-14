import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { NotaService } from '../../../core/services/nota.service';
import { AlunoService } from '../../../core/services/aluno.service';
import { CursoService } from '../../../core/services/curso.service';
import { Aluno } from '../../../shared/models/aluno';
import { Curso } from '../../../shared/models/curso';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { InserirNotaRequest, Nota } from '../../../shared/models/nota';
import { Matricula } from '../../../shared/models/matricula';
import { MatriculaService } from '../../../core/services/matricula.service';
import { Disciplina } from '../../../shared/models/disciplina';
import { DisciplinaService } from '../../../core/services/disciplina.service';

@Component({
  selector: 'app-modal-cadastrar-nota',
  templateUrl: './modal-cadastrar-nota.component.html',
  styleUrls: ['./modal-cadastrar-nota.component.scss'],
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
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' }, 
  ],
})
export class ModalCadastrarNotaComponent implements OnInit {
  public formCadastro: FormGroup;
  public listaDisciplinas: Disciplina[] = [];
  public listaMatriculas: Matricula[] = [];

  public sexoOptions = [
    { value: 'Masculino', label: 'Masculino' },
    { value: 'Feminino', label: 'Feminino' },
  ];

  @Output() notaAdicionado: EventEmitter<void> = new EventEmitter<void>();

  constructor(
    public dialogRef: MatDialogRef<ModalCadastrarNotaComponent>,
    private fb: FormBuilder,
    private readonly notaService: NotaService,
    private toastr: ToastrService,
    private readonly disciplinaService: DisciplinaService,
    private readonly matriculaService: MatriculaService,
    @Inject(MAT_DIALOG_DATA) public nota: Nota


  ) {
    this.formCadastro = this.fb.group({
      id: null,
      matricula: [null, Validators.required],
      disciplina: [null, Validators.required],
      valor: [null, Validators.required],
    });
  }

  ngOnInit(): void {
    this.recuperarDisciplinas();
    this.recuperarMatriculas();
    this.preencherFormulario();

    console.log("matricula", this.listaMatriculas)

    console.log("disciplina", this.listaDisciplinas)

  }

  preencherFormulario(): void {
    if (this.nota) {
      this.formCadastro.patchValue({
        id: this.nota.id,
        matricula: this.nota.matricula,
        disciplina: this.nota.disciplina,
        valor: this.nota.valor
      });
      console.log("value",this.formCadastro.value);
    }
  }
  recuperarMatriculas(): void {
    this.matriculaService.obterTodos().subscribe((response) => {
      this.listaMatriculas = response;
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
      
      
      const nota: InserirNotaRequest = {
        id: this.nota?.id? this.nota.id : 0,
        valor: formValue.valor,
        disciplinaId: formValue.disciplina.id,
        matriculaId: formValue.matricula.id,
      };

      let notaAtualizar: any ={};
      if(this.nota){
        notaAtualizar = {
          id: this.nota.id,
          disciplinaId: formValue.disciplina.id,
          matriculaId: formValue.matricula.id,
          valor: formValue.valor
        }
      }
     
      
      const request = notaAtualizar.id
      ? this.notaService.atualizar(this.nota.id, notaAtualizar)
      : this.notaService.inserir(nota);

      request.subscribe({
        next: (mensagem) => {
          this.toastr.success('Matrícula cadastrada com sucesso!');
          this.notaAdicionado.emit();
          this.dialogRef.close(mensagem);
        },
        error: (error) => {
          console.error('Erro ao cadastrar matrícula:', error);
          this.toastr.error(error.error || error.message);
        },
      });
    }
  }

  trackByMatricula(index: number, matricula: Matricula): number {
    return matricula.id;
  }

  compareMatricula(matricula1: Matricula, matricula2: Matricula) {
    return matricula1 && matricula2 ? matricula1.id === matricula2.id : matricula1 === matricula2;
  }

  trackByDisciplina(index: number, disciplina: Disciplina): number {
    return disciplina.id;
  }

  compareDisciplina(disciplina1: Disciplina, disciplina2: Disciplina) {
    return disciplina1 && disciplina2 ? disciplina1.id === disciplina2.id : disciplina1 === disciplina2;
  }

  }


