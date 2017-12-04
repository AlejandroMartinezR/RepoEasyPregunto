using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace EasyPregunto.Models
{
    public class AprendizVO
    {
        public int Id_aprendizVO { get; set; }

        [StringLength(60, MinimumLength = 3)] // esta es un componenente de la libreria ComponentModel. Se define tamaño max 60 y min 3
        [Display(Name = "Nombres")] //nombre que queremos que nos muestre la vista
        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string NombresApredizVO { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string apellidosAprendizVO { get; set; }

        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(250, ErrorMessage = "El tamaño maximo de {0} es de {1} caracteres")]
        [EmailAddress(ErrorMessage = "El campo debe de un correo valido")]
        public string correoElectronicoAprendizVO { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Clave")]
        [StringLength(255, ErrorMessage = "Debe tener entre 5 y 255 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string claveAprendizVO { get; set; }


        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Clave2")]
        [StringLength(255, ErrorMessage = "Debe tener entre 5 y 255 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Clave",ErrorMessage ="La contraseña y su validacion deben coincidir")]
        public string claveAprendizVO2 { get; set; }

        [Display(Name = "Elige un alias")]
        [StringLength(255, ErrorMessage = "Debe tener entre 5 y 255 caracteres", MinimumLength = 5)]
        public string aliasAprendizVO { get; set; }

        //a rol no se le asignan componentes data anotacion ya que el valor se le dara aca en la clase
        public int Rol { get; set; }

        //se crea un objeto de la base de datos.
        DataEasyDataContext aprendiz = new DataEasyDataContext();

        //se crea un objeto de la tabla aprendiz
        Aprendiz Obj = new Aprendiz();

        Encrypt i = new Encrypt();


        public bool Registrarse()
        {
            //se realiza la consulta
            var consulta = from a in aprendiz.Aprendiz
                           where a.Correo_Electronico_aprendiz == correoElectronicoAprendizVO || a.Alias_aprendiz == aliasAprendizVO
                           select a;

            //se valida si el usuario existe
            if (consulta.Count() > 0)
            {
                //retorna false si el correo o el alias ya estan registrados en la base de datos.
                return false;
            }
            else
            {
                Obj.Nombre_aprendiz = NombresApredizVO;
                Obj.Apellidos_aprendiz = apellidosAprendizVO;
                Obj.Alias_aprendiz = aliasAprendizVO;
                Obj.Correo_Electronico_aprendiz = correoElectronicoAprendizVO;
                Obj.Clave_aprendiz = i.Encripta(claveAprendizVO);
                Obj.Rol = 1;

                aprendiz.Aprendiz.InsertOnSubmit(Obj);
                aprendiz.SubmitChanges();
                return true;
            }


        }

        }
    }
