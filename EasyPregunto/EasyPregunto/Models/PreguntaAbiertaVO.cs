using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPregunto.Models
{
    public class PreguntaAbiertaVO
    {
        DataEasyDataContext modelo = new DataEasyDataContext();
        Pregunta_Abierta Obj = new Pregunta_Abierta();
        public int IdPreguntaAbiertaVO { get; set; }


        public string preguntaVO { get; set; }
        public int IAreaPreguntaVO { get; set; }


        public bool RegistrarPreguntaAbierta(int materia)
        {
            IAreaPreguntaVO = materia;

            Obj.Pregunta = preguntaVO;
            Obj.Area = IAreaPreguntaVO;

                modelo.Pregunta_Abierta.InsertOnSubmit(Obj);
                modelo.SubmitChanges();
                return true;
        }
    }
}