import { Component, OnInit } from '@angular/core';
import { Matricula } from '../../../shared/models/matricula';

import { MatDialog } from '@angular/material/dialog';

import { ToastrService } from 'ngx-toastr';
import { MatriculaService } from '../../../core/services/matricula.service';
import { ModalCadastrarMatriculaComponent } from '../modal-cadastrar-matricula/modal-cadastrar-matricula.component';

@Component({
  selector: 'app-lista-matricula',
  templateUrl: './lista-matricula.component.html',
  styleUrls: ['./lista-matricula.component.scss']
})
export class ListaMatriculaComponent implements OnInit {

  listaMatriculas: Matricula[] = [];

  displayedColumns: string[] = ['id', 'numero', 'nome', 'curso','acoes'];

  constructor(
    private readonly matriculaService: MatriculaService,
    public modalCadastrar: MatDialog,
    public modalEditar: MatDialog,
    private toastr: ToastrService,

  ) { 
  }

  ngOnInit() {
    this.getMatriculas()
  }

  getMatriculas(): void {    
   this.matriculaService.obterTodos().subscribe(response =>
    this.listaMatriculas = response    
   )   
  }

  editarMatricula(matricula: Matricula): void {
    
    const dialogRef = this.modalCadastrar.open(ModalCadastrarMatriculaComponent, {
      data: matricula 
    });

    dialogRef.componentInstance.matriculaAdicionado.subscribe(() => {
      this.getMatriculas(); 
    });
  }

  excluirMatricula(matricula: Matricula){
    this.matriculaService.excluir(matricula.id).subscribe({
      next: () => {
        this.toastr.info('Matricula excluído!');
        this.getMatriculas();
      },
      error: (error) => {
        console.error('Erro ao excluir matricula:', error);
        this.toastr.error(error.error || error.message);
      },
    });
  }
  abrirModalCadastrar() {
    const dialogRef = this.modalCadastrar.open(ModalCadastrarMatriculaComponent);

    dialogRef.componentInstance.matriculaAdicionado.subscribe(() => {
      this.getMatriculas(); 
    });  
  }
}
