namespace mis_221_pa_5_jthroneburg
{
    public class BookingUtility
    {
        Listing[] listings;

        public BookingUtility(Listing[] listings) {
            this.listings = listings;
        }

        Booking[] bookings;

        public BookingUtility(Booking[] bookings) {
            this.bookings = bookings;
        }


        //book
            //write to transactions.txt and include session ID, customer name, customer email, training date, 
            //trainer ID, trainer name and status. Also change listing status
        public void BookListing(int searchVal) {
            int index = FindListing(searchVal);
            listings[index].SetBooked("Booked");
            StreamWriter writer = new StreamWriter("transactions.txt");
            System.Console.WriteLine(listings[index].ToFile);
            writer.Close();
        }

        public void PrintAllBookings() {
            for (int i = 0; i < Booking.GetBookingMaxCount(); i++) {
                System.Console.WriteLine(bookings[i].ToString());
            }
        }

        public int FindListing(int searchVal) {
            for(int i = 0; i < Listing.GetListingMaxCount(); i++) {
                if (listings[i].GetId() == searchVal) {
                    return i;
                }
            }
            return -1;
        }

        
    }
}