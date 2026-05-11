using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;

namespace CircusLunaLibrary.Services
{
	public class ReservationService
	{

		/*det her er min fields som refere til min reservationRepository som gemmer i den via min constructor */
		private ReservationRepository reservationReposiorty;




		/*her er min constructor 
		den er public og har oprettet en tom liste i den , den refere til min Reservationsrepository */
		public ReservationService()
		{
			reservationReposiorty = new ReservationRepository();
		}




        /*her opretter jeg en public void som opretter reservation , 
		 jeg tilføjer parameter (Reservation reservation)  = Reservation er min klass og reservation er parameteren som bliver 
		sendt til Reservation klassen .
		
		reservationReposiorty.AddReservation(reservation) = det her er parameteren som bliver sendt , den fortæller at når den 
		bliver kaldt så skal den tilføjes ved brug af min Reservation klassen ,. 
         */
        public void CreateReservation(Reservation reservation) 
		{
			reservationReposiorty.AddReservation(reservation);		
		}



        /* her opretter jeg en methode som henter alle reservationer 
		 public = åbent for alle 
		List<Reservation> = den skal hente det ved brug af reservation klassen som en liste 
		GetReservations() = er navnet på min methode 
		
		return reservationReposiorty.GetAllReservation(); = den skal retuner reservatioRepository som er feltet i min klasse som
		også tilhøre ReservationsRepositoy. 
         */
        public List<Reservation> GetReservations()
		{
			return reservationReposiorty.GetAllReservation();
		}



		/*her opretter jeg en methode som viser alle min reservationer 
		 public = åben klasse for alle 
		void = */
		public void ShowReservation()
		{
			List<Reservation> reservations = reservationReposiorty.GetAllReservation();

			foreach (Reservation reservation in reservations)
			{
                Console.WriteLine(reservation);
			}
		}




        /* her opretter jeg en methode som tilføjer en billet til min reservation . 
		 public = åbent for alle 
		void = har ingen retur værdi blot en handling 
		AddTicketToReservation = methodens navn 
		( string reservationId , Ticket ticket) =  er mine parameter som methoden skal bruge 

		Reservation reservation = reservationReposiorty.GetReservationById(reservationId);
         = her bruger jeg reservations klassen som jeg giver en variabel ( reservation ) og fortæller den at den skal hente 
		methoden GetReservationByID i min reposiotry som den skal tilføje som en string til min parameter som er reservationsId

		if (reservation != null) = hvis reservation ikke findes skal den returner et null , og ved brug af null betyder hvis 
		nu reservations ikke findes vil den ikke give os nullReferenceExpection som er vil crashe .

		hvis reservations id findes = så Addticket til ticket som er min paramter for methoden i ticket klassen.

         */
        public void AddTicketToReservatio(string reservationId , Ticket ticket)

		{
			Reservation reservation = reservationReposiorty.GetReservationById(reservationId);

			if (reservation != null)
			{
				reservation.AddTicket(ticket);
			}


		}
	}
}
