import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Curso } from '../../shared/models/curso';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})
export class CursoService extends BaseService{
  public url = 'https://localhost:44336/curso';

  constructor(private http: HttpClient) {
    super()
  }

 
  obterTodos(): Observable<Curso[]>{
    return this.http.get<Curso[]>(this.url, super.ObterHeaderJson())
 }
 obterPorId(id: number): Observable<Curso> {
  return this.http.get<Curso>(`${this.url}/${id}`, super.ObterHeaderJson());
}
inserir(curso: Curso): Observable<Curso> {      
  return this.http.post<Curso>(`${this.url}/inserir`, curso, super.ObterHeaderJson());
}
atualizar(id: number, request: Curso): Observable<Curso> {
  return this.http.put<Curso>(`${this.url}/atualizar/${id}`, request, super.ObterHeaderJson());
}
excluir(id: number): Observable<Curso> {
  return this.http.delete<Curso>(this.url + '/excluir/' + id, super.ObterHeaderJson());
}
}
