import { Component, OnInit } from '@angular/core';
import { Professor } from '../../../shared/models/professor';

import { MatDialog } from '@angular/material/dialog';

import { ToastrService } from 'ngx-toastr';
import { ProfessorService } from '../../../core/services/professor.service';
import { ModalCadastrarProfessorComponent } from '../modal-cadastrar-professor/modal-cadastrar-professor.component';

@Component({
  selector: 'app-lista-professor',
  templateUrl: './lista-professor.component.html',
  styleUrls: ['./lista-professor.component.scss']
})
export class ListaProfessorComponent implements OnInit {

  listaProfessores: Professor[] = [];

  displayedColumns: string[] = ['id', 'nome', 'acoes'];

  constructor(
    private readonly professorService: ProfessorService,
    public modalCadastrar: MatDialog,
    public modalEditar: MatDialog,
    private toastr: ToastrService,

  ) { 
  }

  ngOnInit() {
    this.getProfessors()
  }

  getProfessors(): void {    
   this.professorService.obterTodos().subscribe(response =>
    this.listaProfessores = response    
   )   
  }

  editarProfessor(professor: Professor): void {
    
    const dialogRef = this.modalCadastrar.open(ModalCadastrarProfessorComponent, {
      data: professor 
    });

    dialogRef.componentInstance.professorAdicionado.subscribe(() => {
      this.getProfessors(); 
    });
  }

  excluirProfessor(professor: Professor){
    this.professorService.excluir(professor.id).subscribe({
      next: () => {
        this.toastr.info('Professor excluído!');
        this.getProfessors();
      },
      error: (error) => {
        console.error('Erro ao excluir professor:', error);
        this.toastr.error(error.error || error.message);
      },
    });
  }
  abrirModalCadastrar() {
    const dialogRef = this.modalCadastrar.open(ModalCadastrarProfessorComponent);

    dialogRef.componentInstance.professorAdicionado.subscribe(() => {
      this.getProfessors(); 
    });  
  }
}
