using System;
using SplashKitSDK;
using System.Collections.Generic;


public enum MenuOption
{
    PrintUsers,
    SelectUser,
    ScanUsers,
    PrintBlacklist,
    PrintWhitelist,
    UserInsight,
    DeleteUser,
    Quit
}


public class Program
{



    /* This function is our user menu */
    private static MenuOption ReadUserOption()
    {
        int option;
        Console.WriteLine("1. Print Users");
        Console.WriteLine("2. Find User");
        Console.WriteLine("3. Scan Users");
        Console.WriteLine("4. Print Blacklist");
        Console.WriteLine("5. Print Whitelist");
        Console.WriteLine("6. User Insight");
        Console.WriteLine("7. Delete User");
        Console.WriteLine("8. Quit");

        do
        {
            Console.Write("Please select an option from the menu: ");
            string input = Console.ReadLine();
            option = Convert.ToInt32(input);

        } while (option < 1 || option > 8);

        return (MenuOption)(option - 1);
    }

    /* This gets a random list of games for each user
    based on a list of available games */
    private static List<string> gameListGenerator()
    {
        List<string> availableGames = new List<string>();
        availableGames.Add("Farcry");
        availableGames.Add("CS:GO");
        availableGames.Add("Portal");
        availableGames.Add("Half-Life");
        availableGames.Add("Half-Life 2");
        availableGames.Add("Garrys Mod");
        availableGames.Add("Towers Unite");
        availableGames.Add("Golf With Your Friends");
        availableGames.Add("Halo: MCC");
        availableGames.Add("CS: Source");
        availableGames.Add("CS: 1.6");
        List<string> gameList = new List<string>();
        foreach (string game in availableGames)
        {
            double chance = SplashKit.Rnd();
            if (chance > 0.5)
            {
                gameList.Add(game);
            }
        }
        return gameList;

    }


    /*  No database, so we create and add our initial users
     in this function */
    private static void generateUser(Platform Platform)
    {

        List<string> userGameList1 = gameListGenerator();
        Neutral newUser = new Neutral(232, userGameList1, 12, 4, 10000, 90000, 93, 82);
        List<string> userGameList2 = gameListGenerator();
        Neutral newUser2 = new Neutral(233, userGameList2, 9, 6, 3000, 40000, 32, 19);
        List<string> userGameList3 = gameListGenerator();
        Neutral newUser3 = new Neutral(234, userGameList3, 0.2, 23, 400, 3000, 10000, 23);
        List<string> userGameList4 = gameListGenerator();
        Neutral newUser4 = new Neutral(235, userGameList4, 0.5, 0, 100, 300, 45, 35);
        List<string> userGameList5 = gameListGenerator();
        Neutral newUser5 = new Neutral(236, userGameList5, 6, 25, 10000, 10000, 93, 22);

        Platform.AddUser(newUser);
        Platform.AddUser(newUser2);
        Platform.AddUser(newUser3);
        Platform.AddUser(newUser4);
        Platform.AddUser(newUser5);
    }

    /* This looks for our user within the platform */
    private static User FindUser(Platform Platform)
    {
        Console.Write("Enter User ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        User result = Platform.GetUser(id);
        if (result == null)
        {
            Console.WriteLine($"No user found with ID: {Convert.ToString(id)}");
        }
        return result;
    }




    public static void Main()
    {
        Platform Platform = new Platform();
        generateUser(Platform);
        MenuOption userSelection;

        do
        {
            userSelection = ReadUserOption();
            Console.WriteLine(userSelection);

            switch (userSelection)
            {
                case MenuOption.PrintUsers:
                    Platform.PrintUsers();
                    break;

                case MenuOption.SelectUser:
                    Platform.PrintUsers();
                    User current = FindUser(Platform);
                    current.Print();
                    break;

                case MenuOption.ScanUsers:
                    Platform.ScanUsers();
                    break;

                case MenuOption.PrintBlacklist:
                    Platform.PrintBlacklist();
                    break;

                case MenuOption.PrintWhitelist:
                    Platform.PrintWhitelist();
                    break;

                case MenuOption.UserInsight:
                    current = FindUser(Platform);
                    Platform.PrintUserOptions(current);
                    break;

                case MenuOption.DeleteUser:
                    current = FindUser(Platform);
                    Platform.removeUser(current);
                    break;

                case MenuOption.Quit:
                    Console.WriteLine("Quitting...");
                    break;

            }
        } while (userSelection != MenuOption.Quit);
    }
}
