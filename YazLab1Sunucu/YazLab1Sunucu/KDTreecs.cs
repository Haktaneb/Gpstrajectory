using System;
using System.Collections;
using System.Collections.Generic;
using PriorityQueue;

namespace Tree
{
   
    public class KDTree
    {
        private KDNode root;
        private int dimensions;
        private Queue<KDNode> queue;

      
        public KDTree(Point point, int dim)
        {
            root = new KDNode(point, null, null, 0);
            dimensions = dim;
            queue = new Queue<KDNode>();
            queue.Enqueue(root);
        }

      
        public KDNode Root
        {
            get { return root; }
            set { root = value; }
        }

       
        public int Dim
        {
            get { return dimensions; }
        }

       
        public static void PrintInOrder(KDNode node)
        {
            if (node.Left != null) PrintInOrder(node.Left);
            Console.Write(node.Data.ToString() + " at " + node.Depth + "\n");
            if (node.Right != null) PrintInOrder(node.Right);
        }

        public static void PrintPreOrder(KDNode node)
        {
            Console.Write(node.Data.ToString() + " at " + node.Depth + "\n");
            if (node.Left != null) PrintPreOrder(node.Left);
            if (node.Right != null) PrintPreOrder(node.Right);
        }

       
        public static double EuclideanDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow((a[1] - b[0]), 2) + Math.Pow((b[1] - a[0]), 2));
        }

        
        private static double Subtract(Point a, Point b, int dim)
        {
            return a[dim] - b[dim];
        }

       
        public KDNode Insert(KDNode node, KDNode root, int lev = 0)
        {
            if (root == null)
            {
                node.Depth = lev % Dim;
                return node;
            }

            if (lev == 0)
            {
                if (node.Data[lev] > root.Data[lev])
                    root.Right = Insert(node, root.Right, (lev + 1) % Dim);

                else if (node.Data[lev] < root.Data[lev])
                    root.Left = Insert(node, root.Left, (lev + 1) % Dim);
                else
                    return root;
            }
            else
            {
                if (node.Data[lev] > root.Data[lev])
                    root.Right = Insert(node, root.Right, (lev + 1) % Dim);

                else if (node.Data[lev] < root.Data[lev])
                    root.Left = Insert(node, root.Left, (lev + 1) % Dim);
                else
                    return root;
            }

            return root;
        }

      

        public List<String> LocSearch(Point query1,Point query2)
        {
            MinPriorityQueue<Tuple<double, KDNode>> pq = new MinPriorityQueue<Tuple<double, KDNode>>();

           

            List<String> a = new List<String>();
            
            pq.Enqueue(new Tuple<double, KDNode>(0.0, root));

            do
            {
                var current = pq.Dequeue();
                
                var currentNode = current.Item2;
                if (query1.x > query2.x && query1.y > query2.y)
                {
                    if (query1.x >= currentNode.Data.x && query2.x <= currentNode.Data.x && query1.y >= currentNode.Data.y && query2.y <=currentNode.Data.y)
                    {
                        a.Add(currentNode.Data.x.ToString());
                        a.Add(currentNode.Data.y.ToString());
                    }

                }
                else if (query1.x < query2.x && query1.y < query2.y)
                {
                    if (query1.x <= currentNode.Data.x && query2.x >= currentNode.Data.x && query1.y <= currentNode.Data.y && query2.y >= currentNode.Data.y)
                    {
                        a.Add(currentNode.Data.x.ToString());
                        a.Add(currentNode.Data.y.ToString());
                    }

                }
                else if (query1.x < query2.x && query1.y > query2.y)
                {
                    if (query1.x <= currentNode.Data.x && query2.x >= currentNode.Data.x && query1.y >= currentNode.Data.y && query2.y <= currentNode.Data.y)
                    {
                        a.Add(currentNode.Data.x.ToString());
                        a.Add(currentNode.Data.y.ToString());
                    }
                }
                else if (query1.x > query2.x && query1.y < query2.y)
                {
                    if (query1.x >= currentNode.Data.x && query2.x <= currentNode.Data.x && query1.y <= currentNode.Data.y && query2.y >= currentNode.Data.y)
                    {
                        a.Add(currentNode.Data.x.ToString());
                        a.Add(currentNode.Data.y.ToString());
                    }
                }
               
                
          
                KDNode near,far;

               
                    near = currentNode.Right;

                
                    far = currentNode.Left;

                if (near != null) pq.Enqueue(new Tuple<double, KDNode>(0, near));
                if (far != null) pq.Enqueue(new Tuple<double, KDNode>(0, far));

            } while (pq.Count() != 0);
           
            return a;
        }
        

    }
}