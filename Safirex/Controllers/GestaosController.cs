using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Safirex.Models.ClassificacaoOrigem;

namespace Safirex.Controllers
{
    public class GestaosController : BaseController
    {

        // GET: Governos
        public ActionResult Index(int? page, string search = "")
        {

            ViewBag.search = search;
            ViewBag.page = page;

            int pageSize = 08;
            int pageNumber = (page ?? 1);

            var model = db.Gestaos.ToList();
            if (search != "")
            {
                model = db.Gestaos.Where(prop => prop.Nome.Contains(search)).ToList();
            }

            return View(model.ToPagedList(pageNumber, pageSize));

        }

        // GET: Gestaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestao gestao = db.Gestaos.Find(id);
            if (gestao == null)
            {
                return HttpNotFound();
            }
            return View(gestao);
        }

        // GET: Gestaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gestaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GestaoId,Nome")] Gestao gestao)
        {
            if (ModelState.IsValid)
            {
                db.Gestaos.Add(gestao);
                db.SaveChanges();
                return RedirectToPrevious();
            }

            return View(gestao);
        }

        // GET: Gestaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestao gestao = db.Gestaos.Find(id);
            if (gestao == null)
            {
                return HttpNotFound();
            }
            return View(gestao);
        }

        // POST: Gestaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GestaoId,Nome")] Gestao gestao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToPrevious();
            }
            return View(gestao);
        }

        // GET: Gestaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestao gestao = db.Gestaos.Find(id);
            if (gestao == null)
            {
                return HttpNotFound();
            }
            return View(gestao);
        }

        // POST: Gestaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gestao gestao = db.Gestaos.Find(id);
            db.Gestaos.Remove(gestao);
            db.SaveChanges();
            return RedirectToPrevious();
        }

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
