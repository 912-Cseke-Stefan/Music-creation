﻿using NAudio.Wave;

namespace Music.MusicDomain
{
    public class LoopStream : WaveStream
    {
        WaveStream sourceStream;

        /// <summary>
        /// Creates a new Loop stream
        /// </summary>
        /// <param name="sourceStream">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
        /// or else we will not loop to the start again.</param>
        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
            this.EnableLooping = true;
        }

        /// <summary>
        /// Use this to turn looping on or off
        /// </summary>
        public bool EnableLooping { get; set; }

        /// <summary>
        /// Return source stream's wave format
        /// </summary>
        public override WaveFormat WaveFormat
        {
            get { return sourceStream.WaveFormat; }
        }

        /// <summary>
        /// LoopStream simply returns
        /// </summary>
        public override long Length
        {
            get { return sourceStream.Length; }
        }

        /// <summary>
        /// LoopStream simply passes on positioning to source stream
        /// </summary>
        public override long Position
        {
            get { return sourceStream.Position; }
            set { sourceStream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    if (sourceStream.Position == 0 || !EnableLooping)
                    {
                        // something wrong with the source stream
                        break;
                    }
                    // loop
                    sourceStream.Position = 0;
                }
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }
    }

    internal class Track
    {
        private int id;
        public string title { get; }

        private int type; // 1 - drums, 2 - instrument, 3 - fx, 4 - voice
        private long timestamp = 0;
        private byte[] songData;
        private WaveOutEvent waveOut;
        private WaveStream waveStream;

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
            if (songData.Length == 0 || songData == null)
            {
                return;
            }
            if (waveOut.PlaybackState == PlaybackState.Stopped )
            {
                //read the wav data from the byte array
                waveStream = new WaveFileReader(new MemoryStream(songData));
                //WaveStream waveStream = new Mp3FileReader(new MemoryStream(audioData));
                LoopStream loop = new LoopStream(waveStream);
                loop.EnableLooping = true;

                waveOut.Dispose();
                waveOut.Init(loop);
                waveOut.Play();
            }
        }

        public void Stop()
        {
            timestamp = 0;
            waveOut.Dispose();
            if(waveStream != null)
            {
                waveStream.Dispose();
            }
            

        }

        ~Track()
        {
            waveOut.Dispose();
        }

        public PlaybackState GetPlaybackState()
        {
            return waveOut.PlaybackState;
        }
    }
}