import { Estado } from "./estado";

export class Endereco {
    id: number;
    cidade: string;
    cep: string;
    bairro: string;
    numero: number;
    complemento: string;
    estado: Estado;
    estadoId : number;
    constructor(
        id: number,
        cidade: string,
        cep: string, 
        bairro: string, 
        endereco: string,
        numero: number,
        complemento: string,
        estado: Estado,
        estadoId: number )
         {
        this.id = id;
        this.cidade = cidade;
        this.cep = cep;
        this.bairro = bairro;
        this.numero = numero;
        this.complemento = complemento;
        this.estado = estado;
        this.estadoId = estadoId
    }
}
