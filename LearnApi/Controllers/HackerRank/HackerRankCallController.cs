using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using LearnApi.Models;

namespace LearnApi.Controllers.HackerRank
{
    public class HackerRankCallController : ApiController
    {
        private const string URL = "https://jsonmock.hackerrank.com/api/articles";
        private string URLParameters = "?author=epaga&page=0";

        public async Task<HttpResponseMessage> Get()
        {
            HackerRankModel hackerRankModel = new HackerRankModel();
            List<string> authorTitle = new List<string>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(URLParameters);
                if (response.IsSuccessStatusCode)
                {
                    hackerRankModel = await response.Content.ReadAsAsync<HackerRankModel>();
                }

                foreach (var item in hackerRankModel.data)
                {
                    if (item.title != null)
                        authorTitle.Add(item.title);
                }
            }

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, authorTitle);
        }
    }
}