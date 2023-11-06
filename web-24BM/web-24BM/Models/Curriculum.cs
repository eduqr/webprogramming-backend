
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_24BM.Models
{
    public class Curriculum
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El campo nombre no debe superar los 50 caracteres")]
        public string Nombre { get; set; }

		[Required(ErrorMessage = "Los apellidos son requeridos")]
		[StringLength(50, ErrorMessage = "El campo apellidos no debe superar los 50 caracteres")]
        public string Apellidos { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
		[StringLength(100, ErrorMessage = "El campo email no debe superar los 100 caracteres")]
		public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [ValidarEdad(ErrorMessage = "Debe tener entre 18 y 100 años")]
		public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
		[StringLength(160, ErrorMessage = "El campo dirección no debe superar los 160 caracteres")]
		public string Direccion { get; set; }

		[Required(ErrorMessage = "El objetivo es requerido")]
		[StringLength(100, ErrorMessage = "El campo objetivo no debe superar los 100 caracteres")]
		public string Objetivo { get; set; }

		[Required(ErrorMessage = "Los datos laborales son requeridos")]
		[StringLength(200, ErrorMessage = "El campo datos laborales no debe superar los 200 caracteres")]
		public string DatosLaboral { get; set; }

        [Required(ErrorMessage = "La CURP es obligatoria")]
        [RegularExpression(@"^[A-Z]{4}\d{6}[HM][A-Z]{5}[A-Z\d]\d$", ErrorMessage = "La CURP no es válida.")]
        public string CURP { get; set; }

        [NotMapped]
        public IFormFile? Foto { get; set; }
        public string? NombreFoto { get; set; }
    }
}
