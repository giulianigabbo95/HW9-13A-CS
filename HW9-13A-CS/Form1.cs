using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyHomework
{
    public partial class Form1 : Form
    {
        private int m;          // n. of paths
        private int n;          // number of points for each path
        private double sigma;   // distribution variance
        private int t;          // distibutionType
        private int c;          // nb of clusters for histograms
        private int ni;         // n. of iterations for means calculation

        private Distribution RN;

        private ggPictureBox ggPictureBox1;
        private ggPictureBox ggPictBoxMeans;
        private ggPictureBox ggPictBoxVariances;

        private Brush[] brushes = new Brush[8] { Brushes.Turquoise, Brushes.Yellow, Brushes.SeaGreen, Brushes.Red, Brushes.SpringGreen, Brushes.Orange, Brushes.RosyBrown, Brushes.SeaShell };

        public Form1()
        {
            InitializeComponent();

            ggPictureBox1 = new ggPictureBox(MainPanel);
            ggPictureBox1.BackColor = Color.White;
            ggPictureBox1.Top = 0;
            ggPictureBox1.Left = 0;
            ggPictureBox1.Height = MainPanel.Height / 10 * 5;
            ggPictureBox1.Width = MainPanel.Width / 10 * 5;
            ggPictureBox1.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Controls.Add(ggPictureBox1);

            ggPictBoxMeans = new ggPictureBox(MainPanel);
            ggPictBoxMeans.BackColor = Color.White;
            ggPictBoxMeans.Top = ggPictureBox1.Top;
            ggPictBoxMeans.Left = ggPictureBox1.Left + ggPictureBox1.Width;
            ggPictBoxMeans.Height = MainPanel.Height / 3;
            ggPictBoxMeans.Width = MainPanel.Width / 8;
            ggPictBoxMeans.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Controls.Add(ggPictBoxMeans);

            ggPictBoxVariances = new ggPictureBox(MainPanel);
            ggPictBoxVariances.BackColor = Color.White;
            ggPictBoxVariances.Top = ggPictBoxMeans.Top;
            ggPictBoxVariances.Left = ggPictBoxMeans.Right;
            ggPictBoxVariances.Height = MainPanel.Height / 3;
            ggPictBoxVariances.Width = MainPanel.Width / 8;
            ggPictBoxVariances.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Controls.Add(ggPictBoxVariances);

            NbPoints.Value = 100;
            NbClusters.Value = 10;
            cmbDistributionType.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetVariables();
        }

        // Events
        //--------------------------------------------------------

        private void btnRecalc_Click(object sender, EventArgs e)
        {
            SetVariables();
            CreateStatEngineInstance();
            DrawChart();
        }

        private void NbPoints_ValueChanged(object sender, EventArgs e)
        {
            SetVariables();
            CreateStatEngineInstance();
            DrawChart();
        }

        private void variance_ValueChanged(object sender, EventArgs e)
        {
            SetVariables();
            CreateStatEngineInstance();
            DrawChart();
        }

        private void NbPath_ValueChanged(object sender, EventArgs e)
        {
            SetVariables();
            CreateStatEngineInstance();
            DrawChart();
        }

        private void cmbDistribution_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVariables();
            CreateStatEngineInstance();
            DrawChart();
        }

        private void btnClusters_Click(object sender, EventArgs e)
        {
            SetVariables();
            DrawChart();
        }

        private void NbClusters_ValueChanged(object sender, EventArgs e)
        {
            SetVariables();
            DrawChart();
        }

        private void cmbDistributionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVariables();
            CreateStatEngineInstance();
            DrawChart();
        }

        private void btnMeans_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SetVariables();
            MeansCalculation();
            Cursor.Current = Cursors.Default;
        }

        // Methods
        //--------------------------------------------------------

        private void SetVariables()
        {
            n = (int)NbPoints.Value;
            m = (int)NbPath.Value;
            c = (int)NbClusters.Value;
            t = cmbDistributionType.SelectedIndex;
            ni = (int)NbIterations.Value;
        }

        private void CreateStatEngineInstance()
        {
            RN = new Distribution(n, m);
            RN.Paths = RN.GenerateDistribution(t);
            RN.Realizations = RN.GenerateRealizations();
            RN.Clusters = RN.GenerateClusters(c);
        }

        private void DrawChart()
        {
            if (RN != null)
            {
                //MainPanel.Controls.Clear();

                ChartManager CM = new ChartManager(RN, ggPictureBox1);
                CM.DrawPaths(c);

                if (MainPanel.Controls.Count > 3)
                {
                    for (int i = MainPanel.Controls.Count - 1; i >= 3; i--)
                    {
                        MainPanel.Controls.RemoveAt(i);
                    }
                }

                for (int i = 0; i < RN.Realizations.Count; i++)
                {
                    var ggPictBox = new ggPictureBox(MainPanel);
                    ggPictBox.Name = $"PB{i}";
                    ggPictBox.BackColor = Color.White;
                    ggPictBox.Top = ggPictureBox1.Bottom;   // + i * 5; ;
                    ggPictBox.Left = i == 0 ? MainPanel.Left : MainPanel.Left + i * MainPanel.Width / 8;
                    ggPictBox.Height = MainPanel.Height / 3;
                    ggPictBox.Width = MainPanel.Width / 8;
                    ggPictBox.BorderStyle = BorderStyle.FixedSingle;
                    MainPanel.Controls.Add(ggPictBox);

                    CM = new ChartManager(RN, ggPictBox);
                    CM.DrawCharts(RN.Realizations[i], brushes[i], c);
                }
            }
        }

        private void MeansCalculation()
        {
            RN.Means = new List<RandomPoint>();
            RN.Variances = new List<RandomPoint>();
            for (int i = 0; i < c; i++)
            {
                RN.Means.Add(new RandomPoint() { X = i, Y = 0 });
                RN.Variances.Add(new RandomPoint() { X = i, Y = 0 });
            }

            for (int it = 0; it < ni; it++)
            {
                var rn = new Distribution(n, m);
                rn.Paths = RN.GenerateDistribution(t);
                rn.Realizations = rn.GenerateRealizations();
                rn.Clusters = rn.GenerateClusters(c);
                rn.Means = new List<RandomPoint>();
                rn.Variances = new List<RandomPoint>();

                for (int i = 0; i < c; i++)
                {
                    rn.Means.Add(new RandomPoint() { X = i, Y = 0 });
                    rn.Variances.Add(new RandomPoint() { X = i, Y = 0 });
                    for (int j = 0; j < rn.Clusters.Count; j++)
                    {
                        if (j == 0)
                            rn.Means[i].Y = rn.Clusters[j][i].Frequency;
                        else
                            rn.Means[i].Y += rn.Clusters[j][i].Frequency;
                    }
                    rn.Means[i].Y = Math.Round(rn.Means[i].Y / rn.Clusters.Count, 0);

                    for (int j = 0; j < rn.Clusters.Count; j++)
                    {
                        rn.Variances[i].Y += Math.Pow(rn.Clusters[j][i].Frequency - rn.Means[i].Y, 2);
                    }
                    rn.Variances[i].Y = Math.Round(rn.Variances[i].Y / (rn.Clusters.Count - 1), 0);
                }

                for (int k = 0; k < rn.Means.Count; k++)
                {
                    RN.Means[k].Y += rn.Means[k].Y;
                    RN.Variances[k].Y += rn.Variances[k].Y;
                }
            }

            for (int k = 0; k < RN.Means.Count; k++)
            {
                RN.Means[k].Y = Math.Round(RN.Means[k].Y / ni, 0);
                RN.Variances[k].Y = Math.Round(RN.Variances[k].Y / ni, 0);
            }

            ChartManager cm = new ChartManager(RN, ggPictBoxMeans);
            cm.DrawMeans(RN.Means, c);

            cm = new ChartManager(RN, ggPictBoxVariances);
            cm.DrawVariances(RN.Variances, c);
        }
    }
}
