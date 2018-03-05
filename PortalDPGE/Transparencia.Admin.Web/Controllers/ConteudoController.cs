using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Global.App.Util;
using Global.Dom.Entidade.PortalDPGE;
using Global.Dom.Util;
using PortalDPGE.Dados.Persistencia;
using PortalDPGE.Dom.Regras;
using Transparencia.Application.ViewModels.Portal;

namespace Transparencia.Admin.Web.Controllers
{
    public class ConteudoController : Controller
    {
        private const int PortalId = (int)PortalRegras.Portais.Transparencia;

        private const int TipoConteudoGeral = 1;//tipo de conteudo tipico para acesso geral e irrestrito

        private readonly IMapper _mapper;

        public ConteudoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: Conteudo
        public ActionResult Index()
        {
            var dbList = new ConteudoRegras { Servico = new ConteudoDados() }.ListarPorTipoEPortal(new TipoConteudo { Id = TipoConteudoGeral }, PortalId);

            return View(_mapper.Map<IEnumerable<ConteudoConsultaViewModel>>(dbList));
        }
        [HttpGet]
        public ActionResult Cadastrar()
        {
            var usuario = Sistema.ObterUsuarioDaSessao(HttpContext);
            return View(new ConteudoCadastroViewModel(usuario.Login));
        }
        [HttpPost]
        public ActionResult Cadastrar([Bind(Include = "Id,Alias,Titulo,ConteudoHtml,SecaoId")]ConteudoCadastroViewModel model)
        {
            var usuario = Sistema.ObterUsuarioDaSessao(HttpContext);
            model.Login = usuario.Login;

            if (!ModelState.IsValid) return View(model);

            try
            {
                //crio a instancia que será pesistida no banco
                var dbModel = new Conteudo().CopiarEstado(model) as Conteudo;

                if (dbModel == null) return RedirectToAction("Index");

                //crio um tipo de secao que não pode ser copiada via método CopiarEstado
                dbModel.SecaoConteudo = new SecaoConteudo { Id = model.SecaoId };

                dbModel.TipoConteudo = new TipoConteudo { Id = TipoConteudoGeral };

                dbModel.Portal = new Portal { Id = PortalId };

                new ConteudoRegras { Servico = new ConteudoDados() }
                    .CadastrarConteudo(dbModel, usuario);

                TempData["mensagem"] = "Cadastro realizado com sucesso";

                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["mensagem"] = "Não foi possível cadastrar: " + e.Message;
                TempData["mensagemTipo"] = "erro";
                return View("Cadastrar", model);
            }
        }

        // GET: Conteudo/Edit/5
        public ActionResult Alterar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var usuario = Sistema.ObterUsuarioDaSessao(HttpContext);
            var conteudoRegras = new ConteudoRegras { Servico = new ConteudoDados() };

            var dbModel = conteudoRegras.Servico.ObterPorIdCompleto((int)id);
            var model = new ConteudoAlteraViewModel().CopiarEstado(dbModel) as ConteudoAlteraViewModel;// safe cast
            if (model == null) return HttpNotFound();

            model.Login = usuario.Login;

            return View(model);
        }

        // POST: Conteudo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar([Bind(Include = "Id,Alias,Titulo,ConteudoHtml")] ConteudoAlteraViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var conteudoRegras = new ConteudoRegras { Servico = new ConteudoDados() };
                var dbModel = conteudoRegras.Servico.ObterPorId(model.Id);

                var usuario = Sistema.ObterUsuarioDaSessao(HttpContext);
                model.Login = usuario.Login;

                if (dbModel == null) return HttpNotFound("Conteúdo não encontrado");

                var conteudo = new Conteudo().CopiarEstado(model) as Conteudo;

                if (conteudo == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "não foi possível alterar este conteúdo.");

                conteudo.SecaoConteudo = dbModel.SecaoConteudo;

                conteudo.TipoConteudo = new TipoConteudo { Id = TipoConteudoGeral };

                conteudo.Portal = new Portal { Id = PortalId };


                conteudoRegras.AlterarConteudo(conteudo, usuario);

                TempData["mensagem"] = "Alteração realizada com sucesso";

                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {

                TempData["mensagem"] = "Não foi possível alterar: " + e.Message;
                TempData["mensagemTipo"] = "erro";
                return RedirectToAction("Alterar", model.Id);
            }
        }


        // POST: Conteudo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id)
        {
            try
            {
                var cRegras = new ConteudoRegras { Servico = new ConteudoDados() };
                var conteudo = cRegras.ObterPorId(id);
                if (conteudo == null)
                    return HttpNotFound("Conteudo não encontrado");

                var usuario = Sistema.ObterUsuarioDaSessao(HttpContext);
                cRegras.ExcluirConteudo(conteudo, usuario);
                TempData["mensagem"] = "Conteúdo excluído com sucesso.";
            }
            catch (System.Exception e)
            {
                TempData["mensagem"] = "Não foi possível excluir: " + e.Message;
                TempData["mensagemTipo"] = "erro";
            }
            return RedirectToAction("Index");
        }
    }
}