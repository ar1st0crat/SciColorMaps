using System;
using NUnit.Framework;

namespace SciColorMaps.Tests
{
    [TestFixture]
    public class TestColorMap
    {
        private const string DefaultPalette = "viridis";
        private const string DefaultPaletteDifferentCase = "Viridis";

        [Test]
        public void TestWrongRange()
        {
            Assert.Throws<ArgumentException>(
                () => { var cmap = new ColorMap(DefaultPalette, 1.0, 1.0, 256); });
        }

        [Test]
        public void TestWrongNumberOfBins()
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
    }
}
