using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusys.Api.Entities
{
    [Table("Disciplina")]
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
