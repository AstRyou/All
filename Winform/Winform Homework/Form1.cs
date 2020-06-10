using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace HomeWorkWinform
{
   
    public partial class Form1 : System.Windows.Forms.Form
    {
        public string saveSucc= "Blueprint saved succesfully";
        public string saveFail = "save fail";
        public string loadSucc = "Blueprint loaded succesfully";
        public string loadFail = "Failed to load";
        private static int count = 0;
        private List<Point> arr = new List<Point>();    
        private Bitmap bitmap;
        private bool wall;
        private Point point;
        private Point end;
        private int? clicked=null;
        private List<drawnImage> drawnImages;
        private bool isClicked;
        public class drawnImage
        {
            public string buttonName = "";
            public Point center, size, start, end;
            [XmlIgnoreAttribute]
            public Bitmap img;
            public bool isWall;
            public Point[] lines;
            public int angle;
            public drawnImage()
            { }
            public drawnImage(Bitmap Img, Point Start)
            {
                start = Start;
                img = Img;
                size.X = Img.Width;
                size.Y = Img.Height;
                center.X = start.X + size.X / 2;
                center.Y = start.Y + size.Y / 2;
                end.X = start.X + Img.Width;
                end.Y = start.Y + Img.Height;

                
            }
            public void newPoint(int x,int y)
            {
                if (isWall)
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        lines[i].X += x;
                        lines[i].Y += y;
                    }
                }
                    start.X += x;
                    start.Y += y;
                    end.X += x;
                    end.Y += y;
                    center.X += x;
                    center.Y += y;
                
            }
        }
        public Form1()
        {
            InitializeComponent();
            drawnImages = new List<drawnImage>();
            bitmap = new Bitmap(splitContainer1.Panel1.Width, splitContainer1.Panel1.Height);
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            clicked = null;
            drawAll();
            foreach (var control in flowLayoutPanel1.Controls)
            {
                if (control is Button)
                    if (((Button)sender).Name == ((Button)control).Name)
                    {
                        if (((Button)sender).BackColor == Color.Red)
                        {
                            ((Button)sender).BackColor = Color.White;
                            if (((Button)control).Name.Equals("buttonWall")&&arr.Count!=0)
                            {
                                setWall();
                            }
                            ((Button)control).Tag = "0";
                            wall = false;
                        }
                        else
                        {
                            ((Button)sender).BackColor = Color.Red;
                            if(((Button)control).Name.Equals("buttonWall"))
                            { ((Button)control).Tag = "-1";
                            }
                            else
                            ((Button)control).Tag = "1";
                        }
                    }
                    else
                    {
                        ((Button)control).BackColor = Color.White;
                        if (((Button)control).Name.Equals("buttonWall")&&arr.Count!=0)
                        {
                            setWall();
                        }
                        ((Button)control).Tag = "0";
                        wall = false;
                    }
            }   
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                point = e.Location;
            }
         
            if (e.Button == MouseButtons.Right&&wall)
            {
                setWall();
            }
            bool isButtonClicked = true;
            if (int.Parse((string)buttonWall.Tag) < 0)
            {
                listBox1.SelectionMode = SelectionMode.None;
                isButtonClicked = false;
                clicked = null;
                
                if (count == 0)
                {
                    listBox1.Items.Add(buttonWall.Name + " {X=" + e.X + ",Y=" + e.Y + "}");
                  

                }
                if (!wall)
                {
                    wall = true;
                }
                arr.Add(e.Location);
                count++;
            }
            else
            foreach (var control in flowLayoutPanel1.Controls)
            {
                if (control is Button)
                    if (int.Parse((string)((Button)control).Tag) >0)
                    {
                            
                        listBox1.Items.Add(((Button)control).Name + " {X="+e.X+",Y="+e.Y+"}");
                        drawnImages.Add(new drawnImage((Bitmap)((Button)control).BackgroundImage,
                            new Point(e.X- ((Button)control).BackgroundImage.Width/2,
                            e.Y- ((Button)control).BackgroundImage.Height / 2)));
                        drawnImages.Last().buttonName= ((Button)control).Name;
                         ((Button)control).BackColor = Color.White;
                        ((Button)control).Tag = "0";
                         drawLast();
                            isButtonClicked = false;
                            clicked = null;
                            
                    }
            }
            if (isButtonClicked&&e.Button==MouseButtons.Left&&!wall)
            {
                for (int i = 0; i < drawnImages.Count; i++)
                {
                    int wid = (int)Math.Cos(drawnImages[i].angle);
                    int hei= (int)Math.Sin(drawnImages[i].angle);
                    if (drawnImages[i].isWall)
                    {
                        for (int j = 0; j < drawnImages[i].lines.Length-1; j++)
                        {
                            if (hitline(e.Location, drawnImages[i].lines[j], drawnImages[i].lines[j + 1]))
                            {
                                clicked = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (e.X > drawnImages[i].start.X &&
                            e.Y > drawnImages[i].start.Y &&
                            e.X < drawnImages[i].start.X + drawnImages[i].size.X &&
                            e.Y < drawnImages[i].start.Y + drawnImages[i].size.Y)
                        {
                            if (clicked == null)
                            {
                                clicked = i;

                            }
                            else if (Distance(drawnImages[clicked.Value].center, e.Location) >
                                Distance(drawnImages[i].center, e.Location))
                            {
                                clicked = i;
                            }
                        }
                    }
                }
                if (clicked != null)
                {
                    listBox1.SetSelected(clicked.Value, true);
                    isClicked = true;
                }
                if (clicked != null &&
                    drawnImages[clicked.Value].isWall
                    )
                {
                    int? tmp = null;
                    
                    for (int j = 0; j < drawnImages[clicked.Value].lines.Length-1; j++)
                    {
                        if (hitline(e.Location, drawnImages[clicked.Value].lines[j], drawnImages[clicked.Value].lines[j + 1]))
                        {
                            tmp = clicked;
                            break;
                        }
                    }
                    if (tmp == null)
                    {
                        listBox1.SetSelected(clicked.Value, false);
                        isClicked = false;
                        drawnImages[clicked.Value].angle = 0;
                    }
                    clicked = tmp;
                }
                else if (clicked != null &&
                    (e.X < drawnImages[clicked.Value].start.X ||
                          e.Y < drawnImages[clicked.Value].start.Y ||
                          e.X > drawnImages[clicked.Value].start.X + drawnImages[clicked.Value].size.X ||
                          e.Y > drawnImages[clicked.Value].start.Y + drawnImages[clicked.Value].size.Y))
                {
                    listBox1.SetSelected(clicked.Value, false);
                    isClicked = false;
                    drawnImages[clicked.Value].angle = 0;
                    clicked = null;
                   
                    
                }
                drawAll();
            }
        }

        private void newBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(splitContainer1.Panel1.Width, splitContainer1.Panel1.Height);
            pictureBox1.Width = splitContainer1.Panel1.Width;
            pictureBox1.Height = splitContainer1.Panel1.Height;
            pictureBox1.Image = bitmap;
            pictureBox1.Refresh();
        }

        
        void paintbox_MouseWheel(object sender, MouseEventArgs e)
        {
            
                if (clicked != null)
                {
                    drawnImages[clicked.Value].angle -= 5;
                    drawAll();
                } 
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            end = e.Location;
            if (e.Button == MouseButtons.Left&&clicked!=null)
            {
                drawnImages[clicked.Value].newPoint(e.X - point.X, e.Y - point.Y);
                point.X = e.X;
                point.Y = e.Y;
                listBox1.Items.RemoveAt(clicked.Value);
                listBox1.Items.Insert(clicked.Value, drawnImages[clicked.Value].buttonName + " {X=" + e.X + ",Y=" + e.Y + "}");
                
            }
          
            drawAll();

        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            if (pictureBox1.Width < splitContainer1.Panel1.Width ||
                   pictureBox1.Height < splitContainer1.Panel1.Height)
            {
             
                    bitmap = new Bitmap(splitContainer1.Panel1.Width, splitContainer1.Panel1.Height);
                    if(drawnImages!=null)
                    drawAll();
                pictureBox1.Width = splitContainer1.Panel1.Width;
                pictureBox1.Height = splitContainer1.Panel1.Height;
                pictureBox1.Image = bitmap;
                //  pictureBox1.Refresh();
            }
        }
        private void drawLast() {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(drawnImages.Last().img, drawnImages.Last().start);
                
            }
            pictureBox1.Image = bitmap;
        }
        private void drawAll() {
             bitmap = new Bitmap(splitContainer1.Panel1.Width, splitContainer1.Panel1.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (var img in drawnImages)
                {
                    if (wall)
                    {
                        clicked = null;
                    }
                    if (clicked != null && drawnImages[clicked.Value] == img )
                    {

                        ColorMatrix matrix = new ColorMatrix();

                        //set the opacity  
                        matrix.Matrix33 = 0.5f;

                        //create image attributes  
                        ImageAttributes attributes = new ImageAttributes();

                        //set the color(opacity) of the image  
                        attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                        if (drawnImages[clicked.Value].angle != 0)
                        {
                            //now we set the rotation point to the center of our image
                            g.TranslateTransform(drawnImages[clicked.Value].center.X, drawnImages[clicked.Value].center.Y);

                            //now rotate the image
                            g.RotateTransform(drawnImages[clicked.Value].angle);

                            g.TranslateTransform(-drawnImages[clicked.Value].center.X, -drawnImages[clicked.Value].center.Y);

                            //set the InterpolationMode to HighQualityBicubic so to ensure a high
                            //quality image once it is transformed to the specified size
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            Rectangle rect = new Rectangle(0, 0, drawnImages[clicked.Value].img.Width,
                                drawnImages[clicked.Value].img.Height);

                        }

                        //now draw the image  
                        g.DrawImage(drawnImages[clicked.Value].img, new Rectangle(drawnImages[clicked.Value].start.X, drawnImages[clicked.Value].start.Y, drawnImages[clicked.Value].size.X, drawnImages[clicked.Value].size.Y), 0, 0, drawnImages[clicked.Value].size.X, drawnImages[clicked.Value].size.Y, GraphicsUnit.Pixel, attributes);
                    }
                    else
                    {
                        //if (img.angle != 0)
                        //{
                        //    //now we set the rotation point to the center of our image
                        //    g.TranslateTransform(img.center.X, img.center.Y);

                        //    //now rotate the image
                        //    g.RotateTransform(img.angle);

                        //    g.TranslateTransform(-img.center.X, -img.center.Y);

                        //    //set the InterpolationMode to HighQualityBicubic so to ensure a high
                        //    //quality image once it is transformed to the specified size
                        //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            

                        //}
                        g.DrawImage(img.img, new Rectangle(img.start.X,
                            img.start.Y, img.size.X,
                            img.size.Y), 0, 0, img.size.X,
                            img.size.Y, GraphicsUnit.Pixel);
                       // g.DrawImage(img.img, img.start);
                    }
                    
                }
                
            }
            pictureBox1.Refresh();
            pictureBox1.Image = bitmap;
        }
       
        private double Distance(Point v1, Point v2)
        {
            return Math.Sqrt(Math.Pow(v1.Y - v2.Y, 2) + Math.Pow(v1.X - v2.X, 2));
        }
        private void setWall()
        {
            Point min = new Point(0, 0), max = new Point(0, 0);
            count = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (min.X > arr[i].X)
                    min.X = arr[i].X;
                if (max.X < arr[i].X)
                    max.X = arr[i].X;
                if (min.Y > arr[i].Y)
                    min.Y = arr[i].Y;
                if (max.Y < arr[i].Y)
                    max.Y = arr[i].Y;
            }
            Bitmap tmp = new Bitmap(max.X - min.X + 10, max.Y - min.Y + 10);
            using (Graphics g = Graphics.FromImage(tmp))
            {

                GraphicsPath pth = new GraphicsPath();
                pth.AddLines(arr.ToArray());
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen thick_pen = new Pen(Color.Black, 10))
                {
                    g.DrawPath(thick_pen, pth);
                }
                
            }
            drawnImages.Add(new drawnImage(tmp, new Point(min.X, min.Y)));
            wall = false;
            buttonWall.BackColor = Color.White;
            buttonWall.Tag = "0";
            drawnImages.Last().isWall = true;
            drawnImages.Last().lines = arr.ToArray();
            drawnImages.Last().buttonName = (buttonWall.Name);
            arr = new List<Point>();
            listBox1.SelectionMode = SelectionMode.One;
            drawAll();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (wall)
            {
                using (Graphics gr = Graphics.FromImage(bitmap))
                {
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    GraphicsPath pth = new GraphicsPath();
                    pth.AddLines(arr.ToArray());
                    gr.DrawPath(new Pen(Color.Black, 10), pth);
                    
                    using (Pen thick_pen = new Pen(Color.Black, 10))
                    {
                        thick_pen.StartCap = thick_pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                        gr.DrawLine(thick_pen,arr.Last(), end);
                    }
                }
               
            }
        }

       
        private bool hitline(Point Pt, Point Start, Point End)
        {
            if ((Pt.X < Start.X && Pt.X < End.X) || (Pt.X > Start.X && Pt.X > End.X) ||
           (Pt.Y < Start.Y && Pt.Y < End.Y) || (Pt.Y > Start.Y && Pt.Y > End.Y))
                return false;
            // now we calculate the distance:
            float dy = End.Y - Start.Y;
            float dx = End.X - Start.X;
            float Z = dy * Pt.X - dx * Pt.Y + Start.Y * End.X - Start.X * End.Y;
            float N = dy * dy + dx * dx;
            float dist = (float)(Math.Abs(Z) / Math.Sqrt(N));
            // done:
            return dist < 10 / 2f;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            isClicked = true;
            clicked = listBox1.SelectedIndex;
            drawAll();
        }
    
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (clicked != null && listBox1.SelectedIndex < 0)
                    listBox1.SetSelected(clicked.Value, true);
               
                if (isClicked&& listBox1.SelectedIndex>=0)
                {
                    drawnImages.RemoveAt(listBox1.SelectedIndex);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    isClicked = false;
                    clicked = null;
                    drawAll();
                }
                
            }
        }
      

        private void openBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            openFileDialog1.DefaultExt = "bp";
            openFileDialog1.Filter =
                "Blue print (*.bp)|*.bp";
            openFileDialog1.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    drawnImages = new List<drawnImage>();
                    listBox1.Items.Clear();
                    string file = openFileDialog1.FileName;
                    List<drawnImage> listofa = new List<drawnImage>();
                    XmlSerializer formatter = new XmlSerializer(drawnImages.GetType());
                    FileStream aFile = new FileStream(file, FileMode.Open);
                    byte[] buffer = new byte[aFile.Length];
                    aFile.Read(buffer, 0, (int)aFile.Length);
                    MemoryStream stream = new MemoryStream(buffer);

                    foreach (var img in (List<drawnImage>)formatter.Deserialize(stream))
                    {
                        foreach (var control in flowLayoutPanel1.Controls)
                        {
                            if (control is Button)
                                if (img.buttonName.Equals(((Button)control).Name))
                                {
                                    img.img = (Bitmap)((Button)control).BackgroundImage;
                                }

                        }
                        drawnImages.Add(img);
                        listBox1.Items.Add((img.buttonName + " {X=" + img.start.X + ",Y=" + img.start.Y + "}"));
                        
                    };
                    MessageBox.Show(loadSucc);
                }
                catch
                {
                    MessageBox.Show(loadFail);
                }
                drawAll();
            }
            
        }

        private void saveBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            saveFileDialog1.DefaultExt = "bp";
            saveFileDialog1.Filter =
                "Blue print (*.bp)|*.bp";
            saveFileDialog1.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string path = saveFileDialog1.FileName;
                    FileStream outFile = File.Create(path);
                    XmlSerializer formatter = new XmlSerializer(drawnImages.GetType());
                    formatter.Serialize(outFile, drawnImages);
                    MessageBox.Show(saveSucc);
                }
                catch 
                {
                    MessageBox.Show(saveFail);
                }
            }
        }
       
    }
}
