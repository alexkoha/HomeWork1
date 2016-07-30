using System;

namespace ShapeLib
{

    /**
    Please refrain from implementing so many classes in one file.

    */

    public abstract class Shape
    {
        private ConsoleColor _color;

        public abstract double Area { get; } //readonly


        /*
        
         No input validation:
         
         Syntactically, this is correct:
         
         var color = (ConsoleColor)9999;
         var shape = new MyShape(color);
         
         This will not throw a runtime exception, despite the fact that there is no such a memeber in the enumeration.
         Consider using Enum.IsDefined
         https://msdn.microsoft.com/en-us/library/system.enum.isdefined(v=vs.110).aspx
         
         This will enable you to detect invalid instances
         And destroy them before they are used by throwing an exception from within the constructor
         
       */

        protected Shape(ConsoleColor reColor)
        {

            _color = reColor;
        }

        /*
         It is a good practice to delegate initialization logic to a single constructor.
         This is in accordance to the DRY (Dont Repeat Yourself) principle
         
         A DRY implementation of the default constructor would be:
         
          public Shape():this(ConsoleColor.White)
          {
          }
         */
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
        /*
        * No Input validation!
        
        *It is a good practice to delegate initialization logic to a single constructor.
         Although, it is not always possible- in which case all constructors delegate the initialization to a common method
         This is in accordance to the DRY (Dont Repeat Yourself) principle
         
        A DRY instantiation implementation for this class would be:
            
        public Rectangle(ConsoleColor color,int width, int height):base(color)
        {
          Initialize(width,height);
        }
        
        public Rectangle(int width, int height):base(color)
        {
           Initialize(width,height);
        }
        
        private void Initialize(int width, int height)
        {
             _width = width;
            _height = height;
            _area = _width*_height;
        }
        
        */
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

        /**
        Calculating on request is generally a good practice
        But this time the computation should be done at construct time since it's value is 'constant'
        */
        public override double Area => (_hight * _width) / 2;

        /*
        What about setting the color?
        You are missing 'base.Display();'

        */
        public override void Display()
        {
            Console.WriteLine("Rectangle : ");
            Console.WriteLine("Hight : " + _hight);
            Console.WriteLine("width : " + _width);
        }


    }

    /**
        Circle should actually be a derived class of Ellipse, as it is in Geometry
        It was also in the instructions.
    */
    public class Circle : Shape
    {
        private double _radius;

        /*
        * No input validation
        * Refer to my notes regarding a DRY constructor in the Shape and Rectangle clases
        */
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

        /*
        What about setting the color?
        You are missing 'base.Display();'

        */
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

        /*
        * No input validation
        * Refer to my notes regarding a DRY constructor in the Shape and Rectangle clases
        */
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

        /*
        What about setting the color?
        You are missing 'base.Display();'

        */
        public override void Display()
        {
            Console.WriteLine("Elipse : ");
            Console.WriteLine($"Radius One: {_radiusOne}");
            Console.WriteLine($"Radius Two: {_radiusTwo}");
        }

    }

}
