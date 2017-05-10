using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Persona
    {
        public int IdPersona { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese Apellido")]
        public string Apellido { get; set; }
        public Sexo Sexo { get; set; }
        [Required(ErrorMessage = "Seleccione Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }
}
