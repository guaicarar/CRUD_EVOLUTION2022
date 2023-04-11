using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRUD_EVOLUTION2022.Models.ViewModel
{
    public class NuevoUsuariosWiewModels
    {
  
        public int UsuId { get; set; }
        [required]
        [Display (Name ="Nombre")]
        [StringLength (20)]
        public string UsuNombre { get; set; }
        [required]
        [Display(Name = "Password")]
        [StringLength(20)]
        public string UsuPASS { get; set; }

    }
}