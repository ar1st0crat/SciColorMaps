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
            for (var i = 0; i < PaletteColors; i++)
            {
                var color = _palette[i];

                byte gray = 0;
                switch (_options)
                {
                    case GrayScaleOptions.Luminosity:
                        {
                            gray = (byte)(color[0] * 0.21 + color[1] * 0.72 + color[2] * 0.07);
                            break;
                        }
                    case GrayScaleOptions.Lightness:
                        {
                            gray = (byte)((color.Max() + color.Min()) / 2);
                            break;
                        }
                    case GrayScaleOptions.Average:
                        {
                            gray = (byte)((color[0] + color[1] + color[2]) / 3);
                            break;
                        }
                }

                _palette[i][0] = gray;
                _palette[i][1] = gray;
                _palette[i][2] = gray;
            }
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
