string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

int maxPets = 8;
string? readResult;
string menuSelection = "";

string[,] ourAnimals = new string[maxPets, 7];

for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalID = "d1";
            animalSpecies = "dog";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;

        case 1:
            animalID = "d2";
            animalSpecies = "dog";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "gus";
            suggestedDonation = "49.99";
            break;

        case 2:
            animalID = "c3";
            animalSpecies = "cat";
            animalAge = "1";
            animalNickname = "snow";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            suggestedDonation = "40.00";
            break;

        case 3:
            animalID = "c4";
            animalSpecies = "cat";
            animalAge = "";
            animalNickname = "lion";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            suggestedDonation = "45.00";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
    }
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
    decimal decimalDonation;
    if (!decimal.TryParse(suggestedDonation, out decimalDonation)) decimalDonation = 45.00m;
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
};

do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        case "1":
            {
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: ")
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            Console.WriteLine(ourAnimals[i, j]);
                        }
                        Console.WriteLine("\n");
                    }
                }
                Console.WriteLine("\n\rPress the Enter key to continue");
                readResult = Console.ReadLine();
                break;
            }
        case "2":
            {
                string dogDescription = "";
                bool noMatchesDog = true;
                string dogCharacteristic = "";

                while (dogCharacteristic == "")
                {
                    Console.WriteLine($"\nEnter one desired dog characteristics to search for");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        dogCharacteristic = readResult.ToLower().Trim();
                    }
                }

                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 1].Contains("dog"))
                    {
                        dogDescription = (ourAnimals[i, 4] + "\n" + ourAnimals[i, 5]);
                        if (dogDescription.Contains(dogCharacteristic))
                        {
                            Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match!");
                            Console.WriteLine(dogDescription);
                            noMatchesDog = false;
                        }
                    }
                }

                if (noMatchesDog)
                {
                    Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristic);

                }
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            }
        case "3":
            {
                string input = "";


                while (input == "")
                {
                    Console.WriteLine("Write the characteristics separated by commas: ");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        input = readResult.Trim().ToLower().Replace(" ", "");
                    }
                }
                string[] dogCharacteristics = input.Split(",");

                for (int i = 0; i < maxPets; i++)
                {
                    string dogDescription = (ourAnimals[i, 4] + "\n" + ourAnimals[i, 5]);
                    string searchableDescription = dogDescription.ToLower().Replace(" ", "");
                    if (ourAnimals[i, 1].Contains("dog"))
                    {
                        foreach (string character in dogCharacteristics)
                        {
                            if (searchableDescription.Contains(character))
                            {
                                Console.WriteLine($"\nOur dog Nickname: {ourAnimals[i, 3]} matches your search for{character}");
                                Console.WriteLine(dogDescription);
                            }
                        }
                    }
                }

                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            }
        default:
            {

                break;
            }
    }

}
while (menuSelection != "exit");