import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Endereco } from '../../shared/models/endereco';

@Injectable()
export class EnderecoService {
    public url = "http://localhost:5000/";

constructor(
    private http: HttpClient
) {
 }

 
 obterTodos(): Observable<Endereco[]>{
    return this.http.get<Endereco[]>(this.url + 'endereco/obterTodos')
 }
 inserir(): Observable<Endereco[]>{
    return this.http.get<Endereco[]>(this.url + 'endereco/cadastrarEndereco')
 }
 editar(endereco: Endereco): Observable<Endereco>{
    return this.http.put<Endereco>(this.url + 'endereco/editarEndereco', endereco)
 }
 excluir(id: number): Observable<Endereco>{
    return this.http.delete<Endereco>(this.url + 'endereco/excluirEndereco?id=' + id)
 }

}
