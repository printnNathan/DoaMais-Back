using System.Text.RegularExpressions;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace DoaMaisAPI.Azure
{
    public class AzureBlobStorage
    {
        public string UploadImage(string image)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=doamaistcc;AccountKey=sLQmDX50sfiE58Wshd2YKc6kNxj4pEPL/F5EzGC3wVNrlIGZmmi7Cmjy7uxVvXF+Mj5araAk0UCW+ASt9LNWCw==;EndpointSuffix=core.windows.net";
            string containerName = "doamais";

            // Gera um nome randomico para imagem
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            // Limpa o hash enviado
            //var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(image, "");
            var data = image;

            // Gera um array de Bytes
            byte[] imageBytes = Convert.FromBase64String(data);

            // Define o BLOB no qual a imagem será armazenada
            var blobClient = new BlobClient(connectionString, containerName, fileName);

            var blobHttpHeader = new BlobHttpHeaders { ContentType = "image/jpg" };
           
            // Envia a imagem
            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream, new BlobUploadOptions()
                {
                    HttpHeaders = blobHttpHeader,
                });
            }

            // Retorna a URL da imagem
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
