using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallpaper.Data
{
    public class Line : INotifyPropertyChanged, ICloneable
    {
        public Line(){}
        public Line( Point a, Point b)
        {
            this.A = (Point)a.Clone();
            this.B = (Point)b.Clone();
        }

        Point a;
        public Point A
        {
            get => a;
            set
            {
                a = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("A"));
            }
        }
        Point b;
        public Point B
        {
            get => b;
            set
            {
                b = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("B"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            Line clone = new Line();
            clone.A = (Point)this.A.Clone();
            clone.B = (Point)this.B.Clone();
            return clone;
        }
    }
}
