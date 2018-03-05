using Global.Dados.Persistencia;
using Global.Dom.Regras;
using Global.Dom.Util;
using PortalDPGE.Dados.Persistencia.Transparência;
using PortalDPGE.Dados.Persistencia.Views;
using PortalDPGE.Dom.Regras.Views;
using PortalDPGE.Web.Models;
using RHDP.Dados.Persistencia;
using RHDP.Dom.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Transparencia.Web.Models;

namespace Transparencia.Web.Controllers
{


    /// <summary>
    /// todo: https://developerslogblog.wordpress.com/2016/12/30/adding-web-api-support-to-an-existing-asp-net-mvc-project/
    /// </summary>
    [RoutePrefix("api/gestaopessoas")]
    public class API_GestaoPessoasController : Controller
    {

        [HttpGet]
        [Route("quadrocargo/totais-quadro-servidores-ativos")]
        public ActionResult ObterTotaisQuadroAtivo()
        {

            var cc = new Global.Dados.Persistencia.RegistroFuncionalDados().TotalServidoresPorTipoRegistroFuncional();
            var model = new Dictionary<string, string>();
            foreach (var item in cc)
            {

                int tipo = (int)item["idTipoRegistroFuncional"];
                string chave = "";

                switch ((TipoRegistroFuncionalEnum)tipo)
                {
                    case TipoRegistroFuncionalEnum.ExtraQuadro:
                        chave = "EXTRA QUADRO";
                        break;
                    case TipoRegistroFuncionalEnum.Servidor:
                        chave = "ESTATUTÁRIO";
                        break;
                    case TipoRegistroFuncionalEnum.Cedido:
                        chave = "ESTATUTÁRIO CEDIDO";
                        break;
                    case TipoRegistroFuncionalEnum.Defensor:
                        chave = "DEFENSOR";
                        break;
                    case TipoRegistroFuncionalEnum.Terceirizado:
                    case TipoRegistroFuncionalEnum.Estagiario:
                    default:
                        continue;
                }

                string total = item["total"].ToString();
                model.Add(chave, total);
            }

            return Json(model, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        [Route("quadrocargo/{situacao}")]
        public ActionResult ObterQuadroCargos(string situacao)
        {


            //if (string.IsNullOrEmpty(situacao)) return BadRequest("Preencha todos os parâmetros");
            var trfs = new List<int> { (int)TipoRegistroFuncionalEnum.Defensor, (int)TipoRegistroFuncionalEnum.Cedido, (int)TipoRegistroFuncionalEnum.Servidor, (int)TipoRegistroFuncionalEnum.ExtraQuadro };
            RegistroFuncionalRegras rfRegras = new RegistroFuncionalRegras() { Servico = new Global.Dados.Persistencia.RegistroFuncionalDados() };
            List<ServidorAtivoViewModel> ret = new List<ServidorAtivoViewModel>();

            if (situacao.Equals("ativo", StringComparison.InvariantCultureIgnoreCase))
            {

                try
                {
                    var data = rfRegras.ListarServidoresPorStatusETipoRf((int)StatusRegistroFuncionalEnum.Ativo, trfs);

                    foreach (var item in data)
                    {
                        var dado = new ServidorAtivoViewModel(item);
                        ret.Add(dado);
                    }

                    return Json(ret, JsonRequestBehavior.AllowGet);

                }
                catch (Exception e)
                {

                    throw;
                }
            }
            else if (situacao.Equals("inativo", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {

                    var data = rfRegras.ListarServidoresPorStatusETipoRf((int)StatusRegistroFuncionalEnum.Aposentado, trfs);

                    foreach (var item in data)
                    {
                        var dado = new ServidorAtivoViewModel(item);
                        ret.Add(dado);
                    }

                    return Json(ret, JsonRequestBehavior.AllowGet);

                }
                catch (Exception e)
                {

                    throw;
                }
            }

            //if (situacao.Equals("inativo", StringComparison.InvariantCultureIgnoreCase))
            //    return Ok(await _service.ListaServidorQuadroInativoViewModelAsync());

            //return  BadRequest("Situação inválida: use ativo ou inativo");
            return null;
        }

        [HttpGet]
        [Route("antiguidade-servidores")]
        public ActionResult ObterListaAntiguidadeServidores()
        {
            var temp = new RegistroServidorDados().ListarServidoresPorAntiguidadeECargo();
            List<AntiguidadeServidoresViewModel> ret = new List<AntiguidadeServidoresViewModel>();

            foreach (var item in temp)
            {
                var data = new AntiguidadeServidoresViewModel(item);
                ret.Add(data);
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
            

        }

        [HttpGet]
        [Route("antiguidade-defensores-publicos")]
        public ActionResult ObterListaAntiguidadeDefensores()
        {
            var movDefensorDados = new MovimentacaoDefensorDados();

            var dLista = new MovimentacaoDefensorRegras { Servico = new MovimentacaoDefensorDados() }
                .ResultadoAntiguidadeDefensor(movDefensorDados);

            List<AntiguidadeDefensorViewModel> ret = new List<AntiguidadeDefensorViewModel>();

            foreach (var item in dLista)
            {
                var data = new AntiguidadeDefensorViewModel();

                data.SiglaCargo = item.SiglaCargo;
                data.NomeCargo = item.NomeCargo;
                data.Ordem = item.Ordem;
                data.NomeDefensor = item.NomeDefensor;
                data.PeriodoClasse = item.PeriodoClasse;
                data.PeriodoCarreira = item.PeriodoCarreira;
                data.PeriodoEstado = item.PeriodoEstado;
                data.PeriodoServicoPublico = item.PeriodoServicoPublico;
                data.PeriodoAposentacao = item.PeriodoAposentacao;

                ret.Add(data);
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        [Route("movimentacao-defensores-publicos")]
        public ActionResult ObterListaMovimentacaoDefensores()
        {
            //return Ok(await Task.Run(() => _serviceMovimentacaoDefensores.ListaMovimentacaoDefensores()));
            return null;

        }

        [HttpGet]
        [Route("quadro-cargos-vagos-e-ocupados")]
        public ActionResult ObterListaQuadroCargosVagosEOcupados()
        {
            var temp = new VagaRegras() { Servico = new VagaDados() }.ListarQuantidadeVagasPorCargo();

            List<APICargosVagosEOcupadosViewModel> ret = new List<APICargosVagosEOcupadosViewModel>();
            foreach (var item in temp.Data)
            {
                ret.Add(new APICargosVagosEOcupadosViewModel(item));
            }
            return Json(ret, JsonRequestBehavior.AllowGet);



        }



        #region Estagio
        [HttpGet]
        [Route("estagiarios")]
        public ActionResult ObterListaEstagiarios()
        {


            var listaEstagiarios = new List<EstagiariosViewModel>();
            var estDados = new EstagiariosDados();
            var dado = estDados.ListarTodos().ToList();
            dado.AsParallel().ForAll(e => e.CPF = e.CPF.MascaraCpf());

            foreach (var item in dado)
            {
                var data = new EstagiariosViewModel() { };

                Itario.DePara(item, data);

                listaEstagiarios.Add(data);
            }
            return Json(listaEstagiarios, JsonRequestBehavior.AllowGet);
            //return null;
        }


        [HttpGet]
        [Route("residentes-juridicos")]
        public ActionResult ObterListaResidentesJuridicos()
        {


            var listaResidentesJuridicos = new List<ResidentesJuridicosViewModel>();

            var estDados = new ResidentesJuridicosDados();
            var dado = estDados.ListarTodos().ToList();
            dado.AsParallel().ForAll(e => e.CPF = e.CPF.MascaraCpf());

            foreach (var item in dado)
            {
                var data = new ResidentesJuridicosViewModel() { };

                Itario.DePara(item, data);

                listaResidentesJuridicos.Add(data);
            }
            return Json(listaResidentesJuridicos, JsonRequestBehavior.AllowGet);


        }
        #endregion

    }
}
