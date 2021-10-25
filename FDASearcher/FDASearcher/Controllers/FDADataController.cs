using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FDASearcher.DataAdapter;
using Microsoft.AspNetCore.Cors;

namespace FDASearcher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class FDADataController : ControllerBase
    {
        ///   { "death" },
        //    { "headache" },
        //    { "nausea" },
        //    { "vomiting" } 
        /// <summary>
        /// returns aggregated data about what ingridiants cause by what reaction and it's occurrences  
        /// </summary>
        /// <returns></returns>
        [HttpGet("{reaction}")]
        public string Get(string reaction) 
        {
            AggregationLogic logic = new AggregationLogic();
            var content = logic.GetMainIngrediant(reaction);

            return content;
        
        }

       
    }
}
