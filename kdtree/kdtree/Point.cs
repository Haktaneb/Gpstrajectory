using System;
using System.Collections.Generic;

namespace Tree
{
	/// <summary>
	/// Create a typical Point class.
	/// </summary>
	public class Point : IComparable<Point>, IComparable
	{
		// TODO: create a an array to N dimensions, rather than a fixed 2D class.
		public double x;
		public double y;

		/// <summary>
		/// Initializes a Point object to some coordinates.
		/// </summary>
		/// <param name="xCoord">Represents the x coordinate.</param>
		/// <param name="yCoord">Represents the y coordinate.</param>
		public Point(double xCoord, double yCoord)
		{
			SetPoint(xCoord, yCoord);
		}

		/// <summary>
		/// IComparable<T>.CompareTo method.
		/// </summary>
		/// <param name="other">A Point object of which we compare objects of different types to.</param>
		/// <returns>
		/// Returns 1 if the calling object is greater than other or if other is null.
		/// Returns 0 if the calling object and other are equal.
		/// Returns -1 if other is greater than the calling object.
		/// </returns>
		public int CompareTo(Point other)
		{
			// If other is not a valid object reference, this instance is greater. 
			if (other == null) return 1;

			// The temperature comparison depends on the comparison of  
			// the underlying Double values.  
			int mX = x.CompareTo(other.x);
			int mY = y.CompareTo(other.y);

			if (mX == 0 && mY == 0) return 0;
			else if (mX == 0 && mY == 1) return -1;
			else if (mX == 1 && mY == 0) return 1;
			else return 0;
		}

		/// <summary>
		/// IComparable.CompareTo method.
		/// </summary>
		/// <param name="obj">An object of which we compare objects of the same type to.</param>
		/// <returns>
		/// Returns 1 if the calling object is greater than other or if other is null.
		/// Returns 0 if the calling object and other are equal.
		/// Returns -1 if other is greater than the calling object.
		/// </returns>
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

		/// <summary>
		/// Overloading the == operator.
		/// </summary>
		/// <param name="a">A Point which is on the left side of the ==.</param>
		/// <param name="b">A Point which is on the right side of the ==.</param>
		/// <returns>
		/// Returns whether a equals b, using the .Equals method.
		/// Returns using .ReferenceEquals method if either or both a and b are null.
		/// </returns>
		public static bool operator ==(Point a, Point b)
		{
			if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return true;
			if (a[0] == b[0] && a[1] == b[1]) return true;
			else return false;
		}

		/// <summary>
		/// Overloading the != operator.
		/// </summary>
		/// <param name="a">A Point which is on the left side of the !=.</param>
		/// <param name="b">A Point which is on the right side of the !=.</param>
		/// <returns>
		/// Returns whether a equals b, using the .Equals method.
		/// Returns using .ReferenceEquals method if either or both a and b are null.
		/// </returns>
		public static bool operator !=(Point a, Point b)
		{
			if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return true;
			if (a[0] != b[0] || a[1] != b[1]) return true;
			else return false;
		}

		/// <summary>
		/// Defines an indexer in order to access the coordinate values.
		/// </summary>
		/// <param name="index">Represents the index of the coordinate values.</param>
		/// <returns>Returns the value at index.</returns>
		/// <exception cref="IndexOutOfRangeException">If index is out of range.</exception>
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

		/// <summary>
		/// A setter method to set the coordinates.
		/// </summary>
		/// <param name="xCoord">Represents the x coordinate.</param>
		/// <param name="yCoord">Represents the y coordinate.</param>
		public void SetPoint(double xCoord, double yCoord)
		{
			x = xCoord;
			y = yCoord;
		}

		/// <summary>
		/// Override ToString to display Point objects in proper format.
		/// </summary>
		public override string ToString()
		{
			return "(" + x + ", " + y + ")";
		}
	}
}