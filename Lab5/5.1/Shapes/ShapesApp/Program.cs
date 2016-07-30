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

        //Very Good!
        public int Count => ShapesList.Count;

         /*
            Please carefully consider the following notes:

            1)Returning a shape would be better for client code

            2) The user of this code will most likely expect that either a value is returned, or an exception will be thrown.
            Returning null will cause his code to throw a NullReferenceException.
            The best thing to do here is naively access the ArrayList's indexer and hope for the best.
            This is since the ArrayList's indexer will behave accordingly, and your class is no more than a wrapper around it.
        */
        public object this[int index] => index < ShapesList.Count ? ShapesList[index] : null;

        /**
            Input validation!
        
        */
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
