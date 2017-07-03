using System;
using System.Linq;
using NUnit.Framework;

namespace SciColorMaps.Tests
{
    [TestFixture]
    public class TestColorMap
    {
        private const string DefaultPalette = "viridis";
        private const string DefaultPaletteDifferentCase = "Viridis";

        private byte[][] colors;
        private float[] positions;

        [OneTimeSetUp]
        public void PrepareUserColors()
        {
            colors = new byte[][]
            {
                new byte[] { 0, 0, 0 },
                new byte[] { 255, 0, 0 },
                new byte[] { 128, 255, 192 }
            };

            positions = new float[] { 0, 0.35f, 1 };
        }

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
        public void TestUknownPaletteName()
        {
            var cmap = new ColorMap("unknown");

            Assert.That(cmap.PaletteName, Is.EqualTo(DefaultPalette));
        }

        [Test]
        public void TestNullPaletteName()
        {
            Assert.Throws<ArgumentException>(() => { var cmap = new ColorMap(null, 10, 100); });
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

        [Test]
        public void TestAllColorsAreRetrievedByNumberWithoutExceptions()
        {
            var cmap = new ColorMap(DefaultPalette, -30, 30, 78);

            for (var i = 0; i < 78; i++)
            {
                Assert.DoesNotThrow(() => { var color = cmap.GetColorByNumber(i); });
            }
        }

        [Test]
        public void TestUserDefinedColorPositionsNotNull()
        {
            Assert.Throws<ArgumentException>(() => {
                var cmap = ColorMap.CreateFromColors(colors, null, -30, 30, 78);
            });
        }

        [Test]
        public void TestUserDefinedColorsInconsistentWithPositions()
        {
            Assert.Throws<ArgumentException>(() => {
                var cmap = ColorMap.CreateFromColors(colors, new float[] { 0, 1 }, -30, 30, 78);
            });
        }

        [Test]
        public void TestAtLeastTwoUserDefinedColors()
        {
            Assert.Throws<ArgumentException>(() => {
                var cmap = ColorMap.CreateFromColors(
                    new byte[][] { new byte[] { 0, 0, 0 } }, new float[] { 0 }, -30, 30, 78);
            });
        }

        [Test]
        public void TestAllColorsAreRetrievedWithoutExceptionsInUserDefinedColormaps()
        {
            var cmap = ColorMap.CreateFromColors(colors, positions, -30, 30, 78);

            for (var i = 0; i < 78; i++)
            {
                Assert.DoesNotThrow(() => { var color = cmap.GetColorByNumber(i); });
            }
        }

        [Test]
        public void TestIncorrectRGBFormatOfUserDefinedColors()
        {
            Assert.Throws<IndexOutOfRangeException>(() => {
                var cmap = ColorMap.CreateFromColors(
                    new byte[][] {
                        new byte[] { 0, 0, 0 },
                        new byte[] { 0, 0 }         // error here
                    }, 
                    new float[] { 0, 1 },
                    -30, 30, 78);
            });
        }

        [Test]
        public void TestWrongColorPositions()
        {
            Assert.Throws<ArgumentException>(() => {
                var cmap = ColorMap.CreateFromColors(colors, new float[] { 0, 0.5f, 1.2f }, -30, 30, 78);
            });
        }
    }
}
