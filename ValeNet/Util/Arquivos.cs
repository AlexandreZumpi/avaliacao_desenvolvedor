using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ValeNet.Util
{
    public class Arquivos
    {

        /// <summary>
        /// Metodo responsavel pelo envio do arquivo para o servidor
        /// </summary>
        /// <param name="arquivo">Representa o arquivo que vai ser enviado</param>
        /// <param name="PathWebRoot">Caminho absoluto para o diretório que contém os arquivos de conteúdo do aplicativo WEB</param>
        /// <param name="pasta">Pasta onde o arquivo sera salvo</param>
        /// <returns></returns>
        public static string UploadedFile(IFormFile arquivo, string PathWebRoot , string pasta)
        {
            string filePath = "";

            //Obtém o caminho físico da pasta wwwroot
            string caminho_WebRoot = PathWebRoot;

            // monta o caminho onde vamos salvar o arquivo. Por exemplo:   ~\wwwroot\Arquivos\Importacao\Dados
            string caminhoDestinoArquivo = caminho_WebRoot + "\\" + pasta + "\\";

            string uniqueFileName = null;

            if (arquivo != null)
            {
                // Define um nome UNICO para o arquivo enviado
                uniqueFileName = Guid.NewGuid().ToString() + "_" + arquivo.FileName;

                // Combina o caminho do destino do arquivo com o nome do arquivo enviado
                filePath = Path.Combine(caminhoDestinoArquivo, uniqueFileName);

                if (!Directory.Exists(caminhoDestinoArquivo))
                {
                    Directory.CreateDirectory(caminhoDestinoArquivo);
                }

                //copia o arquivo para o local de destino
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    arquivo.CopyTo(fileStream);
                }
            }
            return filePath;
        }
    }
}
