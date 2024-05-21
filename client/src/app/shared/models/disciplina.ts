import { Professor } from "./professor";

export class Disciplina {
    id: number;
    nome: string;
    professorId: number;
    professor: Professor;

    constructor(id: number, nome: string, professorId: number, professor: Professor) {
       this.id = id,
       this.nome = nome, 
       this.professorId = professorId,
       this.professor = professor
        
    }
}
