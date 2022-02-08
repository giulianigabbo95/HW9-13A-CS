using System;
using System.Linq;
using System.Collections.Generic;

namespace MyHomework
{
    public class RandomPoint
    {
        public int X { get; set; }
        public double Y { get; set; }

        public RandomPoint()
        {
            X = 0;
            Y = 0;
        }

        public RandomPoint(int x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public class RandomPath
    {
        public List<RandomPoint> Points { get; set; }

        public RandomPath()
        {
            Points = new List<RandomPoint>();
        }
    }

    public class Cluster
    {
        public double minValue { get; set; }
        public double maxValue { get; set; }
        public double Mean { get; set; }
        public double Variance { get; set; }
        public double Frequency { get; set; }

        public Cluster()
        {
            minValue = 0;
            maxValue = 0;
            Mean = 0;
            Variance = 0;
            Frequency = 0;
        }
    }

    public class Distribution
    {
        #region MEMBERS

        public List<RandomPath> Paths { get; set; }
        public List<List<RandomPoint>> Realizations { get; set; }
        public List<RandomPoint> Means { get; set; }
        public List<RandomPoint> Variances { get; set; }
        public List<List<Cluster>> Clusters  { get; set; }

        private Random R;

        private int noPoints { get; set; }
        private int noPaths { get; set; }
        private double sigma = 0;
        private double variance = 1;
        private double mu = 0;

        #endregion

        #region CONSTRUCTOR

        public Distribution(int nbPoints, int nbPaths)
        {
            noPoints = nbPoints;
            noPaths = nbPaths;

            this.Paths = new List<RandomPath>();
            this.Means = new List<RandomPoint>();
            this.Variances = new List<RandomPoint>();
            this.Realizations = new List<List<RandomPoint>>();
            this.Clusters = new List<List<Cluster>>();

            R = new Random();
        }

        #endregion

        #region PUBLIC

        public List<RandomPath> GenerateDistribution(int distributionType)
        {
            double lastValue = 0;
            double randomVal = 0;
            double y;

            List<RandomPath> paths = new List<RandomPath>();

            for (int i = 0; i < noPaths; i++)
            {
                var path = new RandomPath();

                lastValue = 0;
                for (int x = 1; x <= noPoints; x++)
                {
                    randomVal = GetRandomNormalVariable();
                    switch (distributionType)
                    {
                        case 0:
                            break;
                        case 1:
                            randomVal = Math.Exp(randomVal);
                            break;
                        case 2:
                            randomVal = Math.Pow(randomVal, 2);
                            break;
                        case 3:
                            var denom = GetRandomNormalVariable();
                            randomVal = Math.Pow(randomVal, 2) / Math.Pow(denom, 2);
                            break;
                        default:
                            break;
                    }


                    y = lastValue + randomVal;
                    lastValue = y;

                    RandomPoint p = new RandomPoint() { X = x, Y = y };
                    path.Points.Add(p);
                }

                paths.Add(path);
            }

            return paths;
        }

        public List<List<RandomPoint>> GenerateRealizations()
        {
            List<List<RandomPoint>> realizations = new List<List<RandomPoint>>();

            // Takes 8 vectors (point at time T) from each path with regular steps
            var n = (int)(noPoints / 8);
            List<List<double>> tPoints = new List<List<double>>();
            int j = 0;
            int i = n;
            while (i <= noPoints)
            {
                tPoints.Add(new List<double>());
                foreach (var path in this.Paths)
                {
                    var tPoint = path.Points.Where(f => f.X == i).FirstOrDefault();
                    if (tPoint != null)
                        tPoints[j].Add(tPoint.Y);
                }
                j++;
                i += n;
            }

            for (i = 0; i < tPoints.Count; i++)
            {
                var points = tPoints[i];
                var rpoints = new List<RandomPoint>();
                for (j = 0; j < points.Count(); j++)
                {
                    rpoints.Add(new RandomPoint() { X = j, Y = points[j] });
                }
                realizations.Add(rpoints);
            }

            return realizations;
        }

        public List<List<Cluster>> GenerateClusters(int nbClusters)
        {
            var allClusters = new List<List<Cluster>>();

            for (int i = 0; i < Realizations.Count; i++)
            {
                var realization = Realizations[i];

                allClusters.Add(new List<Cluster>());

                var tPoints = new List<double>();
                foreach (var p in realization)
                {
                    tPoints.Add(p.Y);
                }

                tPoints.Sort();
                var mint = tPoints.First();
                var maxt = tPoints.Last();
                var rng = maxt - mint > 0 ? (maxt - mint) / nbClusters : maxt / nbClusters;

                var clusters = new List<double>();
                for (int j = 0; j < nbClusters; j++)
                {
                    // valori positivi
                    var min = mint;
                    var max = min + rng;
                    var occurs = tPoints.Where(d => d >= min && d < max).Count();
                    var cluster = new Cluster() { minValue = min, maxValue = max, Frequency = occurs };
                    allClusters[i].Add(cluster);
                    mint = max;
                }
            }

            return allClusters;
        }

        #endregion

        #region PRIVATE

        private double GetRandomNormalVariable()
        {
            double u1;
            double u2;
            double rand_normal;

            // //< Method 1 >
            //double rSquared;

            //do
            //{
            //    u1 = 2.0 * R.NextDouble() - 1.0;
            //    u2 = 2.0 * R.NextDouble() - 1.0;
            //    rSquared = (u1 * u1) + (u2 * u2);
            //}
            //while (rSquared >= 1.0);
            //// </Method 1>

            ////polar tranformation 
            //double p = Math.Sqrt(-2.0 * Math.Log(rSquared) / rSquared);
            //rand_normal = u1 * p; //* sigma + mu;

            // <Method 2>
            u1 = R.NextDouble();
            u2 = R.NextDouble();
            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

            rand_normal = rand_std_normal * variance + mu;
            // </Method 2>

            // result
            return rand_normal;
        }

        #endregion
    }
}
