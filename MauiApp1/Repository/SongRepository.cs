using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Repository
{
    public class SongRepository : ISongRepository
    {
        private List<Song> songs;

        public SongRepository()
        {
            songs = new List<Song>();
        }

        public void add(Song elem)
        {
            songs.Add(elem);
        }

        public void delete(Song elem)
        {
            if (!songs.Contains(elem))
                throw new Exception("Element does not exist");
            songs.Remove(elem);
        }

        public Song? search(int id)
        {
            return (from song in songs
                    where song.id == id
                    select song).Take(1); //?
        }

        public Song[] getAll()
        {
            return (from song in songs
                    select song).ToArray();
        }
    }
}
