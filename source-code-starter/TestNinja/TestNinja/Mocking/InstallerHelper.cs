using System;
using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly string _setupDestinationFile;        
        private readonly IBaixadorDeArquivo _baixadorDeArquivo;
        
        public InstallerHelper(string setupDestinationFile, IBaixadorDeArquivo baixadorDeArquivo)
        {
            _setupDestinationFile = setupDestinationFile;
            _baixadorDeArquivo = baixadorDeArquivo;                        
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            if (customerName == null) throw new ArgumentNullException("CustomerName é obrigatório.");
            if (installerName == null) throw new ArgumentNullException("InstallerName é obrigatório.");

            string url = string.Format("http://example.com/{0}/{1}", customerName, installerName);

            return _baixadorDeArquivo.BaixarArquivo(url, _setupDestinationFile);
        }
    }

    public class BaixadorDeArquivo : IBaixadorDeArquivo
    {
        private readonly WebClient _client;

        public BaixadorDeArquivo()
        {
            _client = new WebClient();
        }

        public bool BaixarArquivo(string url, string caminhoDestino)
        {
            try
            {
                _client.DownloadFile(url, caminhoDestino);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }

    public interface IBaixadorDeArquivo
    {
        bool BaixarArquivo(string url, string caminhoDestino);
    }
}