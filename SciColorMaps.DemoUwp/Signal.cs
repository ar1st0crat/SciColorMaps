using System;
using System.IO;

namespace SciColorMaps.DemoUwp
{
    class Signal
    {
        /// <summary>
        /// Samples from all channels
        /// </summary>
        private double[][] _samples;

        /// <summary>
        /// Default samples are taken from the first channel
        /// </summary>
        public double[] Samples => _samples[0];

        public int Length { get; private set; }
        public short SignalType { get; private set; }
        public short Channels { get; private set; }
        public int Freq { get; private set; }
        public int AverageBytesPerSecond { get; private set; }
        public short Align { get; private set; }
        public short BitsPerSample { get; private set; }

        public void Load(Stream waveStream)
        {
            using (var reader = new BinaryReader(waveStream))
            {
                if (reader.ReadInt32() != 0x46464952)     // "RIFF"
                {
                    throw new FormatException("NOT RIFF!");
                }

                // ignore file size
                reader.ReadInt32();

                if (reader.ReadInt32() != 0x45564157)     // "WAVE"
                {
                    throw new FormatException("NOT WAVE!");
                }

                // try to find "fmt " header in the file:

                var fmtPosition = reader.BaseStream.Position;
                while (fmtPosition != reader.BaseStream.Length - 1)
                {
                    reader.BaseStream.Position = fmtPosition;
                    var fmtId = reader.ReadInt32();
                    if (fmtId == 0x20746D66)
                    {
                        break;
                    }
                    fmtPosition++;
                }

                if (fmtPosition == reader.BaseStream.Length - 1)
                {
                    throw new FormatException("NOT fmt !");
                }

                var fmtSize = reader.ReadInt32();

                SignalType = reader.ReadInt16();
                Channels = reader.ReadInt16();
                Freq = reader.ReadInt32();
                AverageBytesPerSecond = reader.ReadInt32();
                Align = reader.ReadInt16();
                BitsPerSample = reader.ReadInt16();

                if (fmtSize == 18)
                {
                    var fmtExtraSize = reader.ReadInt16();
                    reader.ReadBytes(fmtExtraSize);
                }
                
                if (reader.ReadInt32() != 0x61746164)      // "data"
                {
                    throw new FormatException("NOT data!");
                }

                Length = reader.ReadInt32();

                Length /= Channels;
                Length /= (BitsPerSample / 8);

                _samples = new double[Channels][];
                for (var i = 0; i < Channels; i++)
                {
                    _samples[i] = new double[Length];
                }
                
                if (BitsPerSample == 8)
                {
                    for (var i = 0; i < Length; i++)
                    {
                        for (var j = 0; j < Channels; j++)
                        {
                            _samples[j][i] = (reader.ReadByte() - 128) / 256.0;
                        }
                    }
                }
                else
                {
                    for (var i = 0; i < Length; i++)
                    {
                        for (var j = 0; j < Channels; j++)
                        {
                            _samples[j][i] = reader.ReadInt16() / (double)short.MaxValue;
                        }
                    }
                }
            }
        }
    }
}
