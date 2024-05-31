import { Component, OnInit } from '@angular/core';
import { Aluno } from '../../../shared/models/aluno';
import { AlunoService } from '../../../core/services/aluno.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalCadastrarAlunoComponent } from '../modal-cadastrar-aluno/modal-cadastrar-aluno.component';

@Component({
  selector: 'app-lista-aluno',
  templateUrl: './lista-aluno.component.html',
  styleUrls: ['./lista-aluno.component.scss']
})
export class ListaAlunoComponent implements OnInit {

  listaAlunos: Aluno[] = [];

  displayedColumns: string[] = ['id', 'nome'];

  constructor(
    private readonly alunoService: AlunoService,
    public modalCadastrar: MatDialog,
    public modalEditar: MatDialog

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

  
  abrirModalCadastrar() {
    this.modalCadastrar.open(ModalCadastrarAlunoComponent);
  }

  fecharModalTermos(){
   // this.templateTermos?.hide();
  }
}
