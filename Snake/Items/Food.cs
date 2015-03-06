using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Items
{
    public class Food
    {
        char sign = 'o';
        public Point location = new Point();
        public Food()
        {
            {
                location.X = new Random().Next() % 40;
                location.Y = new Random().Next() % 40;
                Show();
            }
        }

        public void Show()
        {
            Console.SetCursorPosition(location.X,location.Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(sign);
        }

    }
}
