using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.MusicDomain;

namespace MauiApp1.Repository
{
    internal class TrackRepository : ITrackRepository
    {
        List<Track> tracks = new List<Track>();
   

        public TrackRepository()
        {
            tracks = new List<Track>(){
            new Track(1, "Track drum", 1, []),
            new Track(2, "Track drum", 1, []),
            new Track(3, "Track music", 2, []),
            new Track(4, "Track music", 2, []),
            new Track(5, "Track fx", 3, []),
            new Track(6, "Track fx", 3, []),
            new Track(7, "Track voice", 4, []),
            new Track(8, "Track voice", 4, []),

            }; 
        }

        public void add(Track elem)
        {
            tracks.Add(elem);
        }

        public void delete(Track elem)
        {
            if (!tracks.Contains(elem))
                throw new Exception("Element does not exist");
            tracks.Remove(elem);
        }

        public Track? search(int id)
        {
            return (from track in tracks
                    where track.getId() == id
                    select track).FirstOrDefault();
        }

        public List<Track> getAll()
        {
            return (from track in tracks
                                       select track).ToList();
        }
    }
}
