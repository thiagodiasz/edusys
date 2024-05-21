using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusys.Api.Entities
{
    [Table("Matricula")]
    public class Matricula
    {
        [Key]
        public int Id { get; set; }
        public string? Matricula { get; set; }
        public int? AlunoId { get; set; }
        public virtual Aluno? Aluno { get; set; }
        public int? CursoId { get; set; }
        public virtual Curso? Curso { get; set; }        

    }
}
