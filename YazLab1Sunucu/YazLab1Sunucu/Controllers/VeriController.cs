using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Tree;
using PriorityQueue;
using System.Globalization;
using System.Threading;

namespace YazLab1Sunucu.Controllers
{

    public class VeriController : ApiController
    {
        // GET: api/Veri
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Veri/5
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/Veri
        public List<String> Post([FromBody]string[,] values)
        {

            int a = ((values.Length / 2) - 1);
            int c = 0;
            int dfc = 0;
            

            if (values[a, 0] == "0" && values[a, 1] == "1")
            {
                Reduction newData = new Reduction();

                return newData.PostRed(values);
            }
            if (values[a, 0] == "0" && values[a, 1] == "0")
            {
                KDTree t = new KDTree(new Point(0, 0), 2);

                for (int i = 0; i < a - 1; i++)
                {
                    // double.Parse(RawData[i, 0], CultureInfo.InvariantCulture)
                    t.Insert(new KDNode(new Point(double.Parse(values[i, 0], CultureInfo.InvariantCulture), double.Parse(values[i, 1], CultureInfo.InvariantCulture))), t.Root);


                }


                Point query1 = new Point(ConvertToDouble(values[a - 2, 0]), ConvertToDouble(values[a - 2, 1]));
                Point query2 = new Point(ConvertToDouble(values[a - 1, 0]), ConvertToDouble(values[a - 1, 1]));
                return t.LocSearch(query1, query2);

            }
            if (values[a, 0] == null)
            {
                for (int e = 0; values[e, 0] != null; e++)
                {
                    c++;
                }
                if (values[c-1, 0] == "1" && values[c-1, 1] == "0")
            {
                KDTree t = new KDTree(new Point(0, 0), 2);

                for (int i = 0; i < c - 1; i++)
                {
                    // double.Parse(RawData[i, 0], CultureInfo.InvariantCulture)
                    t.Insert(new KDNode(new Point(double.Parse(values[i, 0], CultureInfo.InvariantCulture), double.Parse(values[i, 1], CultureInfo.InvariantCulture))), t.Root);


                }


                Point query1 = new Point(ConvertToDouble(values[c - 3, 0]), ConvertToDouble(values[c - 3, 1]));
                Point query2 = new Point(ConvertToDouble(values[c - 2, 0]), ConvertToDouble(values[c - 2, 1]));
                return t.LocSearch(query1, query2);

            }
            }
            List<String> b = new List<String>();
            return b;
            
        }

        // PUT: api/Veri/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Veri/5
        public void Delete(int id)
        {
        }
        private double ConvertToDouble(string s)
        {
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double result = 0;
            try
            {
                if (s != null)
                    if (!s.Contains(","))
                        result = double.Parse(s, CultureInfo.InvariantCulture);
                    else
                        result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception e)
            {
                try
                {
                    result = Convert.ToDouble(s);
                }
                catch
                {
                    try
                    {
                        result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
                    }
                    catch
                    {
                        throw new Exception("Wrong string-to-double format");
                    }
                }
            }
            return result;
        }
    }
}
