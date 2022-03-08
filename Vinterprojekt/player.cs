using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

public class player
{
    float gravity;
    public Texture2D playerTexture;

    public Vector2 position = new Vector2(1, 1);
    Vector2 speed = new Vector2(0, 10);
    public Rectangle playerRect;

    bool collisionCheckHorizontal = false;
    bool collisionCheckVertical = false;
    int animFrame = 0;
    int fpsPerFrame = 15;
    bool isJumping = false;
    string direction = "right";

    public int deaths = 0;





    // Arrays for animation
    public Texture2D[] rightAnimation = {
            Raylib.LoadTexture("player-right1.png"),
            Raylib.LoadTexture("player-right2.png")
        };

    public Texture2D[] leftAnimation = {
        Raylib.LoadTexture("player-left1.png"),
        Raylib.LoadTexture("player-left2.png")
    };

    // Creates a rectangle for collision detection when the class is called
    public player()
    {
        playerRect = new Rectangle((int)position.X, (int)position.Y, playerTexture.width, playerTexture.height);
    }



    // All code for player movement
    public void Movement(List<Rectangle> platforms)
    {
        PlayerX();
        xCollision();

        if (collisionCheckHorizontal && Raylib.IsKeyPressed(KeyboardKey.KEY_X))
        {
            WallJump();
        }

        PlayerY();

        GravitySim();
        yCollision();


        speed.X = 0;

        // Code to change the players x-axis
        void PlayerX()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                if (!isJumping)
                {
                    playerTexture = rightAnimation[animFrame / fpsPerFrame];
                    animFrame++;

                    if (animFrame >= rightAnimation.Length * fpsPerFrame)
                    {
                        animFrame = 0;
                    }
                }


                speed.X = 5;

                direction = "right";
            }
            else if (direction == "right" && !isJumping)
            {
                playerTexture = rightAnimation[0];
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                if (!isJumping)
                {
                    playerTexture = leftAnimation[animFrame / fpsPerFrame];
                    animFrame++;

                    if (animFrame >= leftAnimation.Length * fpsPerFrame)
                    {
                        animFrame = 0;
                    }
                }

                speed.X = -5;
                direction = "left";
            }
            else if (direction == "left" && !isJumping)
            {
                playerTexture = leftAnimation[0];
            }

            position.X += speed.X;


        }

        // Checks collisions for x-axis
        void xCollision()
        {
            foreach (Rectangle platform in platforms)
            {
                collisionCheckHorizontal = Raylib.CheckCollisionRecs(platform, new Rectangle((int)position.X, (int)position.Y, playerTexture.width, playerTexture.height));
                if (collisionCheckHorizontal)
                {
                    position.X -= speed.X;
                    gravity /= 2;
                    speed.Y = 0;

                    if (direction == "right")
                    {
                        playerTexture = rightAnimation[0];
                    }
                    else if (direction == "left")
                    {
                        playerTexture = leftAnimation[0];
                    }

                    break;
                }
            }
        }

        // Code to change the players y-axis
        void PlayerY()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_X) && !isJumping)
            {
                speed.Y = 10;
                isJumping = true;
            }

            if (isJumping == true)
            {
                position.Y -= speed.Y;

                if (direction == "right")
                {
                    playerTexture = rightAnimation[1];
                }
                if (direction == "left")
                {
                    playerTexture = leftAnimation[1];
                }
            }
        }

        void GravitySim()
        {
            if (position.Y < Raylib.GetScreenHeight() - playerTexture.height)
            {
                position.Y += gravity;
                gravity += 0.25f;
            }
        }

        // Checks collisions for y-axis
        void yCollision()
        {
            foreach (Rectangle platform in platforms)
            {
                collisionCheckVertical = Raylib.CheckCollisionRecs(platform, new Rectangle((int)position.X, (int)position.Y, playerTexture.width, playerTexture.height));
                if (collisionCheckVertical)
                {
                    if (position.X + playerTexture.width > platform.x && position.X < platform.x + platform.width)
                    {
                        if (position.Y + playerTexture.height < platform.y + platform.height / 2)
                        {
                            position.Y = platform.y - playerTexture.height;
                            gravity = 0;
                            isJumping = false;
                        }
                        else if (position.Y > platform.y + platform.height / 2)
                        {
                            position.Y += speed.Y;
                            speed.Y /= 2;
                        }
                    }
                    break;
                }
            }
        }

        void WallJump()
        {
            speed.X = 10;
            speed.Y = 10;

            position.Y -= speed.Y;

            if (direction == "right")
            {
                position.X -= speed.X;
            }
            else if (direction == "left")
            {
                position.X += speed.X;
            }
        }
    }

    public bool death()
    {
        if (position.Y + playerTexture.height >= Raylib.GetScreenHeight())
        {
            deaths++;
            return false;
        }
        else
        {
            return true;
        }
    }

    // Draws the players character
    public void Draw()
    {
        Raylib.DrawTexture(playerTexture, (int)position.X, (int)position.Y, Color.WHITE);
    }
}
