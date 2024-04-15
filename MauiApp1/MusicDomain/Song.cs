namespace Music.MusicDomain
{
    internal class Song : Track
    {
        private string artist;

        public Song(int id, string title, string genre, int type, MusicTag tag, byte[] audioData, string artist)
            : base(id, title, genre, type, tag, audioData)
        {
            this.artist = artist;
        }

        public string getArtist()
        {
            return artist;
        }
    }
}
