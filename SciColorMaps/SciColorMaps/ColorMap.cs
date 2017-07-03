using System;
using System.Collections.Generic;
using System.Drawing;

namespace SciColorMaps
{
    /// <summary>
    /// Color map 
    /// 1) uses particular color palette,
    /// 2) automatically calculates color by value and range,
    /// 3) can work with any number of colors
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
        private int _colorCount;

        /// <summary>
        /// Lower bound of the colormap range
        /// </summary>
        private double _lower;

        /// <summary>
        /// Upper bound of the colormap range
        /// </summary>
        private double _upper;

        /// <summary>
        /// Range of values corresponding to one color in the colormap
        /// (is calculated in the constructor based on given parameters)
        /// </summary>
        private double _colorRange;

        /// <summary>
        /// Number of palette colors corresponding to one color in the colormap
        /// (is calculated in the constructor based on given parameters)
        /// </summary>
        private double _colorBinSize;

        /// <summary>
        /// Palette name ("jet", "viridis", "terrain", etc.)
        /// </summary>
        public string PaletteName { get; private set; }

        /// <summary>
        /// Return the number of predefined base colors in palettes
        /// (i.e. 256, but it can be made customizable)
        /// </summary>
        public const int PaletteColors = Palette.Resolution;

        /// <summary>
        /// Return collection of available palettes
        /// </summary>
        public static IEnumerable<string> Palettes
        {
            get { return Palette.Names; }
        }

        private const string DefaultPalette = "viridis";


        /// <summary>
        /// Default constructor creates Jet colormap
        /// </summary>
        public ColorMap() : this(DefaultPalette)
        {
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="colorMap">Copied colormap</param>
        public ColorMap(ColorMap colorMap) : 
            this(colorMap.PaletteName, colorMap._lower, colorMap._upper, colorMap._colorCount)
        {
            _colorRange = colorMap._colorRange;
            _colorBinSize = colorMap._colorBinSize;
        }

        /// <summary>
        /// Construct new colormap
        /// </summary>
        /// <param name="name">Palette name</param>
        /// <param name="lower">Lower bound of the colormap range</param>
        /// <param name="upper">Upper bound of the colormap range</param>
        /// <param name="colorCount">Number of colors in colormap</param>
        /// <exception cref="ArgumentException">Thrown if:
        /// 1) Palette name is null
        /// 2) Number of colors is less than 2 or greater than number of colors in palette
        /// 3) Lower bound is greater than the upper one
        /// </exception>
        public ColorMap(string name,
                        double lower = 0.0f,
                        double upper = 1.0f,
                        int colorCount = Palette.Resolution)
        {
            if (name == null)
            {
                throw new ArgumentException("Palette name should not be null!");
            }

            if (colorCount <= 1 || colorCount > Palette.Resolution)
            {
                throw new ArgumentException(string.Format(
                    "Number of colors should be in range [2, {0}]!", Palette.Resolution));
            }

            if (lower >= upper)
            {
                throw new ArgumentException("Upper bound should be greater than the lower one!");
            }

            _colorCount = colorCount;
            _lower = lower;
            _upper = upper;
            _colorRange = (_upper - _lower) / _colorCount;
            _colorBinSize = Palette.Resolution / (_colorCount + 0.5);

            // setting palette by name:

            var keyName = name.ToLower();

            if (Palette.ByName.ContainsKey(keyName))
            {
                PaletteName = keyName;
            }
            else
            {
                PaletteName = DefaultPalette;
            }

            _palette = Palette.ByName[PaletteName].Value;
        }

        /// <summary>
        /// Get the color corresponding to a given domain value
        /// </summary>
        /// <param name="value">Particular domain value</param>
        /// <returns>Corresponding color</returns>
        public Color GetColor(double value)
        {
            var rgb = this[value];

            return Color.FromArgb(rgb[0], rgb[1], rgb[2]);
        }

        /// <summary>
        /// Get the color by its ordinal number in palette/colormap
        /// </summary>
        /// <param name="no">Color ordinal number</param>
        /// <returns>Corresponding color</returns>
        public Color GetColorByNumber(int no)
        {
            var value = _lower + no * _colorRange;

            return GetColor(value);
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
                    return _palette[Palette.Resolution - 1];
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
                    return new byte[] 
                    {
                        _palette[0, 0], _palette[0, 1], _palette[0, 2]
                    };
                }

                if (value >= _upper)
                {
                    return new byte[]
                    {
                        _palette[Palette.Resolution - 1, 0],
                        _palette[Palette.Resolution - 1, 1],
                        _palette[Palette.Resolution - 1, 2]
                    };
                }

                // get position of the closest color with current resolution
                var pos = (int)((value - _lower) / _colorRange);

                // get the index of this color in palette
                var idx = (int)(pos * _colorBinSize);

                return new byte[]
                {
                    _palette[idx, 0], _palette[idx, 1], _palette[idx, 2]
                };
            }
#endif
        }
    }
}
