using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusys.Api.Entities
{
    [Table("CursoDisciplina")]

    public class CursoDisciplina
    {
        [Key]
        public int Id { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
