import { Aluno } from "./aluno";
import { Curso } from "./curso";

export class Matricula {
    id: number;
    matricula: string;
    cursoId: number;
    alunoId: number;
    curso: Curso;
    aluno: Aluno;
    
    constructor(id: number, matricula: string, cursoId: number, alunoId: number, curso: Curso, aluno: Aluno) {
      this.id = id;
      this.matricula = matricula;
      this.cursoId = cursoId;
      this.alunoId = alunoId;
      this.curso = curso;
      this.aluno = aluno;        
    }
}
