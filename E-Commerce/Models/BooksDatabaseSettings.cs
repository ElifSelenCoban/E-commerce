using System;
namespace E_Commerce.Models
{
	public class BooksDatabaseSettings
	{
		public BooksDatabaseSettings()
		{
		}
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string BooksCollectionName { get; set; } = null!;
    }
}

