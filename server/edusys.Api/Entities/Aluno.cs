using edusys.Api.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusys.Api.Entities
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int? TelefoneId { get; set; }
        public virtual Telefone Telefone { get; set; }

    }
}
