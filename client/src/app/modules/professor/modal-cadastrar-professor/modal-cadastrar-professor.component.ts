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
import { Professor } from '../../../shared/models/professor';
import { ProfessorService } from '../../../core/services/professor.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-modal-cadastrar-professor',
  templateUrl: './modal-cadastrar-professor.component.html',
  styleUrls: ['./modal-cadastrar-professor.component.scss'],
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
export class ModalCadastrarProfessorComponent implements OnInit {
  public formCadastro: FormGroup;
  
  @Output() professorAdicionado: EventEmitter<void> = new EventEmitter<void>();

  public sexoOptions = [
    { value: 'M', label: 'Masculino' },
    { value: 'F', label: 'Feminino' },
    { value: 'Não informado', label: 'Não informar' },
  ];

  public ufOptions = [
    { id: 1, sigla: 'AC', nome: 'Acre' },
    { id: 2, sigla: 'AL', nome: 'Alagoas' },
    { id: 3, sigla: 'AP', nome: 'Amapá' },
    { id: 4, sigla: 'AM', nome: 'Amazonas' },
    { id: 5, sigla: 'BA', nome: 'Bahia' },
    { id: 6, sigla: 'CE', nome: 'Ceará' },
    { id: 7, sigla: 'DF', nome: 'Distrito Federal' },
    { id: 8, sigla: 'ES', nome: 'Espírito Santo' },
    { id: 9, sigla: 'GO', nome: 'Goiás' },
    { id: 10, sigla: 'MA', nome: 'Maranhão' },
    { id: 11, sigla: 'MT', nome: 'Mato Grosso' },
    { id: 12, sigla: 'MS', nome: 'Mato Grosso do Sul' },
    { id: 13, sigla: 'MG', nome: 'Minas Gerais' },
    { id: 14, sigla: 'PA', nome: 'Pará' },
    { id: 15, sigla: 'PB', nome: 'Paraíba' },
    { id: 16, sigla: 'PR', nome: 'Paraná' },
    { id: 17, sigla: 'PE', nome: 'Pernambuco' },
    { id: 18, sigla: 'PI', nome: 'Piauí' },
    { id: 19, sigla: 'RJ', nome: 'Rio de Janeiro' },
    { id: 20, sigla: 'RN', nome: 'Rio Grande do Norte' },
    { id: 21, sigla: 'RS', nome: 'Rio Grande do Sul' },
    { id: 22, sigla: 'RO', nome: 'Rondônia' },
    { id: 23, sigla: 'RR', nome: 'Roraima' },
    { id: 24, sigla: 'SC', nome: 'Santa Catarina' },
    { id: 25, sigla: 'SP', nome: 'São Paulo' },
    { id: 26, sigla: 'SE', nome: 'Sergipe' },
    { id: 27, sigla: 'TO', nome: 'Tocantins' },
  ];
  constructor(
    public dialogRef: MatDialogRef<ModalCadastrarProfessorComponent>,
    private fb: FormBuilder,
    private readonly professorService: ProfessorService,
    private toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) public professor: Professor 

  ) {
    this.formCadastro = this.fb.group({
      nome: ['', Validators.required],
      sexo: ['', Validators.required],
      endereco: this.fb.group({
        bairro: ['', Validators.required],
        cidade: ['', Validators.required],
        numero: ['', [Validators.required, Validators.pattern('^[0-9]*$')]], 
        complemento: ['', Validators.required],
        cep: ['', Validators.required],
        estadoId: ['', Validators.required],
      }),
      telefone: this.fb.group({
        numero: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
        ddd: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
      }),
    });
  }

  ngOnInit(): void {
    console.log(this.professor)
    this.preencherFormulario();

    // this.formCadastro.valueChanges.subscribe((value) => {
    //   console.log('Formulário alterado:', value);
    // });
  }
  preencherFormulario(): void {
    if (this.professor ) {      

      this.formCadastro.patchValue({
        nome: this.professor.nome,
        sexo: this.professor.sexo,
        endereco: {
          bairro: this.professor.endereco.bairro || '',
          cidade: this.professor.endereco.cidade || '',
          numero: this.professor.endereco.numero || '',
          complemento: this.professor.endereco.complemento || '',
          cep: this.professor.endereco.cep || '',
          estadoId: this.professor.endereco.estadoId || '',
        },
        telefone: {
          ddd: this.professor.telefone.ddd || '',
          numero: this.professor.telefone.numero || ''
        }
      });
    }
  }
  
  onSubmit() {
    if (this.formCadastro.valid) {
      const formValue = this.formCadastro.value;
  
      const professor: Professor = {
        id: this.professor ? this.professor.id : 0,
        nome: formValue.nome,
        sexo: formValue.sexo,
        endereco: {
          ...formValue.endereco,
          numero: parseInt(formValue.endereco.numero, 10),
        },
        telefone: formValue.telefone,
        enderecoId: this.professor ? this.professor.enderecoId : 0,
        telefoneId: this.professor ? this.professor.telefoneId : 0,
      };
      
      const request = professor.id ? this.professorService.atualizar(professor.id, professor) : this.professorService.inserir(professor);
 
      request.subscribe({
        next: () => {
          this.toastr.success('Professor cadastrado com sucesso!');
          this.professorAdicionado.emit(); 
          this.dialogRef.close(true);
        },
        error: (error) => {
          console.error('Erro ao cadastrar professor:', error);
          this.toastr.error(error.error || error.message);
        },
      });
    }
  }
  
}
