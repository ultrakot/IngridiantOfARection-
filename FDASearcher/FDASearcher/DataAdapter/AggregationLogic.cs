using FDASearcher.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace FDASearcher.DataAdapter
{
    public class AggregationLogic
    {
        public string GetMainIngrediant(string reaction)
        {

            //gets data
            var consumer = new FDAConsumer();
            var result = consumer.GetJsonDataByUrl(reaction); 
            FDAResult fDAResult = consumer.DeserializeRawData(result);

            //
            List<Result> termCountData = fDAResult.results;            
            List<Result> ProducedResult = termCountData.OrderByDescending((termCount) => termCount.count)
                                                         .Take(10)
                                                         .ToList();
            var countSum = ProducedResult.Sum(res => res.count);


            //pracentage = sum of all reactions  count/sum * 100
            List<AggregationResult> aggregationResult = new List<AggregationResult>();

            aggregationResult = ProducedResult.Select(x => new AggregationResult()
            {
                IngredientName = x.term,
                AmountOfReactions = x.count,
                PracentageInGeneral = Math.Round((double)x.count / (double)countSum,2)
            }).ToList();


            string json = JsonConvert.SerializeObject(aggregationResult, Formatting.Indented);
            return json;

        }


    }
}
