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
    public class MotoristaController : Controller
    {
        private SGTE2Entities db = new SGTE2Entities();

        // GET: Motorista
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult List()
        {
            var tbl_Motorista = db.Tbl_Motorista.Include(t => t.Tbl_Funcionario).Include(t => t.Tbl_Veiculo);
            return View(tbl_Motorista.ToList());
        }

        // GET: Motorista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Motorista tbl_Motorista = db.Tbl_Motorista.Find(id);
            if (tbl_Motorista == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Motorista);
        }

        // GET: Motorista/Create
        public ActionResult Create()
        {
            ViewBag.Funcionario_ID = new SelectList(db.Tbl_Funcionario, "ID", "Funcao");
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa");
            return View();
        }

        // POST: Motorista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,CNH,Funcionario_ID,Veiculo_ID,Ativo")] Tbl_Motorista tbl_Motorista)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Motorista.Add(tbl_Motorista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Funcionario_ID = new SelectList(db.Tbl_Funcionario, "ID", "Funcao", tbl_Motorista.Funcionario_ID);
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Motorista.Veiculo_ID);
            return View(tbl_Motorista);
        }

        // GET: Motorista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Motorista tbl_Motorista = db.Tbl_Motorista.Find(id);
            if (tbl_Motorista == null)
            {
                return HttpNotFound();
            }
            ViewBag.Funcionario_ID = new SelectList(db.Tbl_Funcionario, "ID", "Funcao", tbl_Motorista.Funcionario_ID);
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Motorista.Veiculo_ID);
            return View(tbl_Motorista);
        }

        // POST: Motorista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,CNH,Funcionario_ID,Veiculo_ID,Ativo")] Tbl_Motorista tbl_Motorista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Motorista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Funcionario_ID = new SelectList(db.Tbl_Funcionario, "ID", "Funcao", tbl_Motorista.Funcionario_ID);
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Motorista.Veiculo_ID);
            return View(tbl_Motorista);
        }

        // GET: Motorista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Motorista tbl_Motorista = db.Tbl_Motorista.Find(id);
            if (tbl_Motorista == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Motorista);
        }

        // POST: Motorista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Motorista tbl_Motorista = db.Tbl_Motorista.Find(id);
            db.Tbl_Motorista.Remove(tbl_Motorista);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GerarRelatorio() {

            return View();      
        }

        public ActionResult GerarRota() {
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
