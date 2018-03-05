using System.Collections.Generic;
using System.Text;
using Global.Dados.Util;
using Global.Dom.Entidade.Transparencia.DRH;
using NHibernate;
using NHibernate.Transform;
using Transparencia.Dom.Servicos.DRH;
using Transparencia.Dom.Util;

namespace Transparencia.Dados.Persistencia.DRH
{
    public class ServidorDados : IServicoServidores
    {
        #region Implementation of IServicoServidorAtivo

        public IEnumerable<ServidorAtivo> ListaServidoresAtivos()
        {
            using (var s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var sql = new StringBuilder();


                sql.AppendLine(
                        "SELECT [Nome],[categoriaDescricao][Categoria],[Matricula],[cargoDescricao][CargoEfetivo],")
                    .AppendLine("[cargoComissaoDescricao][CargoEmComissao],[LotacaoAtual],[admissao] [Nomeacao],")
                    .AppendLine("[posse][Exercicio],[AprovadoNoEstagio] [Estavel] FROM [organizador].[dbo].[vwPessoa]")
                                .AppendLine("  where vinculo = 1 and categoria in(1,2,3,4)");

                var query = s.CreateSQLQuery(sql.ToString());


                query.AddScalar("Nome", NHibernateUtil.String)
                    .AddScalar("Categoria", NHibernateUtil.String)
                    .AddScalar("Matricula", NHibernateUtil.String)
                    .AddScalar("CargoEfetivo", NHibernateUtil.String)
                    .AddScalar("CargoEmComissao", NHibernateUtil.String)
                    .AddScalar("LotacaoAtual", NHibernateUtil.String)
                    .AddScalar("Nomeacao", NHibernateUtil.DateTime)
                    .AddScalar("Exercicio", NHibernateUtil.DateTime)
                    .AddScalar("Estavel", NHibernateUtil.String)

                    .SetResultTransformer(Transformers.AliasToBean(typeof(ServidorAtivo)));

                return query.List<ServidorAtivo>() as List<ServidorAtivo>;
            }
        }

        public IEnumerable<ServidorInativo> ListaServidoresInativos()
        {
            using (var s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var sql = new StringBuilder()
                    .AppendLine("SELECT [Nome],[Matricula],[cargoDescricao][CargoEfetivo],[desligamento][Aposentadoria]")
                    .AppendLine("FROM [organizador].[dbo].[vwPessoa] where vinculo = 3 and categoria not in (5)");
                
                var query = s.CreateSQLQuery(sql.ToString());


                query.AddScalar("Nome", NHibernateUtil.String)
                    .AddScalar("Matricula", NHibernateUtil.String)
                    .AddScalar("CargoEfetivo", NHibernateUtil.String)
                    .AddScalar("Aposentadoria", NHibernateUtil.DateTime)
                    
                    .SetResultTransformer(Transformers.AliasToBean(typeof(ServidorInativo)));

                return query.List<ServidorInativo>() as List<ServidorInativo>;
            }
        }
        
        public IEnumerable<CargosVagosEOcupados> ListaCargosVagosEOcupados()
        {
            using (var s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var sql = new StringBuilder()
                    .AppendLine("SELECT [codigo] CodigoCargo ,[descricao] Cargo,[quantidade] Existentes,[Ocupados] ,[Vagos]")
                    .AppendLine("FROM [organizador].[dbo].[vwQuadroCargos]");
                var query = s.CreateSQLQuery(sql.ToString());


                query.AddScalar("CodigoCargo", NHibernateUtil.String)
                    .AddScalar("Cargo", NHibernateUtil.String)
                    .AddScalar("Existentes", NHibernateUtil.Int32)
                    .AddScalar("Ocupados", NHibernateUtil.Int32)
                    .AddScalar("Vagos", NHibernateUtil.Int32)

                    .SetResultTransformer(Transformers.AliasToBean(typeof(CargosVagosEOcupados)));

                return query.List<CargosVagosEOcupados>() as List<CargosVagosEOcupados>;
            }
        }

        public IEnumerable<AntiguidadeServidores> ListaAntiguidadeServidores()
        {
            using (var s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var sql = new StringBuilder()
                    .AppendLine("SELECT [cargoCodigo][CodigoCargo],[cargoDescricao] [Cargo] ,[ordem][OrdemAntiguidade]")
                    .AppendLine(",[inicio] [PosseExercicio],[Nome]")
                    .AppendLine("FROM [organizador].[dbo].[vwAntiguidade]  where cargoDescricao not like '%defensor %' order by [cargoCodigo], [ordem]");
                var query = s.CreateSQLQuery(sql.ToString());


                query.AddScalar("CodigoCargo", NHibernateUtil.String)
                    .AddScalar("Cargo", NHibernateUtil.String)
                    .AddScalar("OrdemAntiguidade", NHibernateUtil.Int32)
                    .AddScalar("PosseExercicio", NHibernateUtil.DateTime)
                    .AddScalar("Nome", NHibernateUtil.String)

                    .SetResultTransformer(Transformers.AliasToBean(typeof(AntiguidadeServidores)));

                return query.List<AntiguidadeServidores>() as List<AntiguidadeServidores>;
            }
        }

        #endregion
    }
}