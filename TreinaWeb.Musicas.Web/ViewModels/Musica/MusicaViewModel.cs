using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musicas.Web.ViewModels.Musica
{
    public class MusicaViewModel
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int  Id { get; set; }

        [Required(ErrorMessage = "O nome da música é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome da música pode ter no máximo 50 caraceres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione um álbum válido")]
        public int IdAlbum { get; set; }
    }
}