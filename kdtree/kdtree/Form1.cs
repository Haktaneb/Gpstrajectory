using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tree;
using PriorityQueue;
using System.Globalization;

namespace kdtree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string[] lines = System.IO.File.ReadAllLines(@"\\Mac\Home\Desktop\latlong.txt");
        static string[,] RawData = new String[lines.Length, 2];
        string[] parts = null;
        public void Read2file()
        {


            for (int i = 0; i < lines.Length; i++)
            {

                parts = lines[i].Split(',');
                RawData[i, 0] = parts[0].ToString();
                RawData[i, 1] = parts[1].ToString();

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            Read2file();
            KDTree t = new KDTree(new Point(0, 0), 2);
             
            for (int i = 0; i < lines.Length; i++)
            {
                // double.Parse(RawData[i, 0], CultureInfo.InvariantCulture)
                t.Insert(new KDNode(new Point(double.Parse(RawData[i, 0], CultureInfo.InvariantCulture), double.Parse(RawData[i, 1], CultureInfo.InvariantCulture))), t.Root);
               

            }


            Point find = new Point(double.Parse(RawData[30, 0], CultureInfo.InvariantCulture), double.Parse(RawData[30, 1], CultureInfo.InvariantCulture));

            t.LocSearch(find);

           // Console.WriteLine("Nearest node to " + find.ToString() + " is " + found.Data.ToString());

        }
    }
}
