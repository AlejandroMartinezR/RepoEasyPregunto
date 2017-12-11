using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyPregunto.Models
{

    public class ExperienciaVO
    {
        DataEasyDataContext modelo = new DataEasyDataContext();

        public int IdExperienciaVO { get; set; }

        [Required(ErrorMessage = "Debe ingresar una institución")]
        [StringLength(60, MinimumLength = 3)]
        public string InstitucionExperienciaVO { get; set; }

        [Required(ErrorMessage = "Debe ingresar un cargo")]
        [StringLength(60, MinimumLength = 3)]
        public string cargoDesempeñadoVO { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha valida")]
        [StringLength(60, MinimumLength = 3)]
        public string FechaIngresoVO { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha valida")]
        [StringLength(60, MinimumLength = 3)]
        public string FechaSalidaVO { get; set; }

        [Required(ErrorMessage = "Debe ingresar un motivo de retiro")]
        [StringLength(60, MinimumLength = 3)]
        public string MotivoDelRetiro { get; set; }

        Experiencia obj = new Experiencia();

        public bool Traerid()
        {
            var selec = (from e in modelo.Experiencia
                         select e.Id_Experiencia).Max();

            IdExperienciaVO = (int)selec;

            return true;
        }

        public bool RegistroExperiencia()
        {

                obj.EmpresaInstitucion_Experiencia = InstitucionExperienciaVO;
                obj.Cargo_Experiencia = cargoDesempeñadoVO;
                obj.FechaIngreso_Experiencia = FechaIngresoVO;
                obj.FechaSalida_Experiencia = FechaSalidaVO;
                obj.MotivoRetiro_Experiencia = MotivoDelRetiro;

                modelo.Experiencia.InsertOnSubmit(obj);
                modelo.SubmitChanges();

            return true;


        }
    }
}