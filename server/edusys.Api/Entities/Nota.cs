using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusys.Api.Entities
{
    [Table("Nota")]
    public class Nota
    {
        [Key]
        public int Id { get; set; }
        public string? Valor { get; set; }
        public int DisciplinaId { get; set; }
        public virtual Disciplina? Disciplina { get; set; }
        public int MatriculaId { get; set; }
        public virtual Matricula? Matricula { get; set; }
        public int AlunoId {  get; set; }
        public virtual Aluno? Aluno { get; set; }
    }
}
