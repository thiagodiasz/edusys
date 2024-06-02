import { Telefone } from "./telefone";
import { Endereco } from "./endereco";

export interface Professor {
    id: number;
    nome: string;
    telefone: Telefone;
    endereco: Endereco;
    sexo: string;
    telefoneId: number;
    enderecoId: number;   
}
