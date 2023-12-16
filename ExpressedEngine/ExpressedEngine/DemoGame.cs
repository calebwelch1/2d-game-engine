using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressedEngine.ExpressedEngine;

namespace ExpressedEngine
{
    class DemoGame : ExpressedEngine.ExpressedEngine
    {
        public DemoGame() : base(new Vector2(615, 515), "Expressed Engine Demo") { }

        public override void OnDraw()
        {
            Console.WriteLine("On load works");

        }

        public override void OnLoad()
        {
            // anything that needs to be loaded into the game before the renderer starts
            Console.WriteLine("On load works");
        }

        int frame = 0;
        public override void OnUpdate()
        {
            Console.WriteLine($"Frame Count: {frame} ");
            frame++;

        }
    }
}
