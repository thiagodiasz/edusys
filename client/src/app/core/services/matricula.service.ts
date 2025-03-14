import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { InserirAlunoComMatriculaRequest, Matricula } from '../../shared/models/matricula';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
   providedIn: 'root'
})
export class MatriculaService extends BaseService{
   public url = 'https://localhost:44336/matricula';

    constructor(
        private http: HttpClient
    ) {
      super();
     }
    
     obterTodos(): Observable<Matricula[]>{
        return this.http.get<Matricula[]>(this.url, super.ObterHeaderJson())
     }
     obterPorId(id: number): Observable<Matricula> {
      return this.http.get<Matricula>(`${this.url}/${id}`, super.ObterHeaderJson());
    }
    
  inserirAlunoComMatricula(request: InserirAlunoComMatriculaRequest): Observable<Matricula> {
    return this.http.post<Matricula>(`${this.url}/inserir`, request);
  }
    atualizar(id: number, request: InserirAlunoComMatriculaRequest): Observable<Matricula> {
      return this.http.put<Matricula>(`${this.url}/atualizar/${id}`, request, super.ObterHeaderJson());
    }
    excluir(id: number): Observable<Matricula> {
      return this.http.delete<Matricula>(this.url + '/excluir/' + id, super.ObterHeaderJson());
    }
    }