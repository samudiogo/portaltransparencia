using System.Collections.Generic;
using System.Text;
using Global.Dom.Entidade.PortalDPGE.Views;
using Transparencia.Dom.Servicos.DRH;
using Global.Dom.Util;
using NHibernate;
using NHibernate.Transform;
using Global.Dados.Util;

namespace Transparencia.Dados.Persistencia.DRH
{
    public class MovimentacaoDefensores : IServicoMovimentacaoDefensores
    {
        private static string DbSci
        {
            get
            {
                var ambiente = Itario.AmbienteAplicacao();
                var ret = string.Empty;
                if (ambiente.Contains("producao") || ambiente.Contains("homologacao-proderj"))
                {
                    ret = "SCI";
                }
                else if (ambiente.Contains("homologacao"))
                {
                    ret = "SCI";
                }
                else if (ambiente.Contains("desenvolvimento"))
                {
                    ret = "SCI";
                }
                return ret;
            }
        }


        public IEnumerable<AntiguidadeDefensor> ListaAntiguidadeDefensores()
        {
            using (var s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = s.CreateSQLQuery(
                    "SELECT [IdQuadroCargo],[Ocupado],[Ordem],[IdCargo],[InicioCargo],[SiglaCargo],[DescricaoCargo],[NomeDefensor],[DataPosse],[DataUltimaPromocao],[TotalDiasEstado],[TotalDiasPublico],[TotalDiasAposentado] FROM [" +
                    DbSci + "].[SITE].[VW_CONSULTA_ANTIGUIDADE_DEFENSOR] ORDER BY IdCargo, Ordem");


                query.AddScalar("IdQuadroCargo", NHibernateUtil.Int32)
                    .AddScalar("Ocupado", NHibernateUtil.Int32)
                    .AddScalar("Ordem", NHibernateUtil.Int32)
                    .AddScalar("IdCargo", NHibernateUtil.Int32)
                    .AddScalar("InicioCargo", NHibernateUtil.DateTime)
                    .AddScalar("SiglaCargo", NHibernateUtil.String)
                    .AddScalar("DescricaoCargo", NHibernateUtil.String)
                    .AddScalar("NomeDefensor", NHibernateUtil.String)
                    .AddScalar("DataPosse", NHibernateUtil.DateTime)
                    .AddScalar("DataUltimaPromocao", NHibernateUtil.DateTime)
                    .AddScalar("TotalDiasEstado", NHibernateUtil.Int32)
                    .AddScalar("TotalDiasPublico", NHibernateUtil.Int32)
                    .AddScalar("TotalDiasAposentado", NHibernateUtil.Int32)
                    .SetResultTransformer(Transformers.AliasToBean(typeof(AntiguidadeDefensor)));

                return query.List<AntiguidadeDefensor>() as List<AntiguidadeDefensor>;
            }
        }

        public IEnumerable<MovimentacaoDefensor> ListaMovimentacaoDefensores()
        {
            using (var s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var sql = new StringBuilder()
                    .AppendLine($"SELECT doc.nome Titulo, doc.data_publicacao DataPublicacao, arq.nome_servidor Link from [{DbSci}].[SITE].[DOCUMENTO] doc ")
                    .AppendLine($"inner join [{DbSci}].[SITE].[TIPO_DOCUMENTO] tpDoc on doc.id_TIPO_DOCUMENTO = tpDoc.id ")
                        .AppendLine(" and tpDoc.nome like 'COMOV Movimentação - Defensores' ")
                    .AppendLine($"inner join [{DbSci}].[DEF].[ARQUIVO] arq on arq.id = doc.id_ARQUIVO");
                var query = s.CreateSQLQuery(sql.ToString());


                query.AddScalar("Titulo", NHibernateUtil.String)
                    .AddScalar("DataPublicacao", NHibernateUtil.DateTime)
                    .AddScalar("Link", NHibernateUtil.String)

                    .SetResultTransformer(Transformers.AliasToBean(typeof(MovimentacaoDefensor)));

                return query.List<MovimentacaoDefensor>() as List<MovimentacaoDefensor>;
            }
        }
    }
}
