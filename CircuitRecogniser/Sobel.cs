using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitRecogniser
{
    class Sobel : ControllerCircuitRecogniser
    {
        public void SobelRecognition()
        {
            for(int i = 1; i<inputBitmap.Width; i++)
            {
                for(int j = 1; i<inputBitmap.Height; j++)
                {
                    //outputBitmap.SetPixel(i, j, ) = Gradient(GetMatrix())
                }
            }
        }

        // Возвращает матрицу окресности точки [x,y]
        private int[,] GetMatrix(int[,] g, int x, int y, int size)
        {
            int[,] result = new int[size, size];
            result.Initialize();
            int delta = size / 2;
            for (int i = x - delta; i <= x + delta; i++)
                for (int j = y - delta; j <= y + delta; j++)
                    result[i - (x - delta), j - (y - delta)] = Convert.ToInt32(inputBitmap.GetPixel(i, j));
            // int ли? если int, то как потом цвет делать цветом?
            return result;
        }

        // результат поэлементного суммирования матриц окресности и изображения
        private static int Gradient(int[,] sxy)
        {
            int gx = sxy[2,0] + 2 * sxy[2, 1] + sxy[2, 2] - sxy[0, 0] - 2 * sxy[0, 1] - sxy[0, 2];
            int gy = sxy[0, 2] + sxy[1, 2] + sxy[2, 2] - sxy[0, 0] - sxy[1, 0] - sxy[2, 0];
            int res = (Math.Sqrt(gx * gx + gy * gy) > 0.5 ? 1 : 0);
            return res;
        }
    }
}
