import { Component, OnInit } from '@angular/core';
import { Aluno } from '../../../shared/models/aluno';
import { AlunoService } from '../../../core/services/aluno.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalCadastrarAlunoComponent } from '../modal-cadastrar-aluno/modal-cadastrar-aluno.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-lista-aluno',
  templateUrl: './lista-aluno.component.html',
  styleUrls: ['./lista-aluno.component.scss']
})
export class ListaAlunoComponent implements OnInit {

  listaAlunos: Aluno[] = [];

  displayedColumns: string[] = ['id', 'nome', 'acoes'];

  constructor(
    private readonly alunoService: AlunoService,
    public modalCadastrar: MatDialog,
    public modalEditar: MatDialog,
    private toastr: ToastrService,

  ) { 
  }

  ngOnInit() {
    this.getAlunos()
  }

  getAlunos(): void {    
   this.alunoService.obterTodos().subscribe(response =>
    this.listaAlunos = response    
   )   
  }

  editarAluno(aluno: Aluno): void {
    
    const dialogRef = this.modalCadastrar.open(ModalCadastrarAlunoComponent, {
      data: aluno 
    });

    dialogRef.componentInstance.alunoAdicionado.subscribe(() => {
      this.getAlunos(); 
    });
  }

  excluirAluno(aluno: Aluno){
    this.alunoService.excluir(aluno.id).subscribe({
      next: () => {
        this.toastr.info('Aluno excluído!');
        this.getAlunos();
      },
      error: (error) => {
        console.error('Erro ao excluir aluno:', error);
        this.toastr.error(error.error || error.message);
      },
    });
  }
  abrirModalCadastrar() {
    const dialogRef = this.modalCadastrar.open(ModalCadastrarAlunoComponent);

    dialogRef.componentInstance.alunoAdicionado.subscribe(() => {
      this.getAlunos(); 
    });  
  }
}
