using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallpaper.Data
{
    public class Point : INotifyPropertyChanged, ICloneable
    {
        public Point() { }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        double x;
        public double X {
            get => x;
            set
            {
                x = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("X"));
            }
        }
        double y;
        public double Y {
            get => y;
            set
            {
                y = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Y"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            var clone = new Point();
            clone.X = this.x;
            clone.Y = this.y;
            return clone;
        }
    }
}
