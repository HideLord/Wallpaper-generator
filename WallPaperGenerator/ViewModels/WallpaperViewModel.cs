using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Wallpaper.Data;
using Wallpaper.Services;

namespace WallPaperGenerator.ViewModels
{
    public class WallpaperViewModel : INotifyPropertyChanged
    {
        private readonly ILineService lineService;

        ObservableCollection<Point> Points;
        private int numPoints;
        public int NumPoints
        {
            get => numPoints;
            set
            {
                numPoints = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumPoints"));
            }
        }

        private double width;
        public double Width
        {
            get => width;
            set
            {
                width = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Width"));
            }
        }

        private double height;
        public double Height
        {
            get => height;
            set
            {
                height = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Height"));
            }
        }
        public WallpaperViewModel(ILineService lineService)
        {
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            numPoints = 100;
            this.lineService = lineService;
            Points = new ObservableCollection<Point>();
        }

        private void GeneratePoints()
        {
            for(int i = 0; i < numPoints; i++)
            {
                var rand = new Random();
                Points.Add(
                    new Point(
                        rand.Next((int)Width),
                        rand.Next((int)Height)
                        )
                    );
            }
        }

        private void GenerateLines()
        {
            Debug.Assert(Points.Count == numPoints);

            List<Tuple<double,int>>[] distances = new List<Tuple<double, int>>[numPoints];

            for(int i = 0; i < numPoints; i++)
            {
                for(int j = 0; j < numPoints; j++)
                {
                    if (i == j)
                    {
                        distances[i].Add(new Tuple<double, int>(double.MaxValue, j));
                        continue;
                    }
                    double dist = Math.Sqrt(Math.Pow(Points[i].X - Points[j].X, 2) + Math.Pow(Points[i].Y - Points[j].Y, 2));
                    distances[i].Add(new Tuple<double, int>(dist,j));
                }
            }
            for(int i = 0; i < numPoints; i++) distances[i].Sort();

            bool[,] used = new bool[numPoints,numPoints];

            for(int i = 0; i < numPoints; i++)
            {
                // TODO algorithm
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
