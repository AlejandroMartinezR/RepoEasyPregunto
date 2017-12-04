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
        public ActionResult registroTutor(TutorVO obj)
        {
            if (ModelState.IsValid)
            {
                return View(obj);
            }
            else
            {
                return View();
            }

        }

        
    }
}