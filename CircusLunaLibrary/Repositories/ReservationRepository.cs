using CircusLunaLibrary.Models;

namespace CircusLunaLibrary.Repositories
{
	public class ReservationRepository
	{

		/* her opretter jeg en private liste i reservations klasse som kun den her klasse har adgang til.*/
		private List<Reservation> reservations;




		/*her oprette jeg min constructor med en tom liste af reservationer . */
		public ReservationRepository()
		{
			reservations = new List<Reservation>();
		}




        /*tilføjer en ny reservation til listen , ved at kalde på AddReservation
		reservations.Add(reservation) = her giver jeg den en instruction op at når du bliver kaldt så skal du add. til reservation 
		som er min parameter som tilhøre Reservation*/
        public void AddReservation(Reservation reservation)
		{
			reservations.Add(reservation);
		}




		/*her er min methode der få fat alle reservationer 
		 public = åbent for alle 
		List<Reservation> = er min datatype. 
		GetAllReservation = navnet på min methode 
		
		 Return reservations = retuner værdierne i reservations . */
		public List<Reservation> GetAllReservation()
		{
			return reservations;
		}




		public Reservation GetReservationById(string id)
		{
			foreach (Reservation reservation in reservations)
			{
				if (reservation.ReservationId == id)
				{
					return reservation;
				}
			}
			return null;
		}


		public void ShowReservations()
		{

		}
	}
}
