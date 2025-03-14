import { Component, OnInit } from '@angular/core';
import { Universidade } from '../../../shared/models/universidade';
import { UniversidadeService } from '../../../core/services/universidade.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalCadastrarUniversidadeComponent } from '../modal-cadastrar-universidade/modal-cadastrar-universidade.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-lista-universidade',
  templateUrl: './lista-universidade.component.html',
  styleUrls: ['./lista-universidade.component.scss']
})
export class ListaUniversidadeComponent implements OnInit {

  listaUniversidades: Universidade[] = [];

  displayedColumns: string[] = ['id', 'nome', 'acoes'];

  constructor(
    private readonly universidadeService: UniversidadeService,
    public modalCadastrar: MatDialog,
    public modalEditar: MatDialog,
    private toastr: ToastrService,

  ) { 
  }

  ngOnInit() {
    this.getUniversidades()
  }

  getUniversidades(): void {    
   this.universidadeService.obterTodos().subscribe(response =>
    this.listaUniversidades = response    
   )   
  }

  editarUniversidade(universidade: Universidade): void {
    
    const dialogRef = this.modalCadastrar.open(ModalCadastrarUniversidadeComponent, {
      data: universidade 
    });

    dialogRef.componentInstance.universidadeAdicionado.subscribe(() => {
      this.getUniversidades(); 
    });
  }

  excluirUniversidade(universidade: Universidade){
    this.universidadeService.excluir(universidade.id).subscribe({
      next: () => {
        this.toastr.info('Universidade excluído!');
        this.getUniversidades();
      },
      error: (error) => {
        console.error('Erro ao excluir universidade:', error);
        this.toastr.error(error.error || error.message);
      },
    });
  }
  abrirModalCadastrar() {
    const dialogRef = this.modalCadastrar.open(ModalCadastrarUniversidadeComponent);

    dialogRef.componentInstance.universidadeAdicionado.subscribe(() => {
      this.getUniversidades(); 
    });  
  }
}
