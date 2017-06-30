using System;
using NUnit.Framework;
using System.Linq;

namespace SciColorMaps.Tests
{
    [TestFixture]
    public class TestColorMap
    {
        private const string DefaultPalette = "jet";
        private const string DefaultPaletteDifferentCase = "Jet";

        [Test]
        public void TestWrongRange()
        {
            Assert.Throws<ArgumentException>(
                () => { var cmap = new ColorMap(DefaultPalette, 1.0, 1.0); });
        }

        [Test]
        public void TestWrongNumberOfColors()
        {
            Assert.Throws<ArgumentException>(
                () => { var cmap = new ColorMap(DefaultPalette, 0.0, 1.0, 0); });
        }

        [Test]
        public void TestNullPaletteName()
        {
            Assert.Throws<ArgumentException>(() => { var cmap = new ColorMap(null); });
        }

        [Test]
        public void TestUknownPaletteName()
        {
            var cmap = new ColorMap("unknown");

            Assert.That(cmap.PaletteName, Is.EqualTo(DefaultPalette));
        }

        [Test]
        public void TestPaletteNameIgnoresCase()
        {
            var cmap = new ColorMap(DefaultPaletteDifferentCase);

            Assert.That(cmap.PaletteName, Is.EqualTo(DefaultPalette));
        }

        [Test]
        public void TestDefaultJetPaletteIsAvailable()
        {
            Assert.That(ColorMap.Palettes.Contains(DefaultPalette));
        }

        [Test]
        public void TestValuesOutOfBoundaries()
        {
            var cmap = new ColorMap(DefaultPalette, 1.0, 2.0);

            Assert.That(cmap[0.9], Is.EqualTo(cmap[1.0]));
            Assert.That(cmap[2.01], Is.EqualTo(cmap[2.0]));
        }

        [Test]
        public void TestBoundaryValues()
        {
            var cmap = new ColorMap(DefaultPalette, 1.0, 4.0, 2);

            Assert.That(cmap[1.0], Is.Not.EqualTo(cmap[4.0]));
        }

        [Test]
        public void TestColorMapWithBigColorResolution()
        {
            var cmap = new ColorMap(DefaultPalette, 1.0, 256.0, 32);

            Assert.That(cmap[1.0], Is.EqualTo(cmap[3.0]));
            Assert.That(cmap[1.0], Is.Not.EqualTo(cmap[9.0]));
        }
    }
}
