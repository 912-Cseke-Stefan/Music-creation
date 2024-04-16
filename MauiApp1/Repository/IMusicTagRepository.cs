using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.MusicDomain;

namespace MauiApp1.Repository
{
    internal interface IMusicTagRepository
    {
        void add(MusicTag elem);
        MusicTag? search(int id);
        MusicTag[] getAll();
    }
}
