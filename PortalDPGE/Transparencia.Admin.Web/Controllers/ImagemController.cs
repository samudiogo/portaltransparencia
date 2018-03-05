using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Global.Dom.Entidade.PortalDPGE;
using PortalDPGE.Dados.Persistencia;
using PortalDPGE.Dom.Regras;
using PortalDPGE.Dom.Util;

namespace Transparencia.Admin.Web.Controllers
{
    public class ImagemController : Controller
    {
        private string _url = DicionarioPortalDPGE.SitePath;

        [HttpPost]
        public JsonResult SaveImage(string imagem, string legenda)
        {
            var miniatura = new Imagem {Legenda = legenda};
            if (imagem.Equals("imagemPadrao"))
                miniatura.Id = 1; //Id:1 = Identificador da imagem padrão 
            else
            {
                var sarova = DicionarioPortalDPGE.uploadsImagemGeral;
                if (!Directory.Exists(sarova))
                    throw new DirectoryNotFoundException("Diretório sarova não encontrado");

                new ImagemRegras {Servico = new ImagemDados()}.SalvaImagemArquivo(
                    out miniatura, Server.MapPath(sarova),
                    legenda: legenda,
                    arquivo: imagem
                    );
            }

            return Json(new {ImagemId = miniatura.Id, mensagem = "Imagem salva com sucesso", state = 200});
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload, string ckEditorFuncNum)
        {
            if (upload == null || upload.ContentLength <= 0) return null;

            var imagemName = Guid.NewGuid().ToString("N") + Path.GetExtension(upload.FileName);
            var path = Path.Combine(Server.MapPath(DicionarioPortalDPGE.uploadsImagemGeral) + imagemName);
            upload.SaveAs(path);

            _url += Regex.Replace(DicionarioPortalDPGE.uploadsImagemGeral, @"\~", "") + imagemName;
            var responseType = ckEditorFuncNum;
            if (!responseType.Equals("json"))
                return Content(string.Format(
                    "<html><body><script>window.parent.CKEDITOR.tools.callFunction({0}, \"{1}\", \"{2}\");</script></body></html>",
                    ckEditorFuncNum, _url, "imagem salva com sucesso"));

            return Json(_url, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult QuickUpload(HttpPostedFileBase upload, string responseType = "json")
        {
            if (upload == null || upload.ContentLength <= 0)
                return Json(new {uploaded = 0, error = new {message = "arquivo inválido. "}},
                    JsonRequestBehavior.AllowGet);

            var imagemName = Guid.NewGuid().ToString("N") + Path.GetExtension(upload.FileName);

            try
            {
                var path = Path.Combine(Server.MapPath(DicionarioPortalDPGE.uploadsImagemGeral) + imagemName);
                upload.SaveAs(path);
            }
            catch (Exception e)
            {
                return Json(new {uploaded = 0, error = new {message = "erro ao processar arquivo. " + e.Message}},
                    JsonRequestBehavior.AllowGet);
            }


            _url += Regex.Replace(DicionarioPortalDPGE.uploadsImagemGeral, @"\~", "") + imagemName;

            return Json(new {@uploaded = 1, @fileName = imagemName, url = _url}, JsonRequestBehavior.AllowGet);
        }
    }
}