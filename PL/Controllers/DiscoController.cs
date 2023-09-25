using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        [HttpGet]
        public ActionResult GetaAll()
        {
            MLd.Disco disco = new MLd.Disco();

            MLd.Result result = BLd.Disco.GetAll();

            if (result.Correct)
            {
                disco.Discos = result.Objetcs;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }

            return View(disco);
        }
        [HttpPost]
        public ActionResult GetAll(MLd.Disco disco)
        {
            MLd.Result result = BLd.Disco.GetAll();
            disco = new MLd.Disco();
            disco.Discos = result.Objetcs;
            return View(disco);
        }

        [HttpGet]
        public ActionResult Add(int? idDisco)
        {
            MLd.Disco disco = new MLd.Disco();

            if (idDisco != 0) //Update
            {
                MLd.Result result = BLd.Disco.GetById(idDisco.Value);
                if (result.Correct)
                {
                    disco = (MLd.Disco)result.Object;

                }
            }
            else //add
            {

            }
            return View(disco);
        }

        [HttpPost]
        public ActionResult Add(MLd.Disco disco)
        {
            if (disco.IdDisco == 0) //add
            {
                MLd.Result result = BLd.Disco.Add(disco);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se incerto correctamente";
                }
                else
                {
                    ViewBag.Error = result.ErrorMessage;
                }
            }
            else //update
            {
                MLd.Result result = BLd.Disco.Update(disco);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se actualizo correctamente";
                }
                else
                {
                    ViewBag.Error = result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Dell(int idDisco)
        {
            MLd.Result result = BLd.Disco.Dell(idDisco);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Se elimino correctamente";
            }
            else
            {
                ViewBag.Error = result.ErrorMessage;
            }
            return PartialView("Modal");
        }
    }
}