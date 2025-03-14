import { Curso } from "./curso";
import { Disciplina } from "./disciplina";

export interface CursoDisciplina {
    id: number;
    cursoId: number;
    curso: Curso;
    disciplinaId: number;
    disciplina: Disciplina;
}
