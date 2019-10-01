using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper.Data;

namespace Wallpaper.Services
{
    public interface ILineService
    {
        bool AreCrossing(Point A1, Point B1, Point A2, Point B2);
        bool AreCrossing(Line A, Line B);
    }
}
