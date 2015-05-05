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
    public class ViagemController : Controller
    {
        private SGTE2Entities db = new SGTE2Entities();

        // GET: Viagem
        public ActionResult Index()
        {
            var tbl_Viagem = db.Tbl_Viagem.Include(t => t.Tbl_Aluno).Include(t => t.Tbl_Escola).Include(t => t.Tbl_Motorista).Include(t => t.Tbl_Passageiro_Viagem1).Include(t => t.Tbl_Veiculo);
            return View(tbl_Viagem.ToList());
        }

        // GET: Viagem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Viagem tbl_Viagem = db.Tbl_Viagem.Find(id);
            if (tbl_Viagem == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Viagem);
        }

        // GET: Viagem/Create
        public ActionResult Create()
        {
            ViewBag.Aluno_ID = new SelectList(db.Tbl_Aluno, "ID", "Nome");
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome");
            ViewBag.Motorista_ID = new SelectList(db.Tbl_Motorista, "ID", "Nome");
            ViewBag.Passageiro_ID = new SelectList(db.Tbl_Passageiro_Viagem, "ID", "Passageiros");
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa");
            return View();
        }

        // POST: Viagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Motorista,Data,Obs_Viagem,Tipo,Aluno_ID,Escola_ID,Veiculo_ID,Motorista_ID,Passageiro_ID")] Tbl_Viagem tbl_Viagem)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Viagem.Add(tbl_Viagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Aluno_ID = new SelectList(db.Tbl_Aluno, "ID", "Nome", tbl_Viagem.Aluno_ID);
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome", tbl_Viagem.Escola_ID);
            ViewBag.Motorista_ID = new SelectList(db.Tbl_Motorista, "ID", "Nome", tbl_Viagem.Motorista_ID);
            ViewBag.Passageiro_ID = new SelectList(db.Tbl_Passageiro_Viagem, "ID", "Passageiros", tbl_Viagem.Passageiro_ID);
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Viagem.Veiculo_ID);
            return View(tbl_Viagem);
        }

        // GET: Viagem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Viagem tbl_Viagem = db.Tbl_Viagem.Find(id);
            if (tbl_Viagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aluno_ID = new SelectList(db.Tbl_Aluno, "ID", "Nome", tbl_Viagem.Aluno_ID);
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome", tbl_Viagem.Escola_ID);
            ViewBag.Motorista_ID = new SelectList(db.Tbl_Motorista, "ID", "Nome", tbl_Viagem.Motorista_ID);
            ViewBag.Passageiro_ID = new SelectList(db.Tbl_Passageiro_Viagem, "ID", "Passageiros", tbl_Viagem.Passageiro_ID);
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Viagem.Veiculo_ID);
            return View(tbl_Viagem);
        }

        // POST: Viagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Motorista,Data,Obs_Viagem,Tipo,Aluno_ID,Escola_ID,Veiculo_ID,Motorista_ID,Passageiro_ID")] Tbl_Viagem tbl_Viagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Viagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Aluno_ID = new SelectList(db.Tbl_Aluno, "ID", "Nome", tbl_Viagem.Aluno_ID);
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome", tbl_Viagem.Escola_ID);
            ViewBag.Motorista_ID = new SelectList(db.Tbl_Motorista, "ID", "Nome", tbl_Viagem.Motorista_ID);
            ViewBag.Passageiro_ID = new SelectList(db.Tbl_Passageiro_Viagem, "ID", "Passageiros", tbl_Viagem.Passageiro_ID);
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Viagem.Veiculo_ID);
            return View(tbl_Viagem);
        }

        // GET: Viagem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Viagem tbl_Viagem = db.Tbl_Viagem.Find(id);
            if (tbl_Viagem == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Viagem);
        }

        // POST: Viagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Viagem tbl_Viagem = db.Tbl_Viagem.Find(id);
            db.Tbl_Viagem.Remove(tbl_Viagem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult List()
        {
            var tbl_Viagem = db.Tbl_Viagem.Include(t => t.Tbl_Aluno).Include(t => t.Tbl_Escola).Include(t => t.Tbl_Motorista).Include(t => t.Tbl_Passageiro_Viagem1).Include(t => t.Tbl_Veiculo);
            return View(tbl_Viagem.ToList());
        }

        public ActionResult ObservacaoViagem()
        {
            var tbl_Viagem = db.Tbl_Viagem.Include(t => t.Tbl_Aluno).Include(t => t.Tbl_Escola).Include(t => t.Tbl_Motorista).Include(t => t.Tbl_Passageiro_Viagem1).Include(t => t.Tbl_Veiculo);
            return View(tbl_Viagem.ToList());
        }

        public ActionResult Planejamento()
        {
            return View();
        
        }


        public ActionResult EditObservacao(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Viagem tbl_Viagem = db.Tbl_Viagem.Find(id);
            if (tbl_Viagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aluno_ID = new SelectList(db.Tbl_Aluno, "ID", "Nome", tbl_Viagem.Aluno_ID);
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome", tbl_Viagem.Escola_ID);
            ViewBag.Motorista_ID = new SelectList(db.Tbl_Motorista, "ID", "Nome", tbl_Viagem.Motorista_ID);
            ViewBag.Passageiro_ID = new SelectList(db.Tbl_Passageiro_Viagem, "ID", "Passageiros", tbl_Viagem.Passageiro_ID);
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Viagem.Veiculo_ID);
            return View(tbl_Viagem);
        }

        // POST: Viagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditObservacao([Bind(Include = "ID,Motorista,Data,Obs_Viagem,Tipo,Aluno_ID,Escola_ID,Veiculo_ID,Motorista_ID,Passageiro_ID")] Tbl_Viagem tbl_Viagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Viagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Aluno_ID = new SelectList(db.Tbl_Aluno, "ID", "Nome", tbl_Viagem.Aluno_ID);
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome", tbl_Viagem.Escola_ID);
            ViewBag.Motorista_ID = new SelectList(db.Tbl_Motorista, "ID", "Nome", tbl_Viagem.Motorista_ID);
            ViewBag.Passageiro_ID = new SelectList(db.Tbl_Passageiro_Viagem, "ID", "Passageiros", tbl_Viagem.Passageiro_ID);
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Viagem.Veiculo_ID);
            return View(tbl_Viagem);
        }

        public ActionResult ListCliente() {
            var tbl_Viagem = db.Tbl_Viagem.Include(t => t.Tbl_Aluno).Include(t => t.Tbl_Escola).Include(t => t.Tbl_Motorista).Include(t => t.Tbl_Passageiro_Viagem1).Include(t => t.Tbl_Veiculo);
            return View(tbl_Viagem.ToList());
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
