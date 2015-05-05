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
    public class ListaAlunoVeiculoController : Controller
    {
        private SGTE2Entities db = new SGTE2Entities();

        // GET: ListaAlunoVeiculo
        public ActionResult Index()
        {
            var tbl_Aluno = db.Tbl_Aluno.Include(t => t.Tbl_Cliente).Include(t => t.Tbl_Escola).Include(t => t.Tbl_Veiculo);
            return View(tbl_Aluno.ToList());
        }


        public ActionResult ListaAlunoPorVeiculo() {
            var tbl_Aluno = db.Tbl_Aluno.Include(t => t.Tbl_Cliente).Include(t => t.Tbl_Escola).Include(t => t.Tbl_Veiculo);
            return View(tbl_Aluno.ToList());
        
        }


     
        // GET: ListaAlunoVeiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Aluno tbl_Aluno = db.Tbl_Aluno.Find(id);
            if (tbl_Aluno == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Aluno);
        }

        // GET: ListaAlunoVeiculo/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_ID = new SelectList(db.Tbl_Cliente, "ID", "Nome");
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome");
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa");
            return View();
        }

        // POST: ListaAlunoVeiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,RG,Escola,Cidade,Bairro,CEP,Estado,Endereco_1,Endereco_2,Ativo,Cliente_ID,Veiculo_ID,Escola_ID")] Tbl_Aluno tbl_Aluno)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Aluno.Add(tbl_Aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_ID = new SelectList(db.Tbl_Cliente, "ID", "Nome", tbl_Aluno.Cliente_ID);
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome", tbl_Aluno.Escola_ID);
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Aluno.Veiculo_ID);
            return View(tbl_Aluno);
        }

        // GET: ListaAlunoVeiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Aluno tbl_Aluno = db.Tbl_Aluno.Find(id);
            if (tbl_Aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_ID = new SelectList(db.Tbl_Cliente, "ID", "Nome", tbl_Aluno.Cliente_ID);
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome", tbl_Aluno.Escola_ID);
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Aluno.Veiculo_ID);
            return View(tbl_Aluno);
        }

        // POST: ListaAlunoVeiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,RG,Escola,Cidade,Bairro,CEP,Estado,Endereco_1,Endereco_2,Ativo,Cliente_ID,Veiculo_ID,Escola_ID")] Tbl_Aluno tbl_Aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_ID = new SelectList(db.Tbl_Cliente, "ID", "Nome", tbl_Aluno.Cliente_ID);
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome", tbl_Aluno.Escola_ID);
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Aluno.Veiculo_ID);
            return View(tbl_Aluno);
        }

        // GET: ListaAlunoVeiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Aluno tbl_Aluno = db.Tbl_Aluno.Find(id);
            if (tbl_Aluno == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Aluno);
        }

        // POST: ListaAlunoVeiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Aluno tbl_Aluno = db.Tbl_Aluno.Find(id);
            db.Tbl_Aluno.Remove(tbl_Aluno);
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
