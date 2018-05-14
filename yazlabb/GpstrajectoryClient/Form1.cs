using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading;

namespace yazlabb
{
   
    public partial class Form1 : Form
    {
        GMarkerGoogle marker;
        GMapOverlay mapOverlay;
        GMarkerGoogle markerR;
        GMarkerGoogle markerPosted;
        static string[] lines = System.IO.File.ReadAllLines(@"\\Mac\Home\Desktop\latlong.txt");
        string[] parts = null;
        static string[,] RawData = new String[lines.Length, 2];
        static string[,] RawDataP = new String[lines.Length+1, 2];
        static string[,] RawData2 = new String[lines.Length + 3, 2];
        static string[,] RawDataPosted = new String[lines.Length, 2];
        static string[,] ReductionData = new String[1000, 2];
        static string[,] ReductionDataP = new String[1000, 2];
        static string[,] ReductionData2 = new String[1000, 2];
        static string[,] ReductionDataPosted = new String[1000, 2];
        List<PointLatLng> koseler = new List<PointLatLng>();
        int j = 0, z = 0;
        static int size = 0,time=0;
        int sayac = 0;
        string[,] array = new String[2, 2];


        public Form1()
        {
            InitializeComponent();
        }
        

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    arrayTransfer();
        //}

        public void arrayTransfer()
        {
            int i = 0;
            for (i = 0; i < lines.Length; i++)
            {
                RawData2[i, 0] = RawData[i, 0];
                RawData2[i, 1] = RawData[i, 1];
            }
            RawData2[i, 0] = array[0, 0];
            RawData2[i, 1] = array[0, 1];
            RawData2[i + 1, 0] = array[1, 0];
            RawData2[i + 1, 1] = array[1, 1];
            RawData2[i + 2, 0] = "0";
            RawData2[i + 2, 1] = "0";


        }
        public void arrayTransfer2()
        {
            int i = 0;
            for (i = 0; i < size-2; i++)
            {
                ReductionData2[i, 0] = ReductionData[i, 0];
                ReductionData2[i, 1] = ReductionData[i, 1];
            }
            ReductionData2[i, 0] = array[0, 0];
            ReductionData2[i, 1] = array[0, 1];
            ReductionData2[i + 1, 0] = array[1, 0];
            ReductionData2[i + 1, 1] = array[1, 1];
            ReductionData2[i + 2, 0] = "1";
            ReductionData2[i + 2, 1] = "0";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            int i = 0;
            for (i = 0; i < lines.Length; i++)
            {
                RawDataP[i, 0] = RawData[i, 0];
                RawDataP[i, 1] = RawData[i, 1];
            }
            RawDataP[i, 0] = "0";
            RawDataP[i, 1] = "1";
           
            //PostRequest("http://localhost:51804/api/Veri",RawDataP);
            PostRequest("http://UMUT:8080/api/Veri", RawDataP);
            double oran = (1.0 - (Convert.ToDouble(size) / Convert.ToDouble(lines.Length))) * 100;
            textBox2.Text = oran.ToString();
            textBox1.Text = time.ToString();
        }
        

        
        
        
        
        public void Read2file()
        {

            
            for (int i = 0; i < lines.Length; i++)
            {

                parts = lines[i].Split(',');
                RawData[i, 0] = parts[0].ToString();
                RawData[i, 1] = parts[1].ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

          
            gMapControl2.DragButton = MouseButtons.Right;
            gMapControl2.CanDragMap = true;
            gMapControl2.AutoScroll = true;
            gMapControl2.MapProvider = GMapProviders.GoogleMap;


            mapOverlay = new GMapOverlay();
            for (int i = 0; i < lines.Length; i++)
            {
                marker = new GMarkerGoogle(new PointLatLng(double.Parse(RawData[i, 0], CultureInfo.InvariantCulture), double.Parse(RawData[i, 1], CultureInfo.InvariantCulture)), GMarkerGoogleType.green);
                mapOverlay.Markers.Add(marker);
            }
           


            marker.ToolTipMode = MarkerTooltipMode.Always;
 

            gMapControl2.Overlays.Add(mapOverlay);
            gMapControl2.Zoom = 9;
            gMapControl2.MinZoom = 0;
            gMapControl2.MaxZoom = 24;


        }

    


            private void button3_Click(object sender, EventArgs e)
            {

                Read2file();

                GMapOverlay routes = new GMapOverlay("routes");
                List<PointLatLng> points = new List<PointLatLng>();
               
            for (int i = 0; i < lines.Length; i++)
                {
                    points.Add(new PointLatLng(double.Parse(RawData[i, 0], CultureInfo.InvariantCulture), double.Parse(RawData[i, 1], CultureInfo.InvariantCulture)));
                }
          
            GMapRoute route = new GMapRoute(points, "A walk in the park");
                route.Stroke = new Pen(Color.Red, 3);

           

                routes.Routes.Add(route);
            

            gMapControl2.Overlays.Add(routes);
           

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Read2file();
        }
        
        private double ConvertToDouble(string s) 
        {
            //internetten alıntı
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
        public void gMapControl2_MouseClick(object sender, MouseEventArgs e)
        {
                   
            if (sayac <= 1)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {

                    double lat = gMapControl2.FromLocalToLatLng(e.X, e.Y).Lat;
                    double lng = gMapControl2.FromLocalToLatLng(e.X, e.Y).Lng;
                    koseler.Add(new PointLatLng(lat, lng));
                    array[sayac,0]=lat.ToString();
                    array[sayac, 1] = lng.ToString();

                    sayac++;
                }
                
            }

            if (sayac == 2)
            {
                
                koseler.Add(new PointLatLng(ConvertToDouble(array[0,0]),ConvertToDouble(array[1,1])));
                koseler.Add(new PointLatLng(ConvertToDouble(array[1,0]), ConvertToDouble(array[0, 1])));
                List<PointLatLng> koseler1 = new List<PointLatLng>();
                koseler1.Add(new PointLatLng(ConvertToDouble(array[0, 0]), ConvertToDouble(array[0, 1])));
                koseler1.Add(new PointLatLng(ConvertToDouble(array[1, 0]), ConvertToDouble(array[0, 1])));
                koseler1.Add(new PointLatLng(ConvertToDouble(array[1, 0]), ConvertToDouble(array[1, 1])));
                koseler1.Add(new PointLatLng(ConvertToDouble(array[0, 0]), ConvertToDouble(array[1, 1])));


                GMapOverlay polyOverlay = new GMapOverlay("polygon");
                GMapPolygon polygon = new GMapPolygon(koseler1, "mypolygon");

                polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                polygon.Stroke = new Pen(Color.Red, 1);
                polyOverlay.Polygons.Add(polygon);
                gMapControl2.Overlays.Add(polyOverlay);
                sayac++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            arrayTransfer();
            
           // PostRequest2("http://localhost:51804/api/Veri", RawData2);
            PostRequest2("http://UMUT:8080/api/Veri", RawData2);
            gMapControl2.DragButton = MouseButtons.Right;
            gMapControl2.CanDragMap = true;
            gMapControl2.AutoScroll = true;
            gMapControl2.MapProvider = GMapProviders.GoogleMap;
            mapOverlay = new GMapOverlay();
            ConvertToDouble(RawData[1, 0]);
            ConvertToDouble(RawDataPosted[1, 0]);

            for (j = 0; j < size; j++)
            {
                markerPosted = new GMarkerGoogle(new PointLatLng(ConvertToDouble(RawDataPosted[j, 0]), ConvertToDouble(RawDataPosted[j, 1])), GMarkerGoogleType.red);
                mapOverlay.Markers.Add(markerPosted);
            }
          
            gMapControl2.Overlays.Add(mapOverlay);
            gMapControl2.Zoom = 9;
            gMapControl2.MinZoom = 0;
            gMapControl2.MaxZoom = 24;

        }
        
        static void PostRequest(string url,String[,] data)
        {


            // url = "http://localhost:51804/api/Veri";
            url = "http://UMUT:8080/api/Veri";
            int cont1 = 0, cont2 = 0; 
            string[] array = null;
            size = 0;
            using (var client = new WebClient())
            {
              
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
      
                
                string serialisedData = JsonConvert.SerializeObject(data);
                //string json = JsonConvert.SerializeObject(data, Formatting.Indented);

                //string[,] deserialized = JsonConvert.DeserializeObject<string[,]>(json);

                var response = client.UploadString(url, serialisedData);
              
              
                List<string> desert = JsonConvert.DeserializeObject<List<String>>(response);

                 array = desert.ToArray();
                time = Convert.ToInt32(array[array.Length - 1]);
                
                for (int i = 0; i < array.Length-1; i++)
                {
                    if (i % 2 == 0)
                    {
                        ReductionData[size, 0] = array[i];
                        cont1 = 1;
                        if (cont1 == 1 && cont2 == 1)
                        {
                            size++;
                            cont1 = 0;
                            cont2 = 0;
                        }
                    }
                    if (i % 2 == 1)
                    {
                        
                        ReductionData[size, 1] = array[i];
                        cont2 = 1;
                        if (cont1 == 1 && cont2 == 1)
                        {
                            size++;
                            cont1 = 0;
                            cont2 = 0;
                        }
                    }
                    
                    
                }
               

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            gMapControl2.DragButton = MouseButtons.Right;
            gMapControl2.CanDragMap = true;
            gMapControl2.AutoScroll = true;
            gMapControl2.MapProvider = GMapProviders.GoogleMap;
            mapOverlay = new GMapOverlay();

            for (j = 0; j <= size - 1; j++)
            {
                markerR = new GMarkerGoogle(new PointLatLng(double.Parse(ReductionData[j, 0], CultureInfo.InvariantCulture), double.Parse(ReductionData[j, 1], CultureInfo.InvariantCulture)), GMarkerGoogleType.red);
                mapOverlay.Markers.Add(markerR);
            }

            gMapControl2.Overlays.Add(mapOverlay);
            gMapControl2.Zoom = 9;
            gMapControl2.MinZoom = 0;
            gMapControl2.MaxZoom = 24;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GMapOverlay routesR = new GMapOverlay("routes");
            List<PointLatLng> pointsR = new List<PointLatLng>();

            for (j = 0; j <= size - 1; j++)
            {
                pointsR.Add(new PointLatLng(double.Parse(ReductionData[j, 0], CultureInfo.InvariantCulture), double.Parse(ReductionData[j, 1], CultureInfo.InvariantCulture)));
            }

            GMapRoute routeR = new GMapRoute(pointsR, "A walk in the park");
            routeR.Stroke = new Pen(Color.DarkCyan, 3);

            routesR.Routes.Add(routeR);
            gMapControl2.Overlays.Add(routesR);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arrayTransfer2();
           // PostRequest3("http://localhost:51804/api/Veri", ReductionData2);
           // url = "http://UMUT:8080/api/Veri";
            PostRequest3("http://UMUT:8080/api/Veri", ReductionData2);
            gMapControl2.DragButton = MouseButtons.Right;
            gMapControl2.CanDragMap = true;
            gMapControl2.AutoScroll = true;
            gMapControl2.MapProvider = GMapProviders.GoogleMap;
            mapOverlay = new GMapOverlay();
            ConvertToDouble(RawData[1, 0]);
            ConvertToDouble(RawDataPosted[1, 0]);

            for (j = 0; j < size; j++)
            {
                markerPosted = new GMarkerGoogle(new PointLatLng(ConvertToDouble(ReductionDataPosted[j, 0]), ConvertToDouble(ReductionDataPosted[j, 1])), GMarkerGoogleType.green);
                mapOverlay.Markers.Add(markerPosted);
            }

            gMapControl2.Overlays.Add(mapOverlay);
            gMapControl2.Zoom = 9;
            gMapControl2.MinZoom = 0;
            gMapControl2.MaxZoom = 24;
        }

        static void PostRequest2(string url, String[,] data)
        {


            // url = "http://localhost:51804/api/Veri";
            url = "http://UMUT:8080/api/Veri";
            string[] array = null;
            int cont1 = 0, cont2 = 0;
            size = 0;
            using (var client = new WebClient())
            {

                client.Headers[HttpRequestHeader.ContentType] = "application/json";


                string serialisedData = JsonConvert.SerializeObject(data);
               
                var response = client.UploadString(url, serialisedData);


                List<string> desert = JsonConvert.DeserializeObject<List<String>>(response);

                array = desert.ToArray();

                for (int i = 0; i < array.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        RawDataPosted[size, 0] = array[i];
                        cont1 = 1;
                        if (cont1 == 1 && cont2 == 1)
                        {
                            size++;
                            cont1 = 0;
                            cont2 = 0;
                        }
                    }
                    if (i % 2 == 1)
                    {

                        RawDataPosted[size, 1] = array[i];
                        cont2 = 1;
                        if (cont1 == 1 && cont2 == 1)
                        {
                            size++;
                            cont1 = 0;
                            cont2 = 0;
                        }
                    }


                }



            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        static void PostRequest3(string url, String[,] data)
        {


            // url = "http://localhost:51804/api/Veri";
            url = "http://UMUT:8080/api/Veri";
            string[] array = null;
            int cont1 = 0, cont2 = 0;
            size = 0;
            using (var client = new WebClient())
            {

                client.Headers[HttpRequestHeader.ContentType] = "application/json";


                string serialisedData = JsonConvert.SerializeObject(data);

                var response = client.UploadString(url, serialisedData);


                List<string> desert = JsonConvert.DeserializeObject<List<String>>(response);

                array = desert.ToArray();

                for (int i = 0; i < array.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        ReductionDataPosted[size, 0] = array[i];
                        cont1 = 1;
                        if (cont1 == 1 && cont2 == 1)
                        {
                            size++;
                            cont1 = 0;
                            cont2 = 0;
                        }
                    }
                    if (i % 2 == 1)
                    {

                        ReductionDataPosted[size, 1] = array[i];
                        cont2 = 1;
                        if (cont1 == 1 && cont2 == 1)
                        {
                            size++;
                            cont1 = 0;
                            cont2 = 0;
                        }
                    }


                }



            }
        }

    }

}

    

    


