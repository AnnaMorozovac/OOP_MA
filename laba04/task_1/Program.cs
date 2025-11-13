using System;

class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Rectangle
{
    public Point TopLeft { get; }
    public Point BottomRight { get; }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    public bool Contains(Point p)
    {
        return p.X >= TopLeft.X && p.X <= BottomRight.X &&
               p.Y >= TopLeft.Y && p.Y <= BottomRight.Y;
    } 
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введiть координати лiвого верхнього та правого нижнього кута прям.:");
        string[] rectTemp = Console.ReadLine().Split(' ');
        int topLeftX = int.Parse(rectTemp[0]);
        int topLeftY = int.Parse(rectTemp[1]);
        int bottomRightX = int.Parse(rectTemp[2]);
        int bottomRightY = int.Parse(rectTemp[3]);

        Rectangle rect = new Rectangle(new Point(topLeftX, topLeftY),
                                       new Point(bottomRightX, bottomRightY));

        Console.Write("Цiле число N: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Координати точок: ");
        Point[] points = new Point[n];
        for (int i=0; i<n; i++)
        {
            string[] point = Console.ReadLine().Split(' ');
            int x = int.Parse(point[0]);
            int y = int.Parse(point[1]);

            points[i] = new Point(x, y);
        }

        Console.WriteLine(" ");
        Console.WriteLine("Результат: ");
        for(int i=0; i<n; i++)
        {
            Console.WriteLine(rect.Contains(points[i])); 
        }

    }
}