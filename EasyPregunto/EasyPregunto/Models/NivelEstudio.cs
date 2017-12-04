using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPregunto.Models
{
    public class NivelEstudio
    {
        public int IdNivelEstudioVO { get; set; }
        public int FormacionAcademicaVO { get; set; }
        public int TituloOptenidoVO { get; set; }
        public string InstitucionEstudio { get; set; }
        public string AnoFinalizacion { get; set; }
    }
}