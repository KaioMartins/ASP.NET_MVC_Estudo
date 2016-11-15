using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Comum.Entity;
using TreinaWeb.Musicas.Dominio;

namespace TreinaWeb.Musicas.AcessoDados.Entity.TypeConfiguration
{
    class MusicaTypeConfiguration : TreinaWebEntityAbstractConfig<Musica>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .HasColumnName("MUS_ID")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("MUS_NOME")
                .HasMaxLength(50)
                .IsRequired();

            //Configurar o ID da outra classe, pois a classe em si é somente uma propriedade de navegação
            Property(p => p.idAlbum)
                .HasColumnName("ALB_ID")
                .IsRequired();


        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            //Musica tem um album, e este Album é obrigatorio
            //está lidando com as propriedades de navegação
            //Lambda
            HasRequired(p => p.Album)//seletor foi pra classe Album
                .WithMany(p => p.Musicas)//voltou pra classe Musica
                .HasForeignKey(fk => fk.idAlbum);//FK da classe Musicas é o idAlbum
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("MUS_MUSICAS");
        }
    }
}
