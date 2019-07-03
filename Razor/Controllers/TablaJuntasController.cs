using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razor.Models;
using Razor.Models.ViewModels;

namespace Razor.Controllers
{
    public class TablaJuntasController : Controller
    {
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

        public ActionResult Nueva_Sala()
        {
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
                    return Redirect("~/TablaJuntas/Index_Sala");
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
                    return Redirect("~/TablaJuntas/Index_Sala");
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
            return Redirect("~/TablaJuntas/Index_Sala");
        }
    }
}
