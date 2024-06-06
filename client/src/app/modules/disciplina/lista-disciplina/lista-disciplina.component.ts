import { Component, OnInit } from '@angular/core';
import { Disciplina } from '../../../shared/models/disciplina';
import { DisciplinaService } from '../../../core/services/disciplina.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalCadastrarDisciplinaComponent } from '../modal-cadastrar-disciplina/modal-cadastrar-disciplina.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-lista-disciplina',
  templateUrl: './lista-disciplina.component.html',
  styleUrls: ['./lista-disciplina.component.scss']
})
export class ListaDisciplinaComponent implements OnInit {

  listaDisciplinas: Disciplina[] = [];

  displayedColumns: string[] = ['id', 'nome', 'acoes'];

  constructor(
    private readonly disciplinaService: DisciplinaService,
    public modalCadastrar: MatDialog,
    public modalEditar: MatDialog,
    private toastr: ToastrService,

  ) { 
  }

  ngOnInit() {
    this.getDisciplinas()
  }

  getDisciplinas(): void {    
   this.disciplinaService.obterTodos().subscribe(response =>
    this.listaDisciplinas = response    
   )   
  }

  editarDisciplina(disciplina: Disciplina): void {
    
    const dialogRef = this.modalCadastrar.open(ModalCadastrarDisciplinaComponent, {
      data: disciplina 
    });

    dialogRef.componentInstance.disciplinaAdicionado.subscribe(() => {
      this.getDisciplinas(); 
    });
  }

  excluirDisciplina(disciplina: Disciplina){
    this.disciplinaService.excluir(disciplina.id).subscribe({
      next: () => {
        this.toastr.info('Disciplina excluído!');
        this.getDisciplinas();
      },
      error: (error) => {
        console.error('Erro ao excluir disciplina:', error);
        this.toastr.error(error.error || error.message);
      },
    });
  }
  abrirModalCadastrar() {
    const dialogRef = this.modalCadastrar.open(ModalCadastrarDisciplinaComponent);

    dialogRef.componentInstance.disciplinaAdicionado.subscribe(() => {
      this.getDisciplinas(); 
    });  
  }
}
