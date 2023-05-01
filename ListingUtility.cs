namespace mis_221_pa_5_jthroneburg
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility(Listing[] listings) {
            this.listings = listings;
        }

        public void GetAllListings() {
            //open
            StreamReader inFile = new StreamReader("listings.txt");
            //int wordCount = 0;

            Listing.SetListingMaxCount(0);
            string line = inFile.ReadLine();
                while(line != null) {
                    string[] temp = line.Split('#');
                    //wordCount += temp.Length;
                    listings[Listing.GetListingMaxCount()] = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5]);
                    Listing.IncListingMaxCount();
                    line = inFile.ReadLine();
                }

            //close
            inFile.Close();
        }

        //read on stack overflow the best way to remove an obj from an array is to convert to a list,
        //remove it, then convert back
        //extra perhaps...
        public void DeleteListing(int index) {
            var listingsList = new List<Listing>(listings);
            listingsList.RemoveAt(index);
            listings = listingsList.ToArray();
            Save();
        }

        //straight from books in class project
        public void AddListing() {
            Listing myListing = new Listing();
            myListing.SetId(Listing.GetListingMaxCount() + 1);
            System.Console.WriteLine("Please enter the name:");
            myListing.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter the date:");
            myListing.SetDate(Console.ReadLine());
            System.Console.WriteLine("Please enter the time:");
            myListing.SetTime(Console.ReadLine());
            System.Console.WriteLine("Please enter the cost:");
            myListing.SetCost(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the booking status:");
            myListing.SetBooked(Console.ReadLine());

            listings[Listing.GetListingMaxCount()] = myListing;
            Listing.GetListingMaxCount();

            Save();
        }

        //this was a crux for me, it took forever to find why they were not saving until i added this
        private void Save() {
            StreamWriter outFile = new StreamWriter("listings.txt");

            for (int i = 0; i < Listing.GetListingMaxCount(); i++) {
                outFile.WriteLine(listings[i].ToFile());
            }

            outFile.Close();
        }

        //same as findListing, should have combined
        public int Find(int searchVal) {
            for(int i = 0; i < Listing.GetListingMaxCount(); i++) {
                if (listings[i].GetId() == searchVal) {
                    return i;
                }
            }
            return -1;
        }

        //view avalible, go through listings and only show open
        public void PrintAllListings() {
            for (int i = 0; i < Listing.GetListingMaxCount(); i++) {
                if(listings[i].GetBooked().ToUpper() == "OPEN")
                System.Console.WriteLine(listings[i].ToString());
            }
        }

        //whoo hoo books project comin in handy
        public void UpdateListing() {
            System.Console.WriteLine("Enter id of listing you'd like to update:");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1) {
                System.Console.WriteLine("Please enter the new name:");
                listings[foundIndex].SetName(Console.ReadLine());
                System.Console.WriteLine("Please enter the new date:");
                listings[foundIndex].SetDate(Console.ReadLine());
                System.Console.WriteLine("Please enter the new time:");
                listings[foundIndex].SetTime(Console.ReadLine());
                System.Console.WriteLine("Please enter the new cost:");
                listings[foundIndex].SetCost(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the new booking status:");
                listings[foundIndex].SetBooked(Console.ReadLine());

                Save();
            }
            else {
                System.Console.WriteLine("Listing not found :(");
            }
        }

        // public void Sort() {
        //     for(int i = 0; i < Book.GetCount() - 1; i++) {
        //         int min = i;
        //         for(int j = i+ 1; j < Book.GetCount(); j++) {
        //             if(books[j].GetGenre().CompareTo(books[min].GetGenre()) < 0 || 
        //             (books[j].GetGenre == books[min].GetGenre && books[j].GetPages() < books[min].GetPages())) {
        //                 min = j;
        //             }
        //         }
        //         if(min != i) {
        //             Swap(min, i);
        //         }
        //     }
        // }

        private void Swap(int x, int y) {
            Listing temp = listings[x];
            listings[x] = listings[y];
            listings[y] = temp;
        }
    }
}