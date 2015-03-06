using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Items
{
    public enum MoveResult
    {
        OK,
        FOOD,
        CRASH
    }

    public class MySnake
    {
        char sign = '*';
        List<Point> body = null;
        public MySnake()
        {
            body  = new List<Point>();
            body.Add(new Point { X = 10, Y = 10 });
            Show();
        }
        public bool Check(int a,int b) 
        {
            foreach(Point p in body)
            {         
                if (p.X == a && p.Y == b)
                {
                    return true;                                   
                }               
            }
            return false;
        }
        public int Score()
        {
            return body.Count;
        }
        public void Show() 
        {
            foreach(Point p in body)
            {
                Console.SetCursorPosition(p.X,p.Y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(sign);
            }
        }


       

        public MoveResult Move(int dx, int dy, Point foodLocation, List<Point> wallPoints)
        {
            //0 - ok, 1 - food, 2 - crash
            Clear();

            if (foodLocation.X == body[0].X + dx && foodLocation.Y == body[0].Y + dy)
            {
                body.Insert(0, foodLocation);
                Show();
                return MoveResult.FOOD;
            }
            foreach (Point p in body) 
            {
                if (p.X == body[0].X + dx && p.Y == body[0].Y + dy) 
                {
                    Show();
                    return MoveResult.CRASH;
                }

            }

            foreach (Point p in wallPoints)
            {
                
                if (p.X == body[0].X + dx && p.Y == body[0].Y + dy)
                {
                    Show();
                    return MoveResult.CRASH;
                }
            }



            for (int i = body.Count-1; i > 0; i--)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }


            body[0].X = body[0].X + dx;
            body[0].Y = body[0].Y + dy;
            Show();

            return MoveResult.OK;
        }

        public void Clear()
        {
            foreach (Point p in body)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }
        }
    }
}
