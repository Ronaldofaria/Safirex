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
    public class SecretariasController : BaseController
    {

        // GET: Secretarias
        public ActionResult Index(int? page, string search = "")
        {

            ViewBag.search = search;
            ViewBag.page = page;

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            var model = db.Secretarias.ToList();
            if (search != "")
            {
                model = db.Secretarias.Where(prop => prop.Nome.Contains(search)).ToList();
            }

            return View(model.ToPagedList(pageNumber, pageSize));

        }

        // GET: Secretarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretarias.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            return View(secretaria);
        }

        // GET: Secretarias/Create
        public ActionResult Create()
        {
            ViewBag.GovernoId = new SelectList(db.Governos, "GovernoId", "Nome");
            return View();
        }

        // POST: Secretarias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SecretariaId,GovernoId,Sigla,Nome,CNPJ,Endereco,Cidade,Bairro,Uf,Cep")] Secretaria secretaria)
        {
            if (ModelState.IsValid)
            {
                db.Secretarias.Add(secretaria);
                db.SaveChanges();
                return RedirectToPrevious();
            }

            ViewBag.GovernoId = new SelectList(db.Governos, "GovernoId", "Nome", secretaria.GovernoId);
            return View(secretaria);
        }

        // GET: Secretarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretarias.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.GovernoId = new SelectList(db.Governos, "GovernoId", "Nome", secretaria.GovernoId);
            return View(secretaria);
        }

        // POST: Secretarias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SecretariaId,GovernoId,Sigla,Nome,CNPJ,Endereco,Cidade,Bairro,Uf,Cep")] Secretaria secretaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secretaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToPrevious();
            }
            ViewBag.GovernoId = new SelectList(db.Governos, "GovernoId", "Nome", secretaria.GovernoId);
            return View(secretaria);
        }

        // GET: Secretarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretaria secretaria = db.Secretarias.Find(id);
            if (secretaria == null)
            {
                return HttpNotFound();
            }
            return View(secretaria);
        }

        // POST: Secretarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Secretaria secretaria = db.Secretarias.Find(id);
            db.Secretarias.Remove(secretaria);
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
