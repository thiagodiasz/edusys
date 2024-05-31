import { Professor } from "./professor";

export interface Disciplina {
    id: number;
    nome: string;
    professorId: number;
    professor: Professor;

  
}
