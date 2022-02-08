using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomework
{
    public class ChartManager
    {
        #region Members

        private ggPictureBox ggPictBox;
        private Bitmap bmp;
        private Rectangle viewPort;
        private Graphics G;

        private int nbPoints;         // number of points for each path

        private Random R = new Random();
        private Distribution D;

        private Pen blackPen = new Pen(Color.Black);
        private Pen whitePen = new Pen(Color.White);

        Pen[] pens = new Pen[8] { Pens.Turquoise, Pens.Yellow, Pens.SeaGreen, Pens.Red, Pens.SpringGreen, Pens.Orange, Pens.RosyBrown, Pens.SeaShell };

        #endregion

        #region Constructor

        public ChartManager(Distribution rn, ggPictureBox pictureBox)
        {
            ggPictBox = pictureBox;
            bmp = new Bitmap(ggPictBox.Width, ggPictBox.Height);
            G = Graphics.FromImage(bmp);

            D = rn;

            nbPoints = D.Paths[0].Points.Count;
        }

        #endregion
        
        #region Public

        public void DrawPaths(int nbClusters = 0)
        {
            var box = new Rectangle(0, 0, ggPictBox.Width, ggPictBox.Height);
            G.FillRectangle(Brushes.White, box);
            viewPort = new Rectangle(0, 0, (ggPictBox.Width * 3 / 4) - 1, ggPictBox.Height - 1);
            G.FillRectangle(Brushes.Black, viewPort);

            double minX = 0;
            double maxX = nbPoints;
            double minY = double.MaxValue; 
            double maxY = double.MinValue;

            var tPoints = new List<double>();
            foreach (var path in D.Paths)
            {
                foreach (var tpoint in path.Points)
                {
                    if (tpoint.Y < minY)
                        minY = tpoint.Y;
                    if (tpoint.Y > maxY)
                        maxY = tpoint.Y;
                }
            }

            double rangeX = maxX - minX;
            double rangeY = maxY - minY;

            DrawPaths(minX, minY, rangeX, rangeY);

            int noCluster = nbClusters == 0 ? 10 : nbClusters;
            DrawHistogram(noCluster, nbPoints, minX, minY, rangeX, rangeY);

            ggPictBox.Image = bmp;
        }

        public void DrawCharts(List<RandomPoint> TPoints, Brush brush, int nbClusters = 0)
        {
            viewPort = new Rectangle(0, 0, (ggPictBox.Width) - 1, ggPictBox.Height - 20);
            G.FillRectangle(brush, viewPort);

            double minX = 0;
            double maxX = nbPoints;
            double minY = double.MaxValue;
            double maxY = double.MinValue;

            var tPoints = new List<double>();
            foreach (var tpoint in TPoints)
            {
                if (tpoint.Y < minY)
                    minY = tpoint.Y;
                if (tpoint.Y > maxY)
                    maxY = tpoint.Y;
            }

            double rangeX = maxX - minX;
            double rangeY = maxY - minY;

            int noCluster = nbClusters == 0 ? 10 : nbClusters;
            DrawRealizationHistogram(viewPort, TPoints, noCluster, minX, minY, rangeX, rangeY);

            ggPictBox.Image = bmp;
        }

        public void DrawMeans(List<RandomPoint> TPoints, int nbClusters = 0)
        {
            viewPort = new Rectangle(0, 0, (ggPictBox.Width) - 1, ggPictBox.Height - 20);
            G.FillRectangle(Brushes.DarkBlue, viewPort);

            double minX = 0;
            double maxX = nbPoints;
            double minY = TPoints.Min(k => k.Y);
            double maxY = TPoints.Max(k => k.Y);

            double rangeX = maxX - minX;
            double rangeY = maxY - minY;

            int noCluster = nbClusters == 0 ? 10 : nbClusters;
            DrawRealizationMeansHistogram("m", viewPort, TPoints, noCluster, minX, minY, rangeX, rangeY);

            ggPictBox.Image = bmp;
        }

        public void DrawVariances(List<RandomPoint> TPoints, int nbClusters = 0)
        {
            viewPort = new Rectangle(0, 0, (ggPictBox.Width) - 1, ggPictBox.Height - 20);
            G.FillRectangle(Brushes.DarkGreen, viewPort);

            double minX = 0;
            double maxX = nbPoints;
            double minY = TPoints.Min(k => k.Y);
            double maxY = TPoints.Max(k => k.Y);

            double rangeX = maxX - minX;
            double rangeY = maxY - minY;

            int noCluster = nbClusters == 0 ? 10 : nbClusters;
            DrawRealizationMeansHistogram("v", viewPort, TPoints, noCluster, minX, minY, rangeX, rangeY);

            ggPictBox.Image = bmp;
        }

        #endregion

        #region Private

        private void DrawPaths(double startX, double startY, double rangeX, double rangeY)
        {
            PointF origin = AdjustPoint(viewPort, new RandomPoint(0, 0), startX, startY, rangeX, rangeY);

            // Points Adjustment and drawing
            for (int i = 0; i < D.Paths.Count(); i++)
            {
                var path = D.Paths[i];

                SolidBrush randomBrush = new SolidBrush(Color.FromArgb(R.Next(255), R.Next(255), R.Next(255)));
                Pen randomPen = new Pen(randomBrush, 1.0f);

                var adjustedPoints = GetAdjustedPoints(viewPort, path.Points, startX, startY, rangeX, rangeY);
                for (int j = 0; j < adjustedPoints.Count - 1; j++)
                {
                    if (j == 0)
                        G.DrawLine(randomPen, (float)origin.X, (float)origin.Y, (float)adjustedPoints[j + 1].X, (float)adjustedPoints[j + 1].Y);
                    else
                        G.DrawLine(randomPen, (float)adjustedPoints[j].X, (float)adjustedPoints[j].Y, (float)adjustedPoints[j + 1].X, (float)adjustedPoints[j + 1].Y);
                }
            }

            //foreach (var path in D.Paths)
            //{
            //    PointF origin = AdjustPoint(new RandomPoint(0, 0), startX, startY, rangeX, rangeY);

            //    SolidBrush randomBrush = new SolidBrush(Color.FromArgb(R.Next(255), R.Next(255), R.Next(255)));
            //    Pen randomPen = new Pen(randomBrush, 1.0f);

            //    for (int i = 1; i < path.Points.Count; i++)
            //    {
            //        PointF lastPoint;
            //        PointF currPoint = AdjustPoint(new RandomPoint(path.Points[i].X, path.Points[i].Y), startX, startY, rangeX, rangeY);
            //        if (i == 1)
            //            lastPoint = origin;
            //        else
            //            lastPoint = AdjustPoint(new RandomPoint(path.Points[i - 1].X, path.Points[i - 1].Y), startX, startY, rangeX, rangeY);

            //        G.DrawLine(randomPen, currPoint.X, currPoint.Y, lastPoint.X, lastPoint.Y);
            //    }
            //}

            //var font = new Font("Calibri", 10.0f);
            //PointF max_x = AdjustPoint(viewPort, new RandomPoint(0, 0), startX, startY, rangeX, rangeY);
            //G.DrawString(tPoint.ToString(), font, Brushes.White, new PointF(origin.X, origin.Y + 10));

            var n = (int)(nbPoints / 8);
            int x = n;
            int c = 0;
            while (x <= nbPoints)
            {
                PointF p = AdjustPoint(viewPort, new RandomPoint(x, 0), startX, startY, rangeX, rangeY);
                G.DrawLine(pens[c], (float)p.X, 0, (float)p.X, ggPictBox.Height);
                x += n;
                c++;
            }

        }

        private void DrawHistogram(int nbClusters, int T, double startX, double startY, double rangeX, double rangeY)
        {
            int x = (int)AdjustX(viewPort, T, startX, rangeX);

            int w = 0;
            int y;
            int h;

            // Find min and max value in T
            var tPoints = new List<double>();
            foreach (var path in D.Paths)
            {
                var tPoint = path.Points.Where(f => f.X == T).FirstOrDefault();
                if (tPoint != null)
                    tPoints.Add(tPoint.Y);
            }

            if (tPoints.Count == 0)
                return;

            tPoints.Sort();
            var mint = tPoints.First();
            var maxt = tPoints.Last();
            var rng = maxt - mint > 0 ? maxt - mint : maxt;

            // Adjusts coordinates to viewport
            var y1 = (int)AdjustY(viewPort, mint, startY, rangeY);
            var y2 = (int)AdjustY(viewPort, maxt, startY, rangeY);

            // Creates clusters for histogram 
            var clusters = new List<double>();
            //nbClusters = (int)((y1 - y2) * 0.1);
            double clusterSize = rng / nbClusters;
            for (int i = 0; i < nbClusters; i++)
            {
                // valori positivi
                var min = mint;
                var max = min + clusterSize;
                var occurs = tPoints.Where(d => d >= min && d < max).Count();
                clusters.Add(occurs);
                mint = max;
            }

            // Calculates height of bars
            h = (y1 - y2) / clusters.Count;

            // Draws bars
            y = (int)y2;
            for (int i = 0; i < clusters.Count; i++)
            {
                w = (int)clusters[i];

                if (i == clusters.Count - 1)
                {
                    h = (int)(y1 - y);
                }

                Rectangle rectangle = new Rectangle(x, y - 1, w + 1, h);
                G.DrawRectangle(Pens.Black, rectangle);

                rectangle = new Rectangle(x, y, w + 1, h - 1);
                G.FillRectangle(Brushes.Gold, rectangle);

                //G.DrawString(clusters[i].ToString(), new Font(FontFamily.GenericSansSerif,6, FontStyle.Bold), Brushes.Black, new Point(x + 5, y));
                y = y + h;
            }

            //var frame = new Rectangle(x, 0, w + 1, ggPictBox.Height - 2);
            //var pen = T == nbPoints ? Pens.Red : Pens.Blue;
            //G.DrawRectangle(pen, frame);
        }

        private void DrawRealizationHistogram(Rectangle vp, List<RandomPoint> TPoints, int nbClusters, double startX, double startY, double rangeX, double rangeY)
        {
            int x = (int)AdjustX(vp, 0, startX, rangeX) + 50;

            int w = 0;
            int y;
            int h;
  
            // Find min and max value in T
            var tPoints = new List<double>();
            foreach (var p in TPoints)
            {
                tPoints.Add(p.Y);
            }

            if (tPoints.Count == 0)
                return;

            tPoints.Sort();
            var mint = tPoints.First();
            var maxt = tPoints.Last();
            var rng = maxt - mint > 0 ? maxt - mint : maxt;

            // Adjusts coordinates to viewport
            var y1 = (int)AdjustY(vp, mint, startY, rangeY);
            var y2 = (int)AdjustY(vp, maxt, startY, rangeY);

            // Creates clusters for histogram 
            var clusters = new List<double>();
            //nbClusters = (int)((y1 - y2) * 0.1);
            double clusterSize = rng / nbClusters;
            for (int i = 0; i < nbClusters; i++)
            {
                // valori positivi
                var min = mint;
                var max = min + clusterSize;
                var occurs = tPoints.Where(d => d >= min && d < max).Count();
                clusters.Add(occurs);
                mint = max;
            }

            // Calculates height of bars
            h = (y1 - y2) / clusters.Count;

            // Draws bars
            y = (int)y2;
            for (int i = 0; i < clusters.Count; i++)
            {
                w = (int)clusters[i];

                if (i == clusters.Count - 1)
                {
                    h = (int)(y1 - y);
                }

                Rectangle rectangle = new Rectangle(x, y - 1, w + 1, h);
                G.DrawRectangle(Pens.White, rectangle);

                rectangle = new Rectangle(x, y, w + 1, h - 1);
                G.FillRectangle(Brushes.Maroon, rectangle);

                G.DrawString(clusters[i].ToString(), new Font(FontFamily.GenericSansSerif,6, FontStyle.Bold), Brushes.Black, new Point(x - 20, y + 5));
                y = y + h;
            }

            var font = new Font(FontFamily.GenericMonospace, 9, FontStyle.Regular);
            G.DrawString("Realizations", font, Brushes.Black, new Point(x, y));
        }

        private void DrawRealizationMeansHistogram(string source, Rectangle vp, List<RandomPoint> TPoints, int nbClusters, double startX, double startY, double rangeX, double rangeY)
        {
            int x = (int)AdjustX(vp, 0, startX, rangeX) + 50;

            int w = 0;
            int y;
            int h;
            int maxOccurs = 0;

            var mint = TPoints.Min(k => k.Y);
            var maxt = TPoints.Max(k => k.Y);

            var clusters = new List<double>();
            foreach (var p in TPoints)
            {
                clusters.Add(p.Y);
            }

            // Adjusts coordinates to viewport
            var y1 = (int)AdjustY(vp, mint, startY, rangeY);
            var y2 = (int)AdjustY(vp, maxt, startY, rangeY);

            // Calculates height of bars
            h = (y1 - y2) / clusters.Count;

            // Draws bars
            y = (int)y2;
            for (int i = 0; i < clusters.Count; i++)
            {
                w = (int)clusters[i];

                if (w > maxOccurs)
                    maxOccurs = w;

                if (i == clusters.Count - 1)
                {
                    h = (int)(y1 - y);
                }

                Rectangle rectangle = new Rectangle(x, y - 1, w + 1, h);
                G.DrawRectangle(Pens.Black, rectangle);

                rectangle = new Rectangle(x, y, w + 1, h - 1);
                G.FillRectangle(Brushes.Red, rectangle);

                G.DrawString(clusters[i].ToString(), new Font(FontFamily.GenericSansSerif, 6, FontStyle.Bold), Brushes.White, new Point(x - 20, y + 5));
                y = y + h;
            }

            var font = new Font(FontFamily.GenericMonospace, 9, FontStyle.Regular);
            var label = source.ToLower() == "m" ? "Means" : "Variances";
            G.DrawString(label, font, Brushes.Black, new Point(x, y));
        }

        private List<PointF> GetAdjustedPoints(Rectangle vp, List<RandomPoint> points, double startX, double startY, double rangeX, double rangeY)
        {
            // Adjusts all points to viewport area
            List<PointF> adjustedPoints = new List<PointF>();

            foreach (RandomPoint point in points)
            {
                var adjPoint = AdjustPoint(vp, point, startX, startY, rangeX, rangeY);
                adjustedPoints.Add(adjPoint);
            }

            return adjustedPoints;
        }

        private PointF AdjustPoint(Rectangle vp, RandomPoint point, double startX, double startY, double rangeX, double rangeY)
        {
            // Adjusts the point to viewport area
            PointF adjustedPoint = new PointF();

            var X = AdjustX(vp, point.X, startX, rangeX);
            var Y = AdjustY(vp, point.Y, startY, rangeY);
            adjustedPoint = new PointF((float)X, (float)Y);

            return adjustedPoint;
        }

        private float AdjustX(Rectangle vp, double x, double startX, double rangeX)
        {
            return (float)(viewPort.Left + viewPort.Width * ((x - startX) / rangeX));
        }

        private float AdjustY(Rectangle vp, double y, double startY, double rangeY)
        {
            return (float)(viewPort.Top + viewPort.Height - (viewPort.Height * ((y - startY) / rangeY)));
        }

        #endregion
    }
}
