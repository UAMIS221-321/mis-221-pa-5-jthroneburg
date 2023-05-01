namespace mis_221_pa_5_jthroneburg
{
    public class Listing
    {
        private int id;
        private string name;
        private string date;
        private string time;
        private int cost;
        private string booked;

        static private int listingMaxCount;

        public Listing() {
        }

        public Listing(int id, string name, string date, string time, int cost, string booked) {
            this.id = id;
            this.name = name;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.booked = booked;
        }

        public void SetId(int id) {
            this.id = id;
        }
        public void SetName(string name) {
            this.name = name;
        }
        public void SetDate(string date) {
            this.date = date;
        }
        public void SetTime(string time) {
            this.time = time;
        }
        public void SetCost(int cost) {
            this.cost = cost;
        }
        public void SetBooked(string booked) {
            this.booked = booked;
        }
        static public void SetListingMaxCount(int count) {
            listingMaxCount = count;
        }

        public int GetId() {
            return id;
        }
        public string GetName() {
            return name;
        }
        public string GetDate() {
            return date;
        }
        public string GetTime() {
            return time;
        }
        public int GetCost() {
            return cost;
        }
        public string GetBooked() {
            return booked;
        }
        static public int GetListingMaxCount() {
            return listingMaxCount;
        }

        static public void IncListingMaxCount() {
            listingMaxCount++;
        }

        public override string ToString() {
            return ($"Listing {id} is with {name} on {date} at {time} for {cost}. Booking status: {booked}");
        }

        public string ToFile() {
            return($"{id}#{name}#{date}#{time}#{cost}#{booked}");
        }

    }
}