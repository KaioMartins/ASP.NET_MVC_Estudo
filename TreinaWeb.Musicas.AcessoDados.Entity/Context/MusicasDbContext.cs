using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Musicas.AcessoDados.Entity.TypeConfiguration;
using TreinaWeb.Musicas.Dominio;

namespace TreinaWeb.Musicas.AcessoDados.Entity.Context
{
    public class MusicasDbContext : DbContext
    {
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Musica> Musicas { get; set; }

        public MusicasDbContext()
        {
            //Qdo o objeto possui uma lista, com o 'LazyLoadingEnabled = true' é carregado cada item da lista
            // a cada iteração, qdo configurado como 'false' já carrega toda a lista com o objeto
            Configuration.LazyLoadingEnabled = false;

            //Se a propriedade acima está desabilitada, desabilitar abaixo
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumTypeConfiguration());
            modelBuilder.Configurations.Add(new MusicaTypeConfiguration());
        }
    }
}
