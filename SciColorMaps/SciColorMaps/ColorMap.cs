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
        private byte[][] _palette;
        
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
        /// Range of values corresponding to one color in the colormap
        /// (it is calculated in the constructor based on given parameters)
        /// </summary>
        private float _step;

        /// <summary>
        /// Number of palette colors corresponding to one color in the colormap
        /// (it is calculated in the constructor based on given parameters)
        /// </summary>
        private float _colorStep;

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
        /// 2) Number of colors is less than 2 or greater than number of colors in palette
        /// 3) Lower bound is greater than the upper one
        /// </exception>
        public ColorMap(string name,
                        float lower = 0.0f,
                        float upper = 1.0f,
                        int colorCount = Palettes.Resolution)
        {
            if (name == null)
            {
                throw new ArgumentException("Palette name should not be null!");
            }

            if (colorCount <= 1 || colorCount > Palettes.Resolution)
            {
                throw new ArgumentException(string.Format(
                    "Number of colors should be in range [2, {0}]!", Palettes.Resolution));
            }

            if (lower >= upper)
            {
                throw new ArgumentException("Upper bound should be greater than the lower one!");
            }

            _colorCount = colorCount;
            _lower = lower;
            _upper = upper;
            _step = (_upper - _lower) / _colorCount;
            _colorStep = Palettes.Resolution / _colorCount;

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
                if (value <= _lower)
                {
                    return _palette[0];
                }

                if (value >= _upper)
                {
                    return _palette[Palettes.Resolution - 1];
                }

                // get the closest color with current resolution
                value -= (value % _colorStep);

                // get the index of this color in palette
                int idx = (int)((value - _lower) / _step * _colorStep);

                return _palette[idx];
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
    }
}
