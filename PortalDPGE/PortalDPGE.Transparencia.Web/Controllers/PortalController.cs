using PortalDPGE.Transparencia.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalDPGE.Transparencia.Web.Controllers
{
    public class PortalController : Controller
    {
        private readonly IPortalApiService _service;

        public PortalController(IPortalApiService service)
        {
            _service = service;
        }

        // GET: Portal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detalhar(string areaOuSecao, string alias)
        {            
            if (string.IsNullOrEmpty(alias) && string.IsNullOrEmpty(areaOuSecao)) return RedirectToAction("Index");


            _service.ObterPorAlias(areaOuSecao, alias);

            return View();
        }
    }
}