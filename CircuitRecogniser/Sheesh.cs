using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitRecogniser
{
    public struct poligons
    {
        // координаты верхней левой и нижней правой точек полигона
        public int x1;
        public int x2;
        public int y1;
        public int y2;
        // высота и ширина полигона соответственно
        public int horizontalSide;
        public int verticalSide;
    }
    public struct img
    {
        public Image im1;
        public Image im2;
        public Boolean pic1;
        public Boolean pic2;
    }
    public class Undo
    {
        public LinkedList<img> Limg = null;
        public static int i = 0;
        public img istruct = new img();
        public Undo(Image image1, Image image2)
        {
            istruct.im1 = image1;
            istruct.im2 = image2;
            istruct.pic1 = true;
            istruct.pic2 = true;
            Limg = new LinkedList<img>();
            Limg.AddFirst(istruct);
        }
        public Undo()
        {
            Limg = new LinkedList<img>();
        }
        public void add(Image image1, Boolean pic1, Boolean pic2)
        {
            istruct.pic1 = pic1;
            istruct.pic2 = pic2;
            if (pic1)
                istruct.im1 = image1;

            else
                istruct.im2 = image1;
            Limg.AddLast(istruct);
            Undo.i++;
        }
        public void add(Image image1, Image image2, Boolean pic1, Boolean pic2)
        {
            istruct.pic1 = pic1;
            istruct.pic2 = pic2;
            istruct.im1 = image1;
            istruct.im2 = image2;
            Limg.AddLast(istruct);
            Undo.i++;
        }
        public void add(Image image1, Image image2)
        {
            istruct.im1 = image1;
            istruct.im2 = image2;
            Limg.AddLast(istruct);
            Undo.i++;
        }
        public img getLast()
        {
            return Limg.Last();
        }
    }
}
