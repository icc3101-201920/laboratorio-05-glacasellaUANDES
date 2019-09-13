using Laboratorio_4_OOP_201902.Cards;
using System;
using System.Collections.Generic;

namespace Laboratorio_4_OOP_201902
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.AddDecks();
            game.AddCaptains();
            Console.WriteLine(game.Captains[0].Name);
        }   
    }
}
