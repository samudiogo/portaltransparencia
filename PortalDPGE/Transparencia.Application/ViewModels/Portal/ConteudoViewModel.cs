using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Global.Dom.Entidade.PortalDPGE;
using PortalDPGE.Dom.Regras;
using PortalDPGE.Dados.Persistencia;

namespace Transparencia.Application.ViewModels.Portal
{
    public class ConteudoViewModel
    {
        public virtual string Login { get; set; }

        public int Id { get; set; }
        [DisplayName("URL")]
        public string Alias { get; set; }
        [DisplayName("Título")]
        [Required]
        public string Titulo { get; set; }
        [AllowHtml]
        [Required(AllowEmptyStrings = true, ErrorMessage = "Digite pelo menos um espaço ai...")]
        [DataType(DataType.MultilineText)]
        public string ConteudoHtml { get; set; }

        [DisplayName("Seção")]
        public virtual SecaoConteudo SecaoConteudo { get; set; }

        public virtual TipoConteudo TipoConteudo { get; set; }
        public virtual Global.Dom.Entidade.PortalDPGE.Portal Portal { get; set; }


    }

    public class ConteudoCadastroViewModel : ConteudoViewModel
    {
        public ConteudoCadastroViewModel()
        {

        }
        public ConteudoCadastroViewModel(string login)
        {
            Login = login;

            TipoConteudoId = 1;//conteudo geral

            PortalId = (int)PortalRegras.Portais.Transparencia;

        }
        public sealed override string Login { get; set; }

        [Required]
        public int SecaoId { get; set; }
        public List<SelectListItem> ListagemSecao
        {
            get
            {
                return new SecaoConteudoRegras { Servico = new SecaoConteudoDados() }
                    .ListarTodos()
                    //.Where(s=> s.Portal.Id == PortalId)
                    .OrderBy(t => t.Nome)
                    .Select(secao => new SelectListItem { Value = secao.Id.ToString(), Text = secao.Nome })
                    .ToList();
            }
        }
        [Required]
        [DisplayName(@"Tipo de Conteúdo")]
        public int TipoConteudoId { get; set; }

        [Required]
        [DisplayName(@"Portal")]
        public int PortalId { get; set; }

    }

    public class ConteudoAlteraViewModel : ConteudoViewModel
    {
        [Required]
        public int TipoConteudoId { get; set; }

        [Required]
        [DisplayName(@"Portal")]
        public int PortalId { get; set; }
    }
    public class ConteudoConsultaViewModel : ConteudoViewModel
    {
        public string Miniatura { get; set; }
    }
}