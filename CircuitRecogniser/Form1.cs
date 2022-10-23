using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CircuitRecogniser
{
    public partial class Form1 : Form
    {
        Canny imageWarrior;
        string sFileName;
        bool canny = false;
        int sch = 0;
        LinkedList<poligons> listPoligon = new LinkedList<poligons>();
        LinkedList<poligons> rezult;
        LinkedList<poligons> rezult1;
        double brightRift;
        double maxBright;
        double minBright;
        int[,] rezCanny;
        string[] codeIm = new string[65536];
        poligons curr = new poligons();
        double[,] PIX_BR;
        byte[,] COMPRESSED;
        int maxFragmentation;
        Undo undoClass = new Undo(null, null);
        Boolean pic = false, pic2 = false;
        int count = 0;
        int rezultPoligons = 1;
        int curElement = 0;
        int blocked = 0;
        int nextFree;
        int[] rezMass = new int[10000000];
        Graphics g;

        private Bitmap SobelEdgeDetect(Bitmap original)
        {
            Bitmap b = original;
            int m = 0, n = 0;
            int[,] sobel = new int[imageWarrior.Obj.Width, imageWarrior.Obj.Height];
            int width = b.Width;
            int height = b.Height;
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            int limit = 64;

            int new_rx = 0, new_ry = 0;
            for (int i = 1; i < b.Width - 1; i++)
            {
                for (int j = 1; j < b.Height - 1; j++)
                {

                    new_rx = 0;
                    new_ry = 0;

                    for (int wi = -1; wi < 2; wi++)
                    {
                        for (int hw = -1; hw < 2; hw++)
                        {
                            new_rx += gx[wi + 1, hw + 1] * (int)PIX_BR[i + hw, j + wi]; ;
                            new_ry += gy[wi + 1, hw + 1] * (int)PIX_BR[i + hw, j + wi]; ;
                        }
                    }
                    if (new_rx * new_rx + new_ry * new_ry > limit * 128)
                        sobel[i, j] = 255;
                    else
                        sobel[i, j] = 0;
                }
            }
            PixelFormat pxf = PixelFormat.Format24bppRgb;
            Bitmap bmp = new Bitmap(sFileName);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);

            // Получаем адрес первой линии.
            IntPtr ptr = bmpData.Scan0;

            // Задаём массив из Byte и помещаем в него надор данных.
            // int numBytes = bmp.Width * bmp.Height * 3; 
            //На 3 умножаем - поскольку RGB цвет кодируется 3-мя байтами
            //Либо используем вместо Width - Stride
            int numBytes = bmpData.Stride * bmp.Height;
            int widthBytes = bmpData.Stride;
            byte[] rgbValues = new byte[numBytes];

            // Копируем значения в массив.
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            // Перебираем пиксели по 3 байта на каждый и меняем значения
            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {

                //int value = rgbValues[counter] + rgbValues[counter + 1] + rgbValues[counter + 2];
                byte color_b = 0;


                if (m == imageWarrior.Obj.Width)
                {
                    n++;
                    m = 0;
                }
                byte value = (byte)sobel[m, n];
                m++;
                color_b = value;

                rgbValues[counter] = color_b;
                rgbValues[counter + 1] = color_b;
                rgbValues[counter + 2] = color_b;

            }
            // Копируем набор данных обратно в изображение
            Marshal.Copy(rgbValues, 0, ptr, numBytes);

            // Разблокируем набор данных изображения в памяти.
            bmp.UnlockBits(bmpData);
            undoClass.add(bmp, false, true);
            count++;
            pic2 = true;
            return bmp;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pictures Files |*.jpg;*.jpeg;*.png";
            
            dialog.InitialDirectory = @"E:\";
            dialog.Multiselect = false;
            dialog.Title = "Please select an image.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sFileName = dialog.FileName;
                Bitmap bmp = new Bitmap(sFileName);
                imageWarrior = new Canny(bmp);
                buttonStart.Enabled = true;
                pictureInput.Image = imageWarrior.DisplayImage();
                PIX_BR = new double[imageWarrior.Obj.Width, imageWarrior.Obj.Height];
                int m = 0, n = 0;
                PixelFormat pxf = PixelFormat.Format24bppRgb;
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);
                IntPtr ptr = bmpData.Scan0;
                int numBytes = bmpData.Stride * bmp.Height;
                byte[] rgbValues = new byte[numBytes];
                Marshal.Copy(ptr, rgbValues, 0, numBytes);
                for (int counter = 0; counter < rgbValues.Length; counter += 3)
                {
                    double value = rgbValues[counter] * 0.3 + rgbValues[counter + 1] * 0.59 + rgbValues[counter + 2] * 0.11;
                    byte color_b = Convert.ToByte(value);
                    if (m == imageWarrior.Obj.Width)
                    {
                        n++;
                        m = 0;
                    }
                    PIX_BR[m, n] = value;
                    m++;
                    rgbValues[counter] = color_b;
                    rgbValues[counter + 1] = color_b;
                    rgbValues[counter + 2] = color_b;

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            CircRecPic form = new CircRecPic(new Bitmap(sFileName));
            if (radioButRoberts.Checked ==true)
            {
                imageWarrior.choise = 1;
                int limit = 150;
                Bitmap roberts = new Bitmap(sFileName);
                int m = imageWarrior.Obj.Width, n = imageWarrior.Obj.Height;
                int[,] Rob = new int[m, n];
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int Gx = 0, Gy = 0, G;
                        int zhx = 0, zhy = 0, zhxx = 0, zhyy = 0;
                        if ((j == m - 1) | (i == n - 1))
                        {
                            if ((j == m - 1) & (i == n - 1))
                            {
                                zhx = (byte)PIX_BR[j, i];
                                zhxx = 0;
                                zhy = 0;
                                zhyy = 0;
                            }
                            else
                            {
                                if (j == m - 1)
                                {
                                    zhx = (byte)PIX_BR[j, i];
                                    zhxx = 0;
                                    zhy = 0;
                                    zhyy = (byte)PIX_BR[j, i + 1];

                                }
                                if (i == n - 1)
                                {
                                    zhx = (byte)PIX_BR[j, i];
                                    zhxx = 0;
                                    zhy = (byte)PIX_BR[j + 1, i];
                                    zhyy = 0;
                                }
                            }
                        }
                        else
                        {
                            zhx = (byte)PIX_BR[j, i];
                            zhxx = (byte)PIX_BR[j + 1, i + 1];
                            zhy = (byte)PIX_BR[j + 1, i];
                            zhyy = (byte)PIX_BR[j, i + 1];

                        }
                        Gx = (zhxx - zhx);
                        Gy = (zhy - zhyy);
                        double GG = Gx * Gx + Gy * Gy;
                        double GGG = Math.Sqrt(GG);
                        G = Convert.ToInt32(GGG);
                        if (G > 255)
                        {
                            G = 255;
                        }
                        Rob[j, i] = G;
                    }
                }
                //MessageBox.Show(Convert.ToString(srZnach));
                for (int i = 0; i < 256; i++)
                    for (int j = 0; j < 256; j++)
                    {
                        Rob[j, i] = Rob[j, i] > limit / 4 ? 255 : 0;
                    }
                m = 0;
                n = 0;
                PixelFormat pxf = PixelFormat.Format24bppRgb;
                Bitmap bmp = new Bitmap(sFileName);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);
                // Получаем адрес первой линии.
                IntPtr ptr = bmpData.Scan0;
                // Задаём массив из Byte и помещаем в него надор данных.
                // int numBytes = bmp.Width * bmp.Height * 3; 
                //На 3 умножаем - поскольку RGB цвет кодируется 3-мя байтами
                //Либо используем вместо Width - Stride
                int numBytes = bmpData.Stride * bmp.Height;
                int widthBytes = bmpData.Stride;
                byte[] rgbValues = new byte[numBytes];

                // Копируем значения в массив.
                Marshal.Copy(ptr, rgbValues, 0, numBytes);

                // Перебираем пиксели по 3 байта на каждый и меняем значения
                for (int counter = 0; counter < rgbValues.Length; counter += 3)
                {
                    byte color_b = 0;
                    if (m == imageWarrior.Obj.Width)
                    {
                        n++;
                        m = 0;
                    }
                    byte value = (byte)Rob[m, n];
                    m++;
                    color_b = value;

                    rgbValues[counter] = color_b;
                    rgbValues[counter + 1] = color_b;
                    rgbValues[counter + 2] = color_b;
                }
                // Копируем набор данных обратно в изображение
                Marshal.Copy(rgbValues, 0, ptr, numBytes);
                // Разблокируем набор данных изображения в памяти.
                bmp.UnlockBits(bmpData);
                form = new CircRecPic(bmp);
                undoClass.add(bmp, false, true);
                count++;
                pic2 = true;
            }
            if (radioButSobel.Checked == true)
            {
                Bitmap sobel = new Bitmap(sFileName);
                form = new CircRecPic(SobelEdgeDetect(sobel));
                imageWarrior.choise = 2;
            }
            if (radioButPrevit.Checked == true)
            {
                imageWarrior.choise = 3;
                int limit = 150;
                int m = imageWarrior.Obj.Width, n = imageWarrior.Obj.Height;
                int[,] previtta = new int[m, n];
                int[,] gx = new int[,] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
                int[,] gy = new int[,] { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } };
                int new_rx = 0, new_ry = 0;
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < m; j++)
                    {

                        new_rx = 0;
                        new_ry = 0;

                        for (int wi = -1; wi < 2; wi++)
                        {
                            for (int hw = -1; hw < 2; hw++)
                            {
                                new_rx += gx[wi + 1, hw + 1] * (int)PIX_BR[i + hw, j + wi]; ;
                                new_ry += gy[wi + 1, hw + 1] * (int)PIX_BR[i + hw, j + wi]; ;
                            }
                        }
                        if (new_rx * new_rx + new_ry * new_ry > limit * 48)
                            previtta[i, j] = 255;
                        else
                            previtta[i, j] = 0;
                    }
                }
                PixelFormat pxf = PixelFormat.Format24bppRgb;
                Bitmap bmp = new Bitmap(sFileName);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);
                IntPtr ptr = bmpData.Scan0;
                int numBytes = bmpData.Stride * bmp.Height;
                int widthBytes = bmpData
                    .Stride;
                byte[] rgbValues = new byte[numBytes];
                // Копируем значения в массив.
                Marshal.Copy(ptr, rgbValues, 0, numBytes);

                // Перебираем пиксели по 3 байта на каждый и меняем значения
                for (int counter = 0; counter < rgbValues.Length; counter += 3)
                {
                    //int value = rgbValues[counter] + rgbValues[counter + 1] + rgbValues[counter + 2];
                    byte color_b = 0;
                    if (m == 256)
                    {
                        n++;
                        m = 0;
                    }
                    byte value = (byte)previtta[m, n];
                    m++;
                    color_b = value;

                    rgbValues[counter] = color_b;
                    rgbValues[counter + 1] = color_b;
                    rgbValues[counter + 2] = color_b;
                }
                // Копируем набор данных обратно в изображение
                Marshal.Copy(rgbValues, 0, ptr, numBytes);

                // Разблокируем набор данных изображения в памяти.
                bmp.UnlockBits(bmpData);
                form = new CircRecPic(bmp);
                undoClass.add(bmp, false, true);
                count++;
                pic2 = true;
            }
            if (radioButCanny.Checked == true)
            {
                imageWarrior.choise = 4;
                int limith = 100, m = 0, n = 0;
                int limitl = 80;
                int sizeOfGausMask = 5;
                rezCanny = new int[256, 256];
                Canny obj = new Canny(new Bitmap(sFileName), limith / 2, limitl / 2, sizeOfGausMask, 1);
                PixelFormat pxf = PixelFormat.Format24bppRgb;
                Bitmap bmp = new Bitmap(obj.DisplayImage(obj.EdgeMap));
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);
                IntPtr ptr = bmpData.Scan0;
                int numBytes = bmpData.Stride * bmp.Height;
                int widthBytes = bmpData.Stride;
                byte[] rgbValues = new byte[numBytes];
                Marshal.Copy(ptr, rgbValues, 0, numBytes);
                for (int counter = 0; counter < rgbValues.Length; counter += 3)
                {
                    if (rgbValues[counter] > 128)
                        rezCanny[m, n] = (int)PIX_BR[m, n];
                    else
                        rezCanny[m, n] = 0;
                    m++;
                    if (m == 256)
                    {
                        n++;
                        m = 0;
                    }
                }
                // Копируем набор данных обратно в изображение
                Marshal.Copy(rgbValues, 0, ptr, numBytes);

                // Разблокируем набор данных изображения в памяти.
                bmp.UnlockBits(bmpData);
                form = new CircRecPic(bmp);
                undoClass.add(bmp, false, true);
                count++;
                canny = true;
                pic2 = true;
            }
            buttonDownload.Enabled = true;
            form.Show(this);
        }



        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {

                //create the grayscale ColorMatrix
                System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(
                   new float[][]
                   {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (System.Drawing.Imaging.ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes())
                {

                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }
    }
}
