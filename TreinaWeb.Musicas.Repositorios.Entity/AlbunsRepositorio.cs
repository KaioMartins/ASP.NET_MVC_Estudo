using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Repositorios.Comum.Entity;

namespace TreinaWeb.Musicas.Repositorios.Entity
{
    //só ira lidar com a camada de AcessoDados.Entity
    //não é preciso implementar os métodos de manipulação, pois já está herdando de repositorios genericos
    public class AlbunsRepositorio : RepositorioGenericoEntity<Album, int>
    {
        public AlbunsRepositorio(MusicasDbContext contexto)
            : base(contexto)
        {

        }
    }
}
