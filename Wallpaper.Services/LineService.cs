using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper.Data;

namespace Wallpaper.Services
{
    public class LineService : ILineService
    {
        public bool AreCrossing(Point A1, Point B1, Point A2, Point B2)
        {
            return AreCrossing(new Line(A1, B1), new Line(A2, B2));
        }

        public bool AreCrossing(Line a, Line b)
        {
            double S1 = (a.B.X - a.A.X) * (b.A.Y - a.A.Y) - (a.B.Y - a.A.Y) * (b.A.X - a.A.X);
            double S2 = (a.B.X - a.A.X) * (b.B.Y - a.A.Y) - (a.B.Y - a.A.Y) * (b.B.X - a.A.X);

            return ((S1 > 0 && S2 < 0) || (S1 < 0 && S2 > 0));
        }
    }
}
