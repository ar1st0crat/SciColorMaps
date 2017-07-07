using System;
using System.Collections.Generic;

namespace SciColorMaps
{
#if !RECTANGULAR

    /// <summary>
    /// Class containing colormaps (palettes) imported from matplotlib
    /// 
    /// =========================== IMPORTANT NOTES! ==========================
    /// 
    /// 1)
    /// Accessing elements in jagged arrays is significantly faster(up to 40%)
    /// compared to rectangular arrays, so the following code is compiled by default.
    /// If an efficient memory management is of more importance then compile
    /// with the 'RECTANGULAR' conditional symbol.
    /// 
    /// 2)
    /// Palette arrays are instantiated LAZILY in the calling code, e.g.:
    ///      var palette = Palette.GnuPlot.Value;
    /// 
    /// 3)
    /// All palettes are READONLY arrays. That means they are NOT consts
    /// and can be modified by calling code. It is AGAINST the contract,
    /// however for the sake of performance there are currently no 
    /// additional checks or converting to ReadOnlyCollection in the code.
    /// 
    /// </summary>
    static class Palette
    {
        /// <summary>
        /// Number of base colors in palette
        /// </summary>
        public const int Resolution = 16;

    #region palettes
        
        /// <summary>
        /// Colormap "accent" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Accent = new Lazy<byte[][]>(() => new []
        {
            new byte[] {127, 201, 127},
            new byte[] {154, 189, 164},
            new byte[] {182, 177, 201},
            new byte[] {210, 179, 187},
            new byte[] {237, 187, 152},
            new byte[] {253, 204, 137},
            new byte[] {254, 232, 146},
            new byte[] {240, 244, 154},
            new byte[] {152, 179, 164},
            new byte[] { 65, 114, 174},
            new byte[] {128,  66, 156},
            new byte[] {208,  19, 135},
            new byte[] {226,  26,  98},
            new byte[] {205,  65,  53},
            new byte[] {177,  92,  34},
            new byte[] {102, 102, 102}
        });

        /// <summary>
        /// Colormap "afmhot" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Afmhot = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] { 32,   0,   0},
            new byte[] { 64,   0,   0},
            new byte[] { 96,   0,   0},
            new byte[] {128,   0,   0},
            new byte[] {160,  32,   0},
            new byte[] {192,  64,   0},
            new byte[] {224,  96,   0},
            new byte[] {255, 128,   0},
            new byte[] {255, 160,  32},
            new byte[] {255, 192,  65},
            new byte[] {255, 224,  97},
            new byte[] {255, 255, 129},
            new byte[] {255, 255, 161},
            new byte[] {255, 255, 193},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "autumn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Autumn = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255,   0,   0},
            new byte[] {255,  16,   0},
            new byte[] {255,  32,   0},
            new byte[] {255,  48,   0},
            new byte[] {255,  64,   0},
            new byte[] {255,  80,   0},
            new byte[] {255,  96,   0},
            new byte[] {255, 112,   0},
            new byte[] {255, 128,   0},
            new byte[] {255, 144,   0},
            new byte[] {255, 160,   0},
            new byte[] {255, 176,   0},
            new byte[] {255, 192,   0},
            new byte[] {255, 208,   0},
            new byte[] {255, 224,   0},
            new byte[] {255, 255,   0}
        });

        /// <summary>
        /// Colormap "binary" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Binary = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 255, 255},
            new byte[] {239, 239, 239},
            new byte[] {223, 223, 223},
            new byte[] {207, 207, 207},
            new byte[] {191, 191, 191},
            new byte[] {175, 175, 175},
            new byte[] {159, 159, 159},
            new byte[] {143, 143, 143},
            new byte[] {127, 127, 127},
            new byte[] {111, 111, 111},
            new byte[] { 95,  95,  95},
            new byte[] { 79,  79,  79},
            new byte[] { 63,  63,  63},
            new byte[] { 47,  47,  47},
            new byte[] { 31,  31,  31},
            new byte[] {  0,   0,   0}
        });

        /// <summary>
        /// Colormap "blues" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Blues = new Lazy<byte[][]>(() => new []
        {
            new byte[] {247, 251, 255},
            new byte[] {234, 242, 250},
            new byte[] {221, 234, 246},
            new byte[] {209, 226, 242},
            new byte[] {197, 218, 238},
            new byte[] {177, 210, 231},
            new byte[] {157, 201, 224},
            new byte[] {131, 187, 219},
            new byte[] {106, 173, 213},
            new byte[] { 85, 159, 205},
            new byte[] { 65, 145, 197},
            new byte[] { 48, 128, 189},
            new byte[] { 32, 112, 180},
            new byte[] { 19,  96, 167},
            new byte[] {  8,  80, 154},
            new byte[] {  8,  48, 107}
        });

        /// <summary>
        /// Colormap "bone" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Bone = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] { 14,  13,  19},
            new byte[] { 28,  27,  38},
            new byte[] { 42,  41,  58},
            new byte[] { 56,  55,  77},
            new byte[] { 70,  69,  97},
            new byte[] { 84,  84, 115},
            new byte[] { 98, 104, 129},
            new byte[] {112, 123, 143},
            new byte[] {126, 142, 157},
            new byte[] {140, 161, 171},
            new byte[] {154, 181, 185},
            new byte[] {168, 199, 199},
            new byte[] {190, 213, 213},
            new byte[] {212, 227, 227},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "brbg" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Brbg = new Lazy<byte[][]>(() => new []
        {
            new byte[] { 84,  48,   5},
            new byte[] {119,  68,   8},
            new byte[] {153,  93,  18},
            new byte[] {185, 123,  40},
            new byte[] {207, 162,  85},
            new byte[] {226, 199, 134},
            new byte[] {240, 223, 178},
            new byte[] {245, 237, 214},
            new byte[] {244, 244, 244},
            new byte[] {215, 237, 234},
            new byte[] {179, 226, 219},
            new byte[] {134, 207, 196},
            new byte[] { 88, 176, 166},
            new byte[] { 44, 143, 135},
            new byte[] { 12, 112, 104},
            new byte[] {  0,  60,  48}
        });

        /// <summary>
        /// Colormap "brg" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Brg = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0, 255},
            new byte[] { 32,   0, 223},
            new byte[] { 64,   0, 191},
            new byte[] { 96,   0, 159},
            new byte[] {128,   0, 127},
            new byte[] {160,   0,  95},
            new byte[] {192,   0,  63},
            new byte[] {224,   0,  31},
            new byte[] {254,   1,   0},
            new byte[] {222,  33,   0},
            new byte[] {190,  65,   0},
            new byte[] {158,  97,   0},
            new byte[] {126, 129,   0},
            new byte[] { 94, 161,   0},
            new byte[] { 62, 193,   0},
            new byte[] {  0, 255,   0}
        });

        /// <summary>
        /// Colormap "bugn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Bugn = new Lazy<byte[][]>(() => new []
        {
            new byte[] {247, 252, 253},
            new byte[] {237, 248, 250},
            new byte[] {228, 244, 248},
            new byte[] {216, 240, 239},
            new byte[] {203, 235, 229},
            new byte[] {178, 225, 215},
            new byte[] {152, 215, 200},
            new byte[] {126, 204, 181},
            new byte[] {101, 193, 163},
            new byte[] { 82, 183, 140},
            new byte[] { 64, 173, 117},
            new byte[] { 49, 155,  92},
            new byte[] { 34, 138,  68},
            new byte[] { 16, 123,  55},
            new byte[] {  0, 107,  43},
            new byte[] {  0,  68,  27}
        });

        /// <summary>
        /// Colormap "bupu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Bupu = new Lazy<byte[][]>(() => new []
        {
            new byte[] {247, 252, 253},
            new byte[] {235, 243, 248},
            new byte[] {223, 235, 243},
            new byte[] {207, 223, 236},
            new byte[] {190, 210, 229},
            new byte[] {174, 199, 223},
            new byte[] {157, 187, 217},
            new byte[] {148, 168, 207},
            new byte[] {140, 149, 197},
            new byte[] {140, 127, 187},
            new byte[] {139, 106, 176},
            new byte[] {137,  85, 166},
            new byte[] {135,  63, 156},
            new byte[] {132,  38, 139},
            new byte[] {127,  14, 122},
            new byte[] { 77,   0,  75}
        });

        /// <summary>
        /// Colormap "bwr" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Bwr = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0, 255},
            new byte[] { 32,  32, 255},
            new byte[] { 64,  64, 255},
            new byte[] { 96,  96, 255},
            new byte[] {128, 128, 255},
            new byte[] {160, 160, 255},
            new byte[] {192, 192, 255},
            new byte[] {224, 224, 255},
            new byte[] {255, 254, 254},
            new byte[] {255, 222, 222},
            new byte[] {255, 190, 190},
            new byte[] {255, 158, 158},
            new byte[] {255, 126, 126},
            new byte[] {255,  94,  94},
            new byte[] {255,  62,  62},
            new byte[] {255,   0,   0}
        });

        /// <summary>
        /// Colormap "cmrmap" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Cmrmap = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] { 19,  19,  64},
            new byte[] { 38,  38, 127},
            new byte[] { 57,  38, 159},
            new byte[] { 77,  38, 190},
            new byte[] {115,  44, 158},
            new byte[] {154,  51, 126},
            new byte[] {205,  57,  81},
            new byte[] {254,  64,  37},
            new byte[] {241,  96,  18},
            new byte[] {229, 128,   0},
            new byte[] {229, 160,  13},
            new byte[] {229, 192,  27},
            new byte[] {229, 211,  79},
            new byte[] {230, 230, 131},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "cool" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Cool = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0, 255, 255},
            new byte[] { 16, 239, 255},
            new byte[] { 32, 223, 255},
            new byte[] { 48, 207, 255},
            new byte[] { 64, 191, 255},
            new byte[] { 80, 175, 255},
            new byte[] { 96, 159, 255},
            new byte[] {112, 143, 255},
            new byte[] {128, 127, 255},
            new byte[] {144, 111, 255},
            new byte[] {160,  95, 255},
            new byte[] {176,  79, 255},
            new byte[] {192,  63, 255},
            new byte[] {208,  47, 255},
            new byte[] {224,  31, 255},
            new byte[] {255,   0, 255}
        });

        /// <summary>
        /// Colormap "coolwarm" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Coolwarm = new Lazy<byte[][]>(() => new []
        {
            new byte[] { 58,  76, 192},
            new byte[] { 77, 103, 215},
            new byte[] { 97, 130, 234},
            new byte[] {119, 154, 246},
            new byte[] {141, 175, 253},
            new byte[] {163, 193, 254},
            new byte[] {184, 207, 248},
            new byte[] {204, 216, 237},
            new byte[] {221, 220, 219},
            new byte[] {236, 210, 196},
            new byte[] {244, 195, 171},
            new byte[] {247, 176, 146},
            new byte[] {243, 152, 121},
            new byte[] {234, 125,  97},
            new byte[] {220,  94,  75},
            new byte[] {179,   3,  38}
        });

        /// <summary>
        /// Colormap "copper" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Copper = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] { 19,  12,   7},
            new byte[] { 39,  24,  15},
            new byte[] { 59,  37,  23},
            new byte[] { 79,  49,  31},
            new byte[] { 98,  62,  39},
            new byte[] {118,  74,  47},
            new byte[] {138,  87,  55},
            new byte[] {158,  99,  63},
            new byte[] {177, 112,  71},
            new byte[] {197, 124,  79},
            new byte[] {217, 137,  87},
            new byte[] {237, 149,  95},
            new byte[] {255, 162, 103},
            new byte[] {255, 174, 111},
            new byte[] {255, 199, 126}
        });

        /// <summary>
        /// Colormap "cubehelix" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Cubehelix = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] { 20,  11,  29},
            new byte[] { 26,  29,  59},
            new byte[] { 22,  55,  76},
            new byte[] { 21,  83,  75},
            new byte[] { 35, 106,  61},
            new byte[] { 67, 119,  48},
            new byte[] {113, 122,  50},
            new byte[] {161, 121,  74},
            new byte[] {196, 122, 117},
            new byte[] {211, 131, 169},
            new byte[] {208, 152, 212},
            new byte[] {198, 180, 237},
            new byte[] {193, 208, 243},
            new byte[] {203, 231, 239},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "dark2" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Dark2 = new Lazy<byte[][]>(() => new []
        {
            new byte[] { 27, 158, 119},
            new byte[] {110, 130,  67},
            new byte[] {193, 102,  16},
            new byte[] {185, 100,  58},
            new byte[] {141, 107, 135},
            new byte[] {139,  98, 170},
            new byte[] {189,  66, 152},
            new byte[] {221,  50, 129},
            new byte[] {164, 105,  82},
            new byte[] {108, 160,  35},
            new byte[] {152, 167,  19},
            new byte[] {208, 170,   6},
            new byte[] {212, 156,   9},
            new byte[] {184, 133,  21},
            new byte[] {156, 115,  39},
            new byte[] {102, 102, 102}
        });

        /// <summary>
        /// Colormap "flag" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Flag = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255,   0,   0},
            new byte[] {252,   0,   0},
            new byte[] {241,   0,   0},
            new byte[] {229,   0,   0},
            new byte[] {217,   0,   0},
            new byte[] {204,   0,   0},
            new byte[] {191,   0,   0},
            new byte[] {178,   0,   0},
            new byte[] {164,   0,   0},
            new byte[] {150,   0,   0},
            new byte[] {136,   0,   0},
            new byte[] {122,   0,   0},
            new byte[] {108,   0,   0},
            new byte[] { 94,   0,   0},
            new byte[] { 80,   0,   0},
            new byte[] {  0,   0,   0}
        });

        /// <summary>
        /// Colormap "gist_earth" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Gist_Earth = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] { 10,  20, 117},
            new byte[] { 21,  56, 120},
            new byte[] { 31,  88, 123},
            new byte[] { 42, 115, 126},
            new byte[] { 51, 132, 117},
            new byte[] { 59, 141,  98},
            new byte[] { 66, 151,  78},
            new byte[] { 93, 160,  75},
            new byte[] {126, 167,  83},
            new byte[] {153, 174,  88},
            new byte[] {179, 181,  93},
            new byte[] {188, 170,  98},
            new byte[] {200, 166, 120},
            new byte[] {218, 182, 159},
            new byte[] {253, 250, 250}
        });

        /// <summary>
        /// Colormap "gist_gray" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Gist_Gray = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] { 16,  16,  16},
            new byte[] { 32,  32,  32},
            new byte[] { 48,  48,  48},
            new byte[] { 64,  64,  64},
            new byte[] { 80,  80,  80},
            new byte[] { 96,  96,  96},
            new byte[] {112, 112, 112},
            new byte[] {128, 128, 128},
            new byte[] {144, 144, 144},
            new byte[] {160, 160, 160},
            new byte[] {176, 176, 176},
            new byte[] {192, 192, 192},
            new byte[] {208, 208, 208},
            new byte[] {224, 224, 224},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "gist_heat" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Gist_Heat = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] { 24,   0,   0},
            new byte[] { 48,   0,   0},
            new byte[] { 72,   0,   0},
            new byte[] { 96,   0,   0},
            new byte[] {120,   0,   0},
            new byte[] {144,   0,   0},
            new byte[] {168,   0,   0},
            new byte[] {192,   0,   0},
            new byte[] {216,  32,   0},
            new byte[] {240,  65,   0},
            new byte[] {255,  97,   0},
            new byte[] {255, 129,   2},
            new byte[] {255, 161,  66},
            new byte[] {255, 193, 131},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "gist_ncar" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Gist_Ncar = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0, 128},
            new byte[] {  0,  74,  55},
            new byte[] {  0,  70, 255},
            new byte[] {  0, 224, 255},
            new byte[] {  0, 250, 176},
            new byte[] {  6, 254,  20},
            new byte[] {103, 212,   0},
            new byte[] {145, 255,  23},
            new byte[] {218, 255,  31},
            new byte[] {255, 227,   0},
            new byte[] {255, 188,  12},
            new byte[] {255,  66,   0},
            new byte[] {255,   0,  70},
            new byte[] {213,  20, 255},
            new byte[] {205,  97, 244},
            new byte[] {254, 247, 254}
        });

        /// <summary>
        /// Colormap "gist_rainbow" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Gist_Rainbow = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255,   0,  40},
            new byte[] {255,  45,   0},
            new byte[] {255, 131,   0},
            new byte[] {255, 218,   0},
            new byte[] {205, 255,   0},
            new byte[] {118, 255,   0},
            new byte[] { 32, 255,   0},
            new byte[] {  0, 255,  53},
            new byte[] {  0, 255, 139},
            new byte[] {  0, 255, 225},
            new byte[] {  0, 197, 255},
            new byte[] {  0, 110, 255},
            new byte[] {  0,  23, 255},
            new byte[] { 63,   0, 255},
            new byte[] {150,   0, 255},
            new byte[] {255,   0, 191}
        });

        /// <summary>
        /// Colormap "gist_stern" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Gist_Stern = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] {244,  16,  32},
            new byte[] {165,  32,  64},
            new byte[] { 85,  48,  96},
            new byte[] { 64,  64, 128},
            new byte[] { 80,  80, 160},
            new byte[] { 96,  96, 192},
            new byte[] {112, 112, 224},
            new byte[] {128, 128, 252},
            new byte[] {144, 144, 184},
            new byte[] {160, 160, 116},
            new byte[] {176, 176,  48},
            new byte[] {192, 192,  17},
            new byte[] {208, 208,  77},
            new byte[] {224, 224, 138},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "gist_yarg" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Gist_Yarg = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 255, 255},
            new byte[] {239, 239, 239},
            new byte[] {223, 223, 223},
            new byte[] {207, 207, 207},
            new byte[] {191, 191, 191},
            new byte[] {175, 175, 175},
            new byte[] {159, 159, 159},
            new byte[] {143, 143, 143},
            new byte[] {127, 127, 127},
            new byte[] {111, 111, 111},
            new byte[] { 95,  95,  95},
            new byte[] { 79,  79,  79},
            new byte[] { 63,  63,  63},
            new byte[] { 47,  47,  47},
            new byte[] { 31,  31,  31},
            new byte[] {  0,   0,   0}
        });

        /// <summary>
        /// Colormap "gnbu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Gnbu = new Lazy<byte[][]>(() => new []
        {
            new byte[] {247, 252, 240},
            new byte[] {235, 247, 229},
            new byte[] {223, 242, 218},
            new byte[] {213, 238, 207},
            new byte[] {203, 234, 196},
            new byte[] {185, 227, 188},
            new byte[] {167, 220, 181},
            new byte[] {144, 212, 188},
            new byte[] {122, 203, 196},
            new byte[] { 99, 191, 203},
            new byte[] { 77, 178, 210},
            new byte[] { 59, 158, 200},
            new byte[] { 42, 139, 189},
            new byte[] { 24, 121, 180},
            new byte[] {  8, 102, 170},
            new byte[] {  8,  64, 129}
        });

        /// <summary>
        /// Colormap "gnuplot" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Gnuplot = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] { 63,   0,  97},
            new byte[] { 90,   0, 180},
            new byte[] {110,   1, 236},
            new byte[] {127,   4, 254},
            new byte[] {142,   7, 234},
            new byte[] {156,  13, 178},
            new byte[] {168,  21,  95},
            new byte[] {180,  32,   0},
            new byte[] {191,  45,   0},
            new byte[] {201,  62,   0},
            new byte[] {211,  83,   0},
            new byte[] {221, 108,   0},
            new byte[] {230, 138,   0},
            new byte[] {238, 172,   0},
            new byte[] {255, 255,   0}
        });

        /// <summary>
        /// Colormap "gnuplot2" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Gnuplot2 = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] {  0,   0,  64},
            new byte[] {  0,   0, 128},
            new byte[] {  0,   0, 192},
            new byte[] {  0,   0, 255},
            new byte[] { 50,   0, 255},
            new byte[] {100,   0, 255},
            new byte[] {150,   9, 245},
            new byte[] {200,  41, 213},
            new byte[] {250,  73, 181},
            new byte[] {255, 105, 149},
            new byte[] {255, 137, 117},
            new byte[] {255, 169,  85},
            new byte[] {255, 201,  53},
            new byte[] {255, 233,  21},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "gray" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Gray = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] { 16,  16,  16},
            new byte[] { 32,  32,  32},
            new byte[] { 48,  48,  48},
            new byte[] { 64,  64,  64},
            new byte[] { 80,  80,  80},
            new byte[] { 96,  96,  96},
            new byte[] {112, 112, 112},
            new byte[] {128, 128, 128},
            new byte[] {144, 144, 144},
            new byte[] {160, 160, 160},
            new byte[] {176, 176, 176},
            new byte[] {192, 192, 192},
            new byte[] {208, 208, 208},
            new byte[] {224, 224, 224},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "greens" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Greens = new Lazy<byte[][]>(() => new []
        {
            new byte[] {247, 252, 245},
            new byte[] {237, 248, 234},
            new byte[] {228, 244, 223},
            new byte[] {213, 238, 207},
            new byte[] {198, 232, 191},
            new byte[] {179, 224, 173},
            new byte[] {160, 216, 154},
            new byte[] {137, 206, 135},
            new byte[] {115, 195, 117},
            new byte[] { 89, 183, 105},
            new byte[] { 64, 170,  92},
            new byte[] { 49, 154,  80},
            new byte[] { 34, 138,  68},
            new byte[] { 16, 123,  55},
            new byte[] {  0, 107,  43},
            new byte[] {  0,  68,  27}
        });

        /// <summary>
        /// Colormap "greys" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Greys = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 255, 255},
            new byte[] {247, 247, 247},
            new byte[] {239, 239, 239},
            new byte[] {228, 228, 228},
            new byte[] {216, 216, 216},
            new byte[] {202, 202, 202},
            new byte[] {188, 188, 188},
            new byte[] {168, 168, 168},
            new byte[] {149, 149, 149},
            new byte[] {131, 131, 131},
            new byte[] {114, 114, 114},
            new byte[] { 97,  97,  97},
            new byte[] { 80,  80,  80},
            new byte[] { 58,  58,  58},
            new byte[] { 35,  35,  35},
            new byte[] {  0,   0,   0}
        });

        /// <summary>
        /// Colormap "hot" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Hot = new Lazy<byte[][]>(() => new []
        {
            new byte[] { 10,   0,   0},
            new byte[] { 52,   0,   0},
            new byte[] { 94,   0,   0},
            new byte[] {136,   0,   0},
            new byte[] {178,   0,   0},
            new byte[] {220,   0,   0},
            new byte[] {255,   7,   0},
            new byte[] {255,  49,   0},
            new byte[] {255,  91,   0},
            new byte[] {255, 133,   0},
            new byte[] {255, 175,   0},
            new byte[] {255, 217,   0},
            new byte[] {255, 255,   6},
            new byte[] {255, 255,  69},
            new byte[] {255, 255, 132},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "hsv" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Hsv = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255,   0,   0},
            new byte[] {255,  94,   0},
            new byte[] {255, 189,   0},
            new byte[] {226, 255,   0},
            new byte[] {131, 255,   0},
            new byte[] { 37, 255,   0},
            new byte[] {  0, 255,  57},
            new byte[] {  0, 255, 151},
            new byte[] {  0, 255, 245},
            new byte[] {  0, 169, 255},
            new byte[] {  0,  75, 255},
            new byte[] { 19,   0, 255},
            new byte[] {113,   0, 255},
            new byte[] {208,   0, 255},
            new byte[] {255,   0, 207},
            new byte[] {255,   0,  23}
        });

        /// <summary>
        /// Colormap "inferno" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Inferno = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   3},
            new byte[] { 10,   7,  35},
            new byte[] { 32,  12,  74},
            new byte[] { 60,   9, 101},
            new byte[] { 87,  15, 109},
            new byte[] {112,  25, 110},
            new byte[] {137,  34, 105},
            new byte[] {163,  43,  97},
            new byte[] {187,  55,  84},
            new byte[] {209,  70,  67},
            new byte[] {228,  90,  49},
            new byte[] {241, 114,  29},
            new byte[] {249, 142,   8},
            new byte[] {251, 172,  16},
            new byte[] {248, 203,  52},
            new byte[] {252, 254, 164}
        });

        /// <summary>
        /// Colormap "jet" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Jet = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0, 127},
            new byte[] {  0,   0, 200},
            new byte[] {  0,   0, 255},
            new byte[] {  0,  64, 255},
            new byte[] {  0, 128, 255},
            new byte[] {  0, 192, 255},
            new byte[] { 21, 255, 225},
            new byte[] { 73, 255, 173},
            new byte[] {124, 255, 121},
            new byte[] {176, 255,  70},
            new byte[] {228, 255,  18},
            new byte[] {255, 207,   0},
            new byte[] {255, 148,   0},
            new byte[] {255,  89,   0},
            new byte[] {255,  29,   0},
            new byte[] {127,   0,   0}
        });

        /// <summary>
        /// Colormap "magma" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Magma = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   3},
            new byte[] { 10,   7,  34},
            new byte[] { 28,  16,  70},
            new byte[] { 53,  15, 106},
            new byte[] { 80,  18, 123},
            new byte[] {105,  28, 128},
            new byte[] {130,  37, 129},
            new byte[] {156,  46, 127},
            new byte[] {182,  54, 121},
            new byte[] {208,  65, 111},
            new byte[] {230,  81,  98},
            new byte[] {245, 106,  91},
            new byte[] {251, 136,  97},
            new byte[] {254, 166, 113},
            new byte[] {254, 196, 136},
            new byte[] {251, 252, 191}
        });

        /// <summary>
        /// Colormap "nipy_spectral" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Nipy_Spectral = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] {123,   0, 140},
            new byte[] { 66,   0, 161},
            new byte[] {  0,   0, 209},
            new byte[] {  0, 119, 221},
            new byte[] {  0, 157, 207},
            new byte[] {  0, 170, 151},
            new byte[] {  0, 156,  29},
            new byte[] {  0, 188,   0},
            new byte[] {  0, 231,   0},
            new byte[] {102, 255,   0},
            new byte[] {227, 241,   0},
            new byte[] {255, 201,   0},
            new byte[] {255, 105,   0},
            new byte[] {235,   0,   0},
            new byte[] {204, 204, 204}
        });

        /// <summary>
        /// Colormap "ocean" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Ocean = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0, 127,   0},
            new byte[] {  0, 103,  16},
            new byte[] {  0,  79,  32},
            new byte[] {  0,  55,  48},
            new byte[] {  0,  31,  64},
            new byte[] {  0,   7,  80},
            new byte[] {  0,  16,  96},
            new byte[] {  0,  40, 112},
            new byte[] {  0,  64, 128},
            new byte[] {  0,  88, 144},
            new byte[] {  0, 112, 160},
            new byte[] { 17, 136, 176},
            new byte[] { 65, 160, 192},
            new byte[] {114, 184, 208},
            new byte[] {162, 208, 224},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "oranges" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Oranges = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 245, 235},
            new byte[] {254, 237, 220},
            new byte[] {253, 229, 205},
            new byte[] {253, 218, 183},
            new byte[] {253, 207, 161},
            new byte[] {253, 190, 133},
            new byte[] {253, 173, 106},
            new byte[] {253, 157,  82},
            new byte[] {252, 140,  59},
            new byte[] {246, 122,  38},
            new byte[] {240, 104,  18},
            new byte[] {228,  87,   9},
            new byte[] {215,  71,   1},
            new byte[] {190,  62,   2},
            new byte[] {164,  53,   3},
            new byte[] {127,  39,   4}
        });

        /// <summary>
        /// Colormap "orrd" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Orrd = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 247, 236},
            new byte[] {254, 239, 217},
            new byte[] {253, 231, 199},
            new byte[] {253, 221, 178},
            new byte[] {253, 211, 157},
            new byte[] {253, 199, 144},
            new byte[] {252, 186, 131},
            new byte[] {252, 163, 109},
            new byte[] {251, 140,  88},
            new byte[] {245, 120,  80},
            new byte[] {238,  99,  71},
            new byte[] {226,  73,  50},
            new byte[] {214,  46,  30},
            new byte[] {196,  22,  14},
            new byte[] {177,   0,   0},
            new byte[] {127,   0,   0}
        });

        /// <summary>
        /// Colormap "paired" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Paired = new Lazy<byte[][]>(() => new []
        {
            new byte[] {166, 206, 227},
            new byte[] { 72, 146, 194},
            new byte[] { 86, 159, 164},
            new byte[] {169, 218, 131},
            new byte[] { 81, 175,  66},
            new byte[] {141, 157,  93},
            new byte[] {247, 135, 135},
            new byte[] {231,  47,  49},
            new byte[] {240, 112,  71},
            new byte[] {253, 177,  87},
            new byte[] {254, 133,  10},
            new byte[] {223, 157, 126},
            new byte[] {174, 144, 197},
            new byte[] {108,  64, 155},
            new byte[] {204, 189, 153},
            new byte[] {177,  89,  40}
        });

        /// <summary>
        /// Colormap "pastel1" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Pastel1 = new Lazy<byte[][]>(() => new []
        {
            new byte[] {251, 180, 174},
            new byte[] {214, 192, 200},
            new byte[] {179, 205, 226},
            new byte[] {191, 220, 211},
            new byte[] {204, 234, 197},
            new byte[] {213, 218, 212},
            new byte[] {222, 203, 227},
            new byte[] {238, 210, 196},
            new byte[] {254, 217, 166},
            new byte[] {254, 236, 185},
            new byte[] {254, 254, 203},
            new byte[] {241, 234, 196},
            new byte[] {229, 216, 190},
            new byte[] {241, 217, 213},
            new byte[] {252, 218, 236},
            new byte[] {242, 242, 242}
        });

        /// <summary>
        /// Colormap "pastel2" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Pastel2 = new Lazy<byte[][]>(() => new []
        {
            new byte[] {179, 226, 205},
            new byte[] {211, 216, 190},
            new byte[] {244, 207, 176},
            new byte[] {237, 207, 191},
            new byte[] {215, 211, 217},
            new byte[] {211, 210, 231},
            new byte[] {229, 206, 229},
            new byte[] {242, 205, 225},
            new byte[] {236, 224, 214},
            new byte[] {230, 242, 202},
            new byte[] {239, 243, 190},
            new byte[] {250, 242, 178},
            new byte[] {251, 237, 182},
            new byte[] {245, 230, 195},
            new byte[] {235, 222, 204},
            new byte[] {204, 204, 204}
        });

        /// <summary>
        /// Colormap "pink" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Pink = new Lazy<byte[][]>(() => new []
        {
            new byte[] { 30,   0,   0},
            new byte[] { 84,  52,  52},
            new byte[] {116,  73,  73},
            new byte[] {140,  90,  90},
            new byte[] {161, 104, 104},
            new byte[] {179, 116, 116},
            new byte[] {194, 130, 127},
            new byte[] {201, 152, 137},
            new byte[] {208, 171, 147},
            new byte[] {214, 189, 156},
            new byte[] {221, 205, 164},
            new byte[] {227, 220, 172},
            new byte[] {233, 233, 182},
            new byte[] {238, 238, 203},
            new byte[] {244, 244, 222},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "piyg" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Piyg = new Lazy<byte[][]>(() => new []
        {
            new byte[] {142,   1,  82},
            new byte[] {176,  17, 108},
            new byte[] {203,  50, 137},
            new byte[] {219, 108, 168},
            new byte[] {231, 151, 196},
            new byte[] {242, 187, 220},
            new byte[] {250, 214, 234},
            new byte[] {250, 233, 242},
            new byte[] {246, 246, 246},
            new byte[] {236, 245, 221},
            new byte[] {217, 239, 187},
            new byte[] {188, 226, 141},
            new byte[] {153, 205,  97},
            new byte[] {119, 181,  59},
            new byte[] { 87, 155,  39},
            new byte[] { 39, 100,  25}
        });

        /// <summary>
        /// Colormap "plasma" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Plasma = new Lazy<byte[][]>(() => new []
        {
            new byte[] { 12,   7, 134},
            new byte[] { 49,   4, 150},
            new byte[] { 76,   2, 161},
            new byte[] {101,   0, 167},
            new byte[] {126,   3, 167},
            new byte[] {149,  17, 161},
            new byte[] {169,  35, 149},
            new byte[] {187,  53, 134},
            new byte[] {203,  71, 119},
            new byte[] {217,  89, 105},
            new byte[] {229, 108,  91},
            new byte[] {240, 128,  77},
            new byte[] {248, 149,  64},
            new byte[] {252, 172,  50},
            new byte[] {253, 196,  39},
            new byte[] {239, 248,  33}
        });

        /// <summary>
        /// Colormap "prgn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Prgn = new Lazy<byte[][]>(() => new []
        {
            new byte[] { 64,   0,  75},
            new byte[] { 97,  26, 110},
            new byte[] {126,  59, 141},
            new byte[] {148, 103, 166},
            new byte[] {173, 139, 189},
            new byte[] {199, 171, 210},
            new byte[] {222, 200, 226},
            new byte[] {237, 225, 237},
            new byte[] {246, 246, 246},
            new byte[] {227, 242, 223},
            new byte[] {203, 234, 197},
            new byte[] {171, 221, 165},
            new byte[] {125, 195, 126},
            new byte[] { 80, 165,  90},
            new byte[] { 40, 131,  64},
            new byte[] {  0,  68,  27}
        });

        /// <summary>
        /// Colormap "prism" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Prism = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255,   0,   0},
            new byte[] {  0,  47, 232},
            new byte[] {245, 255,   0},
            new byte[] {255,   0,  57},
            new byte[] {  0,  86, 195},
            new byte[] {255, 241,   0},
            new byte[] {240,   0, 112},
            new byte[] {  0, 126, 150},
            new byte[] {255, 215,   0},
            new byte[] {202,   0, 163},
            new byte[] {  0, 163,  98},
            new byte[] {255, 184,   0},
            new byte[] {162,   0, 206},
            new byte[] { 16, 197,  42},
            new byte[] {255, 148,   0},
            new byte[] { 84, 254,   0}
        });

        /// <summary>
        /// Colormap "pubu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Pubu = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 247, 251},
            new byte[] {245, 238, 246},
            new byte[] {235, 230, 241},
            new byte[] {221, 219, 235},
            new byte[] {207, 208, 229},
            new byte[] {186, 198, 224},
            new byte[] {165, 188, 218},
            new byte[] {140, 178, 212},
            new byte[] {115, 168, 206},
            new byte[] { 83, 156, 199},
            new byte[] { 53, 143, 191},
            new byte[] { 28, 127, 183},
            new byte[] {  4, 111, 175},
            new byte[] {  4, 100, 157},
            new byte[] {  3,  89, 139},
            new byte[] {  2,  56,  88}
        });

        /// <summary>
        /// Colormap "pubugn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Pubugn = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 247, 251},
            new byte[] {245, 236, 245},
            new byte[] {235, 225, 239},
            new byte[] {221, 217, 234},
            new byte[] {207, 208, 229},
            new byte[] {186, 198, 224},
            new byte[] {165, 188, 218},
            new byte[] {133, 178, 212},
            new byte[] {102, 168, 206},
            new byte[] { 77, 156, 199},
            new byte[] { 52, 143, 190},
            new byte[] { 26, 136, 163},
            new byte[] {  1, 128, 136},
            new byte[] {  1, 117, 112},
            new byte[] {  1, 106,  88},
            new byte[] {  1,  70,  54}
        });

        /// <summary>
        /// Colormap "puor" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Puor = new Lazy<byte[][]>(() => new []
        {
            new byte[] {127,  59,   8},
            new byte[] {159,  77,   6},
            new byte[] {190,  98,   9},
            new byte[] {218, 125,  18},
            new byte[] {238, 157,  60},
            new byte[] {253, 189, 110},
            new byte[] {253, 214, 162},
            new byte[] {251, 233, 207},
            new byte[] {246, 246, 246},
            new byte[] {226, 228, 239},
            new byte[] {205, 205, 228},
            new byte[] {181, 175, 212},
            new byte[] {151, 141, 189},
            new byte[] {121, 103, 166},
            new byte[] { 93,  55, 143},
            new byte[] { 45,   0,  75}
        });

        /// <summary>
        /// Colormap "purd" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Purd = new Lazy<byte[][]>(() => new []
        {
            new byte[] {247, 244, 249},
            new byte[] {238, 234, 243},
            new byte[] {230, 224, 238},
            new byte[] {221, 204, 228},
            new byte[] {211, 184, 217},
            new byte[] {206, 166, 208},
            new byte[] {201, 147, 198},
            new byte[] {212, 123, 187},
            new byte[] {223, 100, 175},
            new byte[] {227,  69, 156},
            new byte[] {230,  40, 136},
            new byte[] {217,  29, 110},
            new byte[] {204,  17,  85},
            new byte[] {177,   8,  76},
            new byte[] {150,   0,  66},
            new byte[] {103,   0,  31}
        });

        /// <summary>
        /// Colormap "purples" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Purples = new Lazy<byte[][]>(() => new []
        {
            new byte[] {252, 251, 253},
            new byte[] {245, 243, 248},
            new byte[] {238, 236, 244},
            new byte[] {228, 227, 239},
            new byte[] {217, 217, 234},
            new byte[] {202, 203, 227},
            new byte[] {187, 188, 219},
            new byte[] {172, 171, 209},
            new byte[] {157, 153, 199},
            new byte[] {142, 138, 192},
            new byte[] {127, 124, 185},
            new byte[] {116, 102, 174},
            new byte[] {105,  80, 162},
            new byte[] { 94,  58, 152},
            new byte[] { 83,  37, 142},
            new byte[] { 63,   0, 125}
        });

        /// <summary>
        /// Colormap "rainbow" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Rainbow = new Lazy<byte[][]>(() => new []
        {
            new byte[] {127,   0, 255},
            new byte[] { 95,  49, 253},
            new byte[] { 63,  97, 250},
            new byte[] { 31, 142, 243},
            new byte[] {  0, 180, 235},
            new byte[] { 32, 212, 224},
            new byte[] { 64, 236, 211},
            new byte[] { 96, 250, 196},
            new byte[] {128, 254, 179},
            new byte[] {160, 249, 161},
            new byte[] {192, 234, 140},
            new byte[] {224, 210, 119},
            new byte[] {255, 178,  96},
            new byte[] {255, 139,  72},
            new byte[] {255,  95,  48},
            new byte[] {255,   0,   0}
        });

        /// <summary>
        /// Colormap "rdbu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Rdbu = new Lazy<byte[][]>(() => new []
        {
            new byte[] {103,   0,  31},
            new byte[] {150,  15,  38},
            new byte[] {187,  42,  51},
            new byte[] {209,  87,  73},
            new byte[] {229, 131, 104},
            new byte[] {245, 172, 139},
            new byte[] {250, 206, 182},
            new byte[] {250, 229, 217},
            new byte[] {246, 246, 246},
            new byte[] {222, 235, 242},
            new byte[] {191, 220, 235},
            new byte[] {152, 200, 223},
            new byte[] {104, 170, 207},
            new byte[] { 61, 139, 191},
            new byte[] { 40, 111, 176},
            new byte[] {  5,  48,  97}
        });

        /// <summary>
        /// Colormap "rdgy" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Rdgy = new Lazy<byte[][]>(() => new []
        {
            new byte[] {103,   0,  31},
            new byte[] {150,  15,  38},
            new byte[] {187,  42,  51},
            new byte[] {209,  87,  73},
            new byte[] {229, 131, 104},
            new byte[] {245, 172, 139},
            new byte[] {250, 206, 182},
            new byte[] {253, 233, 220},
            new byte[] {254, 254, 254},
            new byte[] {234, 234, 234},
            new byte[] {213, 213, 213},
            new byte[] {189, 189, 189},
            new byte[] {159, 159, 159},
            new byte[] {125, 125, 125},
            new byte[] { 89,  89,  89},
            new byte[] { 26,  26,  26}
        });

        /// <summary>
        /// Colormap "rdpu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Rdpu = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 247, 243},
            new byte[] {253, 235, 231},
            new byte[] {252, 223, 220},
            new byte[] {252, 210, 206},
            new byte[] {251, 196, 191},
            new byte[] {250, 177, 186},
            new byte[] {249, 158, 180},
            new byte[] {248, 130, 170},
            new byte[] {246, 103, 160},
            new byte[] {233,  77, 155},
            new byte[] {220,  51, 150},
            new byte[] {196,  25, 137},
            new byte[] {172,   1, 125},
            new byte[] {146,   1, 122},
            new byte[] {120,   0, 118},
            new byte[] { 73,   0, 106}
        });

        /// <summary>
        /// Colormap "rdylbu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Rdylbu = new Lazy<byte[][]>(() => new []
        {
            new byte[] {165,   0,  38},
            new byte[] {196,  30,  38},
            new byte[] {222,  63,  46},
            new byte[] {240, 101,  63},
            new byte[] {248, 142,  82},
            new byte[] {253, 180, 103},
            new byte[] {253, 212, 132},
            new byte[] {254, 236, 162},
            new byte[] {254, 254, 192},
            new byte[] {234, 247, 227},
            new byte[] {209, 235, 243},
            new byte[] {176, 219, 234},
            new byte[] {141, 193, 220},
            new byte[] {108, 164, 204},
            new byte[] { 79, 129, 186},
            new byte[] { 49,  54, 149}
        });

        /// <summary>
        /// Colormap "rdylgn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Rdylgn = new Lazy<byte[][]>(() => new []
        {
            new byte[] {165,   0,  38},
            new byte[] {196,  30,  38},
            new byte[] {222,  63,  46},
            new byte[] {240, 101,  63},
            new byte[] {248, 142,  82},
            new byte[] {253, 180, 102},
            new byte[] {253, 212, 129},
            new byte[] {254, 236, 159},
            new byte[] {254, 254, 189},
            new byte[] {230, 244, 157},
            new byte[] {203, 232, 129},
            new byte[] {171, 219, 109},
            new byte[] {132, 202, 102},
            new byte[] { 90, 183,  96},
            new byte[] { 42, 159,  84},
            new byte[] {  0, 104,  55}
        });

        /// <summary>
        /// Colormap "reds" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Reds = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 245, 240},
            new byte[] {254, 234, 224},
            new byte[] {253, 223, 209},
            new byte[] {252, 205, 185},
            new byte[] {252, 186, 160},
            new byte[] {252, 166, 137},
            new byte[] {251, 145, 113},
            new byte[] {251, 125,  93},
            new byte[] {250, 105,  73},
            new byte[] {244,  81,  58},
            new byte[] {238,  58,  43},
            new byte[] {220,  40,  36},
            new byte[] {202,  23,  28},
            new byte[] {183,  19,  24},
            new byte[] {163,  14,  20},
            new byte[] {103,   0,  13}
        });

        /// <summary>
        /// Colormap "seismic" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Seismic = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,  76},
            new byte[] {  0,   0, 121},
            new byte[] {  0,   0, 166},
            new byte[] {  0,   0, 210},
            new byte[] {  1,   1, 255},
            new byte[] { 65,  65, 255},
            new byte[] {129, 129, 255},
            new byte[] {193, 193, 255},
            new byte[] {255, 253, 253},
            new byte[] {255, 189, 189},
            new byte[] {255, 125, 125},
            new byte[] {255,  61,  61},
            new byte[] {253,   0,   0},
            new byte[] {221,   0,   0},
            new byte[] {189,   0,   0},
            new byte[] {127,   0,   0}
        });

        /// <summary>
        /// Colormap "set1" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Set1 = new Lazy<byte[][]>(() => new []
        {
            new byte[] {228,  26,  28},
            new byte[] {141,  76, 106},
            new byte[] { 55, 126, 183},
            new byte[] { 66, 150, 128},
            new byte[] { 77, 174,  74},
            new byte[] {115, 125, 119},
            new byte[] {153,  78, 161},
            new byte[] {204, 103,  79},
            new byte[] {255, 129,   0},
            new byte[] {255, 193,  26},
            new byte[] {253, 251,  50},
            new byte[] {208, 166,  45},
            new byte[] {167,  87,  43},
            new byte[] {208, 108, 119},
            new byte[] {244, 129, 189},
            new byte[] {153, 153, 153}
        });

        /// <summary>
        /// Colormap "set2" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Set2 = new Lazy<byte[][]>(() => new []
        {
            new byte[] {102, 194, 165},
            new byte[] {167, 170, 135},
            new byte[] {233, 147, 106},
            new byte[] {216, 147, 131},
            new byte[] {167, 155, 177},
            new byte[] {158, 155, 201},
            new byte[] {198, 146, 197},
            new byte[] {226, 143, 186},
            new byte[] {197, 178, 137},
            new byte[] {169, 212,  89},
            new byte[] {200, 216,  69},
            new byte[] {239, 216,  53},
            new byte[] {247, 211,  74},
            new byte[] {236, 202, 118},
            new byte[] {221, 193, 152},
            new byte[] {179, 179, 179}
        });

        /// <summary>
        /// Colormap "set3" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Set3 = new Lazy<byte[][]>(() => new []
        {
            new byte[] {141, 211, 199},
            new byte[] {219, 241, 185},
            new byte[] {230, 228, 193},
            new byte[] {194, 181, 210},
            new byte[] {236, 141, 138},
            new byte[] {195, 150, 157},
            new byte[] {145, 177, 195},
            new byte[] {231, 179, 117},
            new byte[] {214, 201, 101},
            new byte[] {194, 218, 131},
            new byte[] {244, 206, 216},
            new byte[] {231, 212, 221},
            new byte[] {208, 191, 209},
            new byte[] {188, 130, 189},
            new byte[] {198, 198, 194},
            new byte[] {255, 237, 111}
        });

        /// <summary>
        /// Colormap "spectral" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Spectral = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0,   0},
            new byte[] {123,   0, 140},
            new byte[] { 66,   0, 161},
            new byte[] {  0,   0, 209},
            new byte[] {  0, 119, 221},
            new byte[] {  0, 157, 207},
            new byte[] {  0, 170, 151},
            new byte[] {  0, 156,  29},
            new byte[] {  0, 188,   0},
            new byte[] {  0, 231,   0},
            new byte[] {102, 255,   0},
            new byte[] {227, 241,   0},
            new byte[] {255, 201,   0},
            new byte[] {255, 105,   0},
            new byte[] {235,   0,   0},
            new byte[] {204, 204, 204}
        });

        /// <summary>
        /// Colormap "spring" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Spring = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255,   0, 255},
            new byte[] {255,  16, 239},
            new byte[] {255,  32, 223},
            new byte[] {255,  48, 207},
            new byte[] {255,  64, 191},
            new byte[] {255,  80, 175},
            new byte[] {255,  96, 159},
            new byte[] {255, 112, 143},
            new byte[] {255, 128, 127},
            new byte[] {255, 144, 111},
            new byte[] {255, 160,  95},
            new byte[] {255, 176,  79},
            new byte[] {255, 192,  63},
            new byte[] {255, 208,  47},
            new byte[] {255, 224,  31},
            new byte[] {255, 255,   0}
        });

        /// <summary>
        /// Colormap "summer" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Summer = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0, 127, 102},
            new byte[] { 16, 135, 102},
            new byte[] { 32, 143, 102},
            new byte[] { 48, 151, 102},
            new byte[] { 64, 159, 102},
            new byte[] { 80, 167, 102},
            new byte[] { 96, 175, 102},
            new byte[] {112, 183, 102},
            new byte[] {128, 191, 102},
            new byte[] {144, 199, 102},
            new byte[] {160, 207, 102},
            new byte[] {176, 215, 102},
            new byte[] {192, 223, 102},
            new byte[] {208, 231, 102},
            new byte[] {224, 239, 102},
            new byte[] {255, 255, 102}
        });

        /// <summary>
        /// Colormap "terrain" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Terrain = new Lazy<byte[][]>(() => new []
        {
            new byte[] { 51,  51, 153},
            new byte[] { 29,  93, 195},
            new byte[] {  8, 136, 238},
            new byte[] {  0, 172, 196},
            new byte[] {  1, 204, 102},
            new byte[] { 65, 217, 115},
            new byte[] {129, 229, 127},
            new byte[] {193, 242, 140},
            new byte[] {254, 253, 152},
            new byte[] {222, 212, 135},
            new byte[] {190, 171, 117},
            new byte[] {158, 130, 100},
            new byte[] {129,  93,  86},
            new byte[] {161, 134, 129},
            new byte[] {193, 175, 171},
            new byte[] {255, 255, 255}
        });

        /// <summary>
        /// Colormap "viridis" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Viridis = new Lazy<byte[][]>(() => new []
        {
            new byte[] { 68,   1,  84},
            new byte[] { 71,  24, 106},
            new byte[] { 71,  44, 123},
            new byte[] { 66,  64, 133},
            new byte[] { 58,  82, 139},
            new byte[] { 50,  98, 141},
            new byte[] { 44, 114, 142},
            new byte[] { 38, 129, 142},
            new byte[] { 32, 144, 140},
            new byte[] { 30, 159, 136},
            new byte[] { 40, 174, 127},
            new byte[] { 62, 188, 115},
            new byte[] { 94, 201,  97},
            new byte[] {131, 211,  75},
            new byte[] {173, 220,  48},
            new byte[] {253, 231,  36}
        });

        /// <summary>
        /// Colormap "winter" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Winter = new Lazy<byte[][]>(() => new []
        {
            new byte[] {  0,   0, 255},
            new byte[] {  0,  16, 247},
            new byte[] {  0,  32, 239},
            new byte[] {  0,  48, 231},
            new byte[] {  0,  64, 223},
            new byte[] {  0,  80, 215},
            new byte[] {  0,  96, 207},
            new byte[] {  0, 112, 199},
            new byte[] {  0, 128, 191},
            new byte[] {  0, 144, 183},
            new byte[] {  0, 160, 175},
            new byte[] {  0, 176, 167},
            new byte[] {  0, 192, 159},
            new byte[] {  0, 208, 151},
            new byte[] {  0, 224, 143},
            new byte[] {  0, 255, 127}
        });

        /// <summary>
        /// Colormap "wistia" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Wistia = new Lazy<byte[][]>(() => new []
        {
            new byte[] {228, 255, 122},
            new byte[] {234, 249,  97},
            new byte[] {241, 243,  73},
            new byte[] {248, 237,  49},
            new byte[] {255, 231,  25},
            new byte[] {255, 221,  19},
            new byte[] {255, 210,  12},
            new byte[] {255, 199,   6},
            new byte[] {255, 188,   0},
            new byte[] {255, 181,   0},
            new byte[] {255, 174,   0},
            new byte[] {255, 166,   0},
            new byte[] {254, 159,   0},
            new byte[] {254, 151,   0},
            new byte[] {253, 143,   0},
            new byte[] {252, 127,   0}
        });

        /// <summary>
        /// Colormap "ylgn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Ylgn = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 255, 229},
            new byte[] {250, 253, 206},
            new byte[] {246, 251, 184},
            new byte[] {231, 245, 173},
            new byte[] {216, 239, 162},
            new byte[] {194, 230, 152},
            new byte[] {172, 220, 141},
            new byte[] {145, 209, 131},
            new byte[] {119, 197, 120},
            new byte[] { 91, 184, 106},
            new byte[] { 64, 170,  92},
            new byte[] { 49, 150,  79},
            new byte[] { 34, 131,  66},
            new byte[] { 16, 117,  60},
            new byte[] {  0, 103,  54},
            new byte[] {  0,  69,  41}
        });

        /// <summary>
        /// Colormap "ylgnbu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Ylgnbu = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 255, 217},
            new byte[] {245, 251, 196},
            new byte[] {236, 247, 177},
            new byte[] {217, 240, 178},
            new byte[] {198, 232, 180},
            new byte[] {162, 218, 183},
            new byte[] {126, 204, 187},
            new byte[] { 95, 193, 191},
            new byte[] { 64, 181, 195},
            new byte[] { 46, 162, 193},
            new byte[] { 29, 144, 191},
            new byte[] { 31, 118, 179},
            new byte[] { 34,  93, 167},
            new byte[] { 35,  71, 157},
            new byte[] { 36,  51, 146},
            new byte[] {  8,  29,  88}
        });

        /// <summary>
        /// Colormap "ylorbr" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Ylorbr = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 255, 229},
            new byte[] {255, 250, 208},
            new byte[] {254, 246, 187},
            new byte[] {254, 236, 166},
            new byte[] {254, 226, 144},
            new byte[] {254, 211, 111},
            new byte[] {254, 195,  78},
            new byte[] {254, 173,  59},
            new byte[] {253, 152,  40},
            new byte[] {244, 131,  30},
            new byte[] {235, 111,  19},
            new byte[] {219,  93,  10},
            new byte[] {202,  75,   2},
            new byte[] {177,  63,   3},
            new byte[] {151,  51,   4},
            new byte[] {102,  37,   6}
        });

        /// <summary>
        /// Colormap "ylorrd" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[][]> Ylorrd = new Lazy<byte[][]>(() => new []
        {
            new byte[] {255, 255, 204},
            new byte[] {255, 245, 181},
            new byte[] {254, 236, 159},
            new byte[] {254, 226, 138},
            new byte[] {254, 216, 117},
            new byte[] {254, 197,  96},
            new byte[] {253, 177,  75},
            new byte[] {253, 158,  67},
            new byte[] {252, 140,  59},
            new byte[] {252, 108,  50},
            new byte[] {251,  76,  41},
            new byte[] {238,  50,  34},
            new byte[] {226,  25,  28},
            new byte[] {207,  12,  33},
            new byte[] {187,   0,  38},
            new byte[] {128,   0,  38}
        });

    #endregion

        /// <summary>
        /// Convenient dictionary for mapping palette names onto palette byte arrays
        /// </summary>
        public static readonly Dictionary<string, Lazy<byte[][]>>
            ByName = new Dictionary<string, Lazy<byte[][]>>
        {
            {"accent", Accent},
            {"afmhot", Afmhot},
            {"autumn", Autumn},
            {"binary", Binary},
            {"blues", Blues},
            {"bone", Bone},
            {"brbg", Brbg},
            {"brg", Brg},
            {"bugn", Bugn},
            {"bupu", Bupu},
            {"bwr", Bwr},
            {"cmrmap", Cmrmap},
            {"cool", Cool},
            {"coolwarm", Coolwarm},
            {"copper", Copper},
            {"cubehelix", Cubehelix},
            {"dark2", Dark2},
            {"flag", Flag},
            {"gist_earth", Gist_Earth},
            {"gist_gray", Gist_Gray},
            {"gist_heat", Gist_Heat},
            {"gist_ncar", Gist_Ncar},
            {"gist_rainbow", Gist_Rainbow},
            {"gist_stern", Gist_Stern},
            {"gist_yarg", Gist_Yarg},
            {"gnbu", Gnbu},
            {"gnuplot", Gnuplot},
            {"gnuplot2", Gnuplot2},
            {"gray", Gray},
            {"greens", Greens},
            {"greys", Greys},
            {"hot", Hot},
            {"hsv", Hsv},
            {"inferno", Inferno},
            {"jet", Jet},
            {"magma", Magma},
            {"nipy_spectral", Nipy_Spectral},
            {"ocean", Ocean},
            {"oranges", Oranges},
            {"orrd", Orrd},
            {"paired", Paired},
            {"pastel1", Pastel1},
            {"pastel2", Pastel2},
            {"pink", Pink},
            {"piyg", Piyg},
            {"plasma", Plasma},
            {"prgn", Prgn},
            {"prism", Prism},
            {"pubu", Pubu},
            {"pubugn", Pubugn},
            {"puor", Puor},
            {"purd", Purd},
            {"purples", Purples},
            {"rainbow", Rainbow},
            {"rdbu", Rdbu},
            {"rdgy", Rdgy},
            {"rdpu", Rdpu},
            {"rdylbu", Rdylbu},
            {"rdylgn", Rdylgn},
            {"reds", Reds},
            {"seismic", Seismic},
            {"set1", Set1},
            {"set2", Set2},
            {"set3", Set3},
            {"spectral", Spectral},
            {"spring", Spring},
            {"summer", Summer},
            {"terrain", Terrain},
            {"viridis", Viridis},
            {"winter", Winter},
            {"wistia", Wistia},
            {"ylgn", Ylgn},
            {"ylgnbu", Ylgnbu},
            {"ylorbr", Ylorbr},
            {"ylorrd", Ylorrd}
        };

        /// <summary>
        /// Enumerate all available palettes / colormaps
        /// </summary>
        public static IEnumerable<string> Names => ByName.Keys;
    }

#else
    public static class Palette
    {
        /// <summary>
        /// Number of base colors in palette
        /// </summary>
        public const int Resolution = 16;

    #region palettes
        
        /// <summary>
        /// Colormap "accent" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Accent = new Lazy<byte[,]>(() => new byte[,]
        {
            {127, 201, 127},
            {154, 189, 164},
            {182, 177, 201},
            {210, 179, 187},
            {237, 187, 152},
            {253, 204, 137},
            {254, 232, 146},
            {240, 244, 154},
            {152, 179, 164},
            { 65, 114, 174},
            {128,  66, 156},
            {208,  19, 135},
            {226,  26,  98},
            {205,  65,  53},
            {177,  92,  34},
            {102, 102, 102}
        });

        /// <summary>
        /// Colormap "afmhot" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Afmhot = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            { 32,   0,   0},
            { 64,   0,   0},
            { 96,   0,   0},
            {128,   0,   0},
            {160,  32,   0},
            {192,  64,   0},
            {224,  96,   0},
            {255, 128,   0},
            {255, 160,  32},
            {255, 192,  65},
            {255, 224,  97},
            {255, 255, 129},
            {255, 255, 161},
            {255, 255, 193},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "autumn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Autumn = new Lazy<byte[,]>(() => new byte[,]
        {
            {255,   0,   0},
            {255,  16,   0},
            {255,  32,   0},
            {255,  48,   0},
            {255,  64,   0},
            {255,  80,   0},
            {255,  96,   0},
            {255, 112,   0},
            {255, 128,   0},
            {255, 144,   0},
            {255, 160,   0},
            {255, 176,   0},
            {255, 192,   0},
            {255, 208,   0},
            {255, 224,   0},
            {255, 255,   0}
        });

        /// <summary>
        /// Colormap "binary" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Binary = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 255, 255},
            {239, 239, 239},
            {223, 223, 223},
            {207, 207, 207},
            {191, 191, 191},
            {175, 175, 175},
            {159, 159, 159},
            {143, 143, 143},
            {127, 127, 127},
            {111, 111, 111},
            { 95,  95,  95},
            { 79,  79,  79},
            { 63,  63,  63},
            { 47,  47,  47},
            { 31,  31,  31},
            {  0,   0,   0}
        });

        /// <summary>
        /// Colormap "blues" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Blues = new Lazy<byte[,]>(() => new byte[,]
        {
            {247, 251, 255},
            {234, 242, 250},
            {221, 234, 246},
            {209, 226, 242},
            {197, 218, 238},
            {177, 210, 231},
            {157, 201, 224},
            {131, 187, 219},
            {106, 173, 213},
            { 85, 159, 205},
            { 65, 145, 197},
            { 48, 128, 189},
            { 32, 112, 180},
            { 19,  96, 167},
            {  8,  80, 154},
            {  8,  48, 107}
        });

        /// <summary>
        /// Colormap "bone" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Bone = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            { 14,  13,  19},
            { 28,  27,  38},
            { 42,  41,  58},
            { 56,  55,  77},
            { 70,  69,  97},
            { 84,  84, 115},
            { 98, 104, 129},
            {112, 123, 143},
            {126, 142, 157},
            {140, 161, 171},
            {154, 181, 185},
            {168, 199, 199},
            {190, 213, 213},
            {212, 227, 227},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "brbg" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Brbg = new Lazy<byte[,]>(() => new byte[,]
        {
            { 84,  48,   5},
            {119,  68,   8},
            {153,  93,  18},
            {185, 123,  40},
            {207, 162,  85},
            {226, 199, 134},
            {240, 223, 178},
            {245, 237, 214},
            {244, 244, 244},
            {215, 237, 234},
            {179, 226, 219},
            {134, 207, 196},
            { 88, 176, 166},
            { 44, 143, 135},
            { 12, 112, 104},
            {  0,  60,  48}
        });

        /// <summary>
        /// Colormap "brg" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Brg = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0, 255},
            { 32,   0, 223},
            { 64,   0, 191},
            { 96,   0, 159},
            {128,   0, 127},
            {160,   0,  95},
            {192,   0,  63},
            {224,   0,  31},
            {254,   1,   0},
            {222,  33,   0},
            {190,  65,   0},
            {158,  97,   0},
            {126, 129,   0},
            { 94, 161,   0},
            { 62, 193,   0},
            {  0, 255,   0}
        });

        /// <summary>
        /// Colormap "bugn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Bugn = new Lazy<byte[,]>(() => new byte[,]
        {
            {247, 252, 253},
            {237, 248, 250},
            {228, 244, 248},
            {216, 240, 239},
            {203, 235, 229},
            {178, 225, 215},
            {152, 215, 200},
            {126, 204, 181},
            {101, 193, 163},
            { 82, 183, 140},
            { 64, 173, 117},
            { 49, 155,  92},
            { 34, 138,  68},
            { 16, 123,  55},
            {  0, 107,  43},
            {  0,  68,  27}
        });

        /// <summary>
        /// Colormap "bupu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Bupu = new Lazy<byte[,]>(() => new byte[,]
        {
            {247, 252, 253},
            {235, 243, 248},
            {223, 235, 243},
            {207, 223, 236},
            {190, 210, 229},
            {174, 199, 223},
            {157, 187, 217},
            {148, 168, 207},
            {140, 149, 197},
            {140, 127, 187},
            {139, 106, 176},
            {137,  85, 166},
            {135,  63, 156},
            {132,  38, 139},
            {127,  14, 122},
            { 77,   0,  75}
        });

        /// <summary>
        /// Colormap "bwr" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Bwr = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0, 255},
            { 32,  32, 255},
            { 64,  64, 255},
            { 96,  96, 255},
            {128, 128, 255},
            {160, 160, 255},
            {192, 192, 255},
            {224, 224, 255},
            {255, 254, 254},
            {255, 222, 222},
            {255, 190, 190},
            {255, 158, 158},
            {255, 126, 126},
            {255,  94,  94},
            {255,  62,  62},
            {255,   0,   0}
        });

        /// <summary>
        /// Colormap "cmrmap" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Cmrmap = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            { 19,  19,  64},
            { 38,  38, 127},
            { 57,  38, 159},
            { 77,  38, 190},
            {115,  44, 158},
            {154,  51, 126},
            {205,  57,  81},
            {254,  64,  37},
            {241,  96,  18},
            {229, 128,   0},
            {229, 160,  13},
            {229, 192,  27},
            {229, 211,  79},
            {230, 230, 131},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "cool" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Cool = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0, 255, 255},
            { 16, 239, 255},
            { 32, 223, 255},
            { 48, 207, 255},
            { 64, 191, 255},
            { 80, 175, 255},
            { 96, 159, 255},
            {112, 143, 255},
            {128, 127, 255},
            {144, 111, 255},
            {160,  95, 255},
            {176,  79, 255},
            {192,  63, 255},
            {208,  47, 255},
            {224,  31, 255},
            {255,   0, 255}
        });

        /// <summary>
        /// Colormap "coolwarm" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Coolwarm = new Lazy<byte[,]>(() => new byte[,]
        {
            { 58,  76, 192},
            { 77, 103, 215},
            { 97, 130, 234},
            {119, 154, 246},
            {141, 175, 253},
            {163, 193, 254},
            {184, 207, 248},
            {204, 216, 237},
            {221, 220, 219},
            {236, 210, 196},
            {244, 195, 171},
            {247, 176, 146},
            {243, 152, 121},
            {234, 125,  97},
            {220,  94,  75},
            {179,   3,  38}
        });

        /// <summary>
        /// Colormap "copper" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Copper = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            { 19,  12,   7},
            { 39,  24,  15},
            { 59,  37,  23},
            { 79,  49,  31},
            { 98,  62,  39},
            {118,  74,  47},
            {138,  87,  55},
            {158,  99,  63},
            {177, 112,  71},
            {197, 124,  79},
            {217, 137,  87},
            {237, 149,  95},
            {255, 162, 103},
            {255, 174, 111},
            {255, 199, 126}
        });

        /// <summary>
        /// Colormap "cubehelix" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Cubehelix = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            { 20,  11,  29},
            { 26,  29,  59},
            { 22,  55,  76},
            { 21,  83,  75},
            { 35, 106,  61},
            { 67, 119,  48},
            {113, 122,  50},
            {161, 121,  74},
            {196, 122, 117},
            {211, 131, 169},
            {208, 152, 212},
            {198, 180, 237},
            {193, 208, 243},
            {203, 231, 239},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "dark2" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Dark2 = new Lazy<byte[,]>(() => new byte[,]
        {
            { 27, 158, 119},
            {110, 130,  67},
            {193, 102,  16},
            {185, 100,  58},
            {141, 107, 135},
            {139,  98, 170},
            {189,  66, 152},
            {221,  50, 129},
            {164, 105,  82},
            {108, 160,  35},
            {152, 167,  19},
            {208, 170,   6},
            {212, 156,   9},
            {184, 133,  21},
            {156, 115,  39},
            {102, 102, 102}
        });

        /// <summary>
        /// Colormap "flag" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Flag = new Lazy<byte[,]>(() => new byte[,]
        {
            {255,   0,   0},
            {252,   0,   0},
            {241,   0,   0},
            {229,   0,   0},
            {217,   0,   0},
            {204,   0,   0},
            {191,   0,   0},
            {178,   0,   0},
            {164,   0,   0},
            {150,   0,   0},
            {136,   0,   0},
            {122,   0,   0},
            {108,   0,   0},
            { 94,   0,   0},
            { 80,   0,   0},
            {  0,   0,   0}
        });

        /// <summary>
        /// Colormap "gist_earth" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Gist_Earth = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            { 10,  20, 117},
            { 21,  56, 120},
            { 31,  88, 123},
            { 42, 115, 126},
            { 51, 132, 117},
            { 59, 141,  98},
            { 66, 151,  78},
            { 93, 160,  75},
            {126, 167,  83},
            {153, 174,  88},
            {179, 181,  93},
            {188, 170,  98},
            {200, 166, 120},
            {218, 182, 159},
            {253, 250, 250}
        });

        /// <summary>
        /// Colormap "gist_gray" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Gist_Gray = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            { 16,  16,  16},
            { 32,  32,  32},
            { 48,  48,  48},
            { 64,  64,  64},
            { 80,  80,  80},
            { 96,  96,  96},
            {112, 112, 112},
            {128, 128, 128},
            {144, 144, 144},
            {160, 160, 160},
            {176, 176, 176},
            {192, 192, 192},
            {208, 208, 208},
            {224, 224, 224},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "gist_heat" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Gist_Heat = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            { 24,   0,   0},
            { 48,   0,   0},
            { 72,   0,   0},
            { 96,   0,   0},
            {120,   0,   0},
            {144,   0,   0},
            {168,   0,   0},
            {192,   0,   0},
            {216,  32,   0},
            {240,  65,   0},
            {255,  97,   0},
            {255, 129,   2},
            {255, 161,  66},
            {255, 193, 131},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "gist_ncar" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Gist_Ncar = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0, 128},
            {  0,  74,  55},
            {  0,  70, 255},
            {  0, 224, 255},
            {  0, 250, 176},
            {  6, 254,  20},
            {103, 212,   0},
            {145, 255,  23},
            {218, 255,  31},
            {255, 227,   0},
            {255, 188,  12},
            {255,  66,   0},
            {255,   0,  70},
            {213,  20, 255},
            {205,  97, 244},
            {254, 247, 254}
        });

        /// <summary>
        /// Colormap "gist_rainbow" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Gist_Rainbow = new Lazy<byte[,]>(() => new byte[,]
        {
            {255,   0,  40},
            {255,  45,   0},
            {255, 131,   0},
            {255, 218,   0},
            {205, 255,   0},
            {118, 255,   0},
            { 32, 255,   0},
            {  0, 255,  53},
            {  0, 255, 139},
            {  0, 255, 225},
            {  0, 197, 255},
            {  0, 110, 255},
            {  0,  23, 255},
            { 63,   0, 255},
            {150,   0, 255},
            {255,   0, 191}
        });

        /// <summary>
        /// Colormap "gist_stern" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Gist_Stern = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            {244,  16,  32},
            {165,  32,  64},
            { 85,  48,  96},
            { 64,  64, 128},
            { 80,  80, 160},
            { 96,  96, 192},
            {112, 112, 224},
            {128, 128, 252},
            {144, 144, 184},
            {160, 160, 116},
            {176, 176,  48},
            {192, 192,  17},
            {208, 208,  77},
            {224, 224, 138},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "gist_yarg" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Gist_Yarg = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 255, 255},
            {239, 239, 239},
            {223, 223, 223},
            {207, 207, 207},
            {191, 191, 191},
            {175, 175, 175},
            {159, 159, 159},
            {143, 143, 143},
            {127, 127, 127},
            {111, 111, 111},
            { 95,  95,  95},
            { 79,  79,  79},
            { 63,  63,  63},
            { 47,  47,  47},
            { 31,  31,  31},
            {  0,   0,   0}
        });

        /// <summary>
        /// Colormap "gnbu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Gnbu = new Lazy<byte[,]>(() => new byte[,]
        {
            {247, 252, 240},
            {235, 247, 229},
            {223, 242, 218},
            {213, 238, 207},
            {203, 234, 196},
            {185, 227, 188},
            {167, 220, 181},
            {144, 212, 188},
            {122, 203, 196},
            { 99, 191, 203},
            { 77, 178, 210},
            { 59, 158, 200},
            { 42, 139, 189},
            { 24, 121, 180},
            {  8, 102, 170},
            {  8,  64, 129}
        });

        /// <summary>
        /// Colormap "gnuplot" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Gnuplot = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            { 63,   0,  97},
            { 90,   0, 180},
            {110,   1, 236},
            {127,   4, 254},
            {142,   7, 234},
            {156,  13, 178},
            {168,  21,  95},
            {180,  32,   0},
            {191,  45,   0},
            {201,  62,   0},
            {211,  83,   0},
            {221, 108,   0},
            {230, 138,   0},
            {238, 172,   0},
            {255, 255,   0}
        });

        /// <summary>
        /// Colormap "gnuplot2" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Gnuplot2 = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            {  0,   0,  64},
            {  0,   0, 128},
            {  0,   0, 192},
            {  0,   0, 255},
            { 50,   0, 255},
            {100,   0, 255},
            {150,   9, 245},
            {200,  41, 213},
            {250,  73, 181},
            {255, 105, 149},
            {255, 137, 117},
            {255, 169,  85},
            {255, 201,  53},
            {255, 233,  21},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "gray" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Gray = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            { 16,  16,  16},
            { 32,  32,  32},
            { 48,  48,  48},
            { 64,  64,  64},
            { 80,  80,  80},
            { 96,  96,  96},
            {112, 112, 112},
            {128, 128, 128},
            {144, 144, 144},
            {160, 160, 160},
            {176, 176, 176},
            {192, 192, 192},
            {208, 208, 208},
            {224, 224, 224},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "greens" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Greens = new Lazy<byte[,]>(() => new byte[,]
        {
            {247, 252, 245},
            {237, 248, 234},
            {228, 244, 223},
            {213, 238, 207},
            {198, 232, 191},
            {179, 224, 173},
            {160, 216, 154},
            {137, 206, 135},
            {115, 195, 117},
            { 89, 183, 105},
            { 64, 170,  92},
            { 49, 154,  80},
            { 34, 138,  68},
            { 16, 123,  55},
            {  0, 107,  43},
            {  0,  68,  27}
        });

        /// <summary>
        /// Colormap "greys" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Greys = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 255, 255},
            {247, 247, 247},
            {239, 239, 239},
            {228, 228, 228},
            {216, 216, 216},
            {202, 202, 202},
            {188, 188, 188},
            {168, 168, 168},
            {149, 149, 149},
            {131, 131, 131},
            {114, 114, 114},
            { 97,  97,  97},
            { 80,  80,  80},
            { 58,  58,  58},
            { 35,  35,  35},
            {  0,   0,   0}
        });

        /// <summary>
        /// Colormap "hot" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Hot = new Lazy<byte[,]>(() => new byte[,]
        {
            { 10,   0,   0},
            { 52,   0,   0},
            { 94,   0,   0},
            {136,   0,   0},
            {178,   0,   0},
            {220,   0,   0},
            {255,   7,   0},
            {255,  49,   0},
            {255,  91,   0},
            {255, 133,   0},
            {255, 175,   0},
            {255, 217,   0},
            {255, 255,   6},
            {255, 255,  69},
            {255, 255, 132},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "hsv" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Hsv = new Lazy<byte[,]>(() => new byte[,]
        {
            {255,   0,   0},
            {255,  94,   0},
            {255, 189,   0},
            {226, 255,   0},
            {131, 255,   0},
            { 37, 255,   0},
            {  0, 255,  57},
            {  0, 255, 151},
            {  0, 255, 245},
            {  0, 169, 255},
            {  0,  75, 255},
            { 19,   0, 255},
            {113,   0, 255},
            {208,   0, 255},
            {255,   0, 207},
            {255,   0,  23}
        });

        /// <summary>
        /// Colormap "inferno" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Inferno = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   3},
            { 10,   7,  35},
            { 32,  12,  74},
            { 60,   9, 101},
            { 87,  15, 109},
            {112,  25, 110},
            {137,  34, 105},
            {163,  43,  97},
            {187,  55,  84},
            {209,  70,  67},
            {228,  90,  49},
            {241, 114,  29},
            {249, 142,   8},
            {251, 172,  16},
            {248, 203,  52},
            {252, 254, 164}
        });

        /// <summary>
        /// Colormap "jet" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Jet = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0, 127},
            {  0,   0, 200},
            {  0,   0, 255},
            {  0,  64, 255},
            {  0, 128, 255},
            {  0, 192, 255},
            { 21, 255, 225},
            { 73, 255, 173},
            {124, 255, 121},
            {176, 255,  70},
            {228, 255,  18},
            {255, 207,   0},
            {255, 148,   0},
            {255,  89,   0},
            {255,  29,   0},
            {127,   0,   0}
        });

        /// <summary>
        /// Colormap "magma" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Magma = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   3},
            { 10,   7,  34},
            { 28,  16,  70},
            { 53,  15, 106},
            { 80,  18, 123},
            {105,  28, 128},
            {130,  37, 129},
            {156,  46, 127},
            {182,  54, 121},
            {208,  65, 111},
            {230,  81,  98},
            {245, 106,  91},
            {251, 136,  97},
            {254, 166, 113},
            {254, 196, 136},
            {251, 252, 191}
        });

        /// <summary>
        /// Colormap "nipy_spectral" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Nipy_Spectral = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            {123,   0, 140},
            { 66,   0, 161},
            {  0,   0, 209},
            {  0, 119, 221},
            {  0, 157, 207},
            {  0, 170, 151},
            {  0, 156,  29},
            {  0, 188,   0},
            {  0, 231,   0},
            {102, 255,   0},
            {227, 241,   0},
            {255, 201,   0},
            {255, 105,   0},
            {235,   0,   0},
            {204, 204, 204}
        });

        /// <summary>
        /// Colormap "ocean" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Ocean = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0, 127,   0},
            {  0, 103,  16},
            {  0,  79,  32},
            {  0,  55,  48},
            {  0,  31,  64},
            {  0,   7,  80},
            {  0,  16,  96},
            {  0,  40, 112},
            {  0,  64, 128},
            {  0,  88, 144},
            {  0, 112, 160},
            { 17, 136, 176},
            { 65, 160, 192},
            {114, 184, 208},
            {162, 208, 224},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "oranges" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Oranges = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 245, 235},
            {254, 237, 220},
            {253, 229, 205},
            {253, 218, 183},
            {253, 207, 161},
            {253, 190, 133},
            {253, 173, 106},
            {253, 157,  82},
            {252, 140,  59},
            {246, 122,  38},
            {240, 104,  18},
            {228,  87,   9},
            {215,  71,   1},
            {190,  62,   2},
            {164,  53,   3},
            {127,  39,   4}
        });

        /// <summary>
        /// Colormap "orrd" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Orrd = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 247, 236},
            {254, 239, 217},
            {253, 231, 199},
            {253, 221, 178},
            {253, 211, 157},
            {253, 199, 144},
            {252, 186, 131},
            {252, 163, 109},
            {251, 140,  88},
            {245, 120,  80},
            {238,  99,  71},
            {226,  73,  50},
            {214,  46,  30},
            {196,  22,  14},
            {177,   0,   0},
            {127,   0,   0}
        });

        /// <summary>
        /// Colormap "paired" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Paired = new Lazy<byte[,]>(() => new byte[,]
        {
            {166, 206, 227},
            { 72, 146, 194},
            { 86, 159, 164},
            {169, 218, 131},
            { 81, 175,  66},
            {141, 157,  93},
            {247, 135, 135},
            {231,  47,  49},
            {240, 112,  71},
            {253, 177,  87},
            {254, 133,  10},
            {223, 157, 126},
            {174, 144, 197},
            {108,  64, 155},
            {204, 189, 153},
            {177,  89,  40}
        });

        /// <summary>
        /// Colormap "pastel1" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Pastel1 = new Lazy<byte[,]>(() => new byte[,]
        {
            {251, 180, 174},
            {214, 192, 200},
            {179, 205, 226},
            {191, 220, 211},
            {204, 234, 197},
            {213, 218, 212},
            {222, 203, 227},
            {238, 210, 196},
            {254, 217, 166},
            {254, 236, 185},
            {254, 254, 203},
            {241, 234, 196},
            {229, 216, 190},
            {241, 217, 213},
            {252, 218, 236},
            {242, 242, 242}
        });

        /// <summary>
        /// Colormap "pastel2" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Pastel2 = new Lazy<byte[,]>(() => new byte[,]
        {
            {179, 226, 205},
            {211, 216, 190},
            {244, 207, 176},
            {237, 207, 191},
            {215, 211, 217},
            {211, 210, 231},
            {229, 206, 229},
            {242, 205, 225},
            {236, 224, 214},
            {230, 242, 202},
            {239, 243, 190},
            {250, 242, 178},
            {251, 237, 182},
            {245, 230, 195},
            {235, 222, 204},
            {204, 204, 204}
        });

        /// <summary>
        /// Colormap "pink" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Pink = new Lazy<byte[,]>(() => new byte[,]
        {
            { 30,   0,   0},
            { 84,  52,  52},
            {116,  73,  73},
            {140,  90,  90},
            {161, 104, 104},
            {179, 116, 116},
            {194, 130, 127},
            {201, 152, 137},
            {208, 171, 147},
            {214, 189, 156},
            {221, 205, 164},
            {227, 220, 172},
            {233, 233, 182},
            {238, 238, 203},
            {244, 244, 222},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "piyg" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Piyg = new Lazy<byte[,]>(() => new byte[,]
        {
            {142,   1,  82},
            {176,  17, 108},
            {203,  50, 137},
            {219, 108, 168},
            {231, 151, 196},
            {242, 187, 220},
            {250, 214, 234},
            {250, 233, 242},
            {246, 246, 246},
            {236, 245, 221},
            {217, 239, 187},
            {188, 226, 141},
            {153, 205,  97},
            {119, 181,  59},
            { 87, 155,  39},
            { 39, 100,  25}
        });

        /// <summary>
        /// Colormap "plasma" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Plasma = new Lazy<byte[,]>(() => new byte[,]
        {
            { 12,   7, 134},
            { 49,   4, 150},
            { 76,   2, 161},
            {101,   0, 167},
            {126,   3, 167},
            {149,  17, 161},
            {169,  35, 149},
            {187,  53, 134},
            {203,  71, 119},
            {217,  89, 105},
            {229, 108,  91},
            {240, 128,  77},
            {248, 149,  64},
            {252, 172,  50},
            {253, 196,  39},
            {239, 248,  33}
        });

        /// <summary>
        /// Colormap "prgn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Prgn = new Lazy<byte[,]>(() => new byte[,]
        {
            { 64,   0,  75},
            { 97,  26, 110},
            {126,  59, 141},
            {148, 103, 166},
            {173, 139, 189},
            {199, 171, 210},
            {222, 200, 226},
            {237, 225, 237},
            {246, 246, 246},
            {227, 242, 223},
            {203, 234, 197},
            {171, 221, 165},
            {125, 195, 126},
            { 80, 165,  90},
            { 40, 131,  64},
            {  0,  68,  27}
        });

        /// <summary>
        /// Colormap "prism" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Prism = new Lazy<byte[,]>(() => new byte[,]
        {
            {255,   0,   0},
            {  0,  47, 232},
            {245, 255,   0},
            {255,   0,  57},
            {  0,  86, 195},
            {255, 241,   0},
            {240,   0, 112},
            {  0, 126, 150},
            {255, 215,   0},
            {202,   0, 163},
            {  0, 163,  98},
            {255, 184,   0},
            {162,   0, 206},
            { 16, 197,  42},
            {255, 148,   0},
            { 84, 254,   0}
        });

        /// <summary>
        /// Colormap "pubu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Pubu = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 247, 251},
            {245, 238, 246},
            {235, 230, 241},
            {221, 219, 235},
            {207, 208, 229},
            {186, 198, 224},
            {165, 188, 218},
            {140, 178, 212},
            {115, 168, 206},
            { 83, 156, 199},
            { 53, 143, 191},
            { 28, 127, 183},
            {  4, 111, 175},
            {  4, 100, 157},
            {  3,  89, 139},
            {  2,  56,  88}
        });

        /// <summary>
        /// Colormap "pubugn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Pubugn = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 247, 251},
            {245, 236, 245},
            {235, 225, 239},
            {221, 217, 234},
            {207, 208, 229},
            {186, 198, 224},
            {165, 188, 218},
            {133, 178, 212},
            {102, 168, 206},
            { 77, 156, 199},
            { 52, 143, 190},
            { 26, 136, 163},
            {  1, 128, 136},
            {  1, 117, 112},
            {  1, 106,  88},
            {  1,  70,  54}
        });

        /// <summary>
        /// Colormap "puor" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Puor = new Lazy<byte[,]>(() => new byte[,]
        {
            {127,  59,   8},
            {159,  77,   6},
            {190,  98,   9},
            {218, 125,  18},
            {238, 157,  60},
            {253, 189, 110},
            {253, 214, 162},
            {251, 233, 207},
            {246, 246, 246},
            {226, 228, 239},
            {205, 205, 228},
            {181, 175, 212},
            {151, 141, 189},
            {121, 103, 166},
            { 93,  55, 143},
            { 45,   0,  75}
        });

        /// <summary>
        /// Colormap "purd" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Purd = new Lazy<byte[,]>(() => new byte[,]
        {
            {247, 244, 249},
            {238, 234, 243},
            {230, 224, 238},
            {221, 204, 228},
            {211, 184, 217},
            {206, 166, 208},
            {201, 147, 198},
            {212, 123, 187},
            {223, 100, 175},
            {227,  69, 156},
            {230,  40, 136},
            {217,  29, 110},
            {204,  17,  85},
            {177,   8,  76},
            {150,   0,  66},
            {103,   0,  31}
        });

        /// <summary>
        /// Colormap "purples" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Purples = new Lazy<byte[,]>(() => new byte[,]
        {
            {252, 251, 253},
            {245, 243, 248},
            {238, 236, 244},
            {228, 227, 239},
            {217, 217, 234},
            {202, 203, 227},
            {187, 188, 219},
            {172, 171, 209},
            {157, 153, 199},
            {142, 138, 192},
            {127, 124, 185},
            {116, 102, 174},
            {105,  80, 162},
            { 94,  58, 152},
            { 83,  37, 142},
            { 63,   0, 125}
        });

        /// <summary>
        /// Colormap "rainbow" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Rainbow = new Lazy<byte[,]>(() => new byte[,]
        {
            {127,   0, 255},
            { 95,  49, 253},
            { 63,  97, 250},
            { 31, 142, 243},
            {  0, 180, 235},
            { 32, 212, 224},
            { 64, 236, 211},
            { 96, 250, 196},
            {128, 254, 179},
            {160, 249, 161},
            {192, 234, 140},
            {224, 210, 119},
            {255, 178,  96},
            {255, 139,  72},
            {255,  95,  48},
            {255,   0,   0}
        });

        /// <summary>
        /// Colormap "rdbu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Rdbu = new Lazy<byte[,]>(() => new byte[,]
        {
            {103,   0,  31},
            {150,  15,  38},
            {187,  42,  51},
            {209,  87,  73},
            {229, 131, 104},
            {245, 172, 139},
            {250, 206, 182},
            {250, 229, 217},
            {246, 246, 246},
            {222, 235, 242},
            {191, 220, 235},
            {152, 200, 223},
            {104, 170, 207},
            { 61, 139, 191},
            { 40, 111, 176},
            {  5,  48,  97}
        });

        /// <summary>
        /// Colormap "rdgy" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Rdgy = new Lazy<byte[,]>(() => new byte[,]
        {
            {103,   0,  31},
            {150,  15,  38},
            {187,  42,  51},
            {209,  87,  73},
            {229, 131, 104},
            {245, 172, 139},
            {250, 206, 182},
            {253, 233, 220},
            {254, 254, 254},
            {234, 234, 234},
            {213, 213, 213},
            {189, 189, 189},
            {159, 159, 159},
            {125, 125, 125},
            { 89,  89,  89},
            { 26,  26,  26}
        });

        /// <summary>
        /// Colormap "rdpu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Rdpu = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 247, 243},
            {253, 235, 231},
            {252, 223, 220},
            {252, 210, 206},
            {251, 196, 191},
            {250, 177, 186},
            {249, 158, 180},
            {248, 130, 170},
            {246, 103, 160},
            {233,  77, 155},
            {220,  51, 150},
            {196,  25, 137},
            {172,   1, 125},
            {146,   1, 122},
            {120,   0, 118},
            { 73,   0, 106}
        });

        /// <summary>
        /// Colormap "rdylbu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Rdylbu = new Lazy<byte[,]>(() => new byte[,]
        {
            {165,   0,  38},
            {196,  30,  38},
            {222,  63,  46},
            {240, 101,  63},
            {248, 142,  82},
            {253, 180, 103},
            {253, 212, 132},
            {254, 236, 162},
            {254, 254, 192},
            {234, 247, 227},
            {209, 235, 243},
            {176, 219, 234},
            {141, 193, 220},
            {108, 164, 204},
            { 79, 129, 186},
            { 49,  54, 149}
        });

        /// <summary>
        /// Colormap "rdylgn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Rdylgn = new Lazy<byte[,]>(() => new byte[,]
        {
            {165,   0,  38},
            {196,  30,  38},
            {222,  63,  46},
            {240, 101,  63},
            {248, 142,  82},
            {253, 180, 102},
            {253, 212, 129},
            {254, 236, 159},
            {254, 254, 189},
            {230, 244, 157},
            {203, 232, 129},
            {171, 219, 109},
            {132, 202, 102},
            { 90, 183,  96},
            { 42, 159,  84},
            {  0, 104,  55}
        });

        /// <summary>
        /// Colormap "reds" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Reds = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 245, 240},
            {254, 234, 224},
            {253, 223, 209},
            {252, 205, 185},
            {252, 186, 160},
            {252, 166, 137},
            {251, 145, 113},
            {251, 125,  93},
            {250, 105,  73},
            {244,  81,  58},
            {238,  58,  43},
            {220,  40,  36},
            {202,  23,  28},
            {183,  19,  24},
            {163,  14,  20},
            {103,   0,  13}
        });

        /// <summary>
        /// Colormap "seismic" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Seismic = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,  76},
            {  0,   0, 121},
            {  0,   0, 166},
            {  0,   0, 210},
            {  1,   1, 255},
            { 65,  65, 255},
            {129, 129, 255},
            {193, 193, 255},
            {255, 253, 253},
            {255, 189, 189},
            {255, 125, 125},
            {255,  61,  61},
            {253,   0,   0},
            {221,   0,   0},
            {189,   0,   0},
            {127,   0,   0}
        });

        /// <summary>
        /// Colormap "set1" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Set1 = new Lazy<byte[,]>(() => new byte[,]
        {
            {228,  26,  28},
            {141,  76, 106},
            { 55, 126, 183},
            { 66, 150, 128},
            { 77, 174,  74},
            {115, 125, 119},
            {153,  78, 161},
            {204, 103,  79},
            {255, 129,   0},
            {255, 193,  26},
            {253, 251,  50},
            {208, 166,  45},
            {167,  87,  43},
            {208, 108, 119},
            {244, 129, 189},
            {153, 153, 153}
        });

        /// <summary>
        /// Colormap "set2" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Set2 = new Lazy<byte[,]>(() => new byte[,]
        {
            {102, 194, 165},
            {167, 170, 135},
            {233, 147, 106},
            {216, 147, 131},
            {167, 155, 177},
            {158, 155, 201},
            {198, 146, 197},
            {226, 143, 186},
            {197, 178, 137},
            {169, 212,  89},
            {200, 216,  69},
            {239, 216,  53},
            {247, 211,  74},
            {236, 202, 118},
            {221, 193, 152},
            {179, 179, 179}
        });

        /// <summary>
        /// Colormap "set3" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Set3 = new Lazy<byte[,]>(() => new byte[,]
        {
            {141, 211, 199},
            {219, 241, 185},
            {230, 228, 193},
            {194, 181, 210},
            {236, 141, 138},
            {195, 150, 157},
            {145, 177, 195},
            {231, 179, 117},
            {214, 201, 101},
            {194, 218, 131},
            {244, 206, 216},
            {231, 212, 221},
            {208, 191, 209},
            {188, 130, 189},
            {198, 198, 194},
            {255, 237, 111}
        });

        /// <summary>
        /// Colormap "spectral" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Spectral = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0,   0},
            {123,   0, 140},
            { 66,   0, 161},
            {  0,   0, 209},
            {  0, 119, 221},
            {  0, 157, 207},
            {  0, 170, 151},
            {  0, 156,  29},
            {  0, 188,   0},
            {  0, 231,   0},
            {102, 255,   0},
            {227, 241,   0},
            {255, 201,   0},
            {255, 105,   0},
            {235,   0,   0},
            {204, 204, 204}
        });

        /// <summary>
        /// Colormap "spring" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Spring = new Lazy<byte[,]>(() => new byte[,]
        {
            {255,   0, 255},
            {255,  16, 239},
            {255,  32, 223},
            {255,  48, 207},
            {255,  64, 191},
            {255,  80, 175},
            {255,  96, 159},
            {255, 112, 143},
            {255, 128, 127},
            {255, 144, 111},
            {255, 160,  95},
            {255, 176,  79},
            {255, 192,  63},
            {255, 208,  47},
            {255, 224,  31},
            {255, 255,   0}
        });

        /// <summary>
        /// Colormap "summer" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Summer = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0, 127, 102},
            { 16, 135, 102},
            { 32, 143, 102},
            { 48, 151, 102},
            { 64, 159, 102},
            { 80, 167, 102},
            { 96, 175, 102},
            {112, 183, 102},
            {128, 191, 102},
            {144, 199, 102},
            {160, 207, 102},
            {176, 215, 102},
            {192, 223, 102},
            {208, 231, 102},
            {224, 239, 102},
            {255, 255, 102}
        });

        /// <summary>
        /// Colormap "terrain" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Terrain = new Lazy<byte[,]>(() => new byte[,]
        {
            { 51,  51, 153},
            { 29,  93, 195},
            {  8, 136, 238},
            {  0, 172, 196},
            {  1, 204, 102},
            { 65, 217, 115},
            {129, 229, 127},
            {193, 242, 140},
            {254, 253, 152},
            {222, 212, 135},
            {190, 171, 117},
            {158, 130, 100},
            {129,  93,  86},
            {161, 134, 129},
            {193, 175, 171},
            {255, 255, 255}
        });

        /// <summary>
        /// Colormap "viridis" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Viridis = new Lazy<byte[,]>(() => new byte[,]
        {
            { 68,   1,  84},
            { 71,  24, 106},
            { 71,  44, 123},
            { 66,  64, 133},
            { 58,  82, 139},
            { 50,  98, 141},
            { 44, 114, 142},
            { 38, 129, 142},
            { 32, 144, 140},
            { 30, 159, 136},
            { 40, 174, 127},
            { 62, 188, 115},
            { 94, 201,  97},
            {131, 211,  75},
            {173, 220,  48},
            {253, 231,  36}
        });

        /// <summary>
        /// Colormap "winter" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Winter = new Lazy<byte[,]>(() => new byte[,]
        {
            {  0,   0, 255},
            {  0,  16, 247},
            {  0,  32, 239},
            {  0,  48, 231},
            {  0,  64, 223},
            {  0,  80, 215},
            {  0,  96, 207},
            {  0, 112, 199},
            {  0, 128, 191},
            {  0, 144, 183},
            {  0, 160, 175},
            {  0, 176, 167},
            {  0, 192, 159},
            {  0, 208, 151},
            {  0, 224, 143},
            {  0, 255, 127}
        });

        /// <summary>
        /// Colormap "wistia" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Wistia = new Lazy<byte[,]>(() => new byte[,]
        {
            {228, 255, 122},
            {234, 249,  97},
            {241, 243,  73},
            {248, 237,  49},
            {255, 231,  25},
            {255, 221,  19},
            {255, 210,  12},
            {255, 199,   6},
            {255, 188,   0},
            {255, 181,   0},
            {255, 174,   0},
            {255, 166,   0},
            {254, 159,   0},
            {254, 151,   0},
            {253, 143,   0},
            {252, 127,   0}
        });

        /// <summary>
        /// Colormap "ylgn" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Ylgn = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 255, 229},
            {250, 253, 206},
            {246, 251, 184},
            {231, 245, 173},
            {216, 239, 162},
            {194, 230, 152},
            {172, 220, 141},
            {145, 209, 131},
            {119, 197, 120},
            { 91, 184, 106},
            { 64, 170,  92},
            { 49, 150,  79},
            { 34, 131,  66},
            { 16, 117,  60},
            {  0, 103,  54},
            {  0,  69,  41}
        });

        /// <summary>
        /// Colormap "ylgnbu" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Ylgnbu = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 255, 217},
            {245, 251, 196},
            {236, 247, 177},
            {217, 240, 178},
            {198, 232, 180},
            {162, 218, 183},
            {126, 204, 187},
            { 95, 193, 191},
            { 64, 181, 195},
            { 46, 162, 193},
            { 29, 144, 191},
            { 31, 118, 179},
            { 34,  93, 167},
            { 35,  71, 157},
            { 36,  51, 146},
            {  8,  29,  88}
        });

        /// <summary>
        /// Colormap "ylorbr" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Ylorbr = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 255, 229},
            {255, 250, 208},
            {254, 246, 187},
            {254, 236, 166},
            {254, 226, 144},
            {254, 211, 111},
            {254, 195,  78},
            {254, 173,  59},
            {253, 152,  40},
            {244, 131,  30},
            {235, 111,  19},
            {219,  93,  10},
            {202,  75,   2},
            {177,  63,   3},
            {151,  51,   4},
            {102,  37,   6}
        });

        /// <summary>
        /// Colormap "ylorrd" taken from matplotlib
        /// </summary>
        public static readonly Lazy<byte[,]> Ylorrd = new Lazy<byte[,]>(() => new byte[,]
        {
            {255, 255, 204},
            {255, 245, 181},
            {254, 236, 159},
            {254, 226, 138},
            {254, 216, 117},
            {254, 197,  96},
            {253, 177,  75},
            {253, 158,  67},
            {252, 140,  59},
            {252, 108,  50},
            {251,  76,  41},
            {238,  50,  34},
            {226,  25,  28},
            {207,  12,  33},
            {187,   0,  38},
            {128,   0,  38}
        });

    #endregion

        /// <summary>
        /// Convenient dictionary for mapping palette names onto palette byte arrays
        /// </summary>
        public static readonly Dictionary<string, Lazy<byte[,]>>
            ByName = new Dictionary<string, Lazy<byte[,]>>
        {
            {"accent", Accent},
            {"afmhot", Afmhot},
            {"autumn", Autumn},
            {"binary", Binary},
            {"blues", Blues},
            {"bone", Bone},
            {"brbg", Brbg},
            {"brg", Brg},
            {"bugn", Bugn},
            {"bupu", Bupu},
            {"bwr", Bwr},
            {"cmrmap", Cmrmap},
            {"cool", Cool},
            {"coolwarm", Coolwarm},
            {"copper", Copper},
            {"cubehelix", Cubehelix},
            {"dark2", Dark2},
            {"flag", Flag},
            {"gist_earth", Gist_Earth},
            {"gist_gray", Gist_Gray},
            {"gist_heat", Gist_Heat},
            {"gist_ncar", Gist_Ncar},
            {"gist_rainbow", Gist_Rainbow},
            {"gist_stern", Gist_Stern},
            {"gist_yarg", Gist_Yarg},
            {"gnbu", Gnbu},
            {"gnuplot", Gnuplot},
            {"gnuplot2", Gnuplot2},
            {"gray", Gray},
            {"greens", Greens},
            {"greys", Greys},
            {"hot", Hot},
            {"hsv", Hsv},
            {"inferno", Inferno},
            {"jet", Jet},
            {"magma", Magma},
            {"nipy_spectral", Nipy_Spectral},
            {"ocean", Ocean},
            {"oranges", Oranges},
            {"orrd", Orrd},
            {"paired", Paired},
            {"pastel1", Pastel1},
            {"pastel2", Pastel2},
            {"pink", Pink},
            {"piyg", Piyg},
            {"plasma", Plasma},
            {"prgn", Prgn},
            {"prism", Prism},
            {"pubu", Pubu},
            {"pubugn", Pubugn},
            {"puor", Puor},
            {"purd", Purd},
            {"purples", Purples},
            {"rainbow", Rainbow},
            {"rdbu", Rdbu},
            {"rdgy", Rdgy},
            {"rdpu", Rdpu},
            {"rdylbu", Rdylbu},
            {"rdylgn", Rdylgn},
            {"reds", Reds},
            {"seismic", Seismic},
            {"set1", Set1},
            {"set2", Set2},
            {"set3", Set3},
            {"spectral", Spectral},
            {"spring", Spring},
            {"summer", Summer},
            {"terrain", Terrain},
            {"viridis", Viridis},
            {"winter", Winter},
            {"wistia", Wistia},
            {"ylgn", Ylgn},
            {"ylgnbu", Ylgnbu},
            {"ylorbr", Ylorbr},
            {"ylorrd", Ylorrd}
        };

        /// <summary>
        /// Enumerate all available palettes / colormaps
        /// </summary>
        public static IEnumerable<string> Names => ByName.Keys;
    }
#endif
}
