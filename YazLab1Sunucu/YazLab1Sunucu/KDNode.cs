using System;
using System.Collections.Generic;

namespace Tree
{
   
    public class KDNode : IComparable<KDNode>, IComparable
    {
        private Point data;
        private KDNode left;
        private KDNode right;
        private int depth;

      
        public KDNode(Point point, KDNode leftNode = null, KDNode rightNode = null, int dep = 0)
        {
            data = point;
            left = leftNode;
            right = rightNode;
            depth = dep;
        }

       
        public int CompareTo(KDNode other)
        {
           
            if (other == null) return 1;

            
            int mX = Data[0].CompareTo(other.Data[0]);
            int mY = Data[1].CompareTo(other.Data[1]);

            if (mX == 0 && mY == 0)
                return 0;
            else if (mX == 0 && mY == 1)
                return -1;
            else if (mX == 1 && mY == 0)
                return 1;
            else return 0;
        }

      
        public int CompareTo(Object obj)
        {
            if (obj == null)
                return 1;

            KDNode node = obj as KDNode;
            if (node != null)
            {
                int mX = this.Data[0].CompareTo(node.Data[0]);
                int mY = this.Data[1].CompareTo(node.Data[1]);
                if (mX == 0 && mY == 0) return 0;
                else if (mX == 0 && mY == 1) return -1;
                else if (mX == 1 && mY == 0) return 1;
                else return 0;
            }
            else
                throw new ArgumentException("Object is not a KDNode");
        }

      
        public static bool operator ==(KDNode a, KDNode b)
        {
            if (object.ReferenceEquals(a, null))
                return object.ReferenceEquals(b, null);

            return a.Equals(b);
        }

 
        public static bool operator !=(KDNode a, KDNode b)
        {
            return !(a == b);
        }

       
        public Point Data
        {
            get { return data; }
        }

        
        public KDNode Left
        {
            get { return left; }
            set { left = value; }
        }

       
        public KDNode Right
        {
            get { return right; }
            set { right = value; }
        }

       
        public int Depth
        {
            get
            {
                return depth;
            }
            set
            {
                depth = value;
            }
        }
    }
}