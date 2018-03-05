using System.Web.Mvc;
using Global.Dom.Entidade.PortalDPGE;
using System.IO;
using System.Collections.Generic;
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Transparencia.Web.HtmlHelpers
{

    public static class Helpers
    {
        public static uint count;
        /// <summary>
        /// monta documento para transparencia
        /// </summary>
        /// <param name="html">default de expansão</param>
        /// <param name="model">tipo de documento</param>
        /// <param name="link">colocar rota do documento no servidor</param>
        /// <param name="n">número da pasta de documento que virá aberta</param>
        /// <returns></returns>
        public static MvcHtmlString MontaPastaDocumentoTrans(this HtmlHelper html, TipoDocumento model, string link, uint n)
        {
            count = n;
            var texto = "";
            if (count == 0)
            {
                texto = string.Format(@"
            <div class=""panel-group"" id=""accordion{1}"" role=""tablist"" aria-multiselectable=""true"">
                <div class=""panel panel-default"">
                    <div class=""panel-body"" role=""tab"" id=""heading{1}"">
                        <h4 class=""panel-title green-title"">
                        <a role=""button"" data-toggle=""collapse"" data-parent=""#accordion"" aria-expanded=""true"" aria-controls=""collapseOne"">{0}</a>
                        </h4>
                    </div>
                <div id=""Tipo{1}"" class=""panel-collapse collapse in"" role=""tabpanel"" aria-labelledby=""headingOne"">
                    <div class=""panel-body"">",
             new[] { model.Nome, model.Id.ToString() });
            }
            else if (count < 2)
            {
                texto = string.Format(@"
            <div class=""panel-group"" id=""accordion{1}"" role=""tablist"" aria-multiselectable=""true"">
                <div class=""panel panel-default"">
                    <div class=""panel-heading"" role=""tab"" id=""heading{1}"">
                        <h4 class=""panel-title"">
                        <a role=""button"" data-toggle=""collapse"" data-parent=""#accordion"" href=""#Tipo{1}"" aria-expanded=""true"" aria-controls=""collapseOne"">{0}</a>
                        </h4>
                    </div>
                <div id=""Tipo{1}"" class=""panel-collapse collapse in"" role=""tabpanel"" aria-labelledby=""headingOne"">
                    <div class=""panel-body"">",
                new[] { model.Nome, model.Id.ToString() });
            }
            else
            {
                texto = string.Format(@"
            <div class=""panel-group"" id=""accordion{1}"" role=""tablist"" aria-multiselectable=""true"">
                <div class=""panel panel-default"">
                    <div class=""panel-heading"" role=""tab"" id=""heading{1}"">
                        <h4 class=""panel-title"">
                        <a role=""button"" data-toggle=""collapse"" data-parent=""#accordion"" href=""#Tipo{1}"" aria-expanded=""true"" aria-controls=""collapseOne"">{0}</a>
                        </h4>
                    </div>
                <div id=""Tipo{1}"" class=""panel-collapse collapse"" role=""tabpanel"" aria-labelledby=""headingOne"">
                    <div class=""panel-body"">",
            new[] { model.Nome, model.Id.ToString() });
            }

            foreach (var doc in model.ListaDocumentos)
            {
                var extensao = Path.GetExtension(link + doc.Arquivo.NomeServidor).Substring(1);

                texto += string.Format(@"
                <div class=""col-sm-4 margin-boton30 row"">
                    <h5>{0}</h5>
                    <a class=""btn btn-outline-primary btn btn-primary btn-sm text-uppercase"" href=""{2}"" target=""new"">VER {3}</a>
                    Atualizado em: {4}
                </div>",
                new[] { doc.Nome, extensao, new UrlHelper(html.ViewContext.RequestContext).Content(link + doc.Arquivo.NomeServidor), extensao.ToUpper(), doc.Arquivo.DataInclusao.Value.ToString("dd/MM/yyyy") });
            }

            texto += "<div class='clearfix'></div>";

            foreach (var filho in model.TipoDocumentoFilhos)
            {
                n++;
                texto += "<p> </p>";
                texto += MontaPastaDocumentoTrans(html, filho, link, count + n);
            }

            texto += "</div></div></div></div>";

            return MvcHtmlString.Create(texto);
        }

    }
}

