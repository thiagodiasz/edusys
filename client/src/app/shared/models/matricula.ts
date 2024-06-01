import { Aluno } from "./aluno";
import { Curso } from "./curso";

export interface Matricula {
    id: number;
    matricula: string;
    cursoId: number;
    alunoId: number;
    curso: Curso;
    aluno: Aluno; 
}
