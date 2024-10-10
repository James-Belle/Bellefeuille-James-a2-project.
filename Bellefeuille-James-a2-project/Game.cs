// Include code libraries you need below (use the namespace).
using System;
using System.Linq;
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
        bool Fire = false;
        int pawTime = 0;
        Color brightOrange = new Color(180, 100, 50);
        Color darkOrange = new Color(150, 70, 40);

        Color Brown = new Color(80, 40, 10);
        Color coldBrown = new Color(100, 70, 60);
        Color hotBrown = new Color(130, 30, 0);

        Color windowBlue = new Color(100, 110, 200);

        static int frameRate = 20; //how many frames till animation updates
        int tempature = 0;
        int hunger = 0;
        bool windowOpen = false;
        int heaterWoodLeft = 0;
        int[] food = [-1, -1, -1, -1, -1];
        string held = "none"; // this can be none, food, or wood.
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
            if (location%frameRate == 0)
            {//this swaps the animation every 8 frames
                leftLeg = !leftLeg;
            }
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

            // head
            Draw.FillColor = darkOrange;
            Draw.Quad(location + 66 * direction, 124, location + 76 * direction, 116,location + 77 * direction, 132, location + 73 * direction, 140);

            Draw.FillColor = brightOrange;
            Draw.Triangle(location + 85 * direction, 100, location + 87 * direction, 90, location + 95 * direction, 108);
            Draw.Circle(location + 86 * direction, 117, 16);
            Draw.FillColor = Color.OffWhite;
            Draw.Triangle(location + 90 * direction, 120, location + 95 * direction, 112, location + 100 * direction, 120);
            Draw.FillColor = Color.Black;
            Draw.Circle(location + 97 * direction, 118, 2);
        }

        public void CatAction()
        {
            if (tempature < -500 || tempature > 500 || hunger > 800)
            { // here the cat wants something so it paws at the mouse
                pawTime++;
                Draw.FillColor = darkOrange;
                //legs
                Draw.Quad(catPosition - 5, 150, catPosition - 10, 153, catPosition - 13, 190, catPosition - 8, 190);
                Draw.Quad(catPosition + 5, 150, catPosition + 10, 153, catPosition + 13, 190, catPosition + 8, 190);
                
                //body
                Draw.FillColor = brightOrange;
                Draw.Capsule(catPosition, 160, catPosition, 120, 15);
                //feet
                Draw.Circle(catPosition - 13, 190, 6);
                Draw.Circle(catPosition + 13, 190, 6);

                // head
                Draw.Circle(catPosition, 95, 12);


                // paws
                if (pawTime < frameRate)
                {
                    Draw.Circle(catPosition - 14, 60, 7);
                    Draw.Circle(catPosition + 14, 87, 7);


                }
                else if (pawTime < frameRate * 2)
                {
                    Draw.Circle(catPosition + 14, 60, 7);
                    Draw.Circle(catPosition - 14, 87, 7);
                }
                else pawTime = 0;
            }
            else
            { // here the cat is satisfied so it lays down.
                Draw.FillColor = brightOrange;
                Draw.Ellipse(catPosition, 180, 60, 50);
            }
        }

        
        public void backgroundDraw()
        {
            Color Background = Brown;
            if (tempature < -1100)
            {
                Background = coldBrown;
            }
            else if (tempature > 1100)
            {
               Background = hotBrown;
            }
            for (int i = 0; i < 30; i++)
            {
                Draw.FillColor = Color.Black;
                Draw.Rectangle(i * 20, 8, 2, 180);
                Draw.FillColor = Background;
                Draw.Rectangle(i * 20+2, 8, 18, 180);
            }

            Draw.Rectangle(0, 0, 600, 8);
            Draw.Rectangle(0, 188, 600, 12);
        }

        


        public void Furniture()
        {
            
            // heater
            Draw.FillColor = Color.DarkGray;
            Draw.Rectangle(58, 0, 14, 160);
            Draw.Rectangle(30, 140, 70, 60);
            Draw.FillColor = Color.Black;
            if (heaterWoodLeft > 0)
            {
                Draw.FillColor = Color.Red;
            }
            
            Draw.Square(45, 160, 40);
            

            // window
            Draw.FillColor = Color.OffWhite;
            Draw.Rectangle(400, 20, 54, 70);
            if (windowOpen)
            {
                Draw.FillColor = Color.Blue;
                Draw.Rectangle(402, 24, 50, 18);
                Draw.FillColor = windowBlue;
                Draw.Rectangle(402, 44, 50, 40);
                Draw.FillColor = Color.LightGray;
                Draw.Rectangle(402, 55, 50, 18);
            }
            else
            {
                Draw.FillColor = windowBlue;
                Draw.Rectangle(402, 55, 50, 30);
                Draw.FillColor = windowBlue;
                Draw.Rectangle(402, 24, 50, 30);
            }

            // counter
            Draw.FillColor = Color.Gray;
            Draw.Rectangle(490, 120, 110, 80);
            Draw.FillColor = Color.DarkGray;
            Draw.Rectangle(500, 130, 40, 60);
            Draw.Rectangle(550, 130, 40, 60);

            
        }

        public void FoodDraw()
        {
            for (int i = 0; i < 5; i++)
            {
                if (food[i] != -1)
                {
                    Draw.FillColor = Color.LightGray;
                    Draw.Rectangle(food[i], 192, 20, 8);
                    Draw.FillColor = brightOrange;
                    Draw.Circle(food[i] + 10, 196, 3);
                }
            }
        }

        public void DrawUi()
        {
            Draw.FillColor = Color.Blue;
            Draw.Square(550, 0, 50);
            Draw.FillColor = Color.White;
            Draw.Square(555, 5, 40);
            if (held == "wood")
            {
                Draw.FillColor = Brown;
                Draw.Rectangle(560, 20, 20, 10);
            }
            else if (held == "food")
            {
                Draw.FillColor = Color.LightGray;
                Draw.Rectangle(564, 20, 20, 8);
                Draw.FillColor = brightOrange;
                Draw.Circle(574, 24, 3);
            }
        }
        public void Update()
        {
            Window.ClearBackground(Color.White);
            float mouseX = Input.GetMouseX();
            float mouseY = Input.GetMouseY();
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
            else if (mouseX < catPosition - 8)
            {
                catPosition -= 2;
                catWalk(catPosition, -1); // this sends the x coordinate to the cat drawing function
            }
            else
            {
                CatAction();
            }

            //draw food
            FoodDraw();
            //draw ui
            DrawUi();

            // heat and hunger changes.
            tempature += Random.Integer(-5, 5);
            hunger += Random.Integer(-4, 6);
            if (windowOpen == true)
            { // window coolint
                tempature -= 1;
            }

            if (heaterWoodLeft > 0)
            { // heater warming
                tempature += 2;
                heaterWoodLeft -= Random.Integer(0, 2);
            }

            // food tracking
            for (int i = 0; i < 5; i++)
            {
                if (catPosition <= food[i] + 10 && catPosition >= food[i] - 10)
                {
                    food[i] = -1;
                    hunger -= 200;
                }
            }

            if (hunger < 0)
            {
                hunger = 0;
            }


            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {
                Console.WriteLine($"temp {tempature}, food {hunger}, Wood {heaterWoodLeft}, food {food[0]}"); // this is for debugging and will be commented out
                if (held == "none")
                {
                    if (mouseX > 400 && mouseX < 450 && mouseY > 20 && mouseY < 90)
                    {
                        windowOpen = !windowOpen;
                        Console.WriteLine(windowOpen); // testing
                    }

                    if (mouseX > 500 && mouseY > 130)
                    {
                        if (mouseX > 550)
                        {
                            held = "food";
                        }
                        else
                        {
                            held = "wood";
                        }

                    }
                }
                else if (held == "wood")
                {
                    if (mouseX > 500 && mouseX < 550 && mouseY > 130)
                    {
                        held = "none";
                    }
                    else if (mouseX < 100 && mouseX > 30 && mouseY > 140)
                    {
                        held = "none";
                        heaterWoodLeft += 150;
                    }
                }
                else if (held == "food")
                {
                    if (mouseX > 550 && mouseY > 130)
                    {
                        held = "none";
                    }
                    else
                    {
                        bool quitLoop = false;
                        for (int i = 0; i < 5; i++)
                        {
                            if (catPosition <= food[i] - 5 && catPosition >= food[i] + 5)
                            {
                                food[i] = -1;
                                hunger -= 300;
                            }
                            if (food[i] == -1 && quitLoop == false)
                            {
                                food[i] = (int)mouseX;
                                quitLoop = true;
                                held = "none";
                            }
                        }
                    }
                }
            }
            // add feeding mechanic

        }
    }
}
