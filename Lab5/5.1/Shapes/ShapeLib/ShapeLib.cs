using System;

namespace ShapeLib
{

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

    public class Rectangle : Shape
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
            Console.WriteLine("Rectangle : ");
            Console.WriteLine("Hight : " + _hight);
            Console.WriteLine("width : " + _width);
        }


    }

    public class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public Circle(double radius,ConsoleColor reColor) : base(reColor)
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

    public class Elipse : Shape 
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
            Console.WriteLine("Elipse : ");
            Console.WriteLine($"Radius One: {_radiusOne}");
            Console.WriteLine($"Radius Two: {_radiusTwo}");
        }

    }

}
