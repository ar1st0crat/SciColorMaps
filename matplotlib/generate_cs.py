import os
import sys
import re
import argparse


parser = argparse.ArgumentParser(
        description='Script to learn basic argparse')

parser.add_argument('-r', '--resolution',
                    help='colormap resolution \
                    (should be 8, 16, 32, 64, 128 or 256)',
                    default='16')

parser.add_argument('-p', '--portable',
                    help='generate cs file for SciColorMaps.Portable',
                    action='store_true')

parser.add_argument('-a', '--all',
                    help='generate cs file for all colormaps',
                    action='store_true')

parsed = parser.parse_args(sys.argv[1:])


DATADIR = 'colormaps'
FILENAME = 'cs/template'
COLORMAP_LIST = 'colormaps.txt'

PORTABLE = ''
if parsed.portable:
    PORTABLE = '.Portable'

if parsed.resolution not in ['8', '16', '32', '64', '128', '256']:
    print('Resolution should be 8, 16, 32, 64, 128 or 256')
    print('Setting default resolution: 16')
    RESOLUTION = 16
RESOLUTION = int(parsed.resolution)
STEP = 256 // RESOLUTION

if parsed.all:
    colormaps = [file[:-4].lower() for file in os.listdir(DATADIR)]
else:
    # read user-defined list of colormaps from input file
    if not os.path.exists(COLORMAP_LIST):
        print('No colormaps.txt file found! Script aborted')
        exit()
    with open(COLORMAP_LIST, 'rt') as f:
        colormaps = [cmap.rstrip() for cmap in f]

# 'viridis' is the default colormap. It'll be added anyway
if 'viridis' not in colormaps:
    colormaps.append('viridis')

colormaps.sort()

with open(FILENAME, 'rt') as f:
    # read entire template
    code = f.read()

    # substitute general stuff
    code = code.replace(r'{%PORTABLE%}', PORTABLE)
    code = code.replace(r'{%RESOLUTION%}', str(RESOLUTION))

    # first, skip all non-existing colormaps
    cmaps = []
    for colormap in colormaps:
        colormap_file = os.path.join(DATADIR, colormap + '.txt')
        if (not os.path.exists(colormap_file)):
            print('No colormap file: ' + colormap)
            continue
        cmaps.append(colormap)

    colormaps = cmaps

    # substitute colormap pairs: {"gnuplot", Gnuplot}, {"hot", Hot}, ...
    pair_format = '\n            {"%s", %s}'
    pairs = ','.join([pair_format % (c.lower(), c.title()) for c in colormaps])
    code = code.replace(r'{%COLORMAP_PAIRS%}', pairs)

    # substitute byte[][] section for each colormap
    idx1 = code.index(r'{%COLORMAP%}') + len(r'{%COLORMAP%}')
    idx2 = code.index(r'{%COLORMAP%}', idx1)
    templ = code[idx1:idx2]

    cmaps = ''
    for colormap in colormaps:
        colormap_file = os.path.join(DATADIR, colormap + '.txt')
        with open(colormap_file, 'rt') as cmf:
            colors = cmf.read()

        rgbs = re.findall(r'new byte\[\] \{\s*\d+,\s*\d+,\s*\d+\},', colors)
        rgbs = [rgbs[0]] + rgbs[STEP:-STEP:STEP] + [rgbs[-1]]

        x = templ.replace(r'{%COLORMAP_NAME%}', colormap)
        x = x.replace(r'{%COLORMAP_NAME_TITLE%}', colormap.title())
        x = x.replace(r'{%BYTE[][]%}', '\n            '.join(rgbs)[:-1])
        cmaps += x + '\n'

    idx1 -= len(r'{%COLORMAP%}')
    code = code[:idx1] + cmaps + code[idx1:]
    code = code.replace(r'{%COLORMAP%}' + templ + r'{%COLORMAP%}', '')

    # substitute byte[,] section for each colormap
    idx1 = code.index(r'{%COLORMAP%}') + len(r'{%COLORMAP%}')
    idx2 = code.index(r'{%COLORMAP%}', idx1)
    templ = code[idx1:idx2]

    cmaps = ''
    for colormap in colormaps:
        colormap_file = os.path.join(DATADIR, colormap + '.txt')
        with open(colormap_file, 'rt') as cmf:
            colors = cmf.read()
            colors = colors[:colors.index('Jagged')]

        rgbs = re.findall(r'\{\s*\d+,\s*\d+,\s*\d+\},', colors)
        rgbs = [rgbs[0]] + rgbs[STEP:-STEP:STEP] + [rgbs[-1]]

        x = templ.replace(r'{%COLORMAP_NAME%}', colormap)
        x = x.replace(r'{%COLORMAP_NAME_TITLE%}', colormap.title())
        x = x.replace(r'{%BYTE[,]%}', '\n            '.join(rgbs)[:-1])
        cmaps += x + '\n'

    idx1 -= len(r'{%COLORMAP%}')
    code = code[:idx1] + cmaps + code[idx1:]
    code = code.replace(r'{%COLORMAP%}' + templ + r'{%COLORMAP%}', '')

# finally write entire code to cs-file
with open('cs/Palette.cs', 'wt') as f:
    f.write(code)

# log success
print('File Palette.cs is generated succesfully!')
