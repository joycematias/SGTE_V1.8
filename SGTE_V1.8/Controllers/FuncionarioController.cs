using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using System.Text;
using System.Data.SqlClient;
using SGTE_V1._8.Models;
namespace SGTE_V1._8.Controllers
{
    public class FuncionarioController : Controller
    {
        private SGTE2Entities db = new SGTE2Entities();
        SqlConnection funcionarioConexao = new SqlConnection("Data Source=KIDS\\SQLEXPRESS;Initial Catalog=SGTE2;User ID=sa;Password=123");

        
        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
            
        }

        public ActionResult List()
        {
           
            return View(db.Tbl_Funcionario.ToList());
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Funcionario tbl_Funcionario = db.Tbl_Funcionario.Find(id);
            if (tbl_Funcionario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Funcionario);
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Funcao,Matricula,Nome,Endereco,Bairro,Cidade,CEP,Estado,Tel_Residencial,Tel_Celular,Email,RG,CPF,Data_Nasc,Sexo,Ativo")] Tbl_Funcionario tbl_Funcionario)
        {

            if (ModelState.IsValid)
            {
                
                funcionarioConexao.Open();
               
                string strQueryInsertFuncionario = @"INSERT INTO Tbl_Funcionario(Funcao,Matricula,Nome,Endereco,Bairro,Cidade,CEP,Estado,Tel_Residencial,Tel_Celular,Email,RG,CPF,Data_Nasc,Sexo)
                                         VALUES(" + "'" + tbl_Funcionario.Funcao + "'" + "," + tbl_Funcionario.Matricula +  "," + "'" + tbl_Funcionario.Nome + "'" + "," + "'" + tbl_Funcionario.Endereco + "'" + "," +
                                           "'" + tbl_Funcionario.Bairro + "'" + "," + "'" + tbl_Funcionario.Cidade + "'" + "," + "'" + tbl_Funcionario.CEP + "'" + "," + "'" + tbl_Funcionario.Estado + "'" + "," + "'" + tbl_Funcionario.Tel_Residencial + "'" + ","
                                            + "'" + tbl_Funcionario.Tel_Celular + "'" + "," + "'" + tbl_Funcionario.Email + "'" + "," + "'" + tbl_Funcionario.RG + "'" + "," + "'" + tbl_Funcionario.CPF + "'" + "," + "'" + tbl_Funcionario.Data_Nasc + "'" + "," + "'" + tbl_Funcionario.Sexo + "'" + ");" +
                                                "INSERT INTO Tbl_Login(Login,Senha,Nivel_Acesso) VALUES(" + "'" + tbl_Funcionario.Email + "'" + "," + "'" + tbl_Funcionario.Matricula + "'" + "," + "1);";
                SqlCommand cmdComandoInsertFuncionario = new SqlCommand(strQueryInsertFuncionario, funcionarioConexao);
                cmdComandoInsertFuncionario.ExecuteNonQuery();




                //funcionarioConexao.Open();
                //string strQueryTeste = @"SET ID = (Select ID FROM Tbl_Funcionario WHERE" + tbl_Funcionario.Matricula + "=" + "'" + tbl_Funcionario.Matricula + "'" + ")";
               // SqlCommand cmdComandoTeste = new SqlCommand(strQueryTeste, funcionarioConexao);
                //cmdComandoTeste.ExecuteNonQuery();

               //string strQueryUpdate = @"INSERT INTO Tbl_Login (Login,Senha,Nivel_Acesso) VALUES(" + "'" + tbl_Funcionario.Email + "'" + ","+"'123'"+ "," +  "," + "1)";
               //SqlCommand cmdComandoUpdate = new SqlCommand(strQueryUpdate, funcionarioConexao);
               //cmdComandoUpdate.ExecuteNonQuery();
               //funcionarioConexao.Close();
                
                //db.Tbl_Funcionario.Add(tbl_Funcionario);                
               // db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Funcionario);
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Funcionario tbl_Funcionario = db.Tbl_Funcionario.Find(id);
            if (tbl_Funcionario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Funcao,Matricula,Nome,Endereco,Bairro,Cidade,CEP,Estado,Tel_Residencial,Tel_Celular,Email,RG,CPF,Data_Nasc,Sexo,Ativo")] Tbl_Funcionario tbl_Funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Funcionario);
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Funcionario tbl_Funcionario = db.Tbl_Funcionario.Find(id);
            if (tbl_Funcionario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            funcionarioConexao.Open();       
            string strQueryUpdate = @"UPDATE Tbl_Funcionario SET Ativo = 0 WHERE ID =" + id;
            SqlCommand cmdComandoUpdate = new SqlCommand(strQueryUpdate, funcionarioConexao);
            cmdComandoUpdate.ExecuteNonQuery();
            funcionarioConexao.Close();
          
            return RedirectToAction("Index");
            
        }

        public ActionResult Cadastros() {
            return View();
        }

        public ActionResult Relatorios()
        {
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
