using System.Collections.Generic;
using ReactSignalR.Pagination;

namespace ReactSignalR.ClientModels
{
    public class PagedFilterRequest
	{
		public IDictionary<string, object> Filter { get; set; }

		public Page Page { get; set; } 
	}
}