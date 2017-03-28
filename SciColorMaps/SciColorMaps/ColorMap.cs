using System;
using System.Drawing;

namespace SciColorMaps
{
    public class ColorMap
    {
        /// <summary>
        /// 
        /// </summary>
        private float[,] _palette = Palettes.Viridis;

        /// <summary>
        /// 
        /// </summary>
        private int _bins;

        /// <summary>
        /// 
        /// </summary>
        private float _lower;

        /// <summary>
        /// 
        /// </summary>
        private float _upper;

        /// <summary>
        /// 
        /// </summary>
        private float _step;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="bins"></param>
        public ColorMap(string name,
                        float lower = 0.0f,
                        float upper = 1.0f,
                        int bins = 256)
        {
            _bins = bins;
            _lower = lower;
            _upper = upper;

            if (_lower >= _upper)
            {
                throw new ArgumentException("Upper bound should be greater than the lower one!");
            }

            _step = (_upper - _lower) / _bins;

            // well, maybe some sort of a dictionary could be used here...
            // however, polymorphism, imo, would be an overdesign in this case

            switch (name.ToLower())
            {
                case "afmhot":  _palette = Palettes.Afmhot; break;
                case "inferno": _palette = Palettes.Inferno; break;
                case "terrain": _palette = Palettes.Terrain; break;
                case "viridis": _palette = Palettes.Viridis; break;
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

                var idx = Math.Min(_bins - 1, (value - _lower) / _step);

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
