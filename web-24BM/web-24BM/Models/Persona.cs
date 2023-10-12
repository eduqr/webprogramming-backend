using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_24BM.Models
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(25)]
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        
        [StringLength(18)]
        public string CURP { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(13)]
        public string RFC { get; set; }
        public string AreaTrabajo { get; set; }
    }
}
