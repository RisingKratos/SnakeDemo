using Snake.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MapGeneratorCV
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();
                    
            using (FileStream fs = new FileStream("Map1.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    int y = -1;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine().Trim();
                        y++;
                        for (int x = 0; x < line.Length; ++x)
                        {
                            if (line[x] == '#')
                            {
                                Point p = new Point();
                                p.X = x;
                                p.Y = y;
                                points.Add(p);
                            }
                        }
                    }
                }
            }

           XmlSerializer xmls = new XmlSerializer(typeof(List<Point>));
           using (FileStream fs = new FileStream("Map1.xml", FileMode.Create))
           {
               xmls.Serialize(fs,points);
           }


        }
    }
}
