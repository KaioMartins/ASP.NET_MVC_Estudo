using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Musicas.Web.ViewModels.Album;

namespace TreinaWeb.Musicas.Web.Controllers
{
    public class AlbunsController : Controller
    {
        private MusicasDbContext db = new MusicasDbContext();

        // GET: Albuns
        //Exibe a lista do que está cadastrado no banco
        //pega o set do DbContext e envia para a lista
        //Similar ao 'select * from'
        public ActionResult Index()
        {
            //mudar a propriedade padrão gerada pelo Scaffolding
            return View(Mapper.Map<List<Album>, List<AlbumIndexViewModel>>(db.Albuns.ToList()));
        }

        // GET: Albuns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albuns/Create
        public ActionResult Create()
        {
            //return View() sem parametrização: é retornada a View de acordo com o nome da action
            //só irá renderizar uma página
            return View();
        }

        // POST: Albuns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Submissão para o servidor é sempre por POST
        public ActionResult Create([Bind(Include = "Id,Nome,Ano,Observacoes,Email")] AlbumViewModel viewModel)
        {
            //verificação ServerSide
            if (ModelState.IsValid)
            {
                Album album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                db.Albuns.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Albuns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album, AlbumViewModel>(album));
        }

        // POST: Albuns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ano,Observacoes,Email")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Album album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Albuns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albuns/Delete/5
        //ActionName("Delete") = define o nome do nome da action como 'Delete' e também
        // como também 'DeleteConfirmed', pois o asp.net não iria conseguir diferenciar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albuns.Find(id);
            db.Albuns.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //É executado para remvover objetos de memória
        //é feito o override para ser feito o fechamento da conexão com o banco quando 
        // o Controller parar a execução, pois senão o objeto do Controller somente é retirado de memória
        // e a conexão com o banco fica aberta
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
