using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using SGTE_V1._8.Models;

namespace SGTE_V1._8.Controllers
{
    public class ClienteController : Controller
    {
        private SGTE2Entities db = new SGTE2Entities();

        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(db.Tbl_Cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Cliente tbl_Cliente = db.Tbl_Cliente.Find(id);
            if (tbl_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Cidade,Bairro,Endereco,Estado,CEP,Data_Nasc,RG,CPF,Telefone,Celular,Email,Ativo")] Tbl_Cliente tbl_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Cliente.Add(tbl_Cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Cliente tbl_Cliente = db.Tbl_Cliente.Find(id);
            if (tbl_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Cidade,Bairro,Endereco,Estado,CEP,Data_Nasc,RG,CPF,Telefone,Celular,Email,Ativo")] Tbl_Cliente tbl_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Cliente tbl_Cliente = db.Tbl_Cliente.Find(id);
            if (tbl_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Cliente tbl_Cliente = db.Tbl_Cliente.Find(id);
            db.Tbl_Cliente.Remove(tbl_Cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Consultas(){
            return View();
        }

        
        public ActionResult Eventualidade() {
            return View();
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
