using System;
using System.Drawing;

namespace SciColorMaps
{
    public class ColorMap
    {
        /// <summary>
        /// Color palette is an array of predefined RGB values
        /// </summary>
        private float[,] _palette;

        /// <summary>
        /// Palette name ("viridis", "terrain", etc.)
        /// </summary>
        public string PaletteName { get; private set; }

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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="colorCount"></param>
        /// <exception cref="ArgumentException">Thrown if </exception>
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

            _colorCount = colorCount;
            _lower = lower;
            _upper = upper;

            if (_lower >= _upper)
            {
                throw new ArgumentException("Upper bound should be greater than the lower one!");
            }
            
            _step = (_upper - _lower) / _colorCount;

            // well, maybe some sort of a dictionary could be used here...
            // however, polymorphism, imo, would be an overdesign in this case
            PaletteName = name;
            switch (name.ToLower())
            {
                case "afmhot":  _palette = Palettes.Afmhot; break;
                case "inferno": _palette = Palettes.Inferno; break;
                case "terrain": _palette = Palettes.Terrain; break;
                case "viridis": 
                default:
                    _palette = Palettes.Viridis;
                    PaletteName = "viridis";
                    break;
            }
            
            // ...
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public float[] this[float value]
        {
            get
            {
                value = (value > _upper) ? _upper : value;
                value = (value < _lower) ? _lower : value;

                var idx = Math.Min(_colorCount - 1, (value - _lower) / _step);

                var res = new float[3]
                {
                    _palette[(int)idx, 0],
                    _palette[(int)idx, 1],
                    _palette[(int)idx, 2]
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

            return Color.FromArgb((int)(rgb[0] * 255), 
                                  (int)(rgb[1] * 255),
                                  (int)(rgb[2] * 255));
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
        // add static methods for transforming float[] to Color and vice versa
    }
}
