using System;
using System.Collections.Generic;
using System.Linq;

namespace SciColorMaps.Portable
{
    /// <summary>
    /// Color map 
    /// 1) uses particular color palette (as in matplotlib or user-defined),
    /// 2) automatically calculates color by value and range,
    /// 3) can work with any number of colors in range [2, 256]
    /// 
    /// Usage example:
    /// 
    ///     var cmap = new ColorMap("coolwarm", -0.5, 0.5));
    ///     ...
    ///     var color = cmap[0.3];
    ///     
    ///     var viridis = new ColorMap();
    ///     
    ///     var cm = new ColorMap("ocean", 10, 100, 32 /*colors*/)
    ///     
    ///     
    /// All standard matplotlib palettes are available including:
    ///     bone, cool, coolwarm, gist_earth, gnuplot, gnuplot2, hot, inferno,
    ///     jet, ocean, rainbow, seismic, spectral, terrain, viridis (default), etc.
    ///     
    /// Users can create their own palettes, like this:
    /// 
    ///     var colors = new [] { 
    ///                            new byte[] {0, 0, 0},
    ///                            new byte[] {192, 0, 0},
    ///                            new byte[] {255, 224, 255}
    ///                          };
    ///     var positions = new [] { 0, 0.4f, 1 };
    ///     
    ///     // 1) static factory method with default colormap parameters:
    ///     var cmap1 = ColorMap.CreateFromColors(colors, positions);
    ///     
    ///     // 2) static factory method, full set of parameters:
    ///     var cmap2 = ColorMap.CreateFromColors(colors, positions, 10, 100, 32);
    ///     
    ///     // 3) ColorMap constructor:
    ///     var cmap3 = new ColorMap("my_own_colormap", 10, 100, 32, colors, positions);
    ///     
    ///     // Option 3 allows user setting the name of the custom colormap
    ///     // Otherwise the name is set by default: "user"
    ///     
    /// </summary>
    public class ColorMap
    {
        /// <summary>
        /// Color palette is an array of predefined RGB values
        /// </summary>
#if !RECTANGULAR
        protected byte[][] _palette;
#else
        protected byte[,] _palette;
#endif

        /// <summary>
        /// Number of colors in colormap
        /// </summary>
        private readonly int _colorCount;

        /// <summary>
        /// Lower bound of the colormap range
        /// </summary>
        private readonly double _lower;

        /// <summary>
        /// Upper bound of the colormap range
        /// </summary>
        private readonly double _upper;

        /// <summary>
        /// Range of values corresponding to one color in the colormap
        /// (is calculated in the constructor based on given parameters)
        /// </summary>
        private readonly double _colorRange;

        /// <summary>
        /// Number of palette colors corresponding to one color in the colormap
        /// (is calculated in the constructor based on given parameters)
        /// </summary>
        private readonly double _colorBinSize;

        /// <summary>
        /// Palette name ("jet", "viridis", "terrain", etc.)
        /// </summary>
        public string PaletteName { get; private set; }

        /// <summary>
        /// The number of interpolated colors in palettes (full palette)
        /// (currently 256, but it is customizable)
        /// </summary>
        public const int PaletteColors = 256;

        /// <summary>
        /// Return collection of available palettes
        /// </summary>
        public static IEnumerable<string> Palettes => Palette.Names;

        private const string DefaultPalette = "viridis";


        /// <summary>
        /// Default constructor creates Viridis colormap
        /// </summary>
        public ColorMap() : this(DefaultPalette)
        {
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="colorMap">Copied colormap</param>
        public ColorMap(ColorMap colorMap)
        {
            PaletteName = colorMap.PaletteName;
            _palette = colorMap._palette;
            _lower = colorMap._lower;
            _upper = colorMap._upper;
            _colorCount = colorMap._colorCount;
            _colorRange = colorMap._colorRange;
            _colorBinSize = colorMap._colorBinSize;
        }

        /// <summary>
        /// Construct new colormap
        /// </summary>
        /// <param name="name">Palette name</param>
        /// <param name="lower">Lower bound of the colormap range (optional)</param>
        /// <param name="upper">Upper bound of the colormap range (optional)</param>
        /// <param name="colorCount">Number of colors in colormap (optional)</param>
        /// <param name="colors">User-defined collection of colors (optional)</param>
        /// <param name="positions">User-defined collection of color positions in palette (optional)</param>
        /// <exception cref="ArgumentException">Thrown if:
        /// 1) Palette name is null
        /// 2) Number of colors is less than 2 or greater than number of colors in palette
        /// 3) Lower bound is greater than the upper one
        /// </exception>
        public ColorMap(string name,
                        double lower = 0.0,
                        double upper = 1.0,
                        int colorCount = PaletteColors,
                        IEnumerable<byte[]> colors = null,
                        IEnumerable<float> positions = null)
        {
            if (name == null)
            {
                throw new ArgumentException("Palette name should not be null!");
            }

            if (colorCount <= 1 || colorCount > PaletteColors)
            {
                throw new ArgumentException(string.Format(
                    "Number of colors should be in range [2, {0}]!", PaletteColors));
            }

            if (lower >= upper)
            {
                throw new ArgumentException("Upper bound should be greater than the lower one!");
            }

            _colorCount = colorCount;
            _lower = lower;
            _upper = upper;
            _colorRange = (_upper - _lower) / _colorCount;
            _colorBinSize = PaletteColors / (_colorCount - 1 + 1.0 / PaletteColors);

            // create colormap from a predefined palette:
            if (colors == null)
            {
                PaletteName = name.ToLower();

                if (!Palette.ByName.ContainsKey(PaletteName))
                {
                    PaletteName = DefaultPalette;
                }

                positions = Enumerable.Range(0, Palette.Resolution)
                        .Select(pos => (float)pos / (Palette.Resolution - 1))
                        .ToArray();

                CreatePalette(Palette.ByName[PaletteName].Value, positions);
            }
            // create colormap from user-defined colors:
            else
            {
#if !RECTANGULAR
                CreatePalette(colors, positions);
#else
                // convert collection of byte[] to rectangular array
                var colors2D = new byte[colors.Count(), 3];

                var i = 0;
                foreach (var color in colors)
                {
                    colors2D[i, 0] = color[0];
                    colors2D[i, 1] = color[1];
                    colors2D[i, 2] = color[2];
                    i++;
                }

                CreatePalette(colors2D, positions);
#endif
            }
        }

        /// <summary>
        /// Static factory method for creating user-defined palette
        /// </summary>
        /// <param name="colors">Collection of colors as byte[3] arrays</param>
        /// <returns>ColorMap object</returns>
        public static ColorMap CreateFromColors(IEnumerable<byte[]> colors,
                                                IEnumerable<float> positions,
                                                double lower = 0.0,
                                                double upper = 1.0,
                                                int colorCount = PaletteColors)
        {
            return new ColorMap("user", lower, upper, colorCount, colors, positions);
        }

        /// <summary>
        /// Method performs a simple RGB color interpolation for creating user-defined palette
        /// </summary>
        /// <param name="colors">Collection of colors</param>
        /// <param name="positions">Collection of color positions</param>
        /// <exception cref="ArgumentException">Thrown if:
        /// 1) Collection of colors or color positions is null
        /// 2) Number of colors is not the same as the number of color positions
        /// 3) Number of colors is not in the range [2, PaletteColors]
        /// 4) First color position is not 0.0f or last position is not 1.0f
        /// </exception>
#if !RECTANGULAR
        private void CreatePalette(IEnumerable<byte[]> colors, IEnumerable<float> positions)
        {
            if (colors == null || positions == null)
            {
                throw new ArgumentException("Collections of colors and positions should not be null!");
            }

            if (colors.Count() != positions.Count())
            {
                throw new ArgumentException("Number of colors should be the same as the number of color positions!");
            }

            if (colors.Count() <= 1 || colors.Count() > PaletteColors)
            {
                throw new ArgumentException(string.Format(
                    "Number of colors should be in range [2, {0}]!", PaletteColors));
            }

            if (positions.First().CompareTo(0) != 0 || positions.Last().CompareTo(1) != 0)
            {
                throw new ArgumentException("First color position should be 0.0f and last position should be 1.0f!");
            }

            if (colors.Any(c => c.Length != 3))
            {
                throw new ArgumentException("Each color should be an array of 3 bytes!");
            }

            _palette = new byte[PaletteColors][];

            var groups = positions.Select(pos => (int)(pos * PaletteColors)).ToList();

            var i = 0;
            for (var group = 0; group < groups.Count - 1; group++)
            {
                var color1 = colors.ElementAt(group);
                var color2 = colors.ElementAt(group + 1);

                var groupSize = groups[group + 1] - groups[group];

                for (var j = 0; j < groupSize; j++)
                {
                    _palette[i] = new byte[3];

                    _palette[i][0] = (byte)(color1[0] + (double)(color2[0] - color1[0]) * j / groupSize);
                    _palette[i][1] = (byte)(color1[1] + (double)(color2[1] - color1[1]) * j / groupSize);
                    _palette[i][2] = (byte)(color1[2] + (double)(color2[2] - color1[2]) * j / groupSize);

                    i++;
                }
            }
        }
#else
        private void CreatePalette(byte[,] colors, IEnumerable<float> positions)
        {
            var colorCount = colors.GetLength(0);

            if (colors == null || positions == null)
            {
                throw new ArgumentException("Collections of colors and positions should not be null!");
            }

            if (colorCount != positions.Count())
            {
                throw new ArgumentException("Number of colors should be the same as the number of color positions!");
            }

            if (colorCount <= 1 || colorCount > PaletteColors)
            {
                throw new ArgumentException(string.Format(
                    "Number of colors should be in range [2, {0}]!", PaletteColors));
            }

            if (positions.First().CompareTo(0) != 0 || positions.Last().CompareTo(1) != 0)
            {
                throw new ArgumentException("First color position should be 0.0f and last position should be 1.0f!");
            }

            if (colors.GetLength(1) != 3)
            {
                throw new ArgumentException("Each color should be an array of 3 bytes!");
            }

            _palette = new byte[PaletteColors, 3];

            var groups = positions.Select(pos => (int) (pos*PaletteColors)).ToList();

            var i = 0;
            for (var group = 0; group < groups.Count - 1; group++)
            {
                var groupSize = groups[group + 1] - groups[group];

                for (var j = 0; j < groupSize; j++)
                {
                    _palette[i, 0] =
                        (byte) (colors[group, 0] + (double) (colors[group + 1, 0] - colors[group, 0]) * j / groupSize);
                    _palette[i, 1] =
                        (byte) (colors[group, 1] + (double) (colors[group + 1, 1] - colors[group, 1]) * j / groupSize);
                    _palette[i, 2] =
                        (byte) (colors[group, 2] + (double) (colors[group + 1, 2] - colors[group, 2]) * j / groupSize);

                    i++;
                }
            }
        }
#endif

        /// <summary>
        /// Method returns colorCount-sized collection of base colors covering entire palette
        /// </summary>
        /// <returns>Collection of colors</returns>
        public IEnumerable<byte[]> Colors()
        {
#if !RECTANGULAR
            for (var i = 0; i < _colorCount; i++)
            {
                var idx = (int)(i * _colorBinSize);
                yield return _palette[idx];
            }
#else
            for (var i = 0; i < _colorCount; i++)
            {
                var idx = (int)(i * _colorBinSize);
                yield return new []
                {
                    _palette[idx, 0],
                    _palette[idx, 1],
                    _palette[idx, 2]
                };
            }
#endif
        }

        /// <summary>
        /// Get RGB values corresponding to a given domain value 
        /// </summary>
        /// <param name="value">Particular domain value</param>
        /// <returns>Array of 3 bytes (R, G, B)</returns>
        public byte[] this[double value]
        {
#if !RECTANGULAR
            get
            {
                if (value <= _lower)
                {
                    return _palette[0];
                }

                if (value >= _upper)
                {
                    return _palette[PaletteColors - 1];
                }

                // get position of the closest color with current resolution
                var pos = (int)((value - _lower) / _colorRange);

                // get the index of this color in palette
                var idx = (int)(pos * _colorBinSize);

                return _palette[idx];
            }
#else
            get
            {
                if (value <= _lower)
                {
                    return new [] 
                    {
                        _palette[0, 0],
                        _palette[0, 1],
                        _palette[0, 2]
                    };
                }

                if (value >= _upper)
                {
                    return new []
                    {
                        _palette[PaletteColors - 1, 0],
                        _palette[PaletteColors - 1, 1],
                        _palette[PaletteColors - 1, 2]
                    };
                }

                // get position of the closest color with current resolution
                var pos = (int)((value - _lower) / _colorRange);

                // get the index of this color in palette
                var idx = (int)(pos * _colorBinSize);

                return new []
                {
                    _palette[idx, 0],
                    _palette[idx, 1],
                    _palette[idx, 2]
                };
            }
#endif
        }
    }
}
