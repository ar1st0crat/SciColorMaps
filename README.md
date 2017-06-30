# SciColorMaps

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg)

Custom .NET color maps (user-defined or imported from matplotlib) for scientific visualization

Usage example:

```
// create 'jet' colormap with 256 colors, mapping values from range [0, 1]
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

SciColorMaps also provides the ```GrayColorMap``` class. This class gently substitutes base palette with its grayscale analog during construction.

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
