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
    public class EsferasController : BaseController
    {

        // GET: Esferas
        public ActionResult Index(int? page, string search = "")
        {

            try
            {
                ViewBag.search = search;
                ViewBag.page = page;

                int pageSize = 08;
                int pageNumber = (page ?? 1);

                var model = db.Esferas.ToList();
                if (search != "")
                {
                    model = db.Esferas.Where(prop => prop.Nome.Contains(search)).ToList();
                }
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                ErrorMessage = "Erro de aplicação entre em contato com o Suporte!" + ex.Message;
            }

            return View();

        }

        // GET: Esferas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esfera esfera = db.Esferas.Find(id);
            if (esfera == null)
            {
                return HttpNotFound();
            }
            return View(esfera);
        }

        // GET: Esferas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Esferas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EsferaId,Nome")] Esfera esfera)
        {
            if (ModelState.IsValid)
            {
                db.Esferas.Add(esfera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(esfera);
        }

        // GET: Esferas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esfera esfera = db.Esferas.Find(id);
            if (esfera == null)
            {
                return HttpNotFound();
            }
            return View(esfera);
        }

        // POST: Esferas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EsferaId,Nome")] Esfera esfera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(esfera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(esfera);
        }

        // GET: Esferas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esfera esfera = db.Esferas.Find(id);
            if (esfera == null)
            {
                return HttpNotFound();
            }
            return View(esfera);
        }

        // POST: Esferas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Esfera esfera = db.Esferas.Find(id);
            db.Esferas.Remove(esfera);
            db.SaveChanges();
            return RedirectToAction("Index");
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
