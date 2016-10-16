using System.Collections.Generic;

namespace IS.Transactions.Demo.Core.Model
{
    public class SearchCriteria
    {
        public string Term { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public Dictionary<string, string> Filters { get; set; }
    }
}
