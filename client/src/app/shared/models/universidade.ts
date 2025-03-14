import { Telefone } from "./telefone";
import { Endereco } from "./endereco";
import { Matricula } from "./matricula";

export interface Universidade {
    id: number;
    nome: string;    
    endereco: Endereco;
    enderecoId: number;
    telefoneId: number;
    telefone: Telefone;
}
