using System;
using System.Threading;
using Raylib_cs;

Raylib.InitWindow(1200, 800, "yes");
Raylib.SetTargetFPS(60);
Raylib.SetExitKey(0); //Disables the esc key for exiting the window

bool main = true, startGame = false;

if (main == true)
{
    startGame = Menu();
    main = false;
}
if (startGame == true)
{
    Game.StartGame();
}


//Start menu 
static bool Menu()
{
    Texture2D xc = Raylib.LoadTexture(@"xc.png");
    Texture2D title = Raylib.LoadTexture(@"title.png");
    Texture2D exit = Raylib.LoadTexture(@"exit.png");

    while (!Raylib.WindowShouldClose())
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.BLACK);

        //Render start menu textures
        Raylib.DrawTexture(title, (Raylib.GetScreenWidth() - title.width) / 2, Raylib.GetScreenHeight() / 2 - 200, Color.WHITE);
        Raylib.DrawTexture(xc, (Raylib.GetScreenWidth() - xc.width) / 2 , Raylib.GetScreenHeight() / 2, Color.WHITE);
        Raylib.DrawTexture(exit, (Raylib.GetScreenWidth() - exit.width) / 2, Raylib.GetScreenHeight() - 200, Color.WHITE);

        Raylib.EndDrawing();

        //Starts the game if the x and c keys are pressed
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_C))
        {
            Raylib.CloseWindow();
            return true;
        }
        else if(Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
        {
            Raylib.CloseWindow();
        }
    }
    return false;
}
