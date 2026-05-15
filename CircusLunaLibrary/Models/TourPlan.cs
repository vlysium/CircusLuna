using System.Text;

namespace CircusLunaLibrary.Models
{
    public class TourPlan
    {
        /// <summary>
        /// A list of all the performances that are planned for the tour. This list can be empty if there are no performances planned yet.
        /// </summary>
        public List<Performance> Performances { get; set; }

        /// <summary>
        /// Constructor for the TourPlan class. It takes a list of performances as a parameter and assigns it to the Performances property.
        /// </summary>
        /// <param name="performances">A list of performances to include in the tour plan.</param>
        public TourPlan(List<Performance> performances)
        {
            Performances = performances;
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