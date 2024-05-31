import { Component, OnInit, ViewChild } from '@angular/core';
import { Curso } from '../../../shared/models/curso';
import { CursoService } from '../../../core/services/curso.service';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { MatDialog } from '@angular/material/dialog';
import { ModalCadastrarCursoComponent } from '../modal-cadastrar-curso/modal-cadastrar-curso.component';
export interface PeriodicElement {
  position: number;
}
@Component({
  selector: 'app-lista-curso',
  templateUrl: './lista-curso.component.html',
  styleUrls: ['./lista-curso.component.scss']
})
export class ListaCursoComponent implements OnInit {
  
  listaCursos: Curso[] = [];

  displayedColumns: string[] = ['id', 'nome'];

  constructor(
    private readonly cursoService: CursoService,
    public modalCadastrar: MatDialog,
    public modalEditar: MatDialog

  ) { 
  }

  ngOnInit() {
    this.getCursos()
  }

  getCursos(): void {
    
   this.cursoService.obterTodos().subscribe(response =>
    this.listaCursos = response    
   )   
  }

  
  abrirModalCadastrar() {
    this.modalCadastrar.open(ModalCadastrarCursoComponent);
  }

  fecharModalTermos(){
   // this.templateTermos?.hide();
  }

}
