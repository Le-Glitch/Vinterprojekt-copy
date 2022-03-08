using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;


public class platform
{
    int prevLevel = 0;
    string deathsText;
    public int level = 2;
    public List<Rectangle> platforms = new List<Rectangle>();
    public Rectangle winArea;
    player player = new player();
    public bool playerAtStart = false;
    public Vector2 startPos;
    Texture2D movement = Raylib.LoadTexture(@"movement.png");



    public void Level(int deaths)
    {
        platforms.Clear();
        winArea = new Rectangle();

        deathsText = deaths.ToString();

        // sets objects for the current level
        switch (level)

        {
            case 1:
                if (prevLevel != level)
                {
                    startPos = new Vector2(10, Raylib.GetScreenHeight() - 100 - player.playerTexture.height);
                }


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

                winArea = new Rectangle(600, -100, 150, 100);

                prevLevel = 1;
                break;

            case 2:
                if (prevLevel != level)
                {
                    playerAtStart = false;
                    startPos = new Vector2(210, 700 - player.playerTexture.height);
                }

                platforms.AddRange(new List<Rectangle>
                    {
                    new Rectangle(0, 0, 100, Raylib.GetScreenHeight()),
                    new Rectangle(100, 0, 700, 100),
                    new Rectangle(750, 250, 50, 600),
                    new Rectangle(200, 700, 100, 100),
                    new Rectangle(500, 700, 100, 100),
                    new Rectangle(650, 550, 150, 50),
                    new Rectangle(200, 460, 100, 25),
                    new Rectangle(100, 300, 100, 25),
                    new Rectangle(450, 200, 100, 25),
                    }
                );

                winArea = new Rectangle(800, 100, 100, 100);

                prevLevel = 2;
                break;
        }


    }

    // Draws out platforms
    public void Draw()
    {
        if (level == 1)
        {
            Raylib.DrawTexture(movement, 50, 500, Color.WHITE);
        }

        for (int i = 0; i < platforms.Count; i++)
        {
            Raylib.DrawRectangleRec(platforms[i], Color.SKYBLUE);
        }

        Raylib.DrawText(deathsText, 10, 10, 50, Color.WHITE);
    }
}