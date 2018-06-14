using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Safirex.Models.ClassificacaoEstrutura;

namespace Safirex.Controllers
{
    public class GovernosController : BaseController
    {

        // GET: Governos
        public ActionResult Index(int? page, string search = "")
        {

            ViewBag.search = search;
            ViewBag.page = page;

            int pageSize = 08;
            int pageNumber = (page ?? 1);

            var model = db.Governos.ToList();
            if (search != "")
            {
                model = db.Governos.Where(prop => prop.Nome.Contains(search)).ToList();
            }

            return View(model.ToPagedList(pageNumber, pageSize));

        }
        // GET: Governos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governo governo = db.Governos.Find(id);
            if (governo == null)
            {
                return HttpNotFound();
            }
            return View(governo);
        }

        // GET: Governos/Create
        public ActionResult Create()
        {
            ViewBag.GestaoId = new SelectList(db.Gestaos, "GestaoId", "Nome");
            return View();
        }

        // POST: Governos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GovernoId,GestaoId,Nome")] Governo governo)
        {
            if (ModelState.IsValid)
            {
                db.Governos.Add(governo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GestaoId = new SelectList(db.Gestaos, "GestaoId", "Nome", governo.GestaoId);
            return View(governo);
        }

        // GET: Governos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governo governo = db.Governos.Find(id);
            if (governo == null)
            {
                return HttpNotFound();
            }
            ViewBag.GestaoId = new SelectList(db.Gestaos, "GestaoId", "Nome", governo.GestaoId);
            return View(governo);
        }

        // POST: Governos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GovernoId,GestaoId,Nome")] Governo governo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(governo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GestaoId = new SelectList(db.Gestaos, "GestaoId", "Nome", governo.GestaoId);
            return View(governo);
        }

        // GET: Governos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governo governo = db.Governos.Find(id);
            if (governo == null)
            {
                return HttpNotFound();
            }
            return View(governo);
        }

        // POST: Governos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Governo governo = db.Governos.Find(id);
            db.Governos.Remove(governo);
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
