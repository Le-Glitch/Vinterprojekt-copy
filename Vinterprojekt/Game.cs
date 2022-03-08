using System;
using System.Threading;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

public class Game
{
    public static void StartGame()
    {
        Raylib.InitWindow(800, 800, "yes");
        Raylib.SetTargetFPS(60);
        Raylib.SetExitKey(0);

        player p = new player();
        platform plat = new platform();



        while (!Raylib.WindowShouldClose())
        {
            plat.Level(p.deaths);
            p.Movement(plat.platforms);

            // Sets the players starting position
            if (plat.playerAtStart == false)
            {
                p.position = plat.startPos;

                plat.playerAtStart = true;
            }

            plat.playerAtStart = p.death();

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);

            p.Draw();
            plat.Draw();

            Raylib.EndDrawing();

            if (Raylib.CheckCollisionPointRec(p.position, plat.winArea))
            {
                plat.level++;
                plat.playerAtStart = false;
            }
        }
    }
}