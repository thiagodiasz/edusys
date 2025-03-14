import { Disciplina } from "./disciplina";
import { Aluno } from "./aluno";
import { Curso } from "./curso";
import { Matricula } from "./matricula";

export interface Nota {
    id: number;
    valor: number;
    disciplinaId: number;   
    disciplina: Disciplina;
    matriculaId: number;
    matricula : Matricula   
}

export interface InserirNotaRequest {
    id: number;
    valor: number;
    matriculaId: number;
    disciplinaId: number;
  }
