import { Endereco } from "./endereco";

export interface Professor {
    id: number;
    nome: string;
    dataNascimento: Date;
    telefone: string;
    endereco: Endereco;   
}
