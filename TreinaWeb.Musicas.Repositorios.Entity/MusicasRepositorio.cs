using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Repositorios.Comum.Entity;
using System.Data.Entity;

namespace TreinaWeb.Musicas.Repositorios.Entity
{
    public class MusicasRepositorio : RepositorioGenericoEntity<Musica, long>
    {
        public MusicasRepositorio(MusicasDbContext contexto)
            : base(contexto)
        {
            //Chamar método do Entity para selecionar Musicas do Album
            //Classes que trabalham com NavigationProperty precisam desse override
        }

        //RepositorioGenericoEntity
        public override List<Musica> Selecionar()
        {
            //Metodo Include, inclui as propriedades de navegação 
            //Permite a expressão lambda usando o Entity
            return _contexto.Set<Musica>().Include(p => p.Album).ToList();
        }

        public override Musica SelecionarPorId(long id)
        {
            return _contexto.Set<Musica>().Include(p => p.Album).SingleOrDefault(m => m.Id == id);
        }
    }
}
