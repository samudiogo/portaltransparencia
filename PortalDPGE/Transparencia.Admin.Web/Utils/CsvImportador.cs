using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FileHelpers;

namespace Transparencia.Admin.Web.Utils
{
    public class CsvImportador<TTipo> where TTipo : class
    {
        private const string Delimitadores = ";,|";
        public async Task<IEnumerable<TTipo>> ImportaArquivoCsvAsync(HttpPostedFileBase csv)
        {
            List<TTipo> lista = null;
            await Task.Run(() =>
            {
                lista = new FileHelperEngine<TTipo>().ReadStream(new StreamReader(csv.InputStream)).ToList();
            });

            return lista;
        }


        private static string ObtemDelimitador(HttpPostedFileBase csv)
        {
            var reader = new StreamReader(csv.InputStream);

            var primeiraLinha = reader.ReadLine();
            if (primeiraLinha != null && primeiraLinha.Length < 1) throw new Exception("arquivo inválido");
            var d = string.Empty;
            var delimitador = primeiraLinha?.ToCharArray();

            foreach (var item in Delimitadores.ToCharArray())
                if (item.Equals(delimitador?.FirstOrDefault(e => e.Equals(item))))
                    d = item.ToString();
            return d;
        }
    }
}