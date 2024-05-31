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

  obterTodos(): Observable<Curso[]> {
    return this.http.get<Curso[]>(this.url, super.ObterHeaderJson());
  }

  obterPorId(id: string): Observable<Curso> {
    return this.http.get<Curso>(`${this.url}/${id}`);
  }
  inserir(request: Curso):void {
    this.http.post(this.url + '/inserir', request);
  }
  atualizar(curso: Curso): Observable<Curso> {
    return this.http.put<Curso>(this.url + '/atualizar', curso);
  }
  excluir(id: number): Observable<Curso> {
    return this.http.delete<Curso>(this.url + '/excluir?id=' + id);
  }
}
