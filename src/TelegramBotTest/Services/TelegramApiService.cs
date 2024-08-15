using Microsoft.JSInterop;
using RestSharp;
using System.Globalization;
using System.Text.Json;
using TelegramBotTest.Services;

namespace TradingStaking.Services
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
       

        //public async Task StopSelectedBotsAsync(IEnumerable<UIBotDto> bots, CancellationToken ct = default)
        //{
        //    var guids = bots.Select(p => p.Guid.ToString());
        //    var botsForRequest = new
        //    {
        //        ids = guids,
        //        closeOption = "SimpleStop",
        //    };
        //    RestResponse response = new();


        //    var json = JsonSerializer.Serialize(botsForRequest);
        //    var options = new RestClientOptions("https://95.216.29.24:443")
        //    {
        //        RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        //    };
        //    var client = new RestClient(options);
        //    var request = new RestRequest("/api/v1/aevo/bots/StopMultipleBots");
        //    request.Method = Method.Put;
        //    request.AddHeader("Accept", "*/*");
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddHeader("token", "ZgrdVfwUpkqXh6Cu8v4tLGJ7nNjc5MFy");
        //    request.AddJsonBody(json);
        //    try
        //    {

        //        response = await client.ExecuteAsync(request);
        //        _ = jSRuntime.InvokeVoidAsync("console.log", "StopSelectedBots ExecuteAsync:" + response.Content + response.ErrorMessage + response.ErrorException);



        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }

        //}
      
    }
}
