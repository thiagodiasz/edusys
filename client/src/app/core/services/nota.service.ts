import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { InserirNotaRequest, Nota } from '../../shared/models/nota';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
   providedIn: 'root'
})
export class NotaService extends BaseService{
   public url = 'https://localhost:44336/nota';

    constructor(
        private http: HttpClient
    ) {
      super();
     }
    
     obterTodos(): Observable<Nota[]>{
        return this.http.get<Nota[]>(this.url, super.ObterHeaderJson())
     }
     obterPorId(id: number): Observable<Nota> {
      return this.http.get<Nota>(`${this.url}/${id}`, super.ObterHeaderJson());
    }
    inserir(nota: InserirNotaRequest): Observable<Nota> { 
      return this.http.post<Nota>(`${this.url}/inserir`, nota, super.ObterHeaderJson());
    }
    atualizar(id: number, request: InserirNotaRequest): Observable<Nota> {
      return this.http.put<Nota>(`${this.url}/atualizar/${id}`, request, super.ObterHeaderJson());
    }
    excluir(id: number): Observable<Nota> {
      return this.http.delete<Nota>(this.url + '/excluir/' + id, super.ObterHeaderJson());
    }
    }