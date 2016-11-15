using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.Musicas.Dominio
{
    public class Musica
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        //Toda musica está atrelada a um Album e todo Album tem uma lista de musicas
        //1-N
        public virtual Album Album { get; set; }//somente uma representação do album que está atrelada a musica
        public int idAlbum { get; set; }//propriedade de navegação, informação que será persistida no Banco



    }
}
