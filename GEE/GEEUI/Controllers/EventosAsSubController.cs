using GEERepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GEEUI.Controllers
{
    public class EventosAsSubController : Controller
    {
        // GET: EventosAsSub
        public ActionResult Index()
        {
            
           var a = InscricoesRepository.GetIsncricoesPendentes();
            

            return View(a);
        }
    }
}