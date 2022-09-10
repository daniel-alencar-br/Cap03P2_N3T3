using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// acesso aos modelos
using Cap03P2_N3T3.Models;
// faz consultas LINQ
using System.Linq.Expressions;    

namespace Cap03P2_N3T3.Controllers
{
    public class AlunosController : Controller
    {
        public List<Models.Alunos> BD()
        {
            List<Models.Alunos> Lista = new List<Alunos>();

            Lista.Add(new Alunos() { ID = 1, Nome = "Joao", CPF = "12345" });
            Lista.Add(new Alunos() { ID = 2, Nome = "Maria", CPF = "4343" });
            Lista.Add(new Alunos() { ID = 3, Nome = "Sandra", CPF = "657567" });
            Lista.Add(new Alunos() { ID = 4, Nome = "Gabriel", CPF = "12323" });
            Lista.Add(new Alunos() { ID = 5, Nome = "Marlene", CPF = "23456" });
            Lista.Add(new Alunos() { ID = 6, Nome = "Carla", CPF = "23578" });
            Lista.Add(new Alunos() { ID = 7, Nome = "Ezequiel", CPF = "4567" });

            return Lista;
        }

        public Models.Alunos PesquisaAluno(int Codigo)
        {
            var item = from Aluno in BD()
                       where Aluno.ID == Codigo
                       select new { id = Aluno.ID, Nome = Aluno.Nome };

            Models.Alunos Resultado = new Alunos();

            foreach (var Ler in item)
            {
                Resultado.ID = Ler.id;
                Resultado.Nome = Ler.Nome;
            }

            return Resultado;
        }
        
        // site.com.br/alunos/trazeraluno/1

        [HttpGet]
        public ActionResult TrazerAluno(int id)
        {
            // View Tipada = View Vinculada a uma Entidade
            return View(PesquisaAluno(id));
        }

        [HttpGet]
        public ActionResult IncluirAluno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirAluno(FormCollection Form)
        {
            var Cod = Convert.ToInt32(Form["id"]);
            var Nome = Form["nome"].ToString();

            Models.Alunos Novo = new Alunos();
            Novo.ID = Cod;
            Novo.Nome = Nome;

            return View("VerAluno", Novo);
        }

        [HttpGet]
        public ActionResult IncluirAlunoFTipado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirAlunoFTipado(Alunos Aluno)
        {
            // Valida os dados conforme as DataAnnotations
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Validar CPF

            // Ir ao Banco

            return View("VerAluno", Aluno);
        }
    }
}














