using NAudio.Wave;

namespace Music.MusicDomain
{
    internal class Track
    {
        private int id;
        private string title;
        private int type; // 1 - drums, 2 - instrument, 3 - fx, 4 - voice
        private long timestamp = 0;
        private byte[] songData;
        private WaveOutEvent waveOut;
        private WaveStream waveStream;
        private bool playing = false;

        public Track(int id, string title, int type, byte[] songData)
        {
            this.id = id;
            this.title = title;
            this.type = type;
            this.songData = songData;
            waveOut = new WaveOutEvent();
        }

        public int getId()
        {
            return id;
        }

        public byte[] getSongData()
        {
            return songData;
        }

        public string getTitle()
        {
            return title;
        }

        public int getType()
        {
            return type;
        }

        public void Play()
        {
            if (!playing)
            {
                //read the wav data from the byte array
                waveStream = new WaveFileReader(new MemoryStream(songData));
                //WaveStream waveStream = new Mp3FileReader(new MemoryStream(audioData));
                waveOut.Dispose();
                waveOut.Init(waveStream);
                waveOut.Play();
                playing = true;
            }
        }

        public void Pause()
        {
            if (playing)
            {
                timestamp = waveOut.GetPosition();
                waveOut.Pause();
                playing = false;
            }
        }

        public void Stop()
        {
            if (playing)
            {

                playing = false;
                timestamp = 0;
                waveOut.Dispose();
                waveStream.Dispose();

            }

        }

        public void Resume()
        {
            if (!playing)
            {
                WaveStream waveStream = new WaveFileReader(new MemoryStream(songData));
                //WaveStream waveStream = new Mp3FileReader(new MemoryStream(audioData));
                waveStream.Seek(timestamp, SeekOrigin.Begin);
                waveOut.Dispose();
                waveOut.Init(waveStream);
                waveOut.Play();
                playing = true;
            }
        }

        ~Track()
        {
            waveOut.Dispose();
        }
    }
}