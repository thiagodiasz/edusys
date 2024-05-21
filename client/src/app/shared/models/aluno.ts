import { Endereco } from "./endereco";
import { Matricula } from "./matricula";

export class Aluno {
    id: number;
    nome: string;
    sexo: string;
    endereco: Endereco;
    enderecoId: number;
    telefone: string;
    matricula: Matricula[]

    constructor(
        id: number,
        nome: string,
        sexo: string,
        endereco: Endereco,
        telefone: string,
        matricula: Matricula[],
        enderecoId: number
    ) {
        this.id = id,
        this.nome = nome, 
        this.sexo = sexo,
        this.endereco = endereco,
        this.telefone = telefone
        this.matricula = matricula,
        this.enderecoId = enderecoId
    }
}
