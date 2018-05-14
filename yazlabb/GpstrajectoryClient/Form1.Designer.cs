namespace yazlabb
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.gMapControl2 = new GMap.NET.WindowsForms.GMapControl();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gMapControl2
            // 
            this.gMapControl2.Bearing = 0F;
            this.gMapControl2.CanDragMap = true;
            this.gMapControl2.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl2.GrayScaleMode = false;
            this.gMapControl2.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl2.LevelsKeepInMemmory = 5;
            this.gMapControl2.Location = new System.Drawing.Point(-1, 1);
            this.gMapControl2.MarkersEnabled = true;
            this.gMapControl2.MaxZoom = 2;
            this.gMapControl2.MinZoom = 2;
            this.gMapControl2.MouseWheelZoomEnabled = true;
            this.gMapControl2.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl2.Name = "gMapControl2";
            this.gMapControl2.NegativeMode = false;
            this.gMapControl2.PolygonsEnabled = true;
            this.gMapControl2.RetryLoadTile = 0;
            this.gMapControl2.RoutesEnabled = true;
            this.gMapControl2.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl2.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl2.ShowTileGridLines = false;
            this.gMapControl2.Size = new System.Drawing.Size(889, 659);
            this.gMapControl2.TabIndex = 0;
            this.gMapControl2.Zoom = 0D;
            this.gMapControl2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl2_MouseClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(894, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 55);
            this.button2.TabIndex = 1;
            this.button2.Text = "Display Raw Data Markers";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(894, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 55);
            this.button3.TabIndex = 2;
            this.button3.Text = "Draw Path RawData";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(895, 162);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(95, 52);
            this.button5.TabIndex = 4;
            this.button5.Text = "Reduction Raw Data";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(895, 220);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(95, 48);
            this.button6.TabIndex = 5;
            this.button6.Text = "Find Selected Area(Raw)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(996, 34);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 55);
            this.button7.TabIndex = 6;
            this.button7.Text = "Display Reduction Data Markers";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(996, 101);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 55);
            this.button8.TabIndex = 7;
            this.button8.Text = "Draw Path Reduction Data";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(997, 163);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 51);
            this.button4.TabIndex = 8;
            this.button4.Text = "Find Selected Area(Reduction )";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(937, 344);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(947, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Time(ms)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(933, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Reduction rate (%)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(937, 400);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 12;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1120, 703);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gMapControl2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private GMap.NET.WindowsForms.GMapControl gMapControl2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        //private GMapNET.GMapControl map;
    }
}

