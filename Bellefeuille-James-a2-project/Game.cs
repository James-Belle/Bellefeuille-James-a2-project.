// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;
using System.Runtime.InteropServices;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        bool leftLeg = true;
        bool window = false;
        bool Fire = false;
        int pawTime = 0;
        Color brightOrange = new Color(180, 100, 50);
        Color darkOrange = new Color(150, 70, 40);

        Color Brown = new Color(80, 40, 10);
        static int frameRate = 20; //how many frames till animation updates
        int[] catStats = [0, 0];
        bool windowOpen = false;
        int heaterWoodLeft = 0;
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Cat Sim");
            Window.SetSize(600, 200);

        }
        int catPosition = 50;
        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void catWalk(int location, int direction)
        {
            //int catLocal = location^2 potentially way to to absolute function
            if (location%frameRate == 0)
            {//this swaps the animation every 8 frames
                leftLeg = !leftLeg;
            }
            //leftLeg = false;
            if (leftLeg)
            {
                // back right leg
                Draw.FillColor = brightOrange;
                Draw.Circle(location -10 *direction, 192, 9);
                Draw.Quad(location -30 * direction, 150, location -20 * direction, 150, location + -10 * direction, 190, location + -18 * direction, 190);
                // back left leg
                Draw.FillColor = darkOrange;
                Draw.Ellipse(location * direction, 168, 10, 13);
                Draw.Ellipse(location + 6 * direction, 172, 12, 9);
                Draw.Quad(location + 0 * direction, 150, location + 10 * direction, 150, location + 3 * direction, 170, location + 13 * direction, 170);

                // front right leg
                Draw.FillColor = brightOrange;
                Draw.Ellipse(location + 30 * direction, 170, 12, 16);
                Draw.Ellipse(location + 36 * direction, 174, 14, 12);
                Draw.Quad(location + 30 * direction, 150, location + 40 * direction, 150, location + 34 * direction, 174, location + 44 * direction, 174);

                //front left leg
                Draw.FillColor = darkOrange;
                Draw.Circle(location + 73 * direction, 194, 8);
                Draw.Quad(location + 50 * direction, 150, location + 60 * direction, 150, location + 73 * direction, 192, location + 65 * direction, 192);
            }
            else
            {
                // back right leg
                Draw.FillColor = brightOrange;
                Draw.Ellipse(location + -30 * direction, 170, 12, 16);
                Draw.Ellipse(location + -24 * direction, 174, 14, 12);
                Draw.Quad(location -30 * direction, 150, location -20 * direction, 150, location -26 * direction, 174, location -16 * direction, 174);

                // back left leg
                Draw.FillColor = darkOrange;
                Draw.Circle(location + 13 * direction, 194, 8);
                Draw.Quad(location + 0 * direction, 150, location + 10 * direction, 150, location + 13 * direction, 192, location + 5 * direction, 192);

                // front right leg
                Draw.FillColor = brightOrange;
                Draw.Circle(location + 50 * direction, 192, 9);
                Draw.Quad(location + 30 * direction, 150, location + 40 * direction, 150, location + 50 * direction, 190, location + 42 * direction, 190);

                //front left leg
                Draw.FillColor = darkOrange;
                Draw.Ellipse(location + 50 * direction, 168, 10, 13);
                Draw.Ellipse(location + 56 * direction, 172, 12, 9);
                Draw.Quad(location + 50 * direction, 150, location + 60 * direction, 150, location + 53 * direction, 170, location + 63 * direction, 170);
            }

            // body
            Draw.FillColor = brightOrange;
            Draw.Capsule(location -30 * direction, 138, location+60 * direction, 136, 13);
        }

        public void CatAction()
        {
            if (catStats[0] < -500 || catStats[0] > 500 || catStats[1] > 500)
            {
                pawTime++;
                if (pawTime < frameRate)
                {
                    Draw.Circle(50, 50, 10);
                }
                else if (pawTime < frameRate * 2)
                {
                    Draw.Circle(50, 50, 20);
                }
                else pawTime = 0;
            }
            else
            {
                Draw.FillColor = brightOrange;
                Draw.Circle(catPosition, 170, 30);
            }
        }

        
        public void backgroundDraw()
        {
            for (int i = 0; i < 30; i++)
            {
                Draw.FillColor = Color.Black;
                Draw.Rectangle(i * 20, 8, 2, 180);
                Draw.FillColor = Brown;
                Draw.Rectangle(i * 20+2, 8, 18, 180);
            }

            Draw.Rectangle(0, 0, 600, 8);
            Draw.Rectangle(0, 188, 600, 12);
        }

        


        public void Furniture()
        {
            // heater
            Draw.FillColor = Color.DarkGray;
            Draw.Rectangle(40, 160, 50, 80);

            // window
            Draw.FillColor = Color.OffWhite;
            Draw.Rectangle(400, 20, 54, 70);
            Draw.FillColor = Color.Blue;
            Draw.Rectangle(402, 55, 50, 30);
            if (windowOpen)
            {

            }
            else
            {
                Draw.FillColor = Color.Blue;
                Draw.Rectangle(402, 24, 50, 30);
            }

            // counter
            Draw.FillColor = Color.Gray;
            Draw.Rectangle(490, 120, 110, 80);
            Draw.FillColor = Color.DarkGray;
            Draw.Rectangle(500, 130, 40, 60);
            Draw.Rectangle(550, 130, 40, 60);

            
        }

        public void Update()
        {
            Window.ClearBackground(Color.White);
            float mouseX = Input.GetMouseX();
            // draw background
            backgroundDraw();
            //draw furniture
            Furniture();


            // draw cat

            // this makes the cat follow the mouse

            if (mouseX > catPosition + 8)// this is +120 so its in the middle of the cat.
            {
                catPosition += 2;
                catWalk(catPosition, 1); // this sends the x coordinate to the cat drawing function
            }
            else if (mouseX < catPosition -8)
            {
                catPosition -= 2;
                catWalk(catPosition, -1); // this sends the x coordinate to the cat drawing function
            }
            else
            {
                CatAction();
            }

            // update stats
            //for (int i = 0; i<1;i++)
            //{
            //catStats[i] += Random.Integer(-1, 1);
            //}
            catStats[0] += Random.Integer(-5, 5);
            catStats[1] += Random.Integer(-4, 6);
            if (windowOpen == true)
            {
                catStats[0] -= 1;
            }
            
            if (heaterWoodLeft > 0)
            {
                catStats[0] += 2;
            }
            //Input.IsMouseButtonPressed
            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {
                Console.WriteLine($"temp {catStats[0]}, food {catStats[1]}");
                if (mouseX > 400 && mouseX< 450)
                {
                    windowOpen = !windowOpen;
                    Console.WriteLine(windowOpen); // testing
                }


                if (mouseX > 500)
                {
                    catStats[1] = 0;
                }
            }
            // add feeding mechanic
            
        }
    }
}
