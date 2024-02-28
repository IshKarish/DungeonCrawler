﻿namespace DungeonCrawler;

class Program
{
    public static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        
        Character player = new Character();
        
        Object obj = new Object(3, 4, 2, 6);
        Object obj2 = new Object(6, 2, 7, 14);
        Object obj3 = new Object(4, 4, 18, 18);
        Object[] objects = { obj, obj2, obj3 };

        Game game = gameManager.CreateGame(20, player, objects);
        gameManager.StartGame(game);
    }
}