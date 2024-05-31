import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { ListaCursoComponent } from './modules/curso/lista-curso/lista-curso.component';
import { ListaAlunoComponent } from './modules/aluno/lista-aluno/lista-aluno.component';


const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'cursos', component: ListaCursoComponent },
  { path: 'alunos', component: ListaAlunoComponent },

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
