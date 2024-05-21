import { Disciplina } from "./disciplina";
import { Aluno } from "./aluno";
import { Curso } from "./curso";

export class Nota {
    id: number;
    valor: number;
    disciplinaId: number;
    alunoId: number;
    cursoId: number;
    disciplina: Disciplina;
    curso: Curso;
    aluno: Aluno;

    constructor(id: number, valor: number, disciplinaId: number, alunoId: number, cursoId: number, disciplina: Disciplina, curso: Curso, aluno: Aluno) {
        this.id = id,
        this.valor = valor,
        this.disciplinaId = disciplinaId,
        this.alunoId = alunoId,
        this.cursoId = cursoId,
        this.aluno = aluno,
        this.disciplina = disciplina,
        this.curso = curso
    }
}

