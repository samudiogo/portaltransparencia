using Global.Dom.Entidade.PortalDPGE;
using Global.Dom.Util;
using Global.Dom.Validacao;
using Newtonsoft.Json;
using PortalDPGE.Dados.Persistencia;
using PortalDPGE.Dom.Regras;
using PortalDPGE.Dom.Util;
using PortalDPGE.Restrito.Web;
using PortalDPGE.Restrito.Web.Models;
using PortalDPGE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Transparencia.Web.Controllers
{
    [RoutePrefix("gastos-com-pessoal")]
    public class GastosComPessoalController : Controller
    {
        [Route("relatorio-mensal-de-remuneracao")]
        public ActionResult RelatorioMensalDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Relatório Mensal de Remuneração");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("auxilio-alimentacao-refeicao")]
        public ActionResult AuxiolioAlimentacaoDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Auxílio Alimentação");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("auxilio-saude")]
        public ActionResult AuxilioSaudeDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Auxílio Saúde");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("auxilio-transporte-servidores")]
        public ActionResult AuxilioTransporteServidoresDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Auxílio Transporte - Servidores");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        //[Route("gratificacao-por-acumulacao")]
        //public ActionResult GratificacaoPorAcumulacaoDocumentos()
        //{
        //    var model = new DocumentoModel();
        //    model.Documentos = DocumentosPorTipo("Gratificação por Acumulação");
        //    model.Link = DicionarioPortalDPGE.uploadsArquivos;

        //    return View("PastaDocumentos", model);
        //}
        [Route("estagiarios")]
        public ActionResult EstagiariosDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Estagiários");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("residentes-juridicos")]
        public ActionResult ResidentesJuridicosDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Residentes Jurídicos");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }

        protected static TipoDocumento DocumentosPorTipo(string NomeTipo)
        {
            var regras = new TipoDocumentoRegras { Servico = new TipoDocumentoDados() };
            return regras.MontaHierarquiaTipoTransparencia(regras.ObterPorNomeIgualSemPai(NomeTipo)).FirstOrDefault();
        }

        #region Consulta a Remuneração
        [HttpGet]
        [Route("consulta-remuneracao")]
        public ActionResult ConsultaPessoa()
        {
            return View("ConsultaPessoa");
        }

        [HttpPost]
        [ActionName("consulta-remuneracao")]
        public ActionResult ConsultaPessoa(
            [Bind(Include = "NomeOrCpf, g-recaptcha-response,GRecaptchaResponse")] RemuneracaoConsultaViewModel model)
        {

            if (Global.Dom.Util.ModoSite.Producao == Global.Dom.Util.Itario.AmbienteSite())
            {
                var gRecaptchaResponse = Request["g-recaptcha-response"];
                const string googleSecret = "6LdqaRUUAAAAAP899-b-Dayep2eAzF5LSLN_5DTi";

                if (!gRecaptchaResponse.Any())
                {
                    ModelState.AddModelError("GRecaptchaResponse", @"Valide o reCAPTCHA primeiro.");
                    return View("ConsultaPessoa", model);
                }
            }
            if (!ModelState.IsValid)
            {
                return View("ConsultaPessoa", model);
            }
            model.NomeOrCpf = model.NomeOrCpf.RemoveAcentos();
            model.NomeOrCpf = Regex.Replace(model.NomeOrCpf, @"[/./-]", "", RegexOptions.IgnoreCase);


            long possivelCpf;
            if (long.TryParse(model.NomeOrCpf, out possivelCpf))
                if (!ValidaCPF.IsCpf(model.NomeOrCpf))
                {
                    ModelState.AddModelError("GRecaptchaResponse", @"Recaptcha inválido.");
                    ModelState.AddModelError("NomeOrCpf", @"CPF inválido.");
                    return View("ConsultaPessoa", model);
                }


            var reply = JsonConvert.SerializeObject(new CaptchaResponseModel { Success = true });//string.Empty;

            //try
            //{
            //    reply =
            //        new WebClient().DownloadString(
            //            string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
            //                googleSecret, gRecaptchaResponse));
            //}
            //catch (WebException webEx)
            //{
            //    if (webEx.Status == WebExceptionStatus.NameResolutionFailure)
            //        reply = JsonConvert.SerializeObject(new CaptchaResponseModel { Success = true });
            //}
            //catch (Exception)
            //{
            //    reply = JsonConvert.SerializeObject(new CaptchaResponseModel { Success = true });
            //}


            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponseModel>(reply);
            if (!captchaResponse.Success)
            {
                ModelState.AddModelError("GRecaptchaResponse", @"ReCaptcha inválido ou expirado. Recarregue a página e tente novamente");
                return View("ConsultaPessoa", model);
            }
            var modelList = new RemuneracaoServidorRegras { Servico = new RemuneracaoServidorDados() }.ListaPorNomeCpfCompetencia(model.NomeOrCpf).OrderBy(r => r.Nome);

            var lista = new List<RemuneracaoViewModel>();  ///  AutoMapperConfig.Mapper.Map<IEnumerable<RemuneracaoViewModel>>(modelList);

            foreach (var item in modelList)
            {
                RemuneracaoViewModel data = new RemuneracaoViewModel()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Cpf = item.Cpf,
                    TipoVinculo = item.TipoVinculo,
                    Cargo = item.Cargo,
                    RemuneracaoMensal = item.RemuneracaoMensal,
                    RemuneracaoEventual = item.RemuneracaoEventual,
                    TotalDescontos = item.TotalDescontos,
                    LimiteRemuneratorio = item.LimiteRemuneratorio,
                    TotalLiquido = item.TotalLiquido,
                    Competencia = item.Competencia
                };
                lista.Add(data);
            }

            return View("ResultadoConsultaPessoa", lista);
        }


        [HttpGet]
        public ActionResult DetalheRemuneracao(int id)
        {
            var remuneracaoRegras = new RemuneracaoServidorRegras { Servico = new RemuneracaoServidorDados() };
            //var model =
            //    AutoMapperConfig.Mapper.Map<RemuneracaoViewModel>(
            //        remuneracaoRegras.ObterPorId(id));
            var item = remuneracaoRegras.ObterPorId(id);
            var model = new RemuneracaoViewModel()
            {
                Id = item.Id,
                Nome = item.Nome,
                Cpf = item.Cpf,
                TipoVinculo = item.TipoVinculo,
                Cargo = item.Cargo,
                RemuneracaoMensal = item.RemuneracaoMensal,
                RemuneracaoEventual = item.RemuneracaoEventual,
                TotalDescontos = item.TotalDescontos,
                LimiteRemuneratorio = item.LimiteRemuneratorio,
                TotalLiquido = item.TotalLiquido,
                Competencia = item.Competencia
            };

            if (model == null)
                return RedirectToAction("consulta-remuneracao");

            TempData["Cpf"] = model.Cpf;
            var listaCompetencia = new List<SelectListItem>();

            var modelLista = remuneracaoRegras.ListaCompetenciaCpf(model.Cpf);

            var comp = new DateTime(model.Competencia.Year, model.Competencia.Month, model.Competencia.Day);

            listaCompetencia = modelLista.Select(c => new SelectListItem { Value = c.ToString("d"), Text = c.ToString("MMMM/yyyy"), Selected = c.Equals(comp) }).ToList();

            var sb = new StringBuilder();
            sb.AppendFormat("<h3>Competencia: {0:d}</h3>", comp);
            foreach (var x in listaCompetencia)
                sb.AppendFormat("<h4>{0} - {1}</h5>", x.Value, x.Selected);
            ViewBag.Statues = sb.ToString();
            ViewBag.ListaCompetencia = listaCompetencia;
            return View(model);
        }

        [HttpPost]
        public ActionResult _DetalheMensalRemuneracao([Bind(Include = "competenciaData")] DateTime? competenciaData)
        {
            var cpf = TempData["Cpf"].ToString();
            if (string.IsNullOrEmpty(cpf) || !competenciaData.HasValue || competenciaData.Value <= new DateTime(1, 1, 1))
                return RedirectToAction("consulta-remuneracao");

            var remuneracaoRegras = new RemuneracaoServidorRegras { Servico = new RemuneracaoServidorDados() };

            var dbModel = remuneracaoRegras.ObterPorCpfCompetencia(cpf, competenciaData.Value);

            //var model = AutoMapperConfig.Mapper.Map<RemuneracaoViewModel>(dbModel);
            var item = dbModel;
            var model = new RemuneracaoViewModel()
            {
                Id = item.Id,
                Nome = item.Nome,
                Cpf = item.Cpf,
                TipoVinculo = item.TipoVinculo,
                Cargo = item.Cargo,
                RemuneracaoMensal = item.RemuneracaoMensal,
                RemuneracaoEventual = item.RemuneracaoEventual,
                TotalDescontos = item.TotalDescontos,
                LimiteRemuneratorio = item.LimiteRemuneratorio,
                TotalLiquido = item.TotalLiquido,
                Competencia = item.Competencia
            };


            TempData.Keep("Cpf");

            return PartialView(model);
        }
        #endregion
    }
}