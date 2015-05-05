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
    public class EscolaController : Controller
    {
        private SGTE2Entities db = new SGTE2Entities();

        // GET: Escola
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(db.Tbl_Escola.ToList());
        }

        // GET: Escola/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Escola tbl_Escola = db.Tbl_Escola.Find(id);
            if (tbl_Escola == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Escola);
        }

        // GET: Escola/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escola/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Endereco,Cidade,Bairro,CEP,Estado,CNPJ,Ativo")] Tbl_Escola tbl_Escola)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Escola.Add(tbl_Escola);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Escola);
        }

        // GET: Escola/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Escola tbl_Escola = db.Tbl_Escola.Find(id);
            if (tbl_Escola == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Escola);
        }

        // POST: Escola/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Endereco,Cidade,Bairro,CEP,Estado,CNPJ,Ativo")] Tbl_Escola tbl_Escola)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Escola).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Escola);
        }

        // GET: Escola/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Escola tbl_Escola = db.Tbl_Escola.Find(id);
            if (tbl_Escola == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Escola);
        }

        // POST: Escola/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Escola tbl_Escola = db.Tbl_Escola.Find(id);
            db.Tbl_Escola.Remove(tbl_Escola);
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
