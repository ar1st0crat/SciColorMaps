using System;
using System.Linq;

namespace SciColorMaps
{
    /// <summary>
    /// ColorMap decorator that converts all colors of decorated colormap to grayscale
    /// 
    /// Usage example:
    /// 
    ///     var cmap = new GrayColorMap(new ColorMap("viridis", -0.5, 0.5));
    ///     ...
    ///     var color = cmap[0.3];
    /// 
    /// Important:
    ///     Method allocates NEW memory for palette array
    ///     so that it doesn't affect predefined palettes
    /// 
    /// </summary>
    public class GrayColorMap : ColorMap
    {
        /// <summary>
        /// Decorated colormap
        /// </summary>
        private ColorMap _colorMap;

        /// <summary>
        /// Grayscale conversion options
        /// </summary>
        private GrayScaleOptions _options;

        /// <summary>
        /// Recalculate palette colors each using one of 3 simple formulae
        /// </summary>
        private void MakePaletteGrayscale()
        {
#if !RECTANGULAR
            var _prevPalette = _palette;

            // important: create new array for palette
            _palette = new byte[Palette.Resolution][];

            Func<byte[], byte> convertToGray;

            switch (_options)
            {
                case GrayScaleOptions.Lightness:
                    convertToGray = (color) => { return (byte)((color.Max() + color.Min()) / 2); };
                    break;
                case GrayScaleOptions.Average:
                    convertToGray = (color) => { return (byte)((color[0] + color[1] + color[2]) / 3); };
                    break;
                case GrayScaleOptions.Luminosity:
                default:
                    convertToGray = (color) => { return (byte)(color[0] * 0.21 + color[1] * 0.72 + color[2] * 0.07); };
                    break;
            }

            for (var i = 0; i < PaletteColors; i++)
            {
                var gray = convertToGray(_prevPalette[i]);

                _palette[i] = new byte[3] { gray, gray, gray };
            }
#else
            var _prevPalette = _palette;

            // important: create new array for palette
            _palette = new byte[Palette.Resolution, 3];

            Func<byte, byte, byte, byte> convertToGray;

            switch (_options)
            {
                case GrayScaleOptions.Lightness:
                    convertToGray = (r, g, b) => { return (byte)(r * 0.21 + g * 0.72 + b * 0.07); };
                    break;
                case GrayScaleOptions.Average:
                    convertToGray = (r, g, b) => { return (byte)((r + g + b) / 3); };
                    break;
                case GrayScaleOptions.Luminosity:
                default:
                    convertToGray = (r, g, b) => { return (byte)((Math.Max(r, Math.Max(g, b)) + Math.Min(r, Math.Min(g, b))) / 2); };
                    break;
            }

            for (var i = 0; i < PaletteColors; i++)
            {
                var r = _prevPalette[i, 0];
                var g = _prevPalette[i, 1];
                var b = _prevPalette[i, 2];

                var gray = convertToGray(r, g, b);

                _palette[i, 0] = gray;
                _palette[i, 1] = gray;
                _palette[i, 2] = gray;
            }
#endif
        }

        /// <summary>
        /// Constructor (also calls copy constructor of the base ColorMap class)
        /// 
        /// We gently substitute ordinary palette with grayscale palette
        /// 
        /// </summary>
        /// <param name="colorMap">Decorated colormap</param>
        /// <param name="options">Luminosity conversion by default</param>
        public GrayColorMap(ColorMap colorMap,
                            GrayScaleOptions options = GrayScaleOptions.Luminosity)
            : base(colorMap)
        {
            _colorMap = colorMap;
            _options = options;

            // magic goes on here:
            MakePaletteGrayscale();
        }
    }
}
