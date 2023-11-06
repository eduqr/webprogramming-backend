using System.ComponentModel.DataAnnotations;

namespace web_24BM.Models
{
    public class ValidarEdadAttribute : ValidationAttribute
    {

        public override bool IsValid(object fecha)
        {
            if (fecha is not DateTime fechaNacimiento)
            {
                return false;
            }
            
            int edad = (DateTime.Now.Year - fechaNacimiento.Year) - (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear ? 1 : 0);
            
            return edad >= 18 && edad <= 100;
        }
    }
}
