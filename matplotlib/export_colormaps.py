import os
import matplotlib.pyplot as plt


DATADIR = 'colormaps'
os.mkdir(DATADIR)

RGBS_PER_LINE = 4

# get all colormaps available in matplotlib
# (except those that end with '_r')
maps = [m for m in plt.colormaps() if not m.endswith('_r')]

# save colormaps (each to separate .txt file)
for name in maps:
    # e.g. "colormaps/terrain.txt"
    filename = os.path.join(DATADIR, name + '.txt')

    with open(filename, 'wt') as f:
        # get all colors in colormap
        cmap = plt.get_cmap(name)

        f.write('Rectangular array version:\n')
        for i in range(256):
            # format RGB as {r, g, b}, {r, g, b}, etc.
            # so it could easily be copied to C# code
            r = int(cmap(i)[0] * 255)
            g = int(cmap(i)[1] * 255)
            b = int(cmap(i)[2] * 255)
            rgb = '{%3d, %3d, %3d}, ' % (r, g, b)
            # four RGB tuples per line
            if (i + 1) % RGBS_PER_LINE == 0:
                rgb += '\n'
            # append to file
            f.write(rgb)

        f.write('\nJagged array version:\n')
        for i in range(256):
            # format RGB as 'new byte[] {r, g, b}'
            # so it could easily be copied to C# code
            r = int(cmap(i)[0] * 255)
            g = int(cmap(i)[1] * 255)
            b = int(cmap(i)[2] * 255)
            rgb = 'new byte[] {%3d, %3d, %3d}, ' % (r, g, b)
            # four RGB tuples per line
            if (i + 1) % RGBS_PER_LINE == 0:
                rgb += '\n'
            # append to file
            f.write(rgb)

        # log
        print('Exported to file: ' + name)
