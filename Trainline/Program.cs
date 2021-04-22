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
            int hour = 14;
            int days = 0;
            int width = 1200;
            int height = 1000;
            string[] gameState = { "intro", "main", "info", "win" };
            string select = gameState[0];

            Raylib.InitWindow(width, height, "Trainline");
            Raylib.SetTargetFPS(30);

            while (!Raylib.WindowShouldClose())
            {
                switch (select)
                {
                    case "intro":
                        //Rectangle rec = (width / 2) - 300, 250, 550, 60;
                        Raylib.BeginDrawing();
                        Raylib.ClearBackground(Color.WHITE);
                        Raylib.DrawText("Trainline", width / 2 - 300, 50, 120, Color.BLACK);
                        //Raylib.DrawRectangleRounded(rec, 20, 20, Color.BLACK);
                        Raylib.DrawText("Start", width / 2 - 120, 250, 60, Color.WHITE);


                        Raylib.EndDrawing();
                        break;

                    case "main":
                        Color timeOfDay = new Color(Cvalue, 230, Cvalue, 150);
                        Raylib.BeginDrawing();
                        switch (time)
                        {

                        }
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
                        Raylib.DrawRectangle(0, 900, 1200, 100, Color.BLACK);

                        Raylib.DrawCircle(100, 100, 100, Color.MAGENTA);
                        set++;
                        time++;
                        if (set == 5)
                        {
                            min = min + 5;
                        }
                        if (min > 55)
                        {
                            min = 0;
                            hour++;
                        }
                        if (hour > 23)
                        {
                            hour = 0;
                            days++;
                        }
                        if (min == 0 || min == 5)
                        {
                            if (hour <= 9)
                            {

                                Raylib.DrawText("Day " + days + ", Clock 0" + hour + ":0" + min, 800, 900, 40, Color.GREEN);
                            }
                            else
                            {
                                Raylib.DrawText("Day " + days + ", Clock " + hour + ":0" + min, 800, 900, 40, Color.GREEN);
                            }
                        }
                        else if (hour <= 9)
                        {
                            Raylib.DrawText("Day " + days + ", Clock 0" + hour + ":" + min, 800, 900, 40, Color.GREEN);
                        }
                        else
                        {
                            Raylib.DrawText("Day " + days + ", Clock " + hour + ":" + min, 800, 900, 40, Color.GREEN);
                        }
                        Raylib.DrawFPS(50, 50);
                        Raylib.EndDrawing();
                        break;

                    case "info":
                        Raylib.BeginDrawing();

                        Raylib.ClearBackground(Color.WHITE);

                        Raylib.DrawCircle(100, 100, 100, Color.BLUE);

                        Raylib.EndDrawing();
                        break;
                }
            }
        }
    }
}

