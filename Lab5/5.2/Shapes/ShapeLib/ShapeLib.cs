using System;
using System.Text;


namespace ShapeLib
{
    public interface IPersist
    {
        void Write(StringBuilder sb);
    }

    public abstract class Shape
    {
        private ConsoleColor _color;

        public abstract double Area { get; } //readonly


        protected Shape(ConsoleColor reColor)
        {

            _color = reColor;
        }

        protected Shape()
        {
            _color = ConsoleColor.White;
        }

        public virtual void Display()
        {
            Console.BackgroundColor = _color;
        }

    }

    public class Rectangle : Shape, IPersist ,IComparable
    {
        private double _hight;
        private double _width;

        public Rectangle(double hight, double width)
        {
            _hight = hight;
            _width = width;
        }
        public Rectangle(double hight, double width, ConsoleColor reColor) : base(reColor)
        {
            _hight = hight;
            _width = width;
        }

        
        public override double Area => (_hight * _width) / 2;

        public override void Display()
        {
            StringBuilder sb = new StringBuilder();
            Write(sb);
            Console.WriteLine(sb);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("Rectangle : ").AppendLine("Hight : " + _hight).AppendLine("Widgt : " + _width);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Rectangle temp = obj as Rectangle;

            if (temp != null)
                return Area.CompareTo(temp.Area);
            return 1;
        }
    }

    public class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public Circle(double radius, ConsoleColor reColor) : base(reColor)
        {
            _radius = radius;
        }


        public override double Area
        {
            get { return _radius * _radius * Math.PI; }
        }

        public override void Display()
        {
            Console.WriteLine("Circle : ");
            Console.WriteLine($"Radius : {_radius}");
        }
    }

    public class Elipse : Shape , IPersist , IComparable
    {
        private double _radiusOne;
        private double _radiusTwo;

        public Elipse(double radiusOne, double radiusTwo)
        {
            _radiusOne = radiusOne;
            _radiusTwo = radiusTwo;
        }

        public Elipse(double radiusOne, double radiusTwo, ConsoleColor reColor) : base(reColor)
        {
            _radiusOne = radiusOne;
            _radiusTwo = radiusTwo;
        }



        public override double Area
        {
            get { return _radiusOne * _radiusTwo * Math.PI; }
        }

        public override void Display()
        {
            StringBuilder sb = new StringBuilder();
            Write(sb);
            Console.WriteLine("Elipse : ");
            Console.WriteLine(sb);
            //vConsole.WriteLine($"Radius One: {_radiusOne}");
            //Console.WriteLine($"Radius Two: {_radiusTwo}");
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("Circle : ").AppendLine("Radius One: " + _radiusOne).AppendLine("Radius Two: " + _radiusTwo); 
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Elipse temp = obj as Elipse;

            if (temp != null)
                return Area.CompareTo(temp.Area);
            return 1;
        }
    }


}
