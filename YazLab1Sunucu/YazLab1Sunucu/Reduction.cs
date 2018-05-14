using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;


namespace YazLab1Sunucu
{
    public class Reduction
    {
        double Distance01, Distance12, Distance23, Distance34, Distance02, Distance13, Distance24, Distance14, Distance03, Distance04;
        double[] Distance = new Double[8];
        double[] DistanceSort = new Double[8];
        int calc = 0;
        int j = 0, z = 0;
        String[,] ReductionData = new String[ 1200, 2];
        string a = null;
        string oran = null;
        public List<String> PostRed(string[,] Values)
        {
            var list = new List<String>();
            
           double Runtime= ReductionDat(Values);
            
            for (int i = 0; i < calc; i++)
            {
                list.Add(ReductionData[i, 0]);
                list.Add(ReductionData[i, 1]);
            }

            

            int x = (1 - (calc / (Values.Length / 2)));


            //list.Add(oran = ((1 - (calc / (Values.Length/2))) * 100).ToString());
            list.Add(Runtime.ToString());
            
            return list;
        }
        public double ReductionDat(String[,] DrawData)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            
            
            for (int i = 0; i < DrawData.Length/2 - 1; i += 4)
            {

                if (i == DrawData.Length / 2 - 1)
                {
                    break;
                }
                else if (DrawData.Length / 2 - 1 - i == 3)
                {
                    Distance01 = DistanceTo(double.Parse(DrawData[i, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 1], CultureInfo.InvariantCulture));
                    Distance12 = DistanceTo(double.Parse(DrawData[i + 1, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 1], CultureInfo.InvariantCulture));
                    Distance23 = DistanceTo(double.Parse(DrawData[i + 2, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 3, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 3, 1], CultureInfo.InvariantCulture));
                    Distance02 = DistanceTo(double.Parse(DrawData[i, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 1], CultureInfo.InvariantCulture));
                    Distance13 = DistanceTo(double.Parse(DrawData[i + 1, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 3, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 3, 1], CultureInfo.InvariantCulture));
                    Distance[0] = Distance01 + Distance12 + Distance23;
                    Distance[1] = Distance02 + Distance23;
                    Distance[2] = Distance01 + Distance13;
                    for (j = 0; j < 3; j++)
                    {
                        DistanceSort[j] = Distance[j];
                    }
                    Array.Sort(DistanceSort);
                    for (z = 0; z < 3; z++)
                    {
                        if (DistanceSort[z] == Distance[0])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 1, 0];
                            ReductionData[calc, 1] = DrawData[i + 1, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 2, 0];
                            ReductionData[calc, 1] = DrawData[i + 2, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 3, 0];
                            ReductionData[calc, 1] = DrawData[i + 3, 1];

                            break;


                        }
                        else if (DistanceSort[z] == Distance[1])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 2, 0];
                            ReductionData[calc, 1] = DrawData[i + 2, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 3, 0];
                            ReductionData[calc, 1] = DrawData[i + 3, 1];


                            break;

                        }
                        else if (DistanceSort[z] == Distance[2])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 1, 0];
                            ReductionData[calc, 1] = DrawData[i + 1, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 2, 0];
                            ReductionData[calc, 1] = DrawData[i + 2, 1];

                            break;

                        }
                    }
                }
                else if (DrawData.Length / 2 - 1 - i == 2)
                {
                    Distance01 = DistanceTo(double.Parse(DrawData[i, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 1], CultureInfo.InvariantCulture));
                    Distance12 = DistanceTo(double.Parse(DrawData[i + 1, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 1], CultureInfo.InvariantCulture));

                    Distance02 = DistanceTo(double.Parse(DrawData[i, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 1], CultureInfo.InvariantCulture));
                    Distance[0] = Distance01 + Distance12;
                    Distance[1] = Distance02 + Distance23;
                    for (j = 0; j < 2; j++)
                    {
                        DistanceSort[j] = Distance[j];
                    }
                    Array.Sort(DistanceSort);
                    for (z = 0; z < 2; z++)
                    {
                        if (DistanceSort[z] == Distance[0])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 1, 0];
                            ReductionData[calc, 1] = DrawData[i + 1, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 2, 0];
                            ReductionData[calc, 1] = DrawData[i + 2, 1];


                            break;


                        }
                        else if (DistanceSort[z] == Distance[1])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 2, 0];
                            ReductionData[calc, 1] = DrawData[i + 2, 1];

                            break;

                        }
                    }
                }

                else if (i - DrawData.Length / 2 - 1 - i == 1)
                {
                    Distance01 = DistanceTo(double.Parse(DrawData[i, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 1], CultureInfo.InvariantCulture));

                    Distance[0] = Distance01 + Distance12;


                    DistanceSort[j] = Distance[j];



                    if (DistanceSort[z] == Distance[0])
                    {
                        ReductionData[calc, 0] = DrawData[i, 0];
                        ReductionData[calc, 1] = DrawData[i, 1];
                        calc++;
                        ReductionData[calc, 0] = DrawData[i + 1, 0];
                        ReductionData[calc, 1] = DrawData[i + 1, 1];

                        break;


                    }

                }




                if ((DrawData.Length / 2 - 1) - i > 3)
                {
                    Distance01 = DistanceTo(double.Parse(DrawData[i, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 1], CultureInfo.InvariantCulture));
                    Distance12 = DistanceTo(double.Parse(DrawData[i + 1, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 1], CultureInfo.InvariantCulture));
                    Distance23 = DistanceTo(double.Parse(DrawData[i + 2, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 3, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 3, 1], CultureInfo.InvariantCulture));
                    Distance34 = DistanceTo(double.Parse(DrawData[i + 3, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 3, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 4, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 4, 1], CultureInfo.InvariantCulture));
                    Distance02 = DistanceTo(double.Parse(DrawData[i, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 1], CultureInfo.InvariantCulture));
                    Distance13 = DistanceTo(double.Parse(DrawData[i + 1, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 3, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 3, 1], CultureInfo.InvariantCulture));
                    Distance24 = DistanceTo(double.Parse(DrawData[i + 2, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 2, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 4, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 4, 1], CultureInfo.InvariantCulture));
                    Distance14 = DistanceTo(double.Parse(DrawData[i + 1, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 1, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 4, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 4, 1], CultureInfo.InvariantCulture));
                    Distance03 = DistanceTo(double.Parse(DrawData[i, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 3, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 3, 1], CultureInfo.InvariantCulture));
                    Distance04 = DistanceTo(double.Parse(DrawData[i, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i, 1], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 4, 0], CultureInfo.InvariantCulture), double.Parse(DrawData[i + 4, 1], CultureInfo.InvariantCulture));

                    Distance[0] = Distance01 + Distance12 + Distance23 + Distance34;
                    Distance[1] = Distance02 + Distance23 + Distance34;
                    Distance[2] = Distance01 + Distance13 + Distance34;
                    Distance[3] = Distance01 + Distance12 + Distance24;
                    Distance[4] = Distance01 + Distance14;
                    Distance[5] = Distance02 + Distance24;
                    Distance[6] = Distance03 + Distance34;
                    Distance[7] = Distance04;
                    for (j = 0; j < Distance.Length; j++)
                    {
                        DistanceSort[j] = Distance[j];
                    }
                    Array.Sort(DistanceSort);

                    for (z = 0; z < DistanceSort.Length; z++)
                    {
                        if (DistanceSort[z] == Distance[0])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 1, 0];
                            ReductionData[calc, 1] = DrawData[i + 1, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 2, 0];
                            ReductionData[calc, 1] = DrawData[i + 2, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 3, 0];
                            ReductionData[calc, 1] = DrawData[i + 3, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 4, 0];
                            ReductionData[calc, 1] = DrawData[i + 4, 1];
                            break;


                        }
                        else if (DistanceSort[z] == Distance[1])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 2, 0];
                            ReductionData[calc, 1] = DrawData[i + 2, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 3, 0];
                            ReductionData[calc, 1] = DrawData[i + 3, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 4, 0];
                            ReductionData[calc, 1] = DrawData[i + 4, 1];

                            break;

                        }
                        else if (DistanceSort[z] == Distance[2])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 1, 0];
                            ReductionData[calc, 1] = DrawData[i + 1, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 2, 0];
                            ReductionData[calc, 1] = DrawData[i + 2, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 4, 0];
                            ReductionData[calc, 1] = DrawData[i + 4, 1];

                            break;

                        }
                        else if (DistanceSort[z] == Distance[3])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 1, 0];
                            ReductionData[calc, 1] = DrawData[i + 1, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 2, 0];
                            ReductionData[calc, 1] = DrawData[i + 2, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 4, 0];
                            ReductionData[calc, 1] = DrawData[i + 4, 1];

                            break;

                        }
                        else if (DistanceSort[z] == Distance[4])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 1, 0];
                            ReductionData[calc, 1] = DrawData[i + 1, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 4, 0];
                            ReductionData[calc, 1] = DrawData[i + 4, 1];

                            break;

                        }
                        else if (DistanceSort[z] == Distance[5])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 2, 0];
                            ReductionData[calc, 1] = DrawData[i + 2, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 4, 0];
                            ReductionData[calc, 1] = DrawData[i + 4, 1];

                            break;

                        }
                        else if (DistanceSort[z] == Distance[6])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 3, 0];
                            ReductionData[calc, 1] = DrawData[i + 3, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 4, 0];
                            ReductionData[calc, 1] = DrawData[i + 4, 1];
                            break;


                        }
                        else if (DistanceSort[z] == Distance[7])
                        {
                            ReductionData[calc, 0] = DrawData[i, 0];
                            ReductionData[calc, 1] = DrawData[i, 1];
                            calc++;
                            ReductionData[calc, 0] = DrawData[i + 4, 0];
                            ReductionData[calc, 1] = DrawData[i + 4, 1];

                            break;

                        }
                    }
                }
            }
            watch.Stop();
            return  watch.Elapsed.Milliseconds;
        }
        public static double DistanceTo(double lat1, double lon1, double lat2, double lon2)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 1.609344;

        }
      
    }
}