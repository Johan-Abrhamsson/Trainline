using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

namespace Trainline
{
    class Train
    {
        private string name = "";

        private int[] storage = new int[0];

        private float speed = 0.01f;

        private int cost = 0;
    }
    class city
    {
        private int[] resources = new int[15];
        // 0 = Steel

        private string name = "";
        private int Pop = 0;
        private int level = 0;
    }
    class Track
    {
        private string name = "";
        private int x = 0;
        private int y = 0;
        private List<int> order = new List<int>();

        private int size = 10;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector2 mousePos = Raylib.GetMousePosition();
            int time = 0;
            int Cvalue = 230;
            int set = 0;
            int min = 0;
            int hour = 8;
            string[] gameState = { "intro", "main", "info", "win" };
            string select = gameState[0];

            Raylib.InitWindow(800, 600, "Trainline");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                if (select == gameState[0])
                {
                    Color timeOfDay = new Color(Cvalue, Cvalue, Cvalue, 150);
                    Raylib.BeginDrawing();
                    if (time < 720)
                    {
                        if (set == 5)
                        {
                            Cvalue--;
                            set = 0;
                        }
                        Raylib.ClearBackground(timeOfDay);
                    }
                    else if (time >= 720 && time < 1440)
                    {
                        if (set == 5)
                        {
                            Cvalue++;
                            set = 0;
                        }
                        Raylib.ClearBackground(timeOfDay);
                    }
                    if (time > 1440)
                    {
                        time = 0;
                        set = 0;
                    }
                    List<string> Namn = new List<string>();

                    Raylib.DrawCircle(100, 100, 100, Color.MAGENTA);
                    Raylib.DrawText(hour + ":" + min, 500, 500, 20, Color.ORANGE);
                    set++;
                    time++;
                    if (set == 5)
                    {
                        min = min + 5;
                    }
                    if (min > 60)
                    {
                        min = 0;
                        hour++;
                    }
                    if (hour > 23)
                    {
                        hour = 0;
                    }
                    Raylib.DrawFPS(50, 50);
                    Raylib.EndDrawing();
                }
                else if (select == gameState[1])
                {
                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(Color.WHITE);
                    List<string> Namn = new List<string>();

                    Raylib.DrawCircle(100, 100, 100, Color.BLUE);

                    Raylib.EndDrawing();
                }
            }
        }
    }
}

