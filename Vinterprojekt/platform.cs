using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;


public class platform
{
    public int level = 1;
    public List<Rectangle> platforms = new List<Rectangle>();
    public Rectangle winArea;
    player player = new player();
    public bool playerAtStart = false;
    public Vector2 startPos;

    public void Level()
    {
        platforms.Clear();
        winArea = new Rectangle();

        // sets objects for the current level
        switch (level)
        {
            case 1:
                platforms.AddRange(new List<Rectangle>
                        {
                        new Rectangle(0, Raylib.GetScreenHeight() - 100, Raylib.GetScreenWidth(), 100),
                        new Rectangle(Raylib.GetScreenWidth() - 250, Raylib.GetScreenHeight() - 250, 200, 150),
                        new Rectangle(Raylib.GetScreenWidth() - 50, 0, 50, Raylib.GetScreenHeight()),
                        new Rectangle(0, 0, 100, 450),
                        new Rectangle(100, 400, 200, 50),
                        new Rectangle(100, 0, 500, 100),
                        new Rectangle(Raylib.GetScreenWidth() - 250, 300, 200, 50)
                        }
                    );

                startPos = new Vector2(10, Raylib.GetScreenHeight() - 100 - player.playerTexture.height);
                winArea = new Rectangle(600, -100, 150, 100);
            break;
            
            case 2:


            break;
        }

        
    }

    // Draws out platforms
    public void Draw()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            Raylib.DrawRectangleRec(platforms[i], Color.SKYBLUE);
        }
    }
}