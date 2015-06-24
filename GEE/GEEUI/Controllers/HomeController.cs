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
           
            Adms adm = new Adms(); //???


           
            adm.cpf = (string)form["CpfAdm"];
            adm.senha = (string)form["SenhaAdm"];

            adm.cpf.Replace(".", "");
            adm.senha.Replace("-", "");

            if (adm.cpf.Equals("01245678912") && adm.senha.Equals("12345")) 
            {
                // página inicial do adm - menus: listar eventos para aprovação, listar inscrições pendentes...
                return View(); 
            }
            else 
            {
               return RedirectToAction("Index");
            }
          
        }
        public ActionResult ListaEventos (FormCollection form)
        {

            PessoasRepository pessoasRepo = new PessoasRepository();
            Pessoas pessoas = new Pessoas();

            if (form["CpfLogin"].ToString() == null)
            {
                var a = PessoasRepository.GetAll();
                return View(a);
                //View Usuario comum
            }
            else {
                pessoas.cpf = (string)form["CpfLogin"];
                Pessoas pessoasR = new Pessoas();
                pessoasR = PessoasRepository.GetOne(pessoas.cpf);
                ViewBag.nome = pessoasR.nome;
                var a = PessoasRepository.GetAll();
                return View(a);
                //View Usuario comum
            }
           


        }
        [HttpGet]
        public ActionResult CreateEvento()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CreateEvento(FormCollection form)
        {
            Eventos eventos = new Eventos();
            EventosRepository eventosRepo = new EventosRepository();

            eventos.nome = (string)form["NomeEvento"];
            eventos.cidade = (string)form["CidadeEvento"];
            eventos.data = DateTime.Parse(form["DataEvento"]);
            eventos.qtd_horas = Int32.Parse(form["Qtd_horasEvento"]);
            eventos.descricao = (string)form["DescEvento"];

            eventosRepo.Create(eventos);

            return RedirectToAction("ListaEventos");
        }
        [HttpPost]
        public ActionResult DetailEvent (int idEvento)
        {
            
           var a = EventosRepository.GetOne(idEvento);
           return View(a);
        }
        
    }
}