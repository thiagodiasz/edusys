using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusys.Api.Entities
{
    [Table("Telefone")]
    public class Telefone
    {
        [Key]
        public int Id { get; set; }
        public string DDD { get; set; }
        public string Numero {  get; set; }
    }
}
