using EasyPregunto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyPregunto.Controllers
{
    public class UsuarioController : Controller
    {
        int materia;
        DataEasyDataContext modelo = new DataEasyDataContext();
        EstadoSesion obj = new EstadoSesion();
        PreguntaAbiertaVO obj1 = new PreguntaAbiertaVO();
        TutorVO TutorBase = new TutorVO();


        // GET: Usuario
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [Authorize]
        public ActionResult EligeMateria()
        {
            return View();
        }

        public ActionResult PreguntaAbierta()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> PreguntaAbierta(PreguntaAbiertaVO Datos)
        {
            int materia2 = (int)Session["IdMateriaActiva"];
            //Datos.RegistrarPreguntaAbierta(materia2);

            if (Datos.RegistrarPreguntaAbierta(materia2) == true)
            {
                ViewBag.Message = "Pregunta Abierta Registrada";
                return RedirectToAction("TutoresDisponibles", "Usuario");
#pragma warning disable CS0162 // Se ha detectado código inaccesible
                return View();
#pragma warning restore CS0162 // Se ha detectado código inaccesible
            }
            else
            {
                ViewBag.Message = "Error";
                return View();
            }
            
        }


        [HttpPost]
        public async Task<ActionResult> EligeMateria(RegistrarseVO Datos)
        {
            if (Datos.aliasAprendizVO != "")
            {
                if (Datos.login() == true)
                {
                    Session["usuarioConectado"] = Datos.aliasAprendizVO;
                    Session["idUsuarioConectado"] = Datos.Id_aprendizVO;
                    return View();
                }
                else
                {
                    ViewBag.Message = "Error";
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }

        [AllowAnonymous]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Registrar(AprendizVO datos) //metodo asincrono
        {
            if (ModelState.IsValid)
            {
                if (datos.Registrarse() == false)
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
                return View("Registrar");
            }
        }

        public ActionResult MiCuenta()
        {
            return View();
        }

        public ActionResult Matematicas()
        {
            obj.asignaMateria(1);
            Session["IdMateriaActiva"] = 1;
            obj.IdAprendizVO = (int)Session["idUsuarioConectado"];
            obj.RegistraUsuarioyMateria();
            return View(submateria(1));
        }
        public ActionResult Biologia()
        {
            obj.asignaMateria(2);
            Session["IdMateriaActiva"] = 2;
            obj.IdAprendizVO = (int)Session["idUsuarioConectado"];
            obj.RegistraUsuarioyMateria();
            return View(submateria(2));
        }
        public ActionResult Idiomas()
        {
            obj.asignaMateria(3);
            Session["IdMateriaActiva"] = 3;
            obj.IdAprendizVO = (int)Session["idUsuarioConectado"];
            obj.RegistraUsuarioyMateria();
            return View(submateria(3));
        }
        public ActionResult Sistemas()
        {
            obj.asignaMateria(4);
            Session["IdMateriaActiva"] = 4;
            obj.IdAprendizVO = (int)Session["idUsuarioConectado"];
            obj.RegistraUsuarioyMateria();
            return View(submateria(4));
        }

        public IList<SubAreaVO> submateria(int idsubmateria)
        {
            IList<SubAreaVO> SubAreaLista = new List<SubAreaVO>();
            var subAreaAsociada = from a in modelo.Sub_area
                                  where a.Area == idsubmateria
                                  select a;

            var listaDatos = subAreaAsociada.ToList();

            foreach (var SubAreaData in listaDatos)
            {
                SubAreaLista.Add(new SubAreaVO()
                {
                    NombreSubVO = SubAreaData.Nombre_Sub,
                });

            }
            return SubAreaLista;
        }

        // tutodisponible2 es un procediminento almacenado

        public ActionResult TutoresDisponibles()
        {
            materia = (int)Session["IdMateriaActiva"];

            IList<TutorVO> Disponible = new List<TutorVO>();

            var tutorasociado = modelo.tutodisponible3(1, materia);


            var listaDatos = tutorasociado.ToList();

            foreach (var SubAreaData in listaDatos)
            {
                Disponible.Add(new TutorVO()
                {
                    IdTutorVO = SubAreaData.Id_Tutor,
                    NombresTutorVO = SubAreaData.Nombres_Tutor,
                    ApellidosTutorVO = SubAreaData.Apellidos_Tutor,
                    NivelEstudioTutorVO = SubAreaData.Nivel_Estudio,
                    DescripcionPerfilVO = SubAreaData.DescripcionPerfil
                });

            }
            return View(Disponible);
        }

        public ActionResult PaantallaDeEspera()
        {
            return View();
        }

    }
}


