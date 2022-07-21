using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_ASP_NET_5.Models
{
    public class Curso
    {
        //modelo de la base de datos que se utiliza 
        [Key]//define que es una llave primaria (id)
        public int Id { get;set; }
        //uso de DataAnnotations para mejorar la visualización del usuario
        [Required(ErrorMessage ="El campo nombre del curso es obligatorio")]
        [Display(Name ="Nombre del curso")]
        //definicion de parametro de tipo string puede ser de diferente tipo dependiento de la información a tratar
        public string nombreCurso { get; set; }
        [Required(ErrorMessage ="El campo descripcion es obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage ="El campo precio es obligatorio")]
        public double Precio { get; set; }
    }
}
