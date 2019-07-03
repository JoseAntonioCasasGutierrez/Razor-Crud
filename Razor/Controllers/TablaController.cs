using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razor.Models;
using Razor.Models.ViewModels;
using Rotativa;

namespace Razor.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListTablaViewModelEmpleados> list;
            using (Entities2 db = new Entities2())
            {
                list = (from d in db.Empleados
                        select new ListTablaViewModelEmpleados
                        {
                            IdEmpleados = d.Id,
                            Nombre = d.Nombre,
                            Habilidades = d.Habilidades,
                            Salario = d.Salario,
                            FechaContratacion = d.FechaContratacion

                        }).ToList();
            }
            return View(list);
        }

        public ActionResult Nuevo()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(ListTablaViewModelEmpleados model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Entities2 db = new Entities2())
                    {
                        var oTabla = new Empleados();
                        oTabla.Nombre = model.Nombre;
                        oTabla.Habilidades = model.Habilidades;
                        oTabla.Salario = model.Salario;
                        oTabla.FechaContratacion = model.FechaContratacion;

                        db.Empleados.Add(oTabla);
                        db.SaveChanges();

                    }
                    return Redirect("~/Tabla/");
                }
                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
        public ActionResult Editar(int Id)
        {
            ListTablaViewModelEmpleados model = new ListTablaViewModelEmpleados();
            using (Entities2 db = new Entities2())
            {
                var oTabla = db.Empleados.Find(Id);
                model.Nombre = oTabla.Nombre;
                model.Habilidades = oTabla.Habilidades;
                model.Salario = oTabla.Salario;
                model.FechaContratacion = oTabla.FechaContratacion;
                model.IdEmpleados = oTabla.Id;

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(ListTablaViewModelEmpleados model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Entities2 db = new Entities2())
                    {
                        var oTabla = db.Empleados.Find(model.IdEmpleados);
                        oTabla.Nombre = model.Nombre;
                        oTabla.Habilidades = model.Habilidades;
                        oTabla.Salario = model.Salario;
                        oTabla.FechaContratacion = model.FechaContratacion;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Tabla/");
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

            using (Entities2 db = new Entities2())
            {
                var oTabla = db.Empleados.Find(Id);
                db.Empleados.Remove(oTabla);
                db.SaveChanges();


            }
            return Redirect("~/Tabla/");
        }
        public ActionResult Index_TipoSala()
        {
            List<ListTablaViewModelTipoSala> list;
            using (Entities2 db = new Entities2())
            {
                list = (from d in db.TipoSala
                        select new ListTablaViewModelTipoSala
                        {
                            IdTipoSala = d.IdTipoSala,
                            TipoSalaJuntas = d.TipoSalaJuntas
                           

                        }).ToList();
            }
            return View(list);
        }

        public ActionResult Index_Sala()
        {
            List<ListTablaViewModelSalaJuntas> list;
            using (Entities2 db = new Entities2())
            {
                list = (from d in db.SalaJuntas
                        select new ListTablaViewModelSalaJuntas
                        {
                            IdSala = d.Id,
                            Sala = d.Sala,
                            NombreEmpleado = d.NombreEmpleado,
                            FechaRecepcion = d.FechaRecepcion,
                            TotalPersonas = d.TotalPersonas,
                            Horas = d.Horas

                        }).ToList();
            }
            return View(list);
        }
       public ActionResult Nueva_TipoSala()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Nueva_TipoSala(ListTablaViewModelTipoSala model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Entities2 db = new Entities2())
                    {
                        var oTablas = new TipoSala();
                        oTablas.TipoSalaJuntas = model.TipoSalaJuntas;
                        db.TipoSala.Add(oTablas);
                        db.SaveChanges();

                    }
                    return Redirect("~/Tabla/Index_TipoSala");
                }
                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


            public ActionResult Nueva_Sala()
             {
            Entities2 db = new Entities2();
            List<Empleados> list = db.Empleados.ToList();
            List<TipoSala> list1 = db.TipoSala.ToList();
            ViewBag.SalaJuntasList = new SelectList(list, "Nombre", "Nombre");
            ViewBag.TipoSalaList = new SelectList(list1, "TipoSalaJuntas", "TipoSalaJuntas");
            return View();

           

            }
        [HttpPost]
        public ActionResult Nueva_Sala(ListTablaViewModelSalaJuntas model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Entities2 db = new Entities2())
                    {
                        var oTablas = new SalaJuntas();
                        oTablas.Sala = model.Sala;
                        oTablas.NombreEmpleado = model.NombreEmpleado;
                        oTablas.FechaRecepcion = model.FechaRecepcion;
                        oTablas.TotalPersonas = model.TotalPersonas;
                        oTablas.Horas = model.Horas;

                        db.SalaJuntas.Add(oTablas);
                        db.SaveChanges();

                    }
                    return Redirect("~/Tabla/Index_Sala");
                }
                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
        public ActionResult Editar_Sala(int Id)
        {
            ListTablaViewModelSalaJuntas model = new ListTablaViewModelSalaJuntas();
            using (Entities2 db = new Entities2())
            {
                var oTablas = db.SalaJuntas.Find(Id);
                model.Sala = oTablas.Sala;
                model.NombreEmpleado = oTablas.NombreEmpleado;
                model.FechaRecepcion = oTablas.FechaRecepcion;
                model.TotalPersonas = oTablas.TotalPersonas;
                model.Horas = oTablas.Horas;
                model.IdSala = oTablas.Id;

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar_Sala(ListTablaViewModelSalaJuntas model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Entities2 db = new Entities2())
                    {
                        var oTablas = db.SalaJuntas.Find(model.IdSala);
                        oTablas.Sala = model.Sala;
                        oTablas.NombreEmpleado = model.NombreEmpleado;
                        oTablas.FechaRecepcion = model.FechaRecepcion;
                        oTablas.TotalPersonas = model.TotalPersonas;
                        oTablas.Horas = model.Horas;

                        db.Entry(oTablas).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Tabla/Index_Sala");
                }
                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Eliminar_Sala(int Id)
        {

            using (Entities2 db = new Entities2())
            {
                var oTablas = db.SalaJuntas.Find(Id);
                db.SalaJuntas.Remove(oTablas);
                db.SaveChanges();


            }
            return Redirect("~/Tabla/Index_Sala");
        }
        
        public ActionResult Print()
        {
            return new ActionAsPdf("Index", new { FileName = "Empleados.pdf" });
        }
        public ActionResult PrintPDF()
        {
            return new ActionAsPdf("Index_Sala", new { FileName = "Empleados.pdf" });
        }
    }
}
