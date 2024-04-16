using NAudio.Wave;

namespace Music.MusicDomain
{
    internal class Track
    {
        private int id;
        private string title;
        private int type;
        private long timestamp = 0;
        private byte[] audioData;
        private WaveOutEvent waveOut;
        private bool playing = false;

        public Track(int id, string title, int type,byte[] audioData)
        {
            this.id = id;
            this.title = title;
            this.type = type;
            this.audioData = audioData;
            waveOut = new WaveOutEvent();
        }

        public int getId()
        {
            return id;
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
                WaveStream waveStream = new WaveFileReader(new MemoryStream(audioData));
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
                waveOut.Stop();
                playing = false;
                timestamp = 0;
            }
        }

        public void Resume()
        {
            if (!playing)
            {
                WaveStream waveStream = new WaveFileReader(new MemoryStream(audioData));
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

