using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace CRUD_CORE.UI.Models.Modelos
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string Nombre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Cedula { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }

    }
}
