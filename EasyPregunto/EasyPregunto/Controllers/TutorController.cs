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
                    return View("Login");
                }
            }
            else
            {
                ViewBag.Message = "No se registro el usuario correctamente";
                return View("registrotutor");
            }
        }


    }
}