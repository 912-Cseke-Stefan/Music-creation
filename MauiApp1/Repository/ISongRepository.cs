using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Repository
{
    public interface ISongRepository
    {
        void add(Song elem);
        void delete(Song elem);
        Song? search(int id);
        Song[] getAll();
    }
}
