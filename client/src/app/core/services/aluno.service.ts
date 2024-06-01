import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Aluno } from '../../shared/models/aluno';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
   providedIn: 'root'
})
export class AlunoService extends BaseService{
   public url = 'https://localhost:44336/aluno';

    constructor(
        private http: HttpClient
    ) {
      super();
     }
    
     obterTodos(): Observable<Aluno[]>{
        return this.http.get<Aluno[]>(this.url, super.ObterHeaderJson())
     }
     obterPorId(id: number): Observable<Aluno> {
      return this.http.get<Aluno>(`${this.url}/${id}`, super.ObterHeaderJson());
    }
    inserir(aluno: Aluno): Observable<Aluno> {
      debugger
      return this.http.post<Aluno>(`${this.url}/inserir`, aluno, super.ObterHeaderJson());
    }
    atualizar(id: number, request: Aluno): Observable<Aluno> {
      return this.http.put<Aluno>(`${this.url}/atualizar/${id}`, request, super.ObterHeaderJson());
    }
    excluir(id: number): Observable<Aluno> {
      return this.http.delete<Aluno>(this.url + '/excluir/' + id, super.ObterHeaderJson());
    }
    }