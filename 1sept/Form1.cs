using System.Diagnostics.Metrics;

namespace hw
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //private int counter = 0;
        //private int k = 0;

        private int counter = 0;
        Random random = new Random();
        int X = 0;
        int Y = 0;

        int XClick = 0;
        int YClick = 0;

        Button CurrentButton;

        bool buttonReleased = true;

        private void button1_Click_1(object sender, EventArgs e)
        {
               counter++;
            buttonCounter.Text = counter.ToString();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Location = new Point(random.Next(0, this.Width - button1.Width), random.Next(0, this.Height - button1.Height));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            X = 0;
            Y = 0;

            XClick = e.X;
            YClick = e.Y;

            buttonReleased = false;

            CurrentButton = new Button
            {
                Location = new Point(XClick, YClick),
                Size = new Size(X, Y)
            };

            this.Controls.Add(CurrentButton);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!buttonReleased)
            {

                if (CurrentButton != null)
                {

                    var newLocationX = 0;
                    var newLocationY = 0;

                    if (e.X - XClick > 0)
                    {
                        X = e.X - XClick;
                        newLocationX = XClick;
                    }
                    else
                    {
                        newLocationX = e.X;
                        X = Math.Abs(XClick - e.X);
                    }
                    if (e.Y - YClick > 0)
                    {
                        Y = e.Y - YClick;
                        newLocationY = YClick;
                    }
                    else
                    {
                        newLocationY = e.Y;
                        Y = Math.Abs(YClick - e.Y);
                    }

                    CurrentButton.Size = new Size(X, Y);
                    CurrentButton.Location = new Point(newLocationX, newLocationY);
                }
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            buttonReleased = true;
        }
    }

    }

