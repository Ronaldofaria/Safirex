using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Safirex.Models.Domain;
using PagedList;

namespace Safirex.Controllers
{
    public class UsuariosController : BaseController
    {
        private SafirexContext db = new SafirexContext();

        public ActionResult Index(int? page, string search = "")
        {

            ViewBag.search = search;
            ViewBag.page = page;

            int pageSize = 08;
            int pageNumber = (page ?? 1);

            var model = db.Usuarios.ToList();
            if (search != "")
            {
                model = db.Usuarios.Where(prop => prop.NomeCompleto.Contains(search) ||
                                                  prop.Login.Contains(search)).ToList();
            }

            return View(model.ToPagedList(pageNumber, pageSize));

        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult  Cadastro (string MessageErro, string MessageInfo)
        {
            ViewBag.MessageErro = MessageErro;
            ViewBag.MessageInfo = MessageInfo;
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "UsuarioId,NomeCompleto,Login,Senha")] Usuario usuario)
        {
            var t_usuario = (from u in db.Usuarios where u.Login == usuario.Login select u).Count();
            if (t_usuario == 0)
            {
                if (ModelState.IsValid)
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    ViewBag.MessageInfo = "Usuário foi incluido com sucesso.";
                    return RedirectToAction("Login", "Home");
                    //return RedirectToAction("Login", "Home", new { MessageErro = ViewBag.MessageErro, MessageInfo = ViewBag.MessageInfo });
                }
            }
            else
            {
                ViewBag.MessageErro = "Usuario já foi cadastrado, tente novamente.";
                //return RedirectToAction("Cadastro", "Usuarios", new { MessageErro = ViewBag.MessageErro, MessageInfo = ViewBag.MessageInfo });
            }
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioId,NomeCompleto,Login,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId,NomeCompleto,Login,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
