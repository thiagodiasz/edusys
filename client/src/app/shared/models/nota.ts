import { Disciplina } from "./disciplina";
import { Aluno } from "./aluno";
import { Curso } from "./curso";

export interface Nota {
    id: number;
    valor: number;
    disciplinaId: number;
    alunoId: number;
    cursoId: number;
    disciplina: Disciplina;
    curso: Curso;
    aluno: Aluno;    
}

