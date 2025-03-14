import { Aluno } from "./aluno";
import { Curso } from "./curso";

export interface Matricula {
    id: number;
    numero: string;
    cursoId: number;
    alunoId: number;
    curso: Curso;
    aluno: Aluno; 
}

export interface InserirAlunoComMatriculaRequest {
    id: number;
    alunoId: number;
    cursoId: number;
  }