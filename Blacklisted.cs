using System;
using System.Collections.Generic;
using SplashKitSDK;

public class Blacklist : User
{

    public Blacklist(int id, List<String> gameList, double age, int reports, int playtime, int messages, int requests, int friends) : base(id, gameList, age, reports, playtime, messages, requests, friends)
    {
        assignment = 2;
    }

    public override void Print()
    {
        Console.WriteLine("#################");
        Console.WriteLine("__Blacklisted__");
        Console.WriteLine($"User ID: {id}");
        Console.WriteLine($"Account Age: {age}");
        Console.WriteLine($"Reports Gained: {reports}");
        Console.WriteLine("#################");
    }
}