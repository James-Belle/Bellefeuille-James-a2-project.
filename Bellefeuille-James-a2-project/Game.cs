// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;

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
        int pawTime = 0;
        Color brightOrange = new Color(180, 100, 50);
        Color darkOrange = new Color(150, 70, 40);
        static int frameRate = 20; //how many frames till animation updates
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
        public void catWalk(int location)
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
                Draw.Circle(location + 90, 192, 9);
                Draw.Quad(location + 70, 150, location + 80, 150, location + 90, 190, location + 82, 190);
                // back left leg
                Draw.FillColor = darkOrange;
                Draw.Ellipse(location + 100, 168, 10, 13);
                Draw.Ellipse(location + 106, 172, 12, 9);
                Draw.Quad(location + 100, 150, location + 110, 150, location + 103, 170, location + 113, 170);

                // front right leg
                Draw.FillColor = brightOrange;
                Draw.Ellipse(location + 130, 170, 12, 16);
                Draw.Ellipse(location + 136, 174, 14, 12);
                Draw.Quad(location + 130, 150, location + 140, 150, location + 134, 174, location + 144, 174);

                //front left leg
                Draw.FillColor = darkOrange;
                Draw.Circle(location + 173, 194, 8);
                Draw.Quad(location + 150, 150, location + 160, 150, location + 173, 192, location + 165, 192);
            }
            else
            {
                // back right leg
                Draw.FillColor = brightOrange;
                Draw.Ellipse(location + 70, 170, 12, 16);
                Draw.Ellipse(location + 76, 174, 14, 12);
                Draw.Quad(location + 70, 150, location + 80, 150, location + 74, 174, location + 84, 174);

                // back left leg
                Draw.FillColor = darkOrange;
                Draw.Circle(location + 113, 194, 8);
                Draw.Quad(location + 100, 150, location + 110, 150, location + 113, 192, location + 105, 192);

                // front right leg
                Draw.FillColor = brightOrange;
                Draw.Circle(location + 150, 192, 9);
                Draw.Quad(location + 130, 150, location + 140, 150, location + 150, 190, location + 142, 190);

                //front left leg
                Draw.FillColor = darkOrange;
                Draw.Ellipse(location + 150, 168, 10, 13);
                Draw.Ellipse(location + 156, 172, 12, 9);
                Draw.Quad(location + 150, 150, location + 160, 150, location + 153, 170, location + 163, 170);
            }

            // body
            Draw.FillColor = brightOrange;
            Draw.Capsule(location + 70, 138, location+160, 136, 13);
        }

        public void catPaw()
        {
            pawTime++;
            if (pawTime < frameRate)
            {
                Draw.Circle(50, 50, 10);
            }
            else if (pawTime < frameRate*2)
            {
                Draw.Circle(50, 50, 20);
            }
            else pawTime = 0;
        }
        public void Update()
        {
            Window.ClearBackground(Color.White);
            float mouseX =Input.GetMouseX();

            

            // this makes the cat follow the mouse
            if (mouseX > catPosition+122)// this is +120 so its in the middle of the cat.
            {
                catPosition+=2;
                catWalk(catPosition); // this sends the x coordinate to the cat drawing function
            }
            else if (mouseX < catPosition+118)
            {
                catPosition-=2;
                catWalk(catPosition); // this sends the x coordinate to the cat drawing function
            }
            else
            {
                catPaw();
            }


        }
    }
}
