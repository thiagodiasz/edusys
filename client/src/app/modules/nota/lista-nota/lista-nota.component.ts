import { Component, OnInit } from '@angular/core';
import { Nota } from '../../../shared/models/nota';

import { MatDialog } from '@angular/material/dialog';

import { ToastrService } from 'ngx-toastr';
import { NotaService } from '../../../core/services/nota.service';
import { ModalCadastrarNotaComponent } from '../modal-cadastrar-nota/modal-cadastrar-nota.component';
//import { ModalCadastrarNotaComponent } from '../modal-cadastrar-nota/modal-cadastrar-nota.component';

@Component({
  selector: 'app-lista-nota',
  templateUrl: './lista-nota.component.html',
  styleUrls: ['./lista-nota.component.scss']
})
export class ListaNotaComponent implements OnInit {

  listaNotas: Nota[] = [];

  displayedColumns: string[] = ['id', 'aluno', 'disciplina', 'nota','acoes'];

  constructor(
    private readonly notaService: NotaService,
    public modalCadastrar: MatDialog,
    public modalEditar: MatDialog,
    private toastr: ToastrService,

  ) { 
  }

  ngOnInit() {
    this.getNotas()
  }

  getNotas(): void {    
   this.notaService.obterTodos().subscribe(response =>
    this.listaNotas = response    
   )   
  }

  editarNota(nota: Nota): void {
    
    const dialogRef = this.modalCadastrar.open(ModalCadastrarNotaComponent, {
      data: nota 
    });

    dialogRef.componentInstance.notaAdicionado.subscribe(() => {
      this.getNotas(); 
    });
  }

  excluirNota(nota: Nota){
    this.notaService.excluir(nota.id).subscribe({
      next: () => {
        this.toastr.info('Nota excluído!');
        this.getNotas();
      },
      error: (error) => {
        console.error('Erro ao excluir nota:', error);
        this.toastr.error(error.error || error.message);
      },
    });
  }
  abrirModalCadastrar() {
    const dialogRef = this.modalCadastrar.open(ModalCadastrarNotaComponent,{
     
    });

    dialogRef.componentInstance.notaAdicionado.subscribe(() => {
      this.getNotas(); 
    });  
  }
}
