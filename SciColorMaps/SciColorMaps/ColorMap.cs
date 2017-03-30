using System;
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
        private byte[,] _palette;
        
        /// <summary>
        /// Number of colors in colormap
        /// </summary>
        private int _colorCount;

        /// <summary>
        /// Lower bound of the colormap range
        /// </summary>
        private float _lower;

        /// <summary>
        /// Upper bound of the colormap range
        /// </summary>
        private float _upper;

        /// <summary>
        /// Range of values corresponding to one color
        /// </summary>
        private float _step;

        /// <summary>
        /// Palette name ("viridis", "terrain", etc.)
        /// </summary>
        public string PaletteName { get; private set; }

        /// <summary>
        /// Construct new colormap
        /// </summary>
        /// <param name="name">Palette name</param>
        /// <param name="lower">Lower bound of the colormap range</param>
        /// <param name="upper">Upper bound of the colormap range</param>
        /// <param name="colorCount">Number of colors in colormap</param>
        /// <exception cref="ArgumentException">Thrown if:
        /// 1) Palette name is null
        /// 2) Number of colors is 0 or negative
        /// 3) Lower bound is greater than the upper one
        /// </exception>
        public ColorMap(string name,
                        float lower = 0.0f,
                        float upper = 1.0f,
                        int colorCount = 256)
        {
            if (name == null)
            {
                throw new ArgumentException("Palette name should not be null!");
            }

            if (colorCount <= 0)
            {
                throw new ArgumentException("Number of colors should be positive!");
            }

            if (lower >= upper)
            {
                throw new ArgumentException("Upper bound should be greater than the lower one!");
            }

            _colorCount = colorCount;
            _lower = lower;
            _upper = upper;
            _step = (_upper - _lower) / _colorCount;

            // setting palette by name:

            string keyName = name.ToLower();

            if (Palettes.ByName.ContainsKey(keyName))
            {
                _palette = Palettes.ByName[keyName];
                PaletteName = keyName;
            }
            else
            {
                _palette = Palettes.Viridis;
                PaletteName = "viridis";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] this[float value]
        {
            get
            {
                value = (value > _upper) ? _upper : value;
                value = (value < _lower) ? _lower : value;

                var idx = (int)Math.Min(_colorCount - 1, (value - _lower) / _step);

                var res = new byte[3]
                {
                    _palette[idx, 0],   // R
                    _palette[idx, 1],   // G
                    _palette[idx, 2]    // B
                };

                return res;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Color GetColor(float value)
        {
            var rgb = this[value];

            return Color.FromArgb(rgb[0], rgb[1], rgb[2]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public Color GetColorByNumber(int no)
        {
            var value = _lower + no * _step;

            return GetColor(value);
        }

        // TODO: 
        // add static methods for transforming byte[] to Color and vice versa
    }
}
