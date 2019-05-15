using System;
using System.Collections.Generic;
using SplashKitSDK;
public abstract class User
{
    private int _playtime;
    protected int _id;
    private double _age;

    private int _messagesOutgoing;
    private int _friendRequestsOutgoing;
    private int _friends;
    private int _reports;

    public virtual int assignment { get; set; }


    private List<String> _gameList = new List<string>();

    public User(int id, List<string> gameList, double age, int reports, int playtime, int messages, int requests, int friends)
    {
        _id = id;
        _age = age;
        _reports = reports;
        _gameList = gameList;
        _playtime = playtime;
        _messagesOutgoing = messages;
        _friendRequestsOutgoing = requests;
        _friends = friends;

        Console.WriteLine($"### User: {id} - Attributes ###");
        Console.WriteLine($"Playtime: {_playtime}");
        Console.WriteLine($"Messages Outgoing: {_messagesOutgoing}");
        Console.WriteLine($"Friend Requests Sent: {_friendRequestsOutgoing}");
        Console.WriteLine($"Successful Friend Requests: {_friends}");

    }

    public int id
    {
        get { return _id; }
    }
    public int reports
    {
        get { return _reports; }
    }

    public double age
    {
        get { return _age; }
    }

    public List<String> gameList
    {
        get { return _gameList; }
    }

    public int playtime
    {
        get { return _playtime; }
    }

    public int messages
    {
        get { return _messagesOutgoing; }

    }

    public int requests
    {
        get { return _friendRequestsOutgoing; }
    }

    public int friends
    {
        get { return _friends; }
    }



    public abstract void Print();


    public double HealthAnalysis()
    {
        int score = 1;
        int friendSuccess = _friends / _friendRequestsOutgoing;
        int reportValue = _reports * 5;

        if (_playtime < 100)
        {
            score += 5;
        }
        if (friendSuccess < 0.6)
        {
            score += 10;
            if (friendSuccess < 0.25)
            {
                score += 10;
            }
        }
        if (_age < 0.5)
        {
            score += 5;
            if (_age < 0.1)
            {
                score += 5;
            }
        }
        if (_messagesOutgoing > 200)
        {
            if (_age < 0.001)
            {
                score += 15;
            }
        }

        double danger = score + reportValue;
        Console.WriteLine($"Calculated Danger: {danger}");
        return danger;


    }

}