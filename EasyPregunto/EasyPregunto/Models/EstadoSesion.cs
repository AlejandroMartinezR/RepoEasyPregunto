using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPregunto.Models
{
    public class EstadoSesion
    {
        public string EstadoVO { get; set; }
        public int IdAprendizVO { get; set; }
        public int IdTutor { get; set; }
        public int Materia { get; set; }

        DataEasyDataContext modelo = new DataEasyDataContext();
        Estado_Sesion obj = new Estado_Sesion();

        public bool RegistraUsuarioyMateria()
        {
            obj.Estado = "Validacion";
            obj.Aprendiz = IdAprendizVO;
            //si les sale error aca por favor en la tabla Estado Session realize esto
            //alter table [dbo].[Estado_Sesion] alter column [Tutor] int null "Ojo en la base de datos"
            obj.IdArea = Materia;

            modelo.Estado_Sesion.InsertOnSubmit(obj);
            modelo.SubmitChanges();

            return true;
        }

        public int asignaMateria(int materia)
        {
            Materia = materia;
            return Materia;
        }

    }
}