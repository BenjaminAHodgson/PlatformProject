using System;
using System.Collections.Generic;
using SplashKitSDK;



public class Platform
{
    /* This is the list of users stored on the platform
    to be accessed by the admin */
    private static List<User> _users = new List<User>();
    public static void AddUser(User User)
    {
        _users.Add(User);
    }

    // If an account ever needs to be deleted, this will be used //
    public static void removeUser(User user)
    {
        Console.WriteLine("Are you sure? Enter (y/n): ");
        string confirmed = Console.ReadLine().ToLower();

        if (confirmed == "n")
        {
            Console.WriteLine($"User: {user.id} has not been deleted.");
            return;
        }
        else if (confirmed == "y")
        {
            _users.Remove(user);
            Console.WriteLine($"User: {user.id} deleted.");
            return;
        }
        else
        {
            Console.WriteLine("No valid input.");
            return;
        }

    }

    // returns user from input id //
    public User GetUser(int id)
    {
        foreach (User User in _users)
        {
            if (User.id == id)
            {
                return User;
            }
        }
        return null;
    }

    // Prints all users //
    public void PrintUsers()
    {

        foreach (User user in _users)
        {
            user.Print();
        }

    }
    // Prints only our whitelisted users //
    public void PrintWhitelist()
    {

        foreach (User user in _users)
        {

            if (user.assignment == 1)
            {
                user.Print();
            }
        }

    }
    // Prints only our blacklisted users //
    public void PrintBlacklist()
    {

        foreach (User user in _users)
        {
            if (user.assignment == 2)
            {
                user.Print();
            }

        }

    }

    // Options to be presented once a user has been selected // 
    public void PrintUserOptions(User user)
    {
        Console.WriteLine($"Account Age: {user.age}");
        Console.Write($"Game List: ");
        foreach (string game in user.gameList)
        {
            Console.WriteLine($"{game}, ");
        }
        Console.WriteLine($"Reports: {user.reports}");
        Console.WriteLine($"Friend Requests/Friends: {user.requests}/{user.friends}");
        Console.WriteLine();
        Console.WriteLine("1. Blacklist this user.");
        Console.WriteLine("2. Whitelist this user.");
        Console.WriteLine("3. Back");
        Console.Write("Choose an option: ");

        int userOption = Convert.ToInt32(Console.ReadLine());

        if (userOption == 1)
        {
            _users.Remove(user);
            Blacklist newUser = new Blacklist(user.id, user.gameList, user.age, user.reports, user.playtime, user.messages, user.requests, user.friends);
            _users.Add(newUser);
        }
        if (userOption == 2)
        {
            _users.Remove(user);
            Whitelist newUser = new Whitelist(user.id, user.gameList, user.age, user.reports, user.playtime, user.messages, user.requests, user.friends);
            _users.Add(newUser);

        }
        else if (userOption == 3)
        {
            return;
        }

    }
    // Assigns all users to either blacklist or whitelist //
    public void ScanUsers()
    {
        int whitelisted = 0;
        int blacklisted = 0;
        Console.WriteLine("--#################--");
        Console.WriteLine(_users.Count);
        foreach (User user in _users.ToArray())
        {
            double danger = user.HealthAnalysis();
            if (danger <= 50)
            {
                _users.Remove(user);
                Whitelist newUser = new Whitelist(user.id, user.gameList, user.age, user.reports, user.playtime, user.messages, user.requests, user.friends);
                _users.Add(newUser);
                whitelisted++;
            }
            else if (danger > 50)
            {
                _users.Remove(user);
                Blacklist newUser = new Blacklist(user.id, user.gameList, user.age, user.reports, user.playtime, user.messages, user.requests, user.friends);
                _users.Add(newUser);
                blacklisted++;
            }
        }
        Console.WriteLine("--#################--");
        Console.WriteLine($"Total Whitelisted: {whitelisted}");
        Console.WriteLine($"Total Blacklisted: {blacklisted}");
        Console.WriteLine("--#################--");

    }





    // The function below is for creating a user // - Not needed for now

    /* public void CreateUser()
    {
        int id;
        int totalGames;
        List<String> gameList = new List<String>();
        double age;
        int reports;

        Console.Write("Enter user ID: ");
        id = Convert.ToInt32(Console.ReadLine());
        Console.Write("How many games do they own? ");
        totalGames = Convert.ToInt32(Console.ReadLine());
        for( int i = 0; i < totalGames; i++)
        {
            string current;
            Console.Write($"Name of game #{i + 1}: ");
            current = Console.ReadLine();
            gameList.Add(current);
        }
        Console.Write("Enter age of the account (in years): ");
        age = Convert.ToDouble(Console.ReadLine());
        Console.Write("How many reports have they received?");
        reports = Convert.ToInt32(Console.ReadLine());

        Neutral newUser = new Neutral(id, gameList, age, reports);
        
        AddUser(newUser);

    }  */


}
