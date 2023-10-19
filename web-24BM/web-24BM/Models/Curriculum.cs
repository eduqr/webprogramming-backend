
using System.ComponentModel.DataAnnotations;


namespace web_24BM.Models
{
    public class Curriculum
    {
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(50, ErrorMessage = "El campo nombre no debe superar los 50 caracteres")]
        public string Nombre { get; set; }
        [StringLength(50, ErrorMessage = "El campo nombre no debe superar los 50 caracteres")]
        public string Apellidos { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }
        public string Objetivo { get; set; }
        public List<DatoLaboral>? DatosLaboral { get; set;}
        public IFormFile? Foto { get; set; }
    }
}
