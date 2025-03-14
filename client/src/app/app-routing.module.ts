import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { ListaAlunoComponent } from './modules/aluno/lista-aluno/lista-aluno.component';
import { ListaProfessorComponent } from './modules/professor/lista-professor/lista-professor.component';
import { ListaDisciplinaComponent } from './modules/disciplina/lista-disciplina/lista-disciplina.component';
import { ListaCursoComponent } from './modules/curso/lista-curso/lista-curso.component';
import { ListaCursoDisciplinaComponent } from './modules/curso/curso-disciplina/lista-curso-disciplina/lista-curso-disciplina.component';
import { ListaMatriculaComponent } from './modules/matricula/lista-matricula/lista-matricula.component';
import { ListaNotaComponent } from './modules/nota/lista-nota/lista-nota.component';
import { ListaUniversidadeComponent } from './modules/universidade/lista-universidade/lista-universidade.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'cursos', component: ListaCursoComponent },
  { path: 'alunos', component: ListaAlunoComponent },
  { path: 'professores', component: ListaProfessorComponent },
  { path: 'disciplinas', component: ListaDisciplinaComponent },
  { path: 'cursos/disciplinas', component: ListaCursoDisciplinaComponent },
  { path: 'matriculas', component: ListaMatriculaComponent },
  { path: 'notas', component: ListaNotaComponent },
  { path: 'universidades', component: ListaUniversidadeComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
