namespace CircusLunaLibrary.Models
{
	public class BlogPost
	{
		public string BlogPostID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime Date { get; set; }

		public BlogPost(string title, string content, DateTime date)
		{
			BlogPostID = Guid.NewGuid().ToString().Substring(0,8);
			Title = title;
			Content = content;
			Date = date;
		}

		public override string ToString()
		{
			return $"{Date} {Title}\n{Content}";
		}
	}
}
