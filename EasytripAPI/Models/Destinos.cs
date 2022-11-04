using Microsoft.OData.Edm;
using NodaTime;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit;
using Xunit.Sdk;

namespace EasytripAPI.Models
{
    [Table("Destinos")]
    public class Destinos
    {
        [Key]
        public int Id { get; set; } 
        [Required(ErrorMessage = "Informe o nome do destino")]
            [StringLength(100)]
            public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a cidade de origem")]
        public string CidadeOrigem { get; set; }
        public string Pais { get; set; }
        public string DataIda { get; set; }
        public string DataVolta { get; set; }
    }
}
