﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musicas.Web.ViewModels.Musica
{
    public class MusicaExibicaoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome da Música")]
        public string Nome { get; set; }

        [Display(Name = "Nome do álbum")]
        public string NomeAlbum { get; set; }


    }
}