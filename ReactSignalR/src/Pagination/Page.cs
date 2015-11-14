using System.Collections;
using MongoDB.Driver;
using ReactSignalR.Database.Models;

namespace ReactSignalR.Pagination
{
    public class Page
	{
		public long Current { get; set; }

		public long TotalItems { get; set; }

		public long TotalPages { get; set; }

		public long Skip { get; set; }

		public long Size { get; set; }

		public string SortColumn { get; set; }

		public long SortOrder { get; set; }

		public IEnumerable Results { get; set; }

		public SortDefinition<T> CreateSortDefinition<T>() where T : IDocument
		{
			var sortFieldDefinition = new StringFieldDefinition<T>(SortColumn);

			return SortOrder >= 0
						? Builders<T>.Sort.Ascending(sortFieldDefinition)
						: Builders<T>.Sort.Descending(sortFieldDefinition);
		}

		public Page Calculate(long count)
		{
			if (count < 1)
			{
				Current = 0;
				TotalPages = 0;
			}

			var remainder = count % this.Size;

			TotalItems = count;

			TotalPages = (count / Size) + (remainder > 0 ? 1 : 0);

			Current = Current < 1 ? 1 : Current;

			if (TotalPages < Current)
			{
				Current = TotalPages;
			}

			if (Current > 0)
			{
				Skip = (Current - 1) * Size;
			}

			return this;
		}
	}
}