import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Curso } from '../../shared/models/curso';

@Injectable()
export class CursoService {
    public url = "http://localhost:5000/";

constructor(
    private http: HttpClient
) {
 }

 obterTodos(): Observable<Curso[]>{
    return this.http.get<Curso[]>(this.url + 'curso/obterTodos')
 }
 inserir(): Observable<Curso[]>{
    return this.http.get<Curso[]>(this.url + 'curso/cadastrarCurso')
 }
 editar(curso: Curso): Observable<Curso>{
    return this.http.put<Curso>(this.url + 'curso/editarCurso', curso)
 }
 excluir(id: number): Observable<Curso>{
    return this.http.delete<Curso>(this.url + 'curso/excluirCurso?id=' + id)
 }


}