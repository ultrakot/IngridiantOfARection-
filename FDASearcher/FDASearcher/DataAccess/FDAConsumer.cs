using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace FDASearcher.DataAccess
{
    //gets data from the API in its JSON form 
    public class FDAConsumer
    {
        const string BaseUrl = "https://api.fda.gov/drug/event.json?search=patient.reaction.reactionmeddrapt.exact:%22";
        const string SuffixUrl = "%22&count=patient.drug.medicinalproduct.exact";

        /// <summary>
        ///   { "death" },
        //    { "headache" },
        //    { "nausea" },
        //    { "vomiting" } 
        /// </summary>
        /// <param name="reaction"></param>
        /// <returns></returns>
        public string GetJsonDataByUrl(string reaction)
        
        {            
            var client = new RestClient(BaseUrl+reaction+SuffixUrl);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            // await client.ExecuteAsync(request);
            //if (response.IsSuccessful)
            //{
            //}

            return response.Content;
        }

        public FDAResult DeserializeRawData(string Data) 
        {
            FDAResult content = JsonConvert.DeserializeObject<FDAResult>(Data);
            return content;            
        }

    }
}
