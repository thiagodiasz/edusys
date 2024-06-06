import { Component, OnInit } from '@angular/core';
import { Curso } from '../../../shared/models/curso';
import { CursoService } from '../../../core/services/curso.service';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ModalCadastrarCursoComponent } from '../modal-cadastrar-curso/modal-cadastrar-curso.component';

@Component({
  selector: 'app-lista-curso',
  templateUrl: './lista-curso.component.html',
  styleUrls: ['./lista-curso.component.scss'],
})
export class ListaCursoComponent implements OnInit {
  listaCursos: Curso[] = [];

  displayedColumns: string[] = ['id', 'nome', 'acoes'];

  constructor(
    private readonly cursoService: CursoService,
    public modalCadastrar: MatDialog,
    public modalEditar: MatDialog,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.getCursos();
  }

  getCursos(): void {

    this.cursoService
      .obterTodos()
      .subscribe(response => {
        console.log(response)
          this.listaCursos = response
      })

  }

  editarCurso(curso: Curso): void {
    const dialogRef = this.modalCadastrar.open(ModalCadastrarCursoComponent, {
      data: curso,
    });

    dialogRef.componentInstance.cursoAdicionado.subscribe(() => {
      this.getCursos();
    });
  }

  excluirCurso(curso: Curso) {
    this.cursoService.excluir(curso.id).subscribe({
      next: () => {
        this.toastr.info('Curso excluído!');
        this.getCursos();
      },
      error: (error) => {
        console.error('Erro ao excluir curso:', error);
        this.toastr.error(error.error || error.message);
      },
    });
  }
  abrirModalCadastrar() {
    const dialogRef = this.modalCadastrar.open(ModalCadastrarCursoComponent);

    dialogRef.componentInstance.cursoAdicionado.subscribe(() => {
      this.getCursos();
    });
  }
}
