using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using SGTE_V1._8.Models;

namespace SGTE_V1._8.Controllers
{
    public class VeiculoController : Controller
    {
        Tbl_Veiculo model = new Tbl_Veiculo();

        private SGTE2Entities db = new SGTE2Entities();
        SqlConnection veiculoConexao = new SqlConnection("Data Source=KIDS\\SQLEXPRESS;Initial Catalog=SGTE2;User ID=sa;Password=123");

        // GET: Veiculo
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult List()
        {
            var tbl_Veiculo = db.Tbl_Veiculo.Include(t => t.Tbl_Escola).Include(t => t.Tbl_Veiculo2);
            return View(tbl_Veiculo.ToList());
        }

        //GET
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Veiculo tbl_Veiculo = db.Tbl_Veiculo.Find(id);
            ViewBag.id = id;
          
            if (tbl_Veiculo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Veiculo);
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome");
            ViewBag.Motorista_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa");
            return View();
        }

        // POST: Veiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cod_Veiculo,Placa,Modelo,Renavam,Cidade,Licenca,Chassi,Ano_Fabricacao,Num_Lugares,Lugares_Vagos,UF,Ativo,Status,Escola_ID,Motorista_ID")] Tbl_Veiculo tbl_Veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Veiculo.Add(tbl_Veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome", tbl_Veiculo.Escola_ID);
            ViewBag.Motorista_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Veiculo.Motorista_ID);
            return View(tbl_Veiculo);
        }

        // GET: Veiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Veiculo tbl_Veiculo = db.Tbl_Veiculo.Find(id);
            if (tbl_Veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome", tbl_Veiculo.Escola_ID);
            ViewBag.Motorista_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Veiculo.Motorista_ID);
            return View(tbl_Veiculo);
        }

        // POST: Veiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cod_Veiculo,Placa,Modelo,Renavam,Cidade,Licenca,Chassi,Ano_Fabricacao,Num_Lugares,Lugares_Vagos,UF,Ativo,Status,Escola_ID,Motorista_ID")] Tbl_Veiculo tbl_Veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome", tbl_Veiculo.Escola_ID);
            ViewBag.Motorista_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa", tbl_Veiculo.Motorista_ID);
            return View(tbl_Veiculo);
        }

        // GET: Veiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Veiculo tbl_Veiculo = db.Tbl_Veiculo.Find(id);
            if (tbl_Veiculo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Veiculo);
        }

        // POST: Veiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Veiculo tbl_Veiculo = db.Tbl_Veiculo.Find(id);
            db.Tbl_Veiculo.Remove(tbl_Veiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //--------------------------

        public ActionResult ListaAlunos(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Aluno tbl_Veiculo = db.Tbl_Veiculo.Find(id);
            ViewBag.id = id;
            if (tbl_Veiculo == null)
            {
                return HttpNotFound();
            }
            return View(model.listarAlunos());
        }

       
 
       

        //---------------------------------------

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
