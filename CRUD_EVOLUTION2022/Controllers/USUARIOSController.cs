using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using CRUD_EVOLUTION2022.Models;
using CRUD_EVOLUTION2022.Models.ViewModel;
using Microsoft.Ajax.Utilities;

namespace CRUD_EVOLUTION2022.Controllers
{
    public class USUARIOSController : Controller
    {
        // GET: USUARIOS
        public ActionResult Index()
        {
            List<UsuariosViewModel> lst;
            
                using (Crud_Evolution2022Entities1 db= new Crud_Evolution2022Entities1())
           
            {
                lst = (from d in db.USUARIOS
                           select new UsuariosViewModel
                           {
                               UsuId = d.UsuId,
                               UsuNombre= d.UsuNombre,
                               UsuPASS = d.UsuPASS
                           }).ToList();
                
                          
            }
                return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(NuevoUsuariosWiewModels model)
        {
            try
            {
              if (ModelState.IsValid)
                {
                    using (Crud_Evolution2022Entities1 db = new Crud_Evolution2022Entities1())
                    {
                        var oNuevoUsuario = new USUARIOS();

                        oNuevoUsuario.UsuId = model.UsuId;
                        oNuevoUsuario.UsuNombre = model.UsuNombre;
                        oNuevoUsuario.UsuPASS= model.UsuPASS;

                        db.USUARIOS.Add(oNuevoUsuario);
                        db.SaveChanges();
                    }
                }
                return Redirect("Index");
          
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ActionResult Editar(int Id)
        {
            NuevoUsuariosWiewModels model = new NuevoUsuariosWiewModels();          
            using (Crud_Evolution2022Entities1 db = new Crud_Evolution2022Entities1())
            {
                
                var oTabla = db.USUARIOS.Find(Id);
                    model.UsuNombre = oTabla.UsuNombre;
                    model.UsuPASS = oTabla.UsuPASS;
                    model.UsuId = Id;
                return View(model);
            }


        }
        [HttpPost]
        public ActionResult Editar(NuevoUsuariosWiewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Crud_Evolution2022Entities1 db = new Crud_Evolution2022Entities1())
                    {
                        var oTabla = db.USUARIOS.Find(model.UsuId);

                        oTabla.UsuId = model.UsuId;
                        oTabla.UsuNombre = model.UsuNombre;
                        oTabla.UsuPASS=model.UsuPASS;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/USUARIOS/");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {

            using (Crud_Evolution2022Entities1 db = new Crud_Evolution2022Entities1())
            {
                var oNuevoUsuario = db.USUARIOS.Find(Id);
                db.USUARIOS.Remove(oNuevoUsuario);
                db.SaveChanges();
            }
            return Redirect("~/Usuarios/");
        }
        
    }
}