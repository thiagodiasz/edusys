import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Disciplina } from '../../shared/models/disciplina';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
   providedIn: 'root'
})
export class DisciplinaService extends BaseService{
   public url = 'https://localhost:44336/disciplina';

    constructor(
        private http: HttpClient
    ) {
      super();
     }
    
     obterTodos(): Observable<Disciplina[]>{
        return this.http.get<Disciplina[]>(this.url, super.ObterHeaderJson())
     }
     obterPorId(id: number): Observable<Disciplina> {
      return this.http.get<Disciplina>(`${this.url}/${id}`, super.ObterHeaderJson());
    }
    inserir(disciplina: Disciplina): Observable<Disciplina> {      
      return this.http.post<Disciplina>(`${this.url}/inserir`, disciplina, super.ObterHeaderJson());
    }
    atualizar(id: number, request: Disciplina): Observable<Disciplina> {
      return this.http.put<Disciplina>(`${this.url}/atualizar/${id}`, request, super.ObterHeaderJson());
    }
    excluir(id: number): Observable<Disciplina> {
      return this.http.delete<Disciplina>(this.url + '/excluir/' + id, super.ObterHeaderJson());
    }
    }