using System;
using System.Linq;
using RpsDbContext.Models;



namespace RockPaperScissorsV1
{
    partial class Program
    {
        static void Main(string[] args)
        {

            RpsGameDbContext context = new RpsGameDbContext();
            //if (context.Database.EnsureCreated()) Console.WriteLine("it is created!");



            //var players = context.Players.Where(x => x.PlayerFname == "Mark").FirstOrDefault();
            //Console.WriteLine($"The result is {players.PlayerFname} {players.PlayerLname}");
            //var players = context.Players.FirstOrDefault();
            //var players = context.Players.ToList<T>;

            //var result = context.Players.FromSqlRaw($"SELECT * FROM Players").tolist();
            //var result = context.Players.;
            //var result = context.FromSqlRaw("SELECT * FROM Player");

            //var result = context.Players.FromSqlRaw



            foreach (var p in context.Players)
            {
                //Console.WriteLine($"The result is {p.PlayerFname} {p.PlayerLname}");
                var test = p.PlayerFname;
                Console.WriteLine($"Name: {test}");
                p.PlayerAddress = "Nw Tst Road";        // changes the address of all players to this
            }


            //var newPlayer = new RpsDbContext.Models.Player();       // create new object from database types

            //// set object attributes
            //newPlayer.PlayerFname = "Luke";                         
            //newPlayer.PlayerLname = "Scott";        
            //newPlayer.PlayerAge = 23;
            //newPlayer.PlayerAddress = "413 N Walabee";



            //context.Add(newPlayer);     // add the new object to the database

            //context.SaveChanges();      // save and update changes



            Console.WriteLine($"IM HERE");


            //int i = 9;
            //double x = i;
            //Console.WriteLine(x);
            // Create new Rock Paper Scissors game
            RpsGame currentGame = new RpsGame();

            // Start the RPS game
            currentGame.StartGame();
            //currentGame.testMethod

        }

    }
}
