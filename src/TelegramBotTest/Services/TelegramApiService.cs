using Microsoft.JSInterop;
using RestSharp;
using System.Globalization;
using System.Text.Json;

namespace TelegramBotTest.Services
{

    public class TelegramApiService
    {


        HttpClient httpClient = null!;

        public TelegramApiService()
        {


            httpClient = new HttpClient();
        }
        public async Task<IEnumerable<Update>> GetBotUpdateAsync(CancellationToken ct = default)
        {
            var DataSource = new List<Update>();

            try
            {
                var userAddress = "";
                var uri = new Uri($"https://api.telegram.org/bot6735323380:AAHKHtMIrJRCAI2ycWz_vifYTw139Alcim0/getUpdates");
                var bots = await httpClient.GetFromJsonAsync<ResultOfUpdate>(uri, ct);
                DataSource = bots?.Result ?? new List<Update>();
                return DataSource;

            }
            catch (Exception e)
            {

                var t = e;
            }

            return DataSource;
        }


        public async Task SendMessageToBot(SendMessage sendMessage, CancellationToken ct = default)
        {           
            RestResponse response = new();

            var json = JsonSerializer.Serialize(sendMessage);
            var options = new RestClientOptions("https://95.216.29.24:443")
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            var client = new RestClient(options);
            var request = new RestRequest("https://api.telegram.org/bot6735323380:AAHKHtMIrJRCAI2ycWz_vifYTw139Alcim0/sendMessage");
            request.Method = Method.Post;
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/json");
            
            request.AddJsonBody(json);
            try
            {

                response = await client.ExecuteAsync(request);            

            }
            catch (Exception e)
            {
                throw;
            }

        }

    }
}
