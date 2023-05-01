namespace mis_221_pa_5_jthroneburg
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers) {
            this.trainers = trainers;
        }

        public void GetAllTrainers() {
            //open
            StreamReader inFile = new StreamReader("trainers.txt");
            //int wordCount = 0;

            Trainer.SetTrainerMaxCount(0);
            string line = inFile.ReadLine();
                while(line != null) {
                    string[] temp = line.Split('#');
                    //wordCount += temp.Length;
                    trainers[Trainer.GetTrainerMaxCount()] = new Trainer(int.Parse(temp[0]),temp[1], temp[2], temp[3], int.Parse(temp[4]));
                    Trainer.IncTrainerMaxCount();
                    line = inFile.ReadLine();
                }

            //close
            inFile.Close();
        }

        //read on stack overflow the best way to remove an obj from an array is to convert to a list,
        //remove it, then convert back
        public void DeleteTrainer(int index) {
            var trainersList = new List<Trainer>(trainers);
            trainersList.RemoveAt(index);
            trainers = trainersList.ToArray();
            Save();
        }

        public void AddTrainer() {
            Trainer myTrainer = new Trainer();
            myTrainer.SetId(Trainer.GetTrainerMaxCount() + 1);
            System.Console.WriteLine("Please enter the name:");
            myTrainer.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter the address:");
            myTrainer.SetAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter the email:");
            myTrainer.SetEmail(Console.ReadLine());
            System.Console.WriteLine("Please enter the fee:");
            myTrainer.SetFee(int.Parse(Console.ReadLine()));

            trainers[Trainer.GetTrainerMaxCount()] = myTrainer;
            Trainer.IncTrainerMaxCount();

            Save();
        }

        private void Save() {
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for (int i = 0; i < Trainer.GetTrainerMaxCount(); i++) {
                outFile.WriteLine(trainers[i].ToFile());
            }

            outFile.Close();
        }

        private int Find(string searchVal) {
            for(int i = 0; i < Trainer.GetTrainerMaxCount(); i++) {
                if (trainers[i].GetName().ToUpper() == searchVal.ToUpper()) {
                    return i;
                }
            }
            return -1;
        }

        public int FindTrainer(int searchVal) {
            for(int i = 0; i < Trainer.GetTrainerMaxCount(); i++) {
                if (trainers[i].GetId() == searchVal) {
                    return i;
                }
            }
            return -1;
        }

        public void PrintAllTrainers() {
            for (int i = 0; i < Trainer.GetTrainerMaxCount(); i++) {
                System.Console.WriteLine(trainers[i].ToString());
            }
        }

        public void UpdateTrainer() {
            System.Console.WriteLine("Enter name of trainer you'd like to update:");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);

            if(foundIndex != -1) {
                System.Console.WriteLine("Please enter the name:");
                trainers[foundIndex].SetName(Console.ReadLine());
                System.Console.WriteLine("Please enter the address:");
                trainers[foundIndex].SetAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the email:");
                trainers[foundIndex].SetEmail(Console.ReadLine());
                System.Console.WriteLine("Please enter the fee:");
                trainers[foundIndex].SetFee(int.Parse(Console.ReadLine()));

                Save();
            }
            else {
                System.Console.WriteLine("Trainer not found :(");
            }
        }

        
    }
}