namespace mis_221_pa_5_jthroneburg
{
    public class Booking
    {
        private int sessionId;
        private string customerName;
        private string customerEmail;
        private string date;
        private int trainerId;
        private string trainerName;
        private string status;

        static private int bookingMaxCount;

        public void SetSessionId(int id) {
            sessionId = id;
        }
        public void SetCustomerName(string name) {
            customerName = name;
        }
        public void SetEmail(string email) {
            customerEmail = email;
        }
        public void SetDate(string date) {
            this.date = date;
        }
        public void SetTrainerId(int trainerId) {
            this.trainerId = trainerId;
        }
        public void SetTrainerName(string name) {
            trainerName = name;
        }
        public void SetStatus(string status) {
            this.status = status;
        }
        public void SetBookingMaxCount(int count) {
            bookingMaxCount = count;
        }

        public int GetSessionId() {
            return sessionId;
        }
        public string GetCustomerName() {
            return customerName;
        }
        public string GetEmail() {
            return customerEmail;
        }
        public string GetDate() {
            return date;
        }
        public int GetTrainerId() {
            return trainerId;
        }
        public string GetTrainerName() {
            return trainerName;
        }
        public string GetStatus() {
            return status;
        }
        static public int GetBookingMaxCount() {
            return bookingMaxCount;
        }

        public void IncBookingMaxCount() {
            bookingMaxCount++;
        }

        public override string ToString() {
            return($"Session {sessionId} is with {customerName} who can be reached at {customerEmail} and is on {date} with {trainerName} who's ID is {trainerId}. This session is {status}.");
        }

        public string ToFile() {
            return($"{sessionId}#{customerName}#{customerEmail}#{date}#{trainerId}#{trainerName}#{status}");
        }
    }
}