using System;
using System.Linq;

namespace SciColorMaps.Portable
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
        /// Grayscale conversion options
        /// </summary>
        private readonly GrayScaleOptions _options;

        /// <summary>
        /// Recalculate palette colors each using one of 3 simple formulae
        /// </summary>
        private void MakePaletteGrayscale()
        {
#if !RECTANGULAR
            var prevPalette = _palette;

            // important: create new array for palette
            _palette = new byte[PaletteColors][];

            Func<byte[], byte> convertToGray;

            switch (_options)
            {
                case GrayScaleOptions.Lightness:
                    convertToGray = color => (byte)((color.Max() + color.Min()) / 2);
                    break;
                case GrayScaleOptions.Average:
                    convertToGray = color => (byte)((color[0] + color[1] + color[2]) / 3);
                    break;
                default:
                    convertToGray = color => (byte)(color[0] * 0.21 + color[1] * 0.72 + color[2] * 0.07);
                    break;
            }

            for (var i = 0; i < PaletteColors; i++)
            {
                var gray = convertToGray(prevPalette[i]);

                _palette[i] = new [] { gray, gray, gray };
            }
#else
            var prevPalette = _palette;

            // important: create new array for palette
            _palette = new byte[PaletteColors, 3];

            Func<byte, byte, byte, byte> convertToGray;

            switch (_options)
            {
                case GrayScaleOptions.Lightness:
                    convertToGray = (r, g, b) => (byte)(r * 0.21 + g * 0.72 + b * 0.07);
                    break;
                case GrayScaleOptions.Average:
                    convertToGray = (r, g, b) => (byte)((r + g + b) / 3);
                    break;
                default:
                    convertToGray = (r, g, b) => (byte)((Math.Max(r, Math.Max(g, b)) + Math.Min(r, Math.Min(g, b))) / 2);
                    break;
            }

            for (var i = 0; i < PaletteColors; i++)
            {
                var r = prevPalette[i, 0];
                var g = prevPalette[i, 1];
                var b = prevPalette[i, 2];

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
            _options = options;

            // magic goes on here:
            MakePaletteGrayscale();
        }
    }
}
