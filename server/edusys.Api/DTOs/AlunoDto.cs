using edusys.Api.Entities;

namespace edusys.Api.DTOs
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sexo { get; set; }
        public int? EnderecoId { get; set; }
        public virtual Endereco? Endereco { get; set; }
        public string? Telefone { get; set; }
    }
}
