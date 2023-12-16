using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ExpressedEngine.ExpressedEngine
{

    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }
    public abstract class ExpressedEngine
    {
        private Vector2 ScreenSize = new Vector2(512, 512);
        private string Title = "New Game";
        private Canvas Window = null;
        private Thread GameLoopThread = null;

        public ExpressedEngine(Vector2 ScreenSize, string Title)
        {
            this.ScreenSize = ScreenSize;
            this.Title = Title;

            // creating window
            // continuously call redraw whenever we can
            // wan't meant to be a game window so difficult to redraw windows forms with many many game objects so we add this.DoubleBufferd

            Window = new Canvas();
            Window.Size = new Size((int)this.ScreenSize.X, (int)this.ScreenSize.Y);
            Window.Text = this.Title;
            Window.Paint += Renderer;


            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(Window);
        }

        void GameLoop()
        {
            OnLoad();

            while (GameLoopThread.IsAlive)
            {
                try
                {
                    // anything for drawing inside update
                    OnDraw();
                    // our game loop
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    // anything regarding movement or physics
                    OnUpdate();
                    // add delay to allow Window leeway to refresh otherwise it will refresh on top of a refresh call and freeze
                    Thread.Sleep(1);
                }
                catch
                {
                    Console.WriteLine("Game is loading");
                }
  
            }
        }

        private void Renderer(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();


    }
}
