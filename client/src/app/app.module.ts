import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, InjectionToken } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { HomeComponent } from './modules/home/home.component';
import { HeaderComponent } from './core/header/header.component';
import { NgbModalModule, NgbModule } from '@ng-bootstrap/ng-bootstrap'; 
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatTabsModule } from '@angular/material/tabs';
import {MatInputModule} from '@angular/material/input';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { MatSidenav } from '@angular/material/sidenav';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { SidenavComponent } from './core/sidenav/sidenav.component';
import {MatListModule} from '@angular/material/list';
import { ListaAlunoComponent } from './modules/aluno/lista-aluno/lista-aluno.component';
import { MatTableModule } from '@angular/material/table';
import { MAT_DIALOG_DEFAULT_OPTIONS, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogModule, MatDialogTitle } from '@angular/material/dialog';

import { ModalModule, BsModalRef } from 'ngx-bootstrap/modal';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { ToastrModule, provideToastr } from 'ngx-toastr';
import { ListaProfessorComponent } from './modules/professor/lista-professor/lista-professor.component';
import { ListaDisciplinaComponent } from './modules/disciplina/lista-disciplina/lista-disciplina.component';
import { ListaCursoComponent } from './modules/curso/lista-curso/lista-curso.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    SidenavComponent,
    ListaAlunoComponent,
    ListaProfessorComponent,
    ListaDisciplinaComponent,
    ListaCursoComponent 
    
  ],
  exports:[MatTableModule, MatDialogModule],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    CommonModule,
    MatTableModule,
    MatTabsModule,
    MatInputModule,
    MatCardModule,
    MatButtonModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    NgbModule,
    NgbModalModule,
    MatDialogModule,
    ModalModule.forRoot(),
    MatDialogActions, 
    MatDialogClose,
     MatDialogTitle, 
     MatDialogContent,
     MatFormFieldModule,
     FormsModule,
     ToastrModule.forRoot(),
     
    
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
  bootstrap: [AppComponent],
  providers: [    
    BsModalRef,
    provideAnimationsAsync(),
    provideToastr(),
    //{provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}}
  ]
})
export class AppModule { }
