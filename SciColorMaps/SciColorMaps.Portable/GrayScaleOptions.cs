namespace SciColorMaps.Portable
{
    /// <summary>
    /// Three options for how to convert RGB color to grayscale 
    /// (as used in GIMP: https://docs.gimp.org/2.6/en/gimp-tool-desaturate.html)
    /// </summary>
    public enum GrayScaleOptions
    {
        Luminosity,
        Lightness,
        Average
    }
}
