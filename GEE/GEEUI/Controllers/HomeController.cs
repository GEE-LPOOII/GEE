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
            Adms adm = new Adms();
            AdmRepository admRepo = new AdmRepository();
           
            adm.cpf = (string)form["CpfAdm"];
            adm.senha = (string)form["SenhaAdm"];
            adm.cpf = adm.cpf.Replace(".", "");
            adm.cpf = adm.cpf.Replace("-", "");
            
            if (AdmRepository.Login(adm.cpf, adm.senha) == true)
            {

                HttpCookie myCookie = new HttpCookie("login_info");
                myCookie["cpf_adm"] = adm.cpf;
                myCookie["nome_adm"] = adm.nome;

                myCookie.Expires = DateTime.Now.AddDays(1d);
                HttpContext.Response.Cookies.Add(myCookie);
                
                return View("LoginAdm");
            }
            else 
            {
                return Redirect("index");
            }        
        }

        [HttpGet]
        public ActionResult LoginAdm()
        {
            if (Request.Cookies["login_info"] != null)
            {
                if (Request.Cookies["login_info"]["cpf_adm"] != null)
                {
                    ViewBag.IdAdm = Request.Cookies["login_info"]["cpf_adm"];
                }

                if (Request.Cookies["login_info"]["nome_adm"] != null)
                {
                    ViewBag.IdAdm = Request.Cookies["login_info"]["nome_usuario"];
                }

                var eventos = EventosRepository.GetAll();
                return View(eventos);
            }
            else
            {
                return RedirectToAction("Index");
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
            //GetSubA();
            ViewBag.listaSubA = GetSubA();
           
            return View();
        }

       
        
        [HttpPost]
        public ActionResult CreateEvento(FormCollection form)
        {
            //Aquii indaia
            Eventos eventos = new Eventos();
            EventosRepository eventosRepo = new EventosRepository();
            ViewBag.select = int.Parse(form["listaSubA"]); //Aqui ta a informação selecionado do Dropdown

            eventos.nome = (string)form["NomeEvento"];
            eventos.cidade = (string)form["CidadeEvento"];
            eventos.data = DateTime.Parse(form["DataEvento"]);
            eventos.qtd_horas = Int32.Parse(form["Qtd_horasEvento"]);
            eventos.descricao = (string)form["DescEvento"];
            eventos.id_subarea = ViewBag.select; // aqui diz que nao consegue converter de int para subarea
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
        public ActionResult SubEvento(int idEvento, int idPessoa)
        {
            InscricoesRepository subsRepo = new InscricoesRepository();
            subsRepo.Create(idPessoa, idEvento);
            return Redirect("ListaEventos");
        }

        public SelectList GetSubA() 
        {
            List<Subareas> sub = SubareasRepository.GetAll();
            return new SelectList(sub, "id", "nome");
        }
        
    }
}