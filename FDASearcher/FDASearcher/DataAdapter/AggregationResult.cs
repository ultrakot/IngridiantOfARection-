using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDASearcher.DataAdapter
{
    public class AggregationResult
    {
        public string IngredientName { get; set; }
        public int AmountOfReactions { get; set; }
        public double PracentageInGeneral { get; set; }
    }
}
