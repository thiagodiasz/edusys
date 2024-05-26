using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusys.Api.Entities
{
    [Table("Professor")]

    public class Professor
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco? Endereco { get; set; }

    }
}
