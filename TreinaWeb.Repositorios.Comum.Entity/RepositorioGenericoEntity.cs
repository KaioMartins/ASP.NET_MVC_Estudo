using TreinaWeb.Repositorios.Comum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.Repositorios.Comum.Entity
{
    //Colocar limitador Where para que possa especificar o tipo de entidade que é TEntidade
    //irá lidar com o DbContext
    public class RepositorioGenericoEntity<TEntidade, TChave> : IRepositorioGenerico<TEntidade, TChave>
        where TEntidade : class
    {

        //campo privado que irá armazenar o contexto de dados recebido pelo DbContext
        private DbContext _contexto;

        //instalar Entity para usar o DbContext
        public RepositorioGenericoEntity(DbContext contexto)
        {
            _contexto = contexto;
        }
        public void Alterar(TEntidade entidade)
        {
            //Attach reintegra entidade POCO ao Entity, para que este possa manipular
            _contexto.Set<TEntidade>().Attach(entidade);
            //Notificar o Entity que a entidade foi modificada, para que não seja feito um novo Insert
            _contexto.Entry(entidade).State = EntityState.Modified;
            //Salva as alterações no banco
            _contexto.SaveChanges();
        }

        public void Excluir(TEntidade entidade)
        {
            //Attach reintegra entidade POCO ao Entity, para que este possa manipular
            _contexto.Set<TEntidade>().Attach(entidade);
            //Notificar o Entity que a entidade foi deletada, para que não seja feito um novo Insert
            _contexto.Entry(entidade).State = EntityState.Deleted;
            //Salva as alterações no banco
            _contexto.SaveChanges();
        }

        public void ExcluirPorId(TChave id)
        {
            //Localiza o objeto com o SelecionarPorId() e manda para o Excluir()
            TEntidade entidade = SelecionarPorId(id);
            Excluir(entidade);
        }

        public void Inserir(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Add(entidade);
            _contexto.SaveChanges();
        }

        public List<TEntidade> Selecionar()
        {
            return _contexto.Set<TEntidade>().ToList();
        }

        public TEntidade SelecionarPorId(TChave id)
        {
            return _contexto.Set<TEntidade>().Find(id);
        }
    }
}
