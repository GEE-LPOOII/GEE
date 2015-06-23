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

        public ActionResult CadastrarPessoa (FormCollection form)
        {
            PessoasRepository pessoasRepo = new PessoasRepository();
            Pessoas pessoas = new Pessoas();

            pessoas.nome = (string)form["NomeCadastrar"];
            pessoas.telefone = (string)form["TelCadastras"];
            pessoas.email = (string)form["EmailCadastrar"];
            pessoas.cpf = (string)form["CPFCadastrar"];

            if (pessoasRepo.Create(pessoas) == true)
            {
                @ViewBag.resposta = true;
            }
            else
            {
                @ViewBag.resposta = false;
            }
            return null;
            
        }
        [HttpPost]
        public ActionResult LoginAdm (FormCollection form)
       {
           
            Adms adm = new Adms();


           
            adm.cpf = (string)form["CpfAdm"];
            adm.senha = (string)form["SenhaAdm"];

            if (adm.cpf.Equals("01245678912") && adm.senha.Equals("12345")) 
            {

                return View();
            }
            else 
            {
               return RedirectToAction("index");
            }
          
        }
        public ActionResult ListaEventos (FormCollection form)
        {

            PessoasRepository pessoasRepo = new PessoasRepository();
            Pessoas pessoas = new Pessoas();

            pessoas.cpf = (string)form["CpfLogin"];
            Pessoas pessoasR = new Pessoas();
            pessoasR = PessoasRepository.GetOne(pessoas.cpf);
            ViewBag.nome = pessoasR.nome;
            var a = PessoasRepository.GetAll();
            return View(a);


        }
        [HttpPost]
        public ActionResult Inscrever(int idEvento)
        {
            return null;
        }
        [HttpPost]
        public ActionResult DetailEvent (int idEvento)
        {
            
            EventosRepository.GetOne(idEvento);
            return null;
        }
        
    }
}