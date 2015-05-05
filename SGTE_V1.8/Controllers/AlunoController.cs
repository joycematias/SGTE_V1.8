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
    public class AlunoController : Controller
    {
        private SGTE2Entities db = new SGTE2Entities();
        SqlConnection alunoConexao = new SqlConnection("Data Source=KIDS\\SQLEXPRESS;Initial Catalog=SGTE2;User ID=sa;Password=123");
        // GET: Aluno
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult List()
        {
            var tbl_Aluno = db.Tbl_Aluno.Include(t => t.Tbl_Cliente).Include(t => t.Tbl_Escola).Include(t => t.Tbl_Veiculo);
            return View(tbl_Aluno.ToList());
        }

        // GET: Aluno/Details/5
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

        // GET: Aluno/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_ID = new SelectList(db.Tbl_Cliente, "ID", "Nome");
            ViewBag.Escola_ID = new SelectList(db.Tbl_Escola, "ID", "Nome");
            ViewBag.Veiculo_ID = new SelectList(db.Tbl_Veiculo, "ID", "Placa");
            return View();
        }

        // POST: Aluno/Create
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

        // GET: Aluno/Edit/5
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

        // POST: Aluno/Edit/5
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

        // GET: Aluno/Delete/5
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

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Aluno tbl_Aluno = db.Tbl_Aluno.Find(id);
            db.Tbl_Aluno.Remove(tbl_Aluno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET LIstaAluno
       //----------------

        public ActionResult ListaAlunos(int? id)
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
        public ActionResult ListaAlunos(int id)
        {
            Tbl_Veiculo tbl_Veiculo = db.Tbl_Veiculo.Find(id);
            alunoConexao.Open();
            string strQuerySelect = @"SELECT Nome,RG,Escola,Cidade,Bairro,CEP,Estado,Endereco_1,Endereco_2 FROM Tbl_Aluno WHERE Veiculo_ID = " + tbl_Veiculo.ID;
            SqlCommand cmdComandoSelect = new SqlCommand(strQuerySelect, alunoConexao);
            cmdComandoSelect.ExecuteNonQuery();


            // var tbl_Aluno = db.Tbl_Aluno.Include(t => t.Tbl_Cliente).Include(t => t.Tbl_Escola).Include(t => t.Tbl_Veiculo);

            return View(strQuerySelect.ToList());
        }



        //--------------- Aluno av=c
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
