using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EcommerceApi.Services
{
    public class FlutterwaveService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "https://api.flutterwave.com/v3/charges?type=bank_transfer";

        private readonly string _publicKey = "FLWPUBK_TEST-c72bc8cfd5084a7154b9aece0d395257-X";
        private readonly string _secretKey = "FLWSECK_TEST-d126f039a583e220931fd936d74127f2-X";
        public FlutterwaveService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _secretKey);            
        }

        public async Task<string> MakePayment(decimal amount, string email, string callbackUrl){
            var request = new {
                amount = amount,
                email = email,
                currency = "NGN",
                tx_ref = "PaymentRef"
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"https://api.flutterwave.com/v3/charges?type=bank_transfer", content);

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}