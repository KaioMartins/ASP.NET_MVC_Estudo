using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//class que cria Annotations personalizadas para os atributos
//pode servir para validar campos da tela
namespace TreinaWeb.Musicas.Web.Annotations
{
    public class EmailTreinaWebAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value.ToString().EndsWith("@treinaweb.com.br");
        }
    }
}