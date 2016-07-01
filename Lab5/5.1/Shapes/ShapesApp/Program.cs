using System;
using System.Collections;
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

        public object this[int index] => index < ShapesList.Count ? ShapesList[index] : null;

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


        }
    }
}
