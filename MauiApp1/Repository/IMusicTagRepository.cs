using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Repository
{
    public interface IMusicTagRepository
    {
        void add(MusicTag elem);
        MusicTag? search(int id);
        MusicTag[] getAll();
    }
}
