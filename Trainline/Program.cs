using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

namespace Trainline
{
    class Train
    {
        public string name = "";

        public int[] storage = new int[0];

        public float speed = 0.01f;
        public int cost = 0;

        public Vector2 xy = new Vector2(0, 0);
    }
    class city
    {
        private int[] resources = new int[15];
        // 0 = Steel

        private string name = "";
        private int Pop = 0;
        private int level = 0;
    }
    public class Stop
    {
        public Vector2 xy = new Vector2(0, 0);
        public Color stopColor = Color.WHITE;
    }
    public class Track
    {
        public string name = "";
        public int size = 25;
        private static Random generator = new Random();
        public static Color colorLock = new Color(
        generator.Next(255),
        generator.Next(255),
        generator.Next(255),
        255
        );
        public List<Stop> stopOrder = new List<Stop>();

        public void OrderAdd(int xStop, int yStop)
        {
            stopOrder.Add(new Stop { xy = new Vector2(xStop, yStop), stopColor = colorLock });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector2 mousePos = Raylib.GetMousePosition();
            int time = 0;
            int Cvalue = 220;
            int set = 0;
            int min = 0;
            int hour = 14;
            int days = 0;
            int width = 1200;
            int height = 1000;
            string[] gameState = { "intro", "main", "info", "settings", "win" };
            string select = gameState[0];
            Color timeOfDay = new Color(Cvalue, Cvalue, Cvalue - 60, 150);
            Track Traintrack = new Track() { name = "Tomoul track" };
            Traintrack.OrderAdd(100, 200);
            Traintrack.OrderAdd(950, 700);
            Train Cooltrain = new Train() { name = "Tomoul Train", storage = new int[5], speed = 2f, cost = 500, xy = new Vector2(Traintrack.stopOrder[0].xy.X - 25, Traintrack.stopOrder[0].xy.Y - 10) };

            Raylib.InitWindow(width, height, "Trainline");
            Raylib.SetTargetFPS(30);

            while (!Raylib.WindowShouldClose())
            {

                switch (select)
                {
                    case "intro":

                        Raylib.BeginDrawing();
                        Raylib.ClearBackground(timeOfDay);
                        Raylib.DrawText("Trainline", width / 2 - 300, 50, 120, Color.BLACK);
                        Raylib.DrawRectangle(width / 2 - 120, height / 2 - 120, 220, 100, Color.BLACK);
                        Raylib.DrawText("Start", width / 2 - 100, height / 2 - 100, 60, Color.WHITE);
                        Raylib.DrawRectangle(width / 2 - 150, height / 2, 300, 100, Color.BLACK);
                        Raylib.DrawText("Settings", width / 2 - 130, height / 2 + 20, 60, Color.WHITE);
                        mousePos = Raylib.GetMousePosition();
                        Vector2 startPosMin = new Vector2(width / 2 - 120, height / 2 - 120);
                        Vector2 startPosMax = new Vector2(width / 2 + 100, height / 2 - 20);
                        Vector2 settingsPosMin = new Vector2(width / 2 - 150, height / 2);
                        Vector2 settingsPosMax = new Vector2(width / 2 + 150, height / 2 + 120);
                        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) == true && mousePos.X >= startPosMin.X && mousePos.Y >= startPosMin.Y && mousePos.X <= startPosMax.X && mousePos.Y <= startPosMax.Y)
                        {
                            select = gameState[1];
                        }
                        else if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) == true && mousePos.X >= settingsPosMin.X && mousePos.Y >= settingsPosMin.Y && mousePos.X <= settingsPosMax.X && mousePos.Y <= settingsPosMax.Y)
                        {
                            select = gameState[3];
                        }


                        Raylib.EndDrawing();
                        break;

                    case "main":
                        timeOfDay = new Color(Cvalue, Cvalue, Cvalue - 60, 150);
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
                        Raylib.DrawRectangle(0, 900, 1200, 100, Color.BLACK);
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
                        trainmove(Cooltrain, Traintrack);
                        break;

                    case "info":
                        Raylib.BeginDrawing();

                        Raylib.ClearBackground(Color.WHITE);

                        Raylib.DrawCircle(100, 100, 100, Color.BLUE);

                        Raylib.EndDrawing();
                        break;
                    case "settings":

                        Raylib.BeginDrawing();

                        Raylib.ClearBackground(Color.WHITE);
                        Raylib.DrawCircle(100, 100, 100, Color.BLUE);
                        Raylib.EndDrawing();
                        break;
                }
            }
        }
        static void trainmove(Train trainMove, Track trackNow)
        {
            for (int i = 0; i < trackNow.stopOrder.Count; i++)
            {
                Raylib.DrawCircle((int)trackNow.stopOrder[i].xy.X, (int)trackNow.stopOrder[i].xy.Y, trackNow.size, trackNow.stopOrder[i].stopColor);
            Raylib.DrawRectangle((int)trainMove.xy.X, (int)trainMove.xy.Y, 50, 20, Color.BLACK);
            Vector2 k = trainMove.xy - trackNow.stopOrder[i].xy;

            Vector2 n = Vector2.Normalize(k);

            n = n * trainMove.speed;
            }
        }
    }
}

