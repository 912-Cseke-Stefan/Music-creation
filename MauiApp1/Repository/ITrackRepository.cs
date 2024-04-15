using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Repository
{
    internal interface ITrackRepository
    {
        void add(Track elem);
        void delete(Track elem);
        Track? search(int id);
        Track[] getAll();
    }
}
