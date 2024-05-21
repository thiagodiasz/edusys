import { Endereco } from "./endereco";

export class Professor {
    id: number;
    nome: string;
    dataNascimento: Date;
    telefone: string;
    endereo: Endereco;

    constructor(id: number, nome: string, dataNascimento: Date, telefone: string, endereco: Endereco) {
        this.id = id,
        this.nome = nome,
        this.dataNascimento = dataNascimento,
        this.telefone = telefone,
        this.endereo = endereco
    }
}
