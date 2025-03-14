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
import { Universidade } from '../../../shared/models/universidade';
import { UniversidadeService } from '../../../core/services/universidade.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';

@Component({
  selector: 'app-modal-cadastrar-universidade',
  templateUrl: './modal-cadastrar-universidade.component.html',
  styleUrls: ['./modal-cadastrar-universidade.component.scss'],
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
export class ModalCadastrarUniversidadeComponent implements OnInit {
  public formCadastro: FormGroup;
  
  @Output() universidadeAdicionado: EventEmitter<void> = new EventEmitter<void>();

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
    public dialogRef: MatDialogRef<ModalCadastrarUniversidadeComponent>,
    private fb: FormBuilder,
    private readonly universidadeService: UniversidadeService,
    private toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) public universidade: Universidade 

  ) {
    this.formCadastro = this.fb.group({
      nome: ['', Validators.required],
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
    console.log(this.universidade)
    this.preencherFormulario();

    // this.formCadastro.valueChanges.subscribe((value) => {
    //   console.log('Formulário alterado:', value);
    // });
  }
  preencherFormulario(): void {
    if (this.universidade ) {      

      this.formCadastro.patchValue({
        nome: this.universidade.nome,
        endereco: {
          bairro: this.universidade.endereco.bairro || '',
          cidade: this.universidade.endereco.cidade || '',
          numero: this.universidade.endereco.numero || '',
          complemento: this.universidade.endereco.complemento || '',
          cep: this.universidade.endereco.cep || '',
          estadoId: this.universidade.endereco.estadoId || '',
        },
        telefone: {
          ddd: this.universidade.telefone.ddd || '',
          numero: this.universidade.telefone.numero || ''
        },
      });
    }
  }
  
  
  
  onSubmit() {
    if (this.formCadastro.valid) {
      const formValue = this.formCadastro.value;
  
      const universidade: Universidade = {
        id: this.universidade ? this.universidade.id : 0,
        nome: formValue.nome,
        endereco: {
          ...formValue.endereco,
          numero: parseInt(formValue.endereco.numero, 10),
        },
        telefone: formValue.telefone,
        enderecoId: this.universidade ? this.universidade.enderecoId : 0,
        telefoneId: this.universidade ? this.universidade.telefoneId : 0,

      };
      
      const request = universidade.id ? this.universidadeService.atualizar(universidade.id, universidade) : this.universidadeService.inserir(universidade);

      request.subscribe({
        next: () => {
          this.toastr.success('Universidade cadastrado com sucesso!');
          this.universidadeAdicionado.emit(); 
          this.dialogRef.close(true);
        },
        error: (error) => {
          console.error('Erro ao cadastrar universidade:', error);
          this.toastr.error(error.error || error.message);
        },
      });
    }
  }
  
}
