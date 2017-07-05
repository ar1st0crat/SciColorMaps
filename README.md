# SciColorMaps

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg)

Simple and convenient library providing custom .NET color maps (user-defined or imported from matplotlib) for scientific visualization.

Library comes in two versions:

- **SciColorMaps.Portable.dll** does not rely on any framework-dependent color structure (like ```System.Drawing.Color``` or ```System.Windows.Media.Color```). It operates with pure byte arrays, so it can be used in any .NET project.

- **SciColorMaps.dll** provides some additional functions that handle GDI+ colors, so it can be used in WinForms and WPF projects.


## Base ColorMap class

Usage example:

```
// create 'viridis' colormap with 256 colors, mapping values from range [0, 1]
var cmap = new ColorMap();

// create 'rainbow' colormap with 256 colors, mapping values from range [0, 1]
var cmap = new ColorMap("rainbow");

// create 'gnuplot' colormap with 256 colors, mapping values from range [-7.5, 7.5]
var cmap = new ColorMap("gnuplot", -7.5, 7.5);

// create 'coolwarm' colormap with 64 colors, mapping values from range [10, 100]
var cmap = new ColorMap("coolwarm", 10, 100, 64);

// get color corresponding to value 25
var color = cmap[25];

// print names of all available predefined palettes
foreach (var palette in ColorMap.Palettes)
{
    Console.WriteLine(palette);
}

// currently prints:
// bone
// cool
// coolwarm
// gist_earth
// gnuplot
// gnuplot2
// hot
// inferno
// jet
// ocean
// rainbow
// seismic
// spectral
// terrain
// viridis

```

![pic1](https://github.com/ar1st0crat/SciColorMaps/blob/master/Screenshots/WinForms.png)

![pic2](https://github.com/ar1st0crat/SciColorMaps/blob/master/Screenshots/WinForms2.png)


## User-defined colormaps

Users can create their own color palettes, like this:

```
// === works for both versions of SciColorMaps ===

var rgbs = new [] { 
                    new byte[] {0, 0, 0},
                    new byte[] {192, 0, 0},
                    new byte[] {255, 224, 255}
                  };
var positions = new float[] { 0, 0.4f, 1 };

// 1) static factory method with default colormap parameters:
var cmap1 = ColorMap.CreateFromColors(rgbs, positions);

// 2) static factory method, full set of parameters:
var cmap2 = ColorMap.CreateFromColors(rgbs, positions, 10, 100, 32);

// 3) ColorMap constructor:
var cmap3 = new ColorMap("my_own_colormap", -2, 2, 128, rgbs, positions);


// === won't compile for SciColorMaps.Portable ===

var colors = new Color[] { Color.Black, Color.Blue, Color.White };

// 4) static factory method with default colormap parameters:
var cmap4 = ColorMap.CreateFromColors(colors, positions);

// 5) static factory method, full set of parameters:
var cmap5 = ColorMap.CreateFromColors(colors, positions, 10, 100, 32);

// 6) ColorMap constructor:
var cmap6 = new ColorMap("fancy_colormap", 10, 100, 32, colors, positions);

```

Options 3 and 6 allow user setting the name of the custom colormap. Otherwise the name is set by default: "user".

Note also, the first color position should be 0.0f and last position should be 1.0f (otherwise an ArgumentException will be thrown).

*Byte arrays can be easily converted to any framework-specific color structures/classes.*

For example, in WPF the following extension method can be used:

```
using SciColorMaps.Portable;

public static class ColorUtils
{
    public static Color ToMediaColor(this byte[] rgb)
    {
        return Color.FromRgb(rgb[0], rgb[1], rgb[2]);
    }
}

...

var cmap = new ColorMap("ocean");
var color = cmap[0.3].ToMediaColor();

```

![User-defined](https://github.com/ar1st0crat/SciColorMaps/blob/master/Screenshots/WinFormsCustom.png)


## Grayscale colormaps

SciColorMaps provides the ```GrayColorMap``` decorator class. This class gently substitutes base palette with its grayscale analog during construction.

Usage example:

```
// upper sreenshot
var cmap1 = new GrayColorMap(new ColorMap("gnuplot2", min, max));

// lower screenshot
var cmap2 = new GrayColorMap(new ColorMap("gnuplot2", min, max), GrayScaleOptions.Lightness);


// the three simple algorithms for conversion are implemented
// (as in GIMP: https://docs.gimp.org/2.6/en/gimp-tool-desaturate.html)

// public enum GrayScaleOptions
// {
//     Luminosity,      // gray = 0.21*R + 0.72*G + 0.07*B
//     Lightness,       // gray = (max(R, G, B) + min(R, G, B)) / 2
//     Average          // gray = (R + G + B) / 3
// }

// GrayScaleOptions.Luminosity is used by default

```

![Grayscale](https://github.com/ar1st0crat/SciColorMaps/blob/master/Screenshots/WinFormsGray.png)


## Mirrored colormaps

SciColorMaps also provides the ```MirrorColorMap``` decorator class. This class substitutes base palette with its mirrored analog during construction.

Usage example:

```
// mirrored colors
var cmap = new MirrorColorMap(new ColorMap("ocean"));

```

## Compiling SciColorMaps

1) Accessing elements in jagged arrays is significantly faster (up to **40%**) compared to rectangular arrays, hence the jagged arrays are used and compiled by default. If an efficient memory management is of more importance then compile SciColorMaps with the 'RECTANGULAR' conditional symbol.

| compilation   | dll size |
----------------|-----------
| default       | ~259kb   |
| RECTANGULAR   | ~27kb    |


2) If you want to save some bytes you can remove any standard color map - just comment out all declarations you don't need in file ```Palette.cs```.

Also, if you are worried about the memory usage, please note that palette arrays are instantiated *lazily* in the calling code, e.g.:

```
var palette = Palette.GnuPlot.Value;

```


## WinForms demo app

Left button click on surface 2d area -> change colormap to its mirrored version.

Right button click on surface 2d area -> change colormap to its grayscale version.

Left button click on colormap strip -> open dialog for constructing your own palette.


## WPF demo app

Shows how to use SciColorMaps.Portable.

![WPF](https://github.com/ar1st0crat/SciColorMaps/blob/master/Screenshots/Wpf.png)
