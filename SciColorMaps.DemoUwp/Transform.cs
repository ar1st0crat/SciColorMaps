using System;
using System.Collections.Generic;
using System.Linq;

namespace SciColorMaps.DemoUwp
{
    /// <summary>
    /// Static class containing code of common DSP transforms:
    /// 
    ///  1) FFT + MagnitudeSpectrum and LogPowerSpectrum
    ///  2) STFT (spectrogram)
    /// 
    /// </summary>
    public static class Transform
    {
        /// <summary>
        /// One of many possible implementations of an FFT algorithm
        /// </summary>
        /// <param name="re">Array of real parts of samples</param>
        /// <param name="im">Array of imaginary parts of samples</param>
        /// <param name="n">Size of FFT</param>
        /// 
        /// NOTE: method expects FFT size to be a power of 2
        ///       however, for the sake of performance, does NOT check FFT size
        /// 
        private static void Fft(double[] re, double[] im, int n)
        {
            double t1, t2;
            int i, j;
            int L, M, S;

            L = n;
            M = n / 2;
            S = n - 1;
            while (L >= 2)
            {
                var l = L >> 1;
                t1 = Math.PI / l;
                var u1 = 1.0;
                var u2 = 0.0;
                var c = Math.Cos(t1);
                var s = -Math.Sin(t1);
                for (j = 0; j < l; j++)
                {
                    for (i = j; i < n; i += L)
                    {
                        var p = i + l;
                        t1 = re[i] + re[p];
                        t2 = im[i] + im[p];
                        var t3 = re[i] - re[p];
                        var t4 = im[i] - im[p];
                        re[p] = t3 * u1 - t4 * u2;
                        im[p] = t4 * u1 + t3 * u2;
                        re[i] = t1;
                        im[i] = t2;
                    }
                    var u3 = u1 * c - u2 * s;
                    u2 = u2 * c + u1 * s;
                    u1 = u3;
                }
                L >>= 1;
            }
            j = 0;
            for (i = 0; i < S; i++)
            {
                if (i > j)
                {
                    t1 = re[j];
                    t2 = im[j];
                    re[j] = re[i];
                    im[j] = im[i];
                    re[i] = t1;
                    im[i] = t2;
                }
                var k = M;
                while (j >= k)
                {
                    j -= k;
                    k >>= 1;
                }
                j += k;
            }
        }

        /// <summary>
        /// Magnitude spectrum:
        /// 
        ///     spectrum = sqrt(re * re + im * im)
        /// 
        /// </summary>
        /// <param name="real">Array of real parts of samples</param>
        /// <param name="imag">Array of imaginary parts of samples</param>
        /// <param name="fftSize">Size of FFT</param>
        /// <returns>Left HALF of the magnitude spectrum</returns>
        /// 
        /// NOTE: method expects FFT size to be a power of 2
        ///       however, for the sake of performance, does NOT check FFT size
        /// 
        public static double[] MagnitudeSpectrum(double[] real, double[] imag, int fftSize = 512)
        {
            Fft(real, imag, fftSize);

            var reals = real.Take(fftSize / 2);
            var imags = imag.Take(fftSize / 2);

            return reals.Zip(imags, (re, im) => Math.Sqrt(re * re + im * im)).ToArray();
        }

        /// <summary>
        /// Log power spectrum:
        /// 
        ///     spectrum = 20 * log10(re * re + im * im)
        /// 
        /// </summary>
        /// <param name="real">Array of real parts of samples</param>
        /// <param name="imag">Array of imaginary parts of samples</param>
        /// <param name="fftSize">Size of FFT</param>
        /// 
        /// NOTE: method expects FFT size to be a power of 2
        ///       however, for the sake of performance, does NOT check FFT size
        /// 
        /// <returns>Left HALF of the log-power spectrum</returns>
        public static double[] LogPowerSpectrum(double[] real, double[] imag, int fftSize = 512)
        {
            Fft(real, imag, fftSize);

            var reals = real.Take(fftSize / 2);
            var imags = imag.Take(fftSize / 2);

            return reals.Zip(imags, (re, im) => 20 * Math.Log10(re * re + im * im + 1e-12)).ToArray();
        }

        /// <summary>
        /// STFT (spectrogram) - list of spectra in time
        /// </summary>
        /// <param name="samples">The samples of signal</param>
        /// <param name="fftSize">Size of FFT</param>
        /// <param name="hopSize">Hop (overlap) size</param>
        /// <returns>Spectrogram of the signal</returns>
        public static List<double[]> Spectrogram(double[] samples, int fftSize = 512, int hopSize = 256)
        {
            var spectrogram = new List<double[]>();

            for (var start = 0; start + fftSize < samples.Length; start += hopSize)
            {
                var real = samples.Skip(start).Take(fftSize).ToArray();
                var imag = new double[fftSize];

                spectrogram.Add(MagnitudeSpectrum(real, imag, fftSize));
            }

            // if you need to process the last (not full) portion of data, pad it with zeros:

            // Array.Resize(ref real, fftSize);
            // Array.Resize(ref imag, fftSize);
            
            return spectrogram;
        }
    }
}
