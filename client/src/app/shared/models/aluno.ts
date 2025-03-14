import { Telefone } from "./telefone";
import { Endereco } from "./endereco";
import { Matricula } from "./matricula";

export interface Aluno {
    id: number;
    nome: string;
    sexo: string;
    endereco: Endereco;
    enderecoId: number;
    telefoneId: number;
    telefone: Telefone;
    dataNascimento: Date   
}
