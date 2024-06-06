import { Curso } from "./curso";
import { Professor } from "./professor";

export interface Disciplina {
    id: number;
    nome: string;
    professorId?: number;
    professor?: Professor;  
    cursoId?: number;
    curso?: Curso;
}
