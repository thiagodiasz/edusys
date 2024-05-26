using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusys.Api.Entities
{    
    [Table("Estado")]
    public class Estado
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? UF { get; set; }
    }
}
