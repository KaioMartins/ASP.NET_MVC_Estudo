using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Musicas.Web.ViewModels.Album;

namespace TreinaWeb.Musicas.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            //permite que crie mapeamento entre dois objetos
            //faz um match com o nome do atributo
            Mapper.CreateMap<Album, AlbumIndexViewModel>();
            Mapper.CreateMap<Album, AlbumViewModel>();
        }
    }
}