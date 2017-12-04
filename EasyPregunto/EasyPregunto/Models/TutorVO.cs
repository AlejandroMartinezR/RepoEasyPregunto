using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EasyPregunto.Models
{
    public class TutorVO
    {
        DataEasyDataContext modelo = new DataEasyDataContext();

        public int IdTutorVO { get; set; }

        public int TipoDocumentoTutorVO { get; set; }

        [Required(ErrorMessage ="Campo Requerido")]
        public int NumeroDocumentoTutorVO { get; set; }


        [Required(ErrorMessage ="Campo Requerido")]
        public int ExperienciaTutorVO { get; set; }


        [StringLength(60, MinimumLength = 3)] // esta es un componenente de la libreria ComponentModel. Se define tamaño max 60 y min 3
        [Display(Name = "Nombretuto")] //nombre que queremos que nos muestre la vista
        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string NombresTutorVO { get; set; }

        [StringLength(60, MinimumLength = 3)] // esta es un componenente de la libreria ComponentModel. Se define tamaño max 60 y min 3
        [Display(Name = "Apellidotuto")] //nombre que queremos que nos muestre la vista
        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string ApellidosTutorVO { get; set; }

        [StringLength(60, MinimumLength = 3)] // esta es un componenente de la libreria ComponentModel. Se define tamaño max 60 y min 3
        [Display(Name = "Correoelectronico")] //nombre que queremos que nos muestre la vista
        [Required(ErrorMessage = "El campo es Obligatorio")]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronicoTutorVO { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        [Display(Name ="contrasena")]
        [DataType(DataType.Password)]
        public string ClaveTutorVO { get; set; }


        [Required(ErrorMessage ="campo telefonico requerido")]
        public string TelefonoTutorVO { get; set; }


        public int NivelEstudioTutorVO { get; set; }

        [Required(ErrorMessage ="campo Requerido")]
        public string TiempoLaboradoTutorVO { get; set; }

        public int EstadoTutorVO { get; set; }

        public int RolTutorVO { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int AreaConocimientoTutorVO { get; set; }

        [Required(ErrorMessage ="Debe realizar una breve descripcion de perfil")]
        [DataType(DataType.MultilineText)]
        public string DescripcionPerfilVO { get; set; }

        Tutor obj = new Tutor();
        Encrypt i = new Encrypt();

        public bool RegistrarseTutor()
        {
            //se realiza la consulta
            var consulta = from a in modelo.Tutor
                           where a.Correo_Electronico_tutor == CorreoElectronicoTutorVO
                           select a;

            //se valida si el usuario existe
            if (consulta.Count() > 0)
            {
                //retorna false si el correo o el alias ya estan registrados en la base de datos.
                return false;
            }
            else
            {
                obj.Tipo_Documento = TipoDocumentoTutorVO;
                obj.Numero_Documento = NumeroDocumentoTutorVO;
                obj.Nombres_Tutor = NombresTutorVO;
                obj.Apellidos_Tutor = ApellidosTutorVO;
                obj.Clave_Tutor = i.Encripta(ClaveTutorVO);
                obj.Correo_Electronico_tutor = CorreoElectronicoTutorVO;
                obj.Telefono_Tutor = TelefonoTutorVO;
                obj.Tiempo_Laborado = TiempoLaboradoTutorVO;
                obj.Rol = 2;


                modelo.Tutor.InsertOnSubmit(obj);
                modelo.SubmitChanges();
                return true;
            }


        }
    }
}