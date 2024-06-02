import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Professor } from '../../shared/models/professor';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
   providedIn: 'root'
})
export class ProfessorService extends BaseService{
   public url = 'https://localhost:44336/professor';

    constructor(
        private http: HttpClient
    ) {
      super();
     }
    
     obterTodos(): Observable<Professor[]>{
        return this.http.get<Professor[]>(this.url, super.ObterHeaderJson())
     }
     obterPorId(id: number): Observable<Professor> {
      return this.http.get<Professor>(`${this.url}/${id}`, super.ObterHeaderJson());
    }
    inserir(professor: Professor): Observable<Professor> {
      debugger
      return this.http.post<Professor>(`${this.url}/inserir`, professor, super.ObterHeaderJson());
    }
    atualizar(id: number, request: Professor): Observable<Professor> {
      return this.http.put<Professor>(`${this.url}/atualizar/${id}`, request, super.ObterHeaderJson());
    }
    excluir(id: number): Observable<Professor> {
      return this.http.delete<Professor>(this.url + '/excluir/' + id, super.ObterHeaderJson());
    }
    }