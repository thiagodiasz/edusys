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
import { Aluno } from '../../../shared/models/aluno';
import { AlunoService } from '../../../core/services/aluno.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';

@Component({
  selector: 'app-modal-cadastrar-aluno',
  templateUrl: './modal-cadastrar-aluno.component.html',
  styleUrls: ['./modal-cadastrar-aluno.component.scss'],
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
    MatDatepickerModule
  ],
})
export class ModalCadastrarAlunoComponent implements OnInit {
  public formCadastro: FormGroup;
  
  @Output() alunoAdicionado: EventEmitter<void> = new EventEmitter<void>();

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
    public dialogRef: MatDialogRef<ModalCadastrarAlunoComponent>,
    private fb: FormBuilder,
    private readonly alunoService: AlunoService,
    private toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) public aluno: Aluno 

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
      dataNascimento: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    console.log(this.aluno)
    this.preencherFormulario();

    // this.formCadastro.valueChanges.subscribe((value) => {
    //   console.log('Formulário alterado:', value);
    // });
  }
  preencherFormulario(): void {
    if (this.aluno ) {      

      this.formCadastro.patchValue({
        nome: this.aluno.nome,
        sexo: this.aluno.sexo,
        endereco: {
          bairro: this.aluno.endereco.bairro || '',
          cidade: this.aluno.endereco.cidade || '',
          numero: this.aluno.endereco.numero || '',
          complemento: this.aluno.endereco.complemento || '',
          cep: this.aluno.endereco.cep || '',
          estadoId: this.aluno.endereco.estadoId || '',
        },
        telefone: {
          ddd: this.aluno.telefone.ddd || '',
          numero: this.aluno.telefone.numero || ''
        },
        dataNascimento: this.aluno.dataNascimento || ''
      });
    }
  }
  
  
  
  onSubmit() {
    if (this.formCadastro.valid) {
      const formValue = this.formCadastro.value;
  
      const aluno: Aluno = {
        id: this.aluno ? this.aluno.id : 0,
        nome: formValue.nome,
        sexo: formValue.sexo,
        endereco: {
          ...formValue.endereco,
          numero: parseInt(formValue.endereco.numero, 10),
        },
        telefone: formValue.telefone,
        enderecoId: this.aluno ? this.aluno.enderecoId : 0,
        telefoneId: this.aluno ? this.aluno.telefoneId : 0,
        dataNascimento: this.aluno ? this.aluno.dataNascimento : formValue.dataNascimento,

      };
      
      const request = aluno.id ? this.alunoService.atualizar(aluno.id, aluno) : this.alunoService.inserir(aluno);

      request.subscribe({
        next: () => {
          this.toastr.success('Aluno cadastrado com sucesso!');
          this.alunoAdicionado.emit(); 
          this.dialogRef.close(true);
        },
        error: (error) => {
          console.error('Erro ao cadastrar aluno:', error);
          this.toastr.error(error.error || error.message);
        },
      });
    }
  }
  
}
