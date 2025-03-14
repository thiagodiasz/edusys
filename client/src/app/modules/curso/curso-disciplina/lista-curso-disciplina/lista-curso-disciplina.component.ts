import { Component, OnInit } from '@angular/core';
import { Curso } from '../../../../shared/models/curso';
import { CursoService } from '../../../../core/services/curso.service';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ModalCadastrarCursoDisciplinaComponent } from '../modal-cadastrar-curso-disciplina/modal-cadastrar-curso-disciplina.component';
import { CursoDisciplina } from '../../../../shared/models/cursoDisciplina';

@Component({
  selector: 'app-lista-curso-disciplina',
  templateUrl: './lista-curso-disciplina.component.html',
  styleUrls: ['./lista-curso-disciplina.component.css'],
  
})
export class ListaCursoDisciplinaComponent implements OnInit {

  listaCursoDisciplina: CursoDisciplina[] = []

  displayedColumns: string[] = ['id', 'curso', 'disciplina', 'acoes'];

  constructor(
    private readonly cursoService: CursoService,
    public modalCadastrar: MatDialog,
    public modalEditar: MatDialog,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {
    this.getCursos();
  }

  getCursos(): void {
    this.cursoService.obterTodosCursoDisciplina().subscribe((response) => {
      console.log(response);
      this.listaCursoDisciplina = response;
    });
  }

  editarCurso(curso: Curso): void {
    const dialogRef = this.modalCadastrar.open(ModalCadastrarCursoDisciplinaComponent, {
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
    const dialogRef = this.modalCadastrar.open(ModalCadastrarCursoDisciplinaComponent);

    dialogRef.componentInstance.cursoAdicionado.subscribe(() => {
      this.getCursos();
    });
  }
  abrirListaCurso() {
    this.router.navigate(['/cursos']);

 }

}
