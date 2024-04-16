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
        private List<Track> tracks;

        public TrackRepository()
        {
            tracks = new List<Track>();
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

        public Track[] getAll()
        {
            return (from track in tracks
                    select track).ToArray();
        }
    }
}
