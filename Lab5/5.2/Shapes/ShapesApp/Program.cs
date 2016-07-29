using System;
using System.Collections;
using System.Text;
using ShapeLib;

namespace ShapesApp
{
    public class ShapesManager
    {
        public ArrayList ShapesList;

        public ShapesManager()
        {
            ShapesList = new ArrayList();
        }

        public int Count => ShapesList.Count;

        public object this[int index] => index<ShapesList.Count? ShapesList[index] : null;

        public void Add(Shape newShape)
        {
            ShapesList.Add(newShape);

        }

        public void DisplayAll()
        {
            foreach (Shape shape in ShapesList)
            {
                Console.WriteLine("------------------------");
                shape.Display();
                Console.WriteLine("Area is : " + shape.Area);  
            }
        }

        /**
            Very good!
            Consider this implementation:

            foreach (var persistable in Shapes.OfType<IPersist>())
            {
               persistable.Write(st);
            }

        OfType will select only members which are assignable to an IPersist reference and return such a collection
        https://msdn.microsoft.com/en-us/library/bb360913(v=vs.110).aspx

        */
        public void Save(StringBuilder sb)
        {
            foreach (var shape in ShapesList)
            {
                if (shape is IPersist)
                {
                    IPersist temp  = shape as IPersist;
                    temp.Write(sb);
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            ShapesManager manager = new ShapesManager();

            manager.Add(new Rectangle(2,4));
            manager.Add(new Circle(6));
            manager.Add(new Elipse(5,2 ));

            manager.DisplayAll();

            Console.WriteLine("\nTesting Save Method: ");
            StringBuilder sb = new StringBuilder(); 
            manager.Save(sb);
            Console.WriteLine(sb.ToString());

            Console.WriteLine("\nTesting CompareTo Method: ");
            Console.WriteLine("~Rectangles~");
            var rec1 = new Rectangle(2,2);
            var rec2 = new Rectangle(2,4);
            Console.WriteLine("Copmare rec 1 with rec 2: ");
            Console.WriteLine(rec1.CompareTo(rec2));
            Console.WriteLine("Copmare rec 2 with rec 1: ");
            Console.WriteLine(rec2.CompareTo(rec1));

            Console.WriteLine("\n~Ellipses~");
            var elip1 = new Rectangle(3, 2);
            var elip2 = new Rectangle(1, 4);
            Console.WriteLine("Copmare elip 1 with elip 2: ");
            Console.WriteLine(elip1.CompareTo(elip2));
            Console.WriteLine("Copmare elip 2 with elip 1: ");
            Console.WriteLine(elip2.CompareTo(elip1));
        }
    }
}
