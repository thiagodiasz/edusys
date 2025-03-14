import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Universidade } from '../../shared/models/universidade';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
   providedIn: 'root'
})
export class UniversidadeService extends BaseService{
   public url = 'https://localhost:44336/universidade';

    constructor(
        private http: HttpClient
    ) {
      super();
     }
    
     obterTodos(): Observable<Universidade[]>{
        return this.http.get<Universidade[]>(this.url, super.ObterHeaderJson())
     }
     obterPorId(id: number): Observable<Universidade> {
      return this.http.get<Universidade>(`${this.url}/${id}`, super.ObterHeaderJson());
    }
    inserir(universidade: Universidade): Observable<Universidade> {      
      return this.http.post<Universidade>(`${this.url}/inserir`, universidade, super.ObterHeaderJson());
    }
    atualizar(id: number, request: Universidade): Observable<Universidade> {
      return this.http.put<Universidade>(`${this.url}/atualizar/${id}`, request, super.ObterHeaderJson());
    }
    excluir(id: number): Observable<Universidade> {
      return this.http.delete<Universidade>(this.url + '/excluir/' + id, super.ObterHeaderJson());
    }
    }