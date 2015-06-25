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
            PessoasRepository.conect();
            return View();
        }

       

        public ActionResult CadastrarPessoa (FormCollection form)
        {
            PessoasRepository pessoasRepo = new PessoasRepository();
            Pessoas pessoas = new Pessoas();

            pessoas.cpf = (string)form["CPFCadastrar"];
            pessoas.cpf = pessoas.cpf.Replace(".", "");
            pessoas.cpf = pessoas.cpf.Replace("-", "");
            pessoas.nome = (string)form["NomeCadastrar"];
            pessoas.telefone = (string)form["TelCadastras"];
            pessoas.email = (string)form["EmailCadastrar"];

            if (pessoasRepo.Create(pessoas) == true)
            {
                @ViewBag.resposta = true;
            }
            else
            {
                @ViewBag.resposta = false;
            }
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public ActionResult LoginAdm (FormCollection form)
       {
           
            Adms adm = new Adms(); //???
            AdmRepository admRepo = new AdmRepository();


           
            adm.cpf = (string)form["CpfAdm"];
            adm.senha = (string)form["SenhaAdm"];
            adm.cpf = adm.cpf.Replace(".", "");
            adm.cpf = adm.cpf.Replace("-", "");
            
            if (AdmRepository.Login(adm.cpf, adm.senha) == true)
            {
                var pessoa = PessoasRepository.GetAll();
                
                return View(pessoa);
                 

            }
            else 
            {
                return Redirect("index");
            }

          
          
        }
        [HttpPost]
        public ActionResult ListaEventos (FormCollection form)
        {

            PessoasRepository pessoasRepo = new PessoasRepository();
            Pessoas pessoas = new Pessoas();
           var cpf = (string)form["CpfLogin"];
            if (cpf == null)
            {
                var a = PessoasRepository.GetAll();
                return View(a);
                //View Usuario comum
            }
            else {
                pessoas.cpf = (string)form["CpfLogin"];
                pessoas.cpf = pessoas.cpf.Replace(".", "");
                pessoas.cpf =pessoas.cpf.Replace("-", "");
                Pessoas pessoasR = new Pessoas();
                pessoasR = PessoasRepository.GetOne(pessoas.cpf);
                ViewBag.nome = pessoasR.nome;
                ViewBag.idPessoa = pessoasR.id;
                var a = EventosRepository.GetAll();
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

        [HttpGet]
        public ActionResult DetailEvent (int id)
        {
            
           var a = EventosRepository.GetOne(id);
           return View(a);
        }



        [HttpGet]
        public ActionResult DeletePessoa(int id)
        {
            PessoasRepository pessoasRepo = new PessoasRepository();
            pessoasRepo.Delete(id);
            return RedirectToAction("ListaEventos");
        }

        [HttpGet]
        public ActionResult CreateAdm ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdm(Adms adm)
        {
            AdmRepository ad = new AdmRepository();
            ad.Create(adm);
            return RedirectToAction("LoginAdm");
        }
        [HttpGet]
        public ActionResult SubEvento(int id)
        {
            InscricoesRepository subsRepo = new InscricoesRepository();
            return null;
        }
        
    }
}