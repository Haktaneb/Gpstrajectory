using System;
using System.Collections.Generic;

namespace Tree
{
   
    public class Point : IComparable<Point>, IComparable
    {
       
        public double x;
        public double y;

        public Point(double xCoord, double yCoord)
        {
            SetPoint(xCoord, yCoord);
        }

       
        public int CompareTo(Point other)
        {
           
            if (other == null) return 1;

            
            int mX = x.CompareTo(other.x);
            int mY = y.CompareTo(other.y);

            if (mX == 0 && mY == 0) return 0;
            else if (mX == 0 && mY == 1) return -1;
            else if (mX == 1 && mY == 0) return 1;
            else return 0;
        }

        
        public int CompareTo(Object obj)
        {
            if (obj == null) return 1;

            Point p = obj as Point;
            if (p != null)
            {
                int mX = this.x.CompareTo(p.x);
                int mY = this.y.CompareTo(p.y);
                if (mX == 0 && mY == 0) return 0;
                else if (mX == 0 && mY == 1) return -1;
                else if (mX == 1 && mY == 0) return 1;
                else return 0;
            }
            else
                throw new ArgumentException("Object is not a Temperature");
        }

      
        public static bool operator ==(Point a, Point b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return true;
            if (a[0] == b[0] && a[1] == b[1]) return true;
            else return false;
        }

      
        public static bool operator !=(Point a, Point b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return true;
            if (a[0] != b[0] || a[1] != b[1]) return true;
            else return false;
        }

       
        public double this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else throw new System.IndexOutOfRangeException("index " + index + " is out of range");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else throw new System.IndexOutOfRangeException("index " + index + " is out of range");
            }

        }

        
        public void SetPoint(double xCoord, double yCoord)
        {
            x = xCoord;
            y = yCoord;
        }

       
        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }
}