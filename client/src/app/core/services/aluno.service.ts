import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Aluno } from '../../shared/models/aluno';
import { Observable } from 'rxjs';

@Injectable()
export class AlunoService {
    public url = "http://localhost:5000/";

    constructor(
        private http: HttpClient
    ) {
     }
    
     obterTodos(): Observable<Aluno[]>{
        return this.http.get<Aluno[]>(this.url + 'aluno/obterTodos')
     }
     inserir(): Observable<Aluno[]>{
        return this.http.get<Aluno[]>(this.url + 'aluno/cadastrarAluno')
     }
     editar(aluno: Aluno): Observable<Aluno>{
        return this.http.put<Aluno>(this.url + 'aluno/editarAluno', aluno)
     }
     excluir(id: number): Observable<Aluno>{
        return this.http.delete<Aluno>(this.url + 'aluno/excluirAluno?id=' + id)
     }
    }