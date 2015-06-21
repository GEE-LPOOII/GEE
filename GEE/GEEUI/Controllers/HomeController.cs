using GEEData;
using GEERepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace GEEUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult CadastrarPessoa (FormCollection form)
        {
            PessoasRepository pessoasRepo = new PessoasRepository();
            Pessoas pessoas = new Pessoas();

            pessoas.nome = (string)form["NomeCadastrar"];
            pessoas.telefone = (string)form["TelCadastras"];
            pessoas.email = (string)form["EmailCadastrar"];
            pessoas.cpf = (string)form["CPFCadastrar"];

            pessoasRepo.Create(pessoas);
            ViewBag.resposta = true;
            return null;           
            
        }
        [HttpPost]
        public ActionResult LoginAdm (FormCollection form)
        {
            
        }
    }
}