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
            Mapper.CreateMap<Album, AlbumExibicaoViewModel>()
                .ForMember(p => p.Nome, opt =>
                {
                    //irá mapear 2 propriedades para criar um campo personalizado na tela
                    //Personaliza o parametro 'Nome' do ViewModel
                    opt.MapFrom(src => string.Format("{0} ({1})", src.Nome, src.Ano.ToString()));
                });
            Mapper.CreateMap<Album, AlbumViewModel>();
        }
    }
}