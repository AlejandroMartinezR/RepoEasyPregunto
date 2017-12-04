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

    public class RegistrarseVO
    {
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

        public string aliasAprendizVO { get; set; }
        public int Id_aprendizVO { get; set; }

        public string Final { get; set; }

        DataEasyDataContext aprendiz = new DataEasyDataContext();
        Aprendiz obj = new Aprendiz();

        Encrypt i = new Encrypt();

        public bool login()
        {
            var consultaLogin = from a in aprendiz.Aprendiz
                                where a.Correo_Electronico_aprendiz == correoElectronicoAprendizVO && a.Clave_aprendiz == i.Encripta(claveAprendizVO)
                                select a;

            if (consultaLogin.Count() > 0)
            {
                var datosLista = consultaLogin.ToList();
                foreach (var Data in datosLista)
                {
                    aliasAprendizVO = Data.Alias_aprendiz;
                    Id_aprendizVO = Data.Id_aprendiz;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}