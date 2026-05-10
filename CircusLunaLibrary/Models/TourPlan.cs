using System.Text;

namespace CircusLunaLibrary.Models
{
	public class TourPlan
	{
		public List<Performance> Performances { get; set; } = new List<Performance>();
		public TourPlan()
		{
		}
        public override string ToString()
        {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("-----TURNEPLAN------");

            if (Performances.Count == 0)
            {
                sb.AppendLine("Der er endnu ikke planlagt nogle forestillinger");
            }
			else
			{
                foreach (Performance p in Performances)
				{
					sb.AppendLine(p.ToString());
					sb.AppendLine("-------------------------------------------------------------");
				}
            }            		
			return $"{sb.ToString()}";
        }
	}
}
