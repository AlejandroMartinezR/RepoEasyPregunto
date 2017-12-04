using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPregunto.Models
{
    public class TutorVO
    {
        DataEasyDataContext modelo = new DataEasyDataContext();

        public int IdTutorVO { get; set; }
        public int TipoDocumentoTutorVO { get; set; }
        public int NumeroDocumentoTutorVO { get; set; }
        public int ExperienciaTutorVO { get; set; }
        public string NombresTutorVO { get; set; }
        public string ApellidosTutorVO { get; set; }
        public string CorreoElectronicoTutorVO { get; set; }
        public string ClaveTutorVO { get; set; }
        public string TelefonoTutorVO { get; set; }
        public int NivelEstudioTutorVO { get; set; }
        public string TiempoLaboradoTutorVO { get; set; }
        public int EstadoTutorVO { get; set; }
        public int RolTutorVO { get; set; }
        public int AreaConocimientoTutorVO { get; set; }
        public string DescripcionPerfilVO { get; set; }

        // no tocar esta propiedad!!!
        public bool Bandera { get; set; }

        //Propiedades de prueba

        public int IdNivelEstudioVO { get; set; }
        public int FormacionAcademicaVO { get; set; }
        public int TituloOptenidoVO { get; set; }
        public string InstitucionEstudioVO { get; set; }
        public string AnoFinalizacionVO { get; set; }

    }
}