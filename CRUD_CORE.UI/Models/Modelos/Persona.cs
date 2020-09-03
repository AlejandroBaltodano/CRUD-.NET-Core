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
        [Required(ErrorMessage ="This field Nombre is required")]
        public string Nombre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field Cedula is required")]
        public string Cedula { get; set; }
        [Column(TypeName = "date")]
        [Display(Name ="Fecha nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd }", ApplyFormatInEditMode = true)]
        public DateTime? FechaNacimiento { get; set; }

    }
}
