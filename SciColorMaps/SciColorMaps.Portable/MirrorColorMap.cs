namespace SciColorMaps.Portable
{
    /// <summary>
    /// ColorMap decorator that mirrors colors of decorated colormap
    /// 
    /// Usage example:
    /// 
    ///     var cmap = new MirrorColorMap(new ColorMap("ocean"));
    ///     ...
    ///     var color = cmap[0.3];
    /// 
    /// Important:
    ///     Method allocates NEW memory for palette array
    ///     so that it doesn't affect predefined palettes
    /// 
    /// </summary>
    public class MirrorColorMap : ColorMap
    {
        /// <summary>
        /// Recalculate palette colors
        /// </summary>
        private void MakeMirroredPalette()
        {
#if !RECTANGULAR
            var prevPalette = _palette;

            // important: create new array for palette
            _palette = new byte[PaletteColors][];
            
            for (var i = 0; i < PaletteColors; i++)
            {
                var rgb = prevPalette[PaletteColors - 1 - i];

                _palette[i] = new [] { rgb[0], rgb[1], rgb[2] };
            }
#else
            var prevPalette = _palette;

            // important: create new array for palette
            _palette = new byte[PaletteColors, 3];

            for (var i = 0; i < PaletteColors; i++)
            {
                _palette[i, 0] = prevPalette[PaletteColors - 1 - i, 0];
                _palette[i, 1] = prevPalette[PaletteColors - 1 - i, 1];
                _palette[i, 2] = prevPalette[PaletteColors - 1 - i, 2];
            }
#endif
        }

        /// <summary>
        /// Constructor (also calls copy constructor of the base ColorMap class)
        /// 
        /// We gently substitute ordinary palette with mirrored palette
        /// 
        /// </summary>
        /// <param name="colorMap">Decorated colormap</param>
        public MirrorColorMap(ColorMap colorMap) : base(colorMap)
        {
            MakeMirroredPalette();
        }
    }
}
