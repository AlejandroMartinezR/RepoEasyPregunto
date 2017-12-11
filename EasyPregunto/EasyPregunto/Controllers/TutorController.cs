using EasyPregunto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyPregunto.Controllers
{
    public class TutorController : Controller
    {
        DataEasyDataContext modelo = new DataEasyDataContext();
        TutorVO obj = new TutorVO();
        ExperienciaVO epx = new ExperienciaVO();


        // GET: Tutor
        public ActionResult PerfilTutor()
        {
            return View();
        }

        public ActionResult registroTutor()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> registroTutor(TutorVO datos) //metodo asincrono
        {
            if (ModelState.IsValid)
            {
                if (datos.RegistrarseTutor() == false)
                {
                    ViewBag.Message = "El usuario o email ya se encuentre registrado";
                    return View("Registrar", datos);
                }
                else

                {

                    ViewBag.Message = "Se registro el tutor de manera correcta";
                    return View("registroTutor");
                }
            }
            else
            {
                ViewBag.Message = "No se registro el usuario correctamente";
                return View("registrotutor");
            }
        }

        public ActionResult registraExperiencia()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> registraExperiencia(ExperienciaVO datos) //metodo asincrono
        {
            if (ModelState.IsValid)
            {
                if (datos.RegistroExperiencia() == false)
                {
                    ViewBag.Message = "No se registro la experiencia";
                    return View("registraExperiencia", datos);
                }
                else

                {
                    ViewBag.Message = "Se registro la experiencia de manera correcta";
                    return View("registraExperiencia");                   
                }
            }
            else
            {
                ViewBag.Message = "No se registro el usuario correctamente";
                return View("registraExperiencia");
            }
        }

        public ActionResult LoginTutor()
        {
            return View();
        }
    }
}