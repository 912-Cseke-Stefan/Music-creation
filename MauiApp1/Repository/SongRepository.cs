using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.MusicDomain;

namespace MauiApp1.Repository
{
    internal class SongRepository : ISongRepository
    {
        List<Song> songs = new List<Song>
        {
            new Song(1, "Bohemian Rhapsody", 1, [], "Queen"),
            new Song(2, "Shape of You", 1, [], "Ed Sheeran"),
            new Song(3, "Rolling in the Deep", 1, [], "Adele"),
            new Song(4, "Hotel California", 1, [], "Eagles"),
            new Song(5, "Stairway to Heaven", 1, [], "Led Zeppelin")
        };


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
                    where song.getId() == id
                    select song).FirstOrDefault();
        }

        public Song[] getAll()
        {
            return (from song in songs
                    select song).ToArray();
        }
    }
}
