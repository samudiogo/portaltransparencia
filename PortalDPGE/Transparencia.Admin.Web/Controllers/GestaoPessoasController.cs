using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Transparencia.Application.Contratos.DRH;
using Transparencia.Admin.Web.Utils;
using Transparencia.Application.FileHelperMappings;
using Transparencia.Application.ViewModels.DRH;

namespace Transparencia.Admin.Web.Controllers
{
    public class GestaoPessoasController : Controller
    {        
        private readonly IGestaoPessoasAdmAppService _servicoGestaoPessoasAdm;
        private readonly CultureInfo _cultureBr = new CultureInfo("pt-BR");

        private readonly IMapper _mapper;

        public GestaoPessoasController(IMapper mapper, IGestaoPessoasAdmAppService servicoGestaoPessoasAdm)
        {
            _mapper = mapper;
            _servicoGestaoPessoasAdm = servicoGestaoPessoasAdm;
        }

        // GET: GestaoPessoas
        public ActionResult Index()
        {
            //TODO: Implementar Botão de upload de arquivo CSV
            //TODO: Gerar no Mockaroo um CSV de exemplo para teste 100 registros
            return View();
        }
        [HttpGet]
        public ActionResult ImportaCsvEstagiarios()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ImportaCsvEstagiarios([Bind(Include = "arquivoUpload")] HttpPostedFileBase arquivoUpload)
        {
            var lista = await new CsvImportador<EstagiariosFileMap>().ImportaArquivoCsvAsync(arquivoUpload);

            if (lista == null) return RedirectToAction("ImportaCsvEstagiarios");

            _servicoGestaoPessoasAdm.SalvaListaEstagiarios(_mapper.Map<IEnumerable<EstagiariosViewModel>>(lista));

            return View();
        }

        [HttpGet]
        public ActionResult ImportaCsvResidentesJuridicos()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ImportaCsvResidentesJuridicos([Bind(Include = "arquivoUpload")] HttpPostedFileBase arquivoUpload)
        {
            var lista = await new CsvImportador<ResidentesJuridicosFileMap>().ImportaArquivoCsvAsync(arquivoUpload);

            if (lista == null) return RedirectToAction("ImportaCsvResidentesJuridicos");

            _servicoGestaoPessoasAdm.SalvaListaResidentesJuridicos(_mapper.Map<IEnumerable<ResidentesJuridicosViewModel>>(lista));

            return View();
        }


    }
}