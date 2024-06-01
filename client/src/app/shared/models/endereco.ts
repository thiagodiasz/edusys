import { Estado } from "./estado";

export interface Endereco {
    id: number;
    cidade: string;
    cep: string;
    bairro: string;
    numero: number;
    complemento: string;
    estado: Estado;
    estadoId : number;
    
}
