using System;
using SQLite;

namespace DatabaseDemo
{
	public static class Data {
		static readonly string Path = System.IO.Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), "database.db");
		static SQLite.SQLiteConnection connection;
		public static SQLite.SQLiteConnection Connection
		{
			get {
				if (connection == null) {
					connection = new SQLiteConnection (Path,SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex , true);
				}
				return connection;
			}
		}


	}

	public class Valuation
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[Indexed]
		public int StockId { get; set; }
		public DateTime Time { get; set; }
		public decimal Price { get; set; }
	}
	public class Stock
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[MaxLength(8)]
		public string Symbol { get; set; }

		public override string ToString ()
		{
			return string.Format ("[Stock: Id={0}, Symbol={1}]", Id, Symbol);
		}
	}

}

