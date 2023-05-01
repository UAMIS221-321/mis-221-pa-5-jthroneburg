namespace mis_221_pa_5_jthroneburg
{
    public class Trainer
    {
        private int id;
        private string name;
        private string address;
        private string email;
        private int fee;

        static private int trainerMaxCount;

        public Trainer() {
        }

        public Trainer(int id, string name, string address, string email, int fee) {
            this.id = id;
            this.name = name;
            this.address = address;
            this.email = email;
            this.fee = fee;
        }

        public void SetId(int id) {
            this.id = id;
        }
        public void SetName(string name) {
            this.name = name;
        }
        public void SetAddress(string address) {
            this.address = address;
        }
        public void SetEmail(string email) {
            this.email = email;
        }
        public void SetFee(int fee) {
            this.fee = fee;
        }
        static public void SetTrainerMaxCount(int count) {
            trainerMaxCount = count;
        }

        public int GetId() {
            return id;
        }
        public string GetName() {
            return name;
        }
        public string GetAddress() {
            return address;
        }
        public string GetEmail() {
            return email;
        }
        public int GetFee() {
            return fee;
        }
        static public int GetTrainerMaxCount() {
            return trainerMaxCount;
        }

        static public void IncTrainerMaxCount() {
            trainerMaxCount++;
        }
        static public void DecTrainerMaxCount() {
            trainerMaxCount--;
        }

        public override string ToString() {
            return($"{name} is id number {id}, can be reached at {email} or {address}, and charges ${fee} per hour.");
        }

        public string ToFile() {
            return($"{name}#{id}#{address}#{email}#{fee}");
        }

    }
}