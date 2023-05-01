namespace mis_221_pa_5_jthroneburg
{
    public class Reports
    {
        private Booking[] bookings;

        public Reports(Booking[] bookings) {
            this.bookings = bookings;
        }

        //sessions from a customer email
        public void IndividualSessions(string email) {
            for(int i = 0; i < Booking.GetBookingMaxCount(); i++) {
                if (bookings[i].GetEmail() == email) {
                    System.Console.WriteLine(bookings[i].ToString);
                }
            }
        }

        //all sessions by customer then date, show total number of sessions per customer 
        public void Sort() {  
            for(int i = 0; i < Booking.GetBookingMaxCount() - 1; i++) {
                int min = i;
                for(int j = i+ 1; j < Booking.GetBookingMaxCount(); j++) {
                    if(bookings[j].GetCustomerName().CompareTo(bookings[min].GetCustomerName()) < 0 || 
                    (bookings[j].GetCustomerName() == bookings[min].GetCustomerName() && bookings[j].GetDate().CompareTo(bookings[min].GetDate()) < 0)) {
                        min = j;
                    }
                }
                if(min != i) {
                    Swap(min, i);
                }
            }
        }

        public void SessionsPerCustomer() {
            string curr = bookings[0].GetCustomerName();
            int count = 0;

            for (int i = 1; i < Booking.GetBookingMaxCount(); i++) {
                if (bookings[i].GetCustomerName() == curr) {
                    count ++;
                } else{
                    ProcessBreak(ref curr, ref count, bookings[i]);
                }
            }
            ProcessBreak(curr, count);
        }

        public void ProcessBreak(ref string curr, ref int count, Booking newBook) {
            System.Console.WriteLine($"{curr} went to {count} sessions.");
            curr = newBook.GetCustomerName();
            count = 0;
        }

        public void ProcessBreak(string curr, int count) {
            System.Console.WriteLine($"{curr} went to {count} sessions.");
        }

        public void SortRevenue() {  
            for(int i = 0; i < Booking.GetBookingMaxCount() - 1; i++) {
                int min = i;
                for(int j = i+ 1; j < Booking.GetBookingMaxCount(); j++) {
                    if(bookings[j].GetDate().CompareTo(bookings[min].GetDate()) < 0)
                     {
                        min = j;
                    }
                }
                if(min != i) {
                    Swap(min, i);
                }
            }
        }

        private void Swap(int x, int y) {
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }
        

    }
}