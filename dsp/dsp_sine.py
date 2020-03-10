#!/usr/bin/env python3
# coding: utf-8

import numpy as np
import matplotlib.pyplot as plt

# Sine wave parameters
frequency = 2
amplitude = 5
sample_rate = 16
T = 1 / frequency
Ts = 1 / sample_rate

super_sr = 10000
t_ssr = 1 / super_sr

_min = 0
_max = 1

# Sine function
def sinf(t):
    return amplitude * np.sin(2*np.pi*frequency*t)

# Analog sine wave
x = np.linspace(_min, _max, super_sr)
y = sinf(x)

# Sampling points
xp = np.linspace(_min, _max, sample_rate)
yp = sinf(xp)

# Nyquist–Shannon sampling theorem
xs = np.linspace(_min, _max, super_sr)
ys = []

for i in xs:
    sm = 0.0
    for k in range(len(xp)):
        sm += yp[k] * np.sinc((i-xp[k])*sample_rate)
    ys += [sm]

# ---------------------------------------------------------------------

# Drawing routine
fig, axs = plt.subplots(2, sharex=True, sharey=True)
fig.subplots_adjust(wspace=0.9, hspace=0.2)
titles = ['Sine wave (Original)', 'Sine wave (NSST)']

for i in range(2):
    axs[i].grid(True)
    axs[i].axhline(y=0, color='k')

    axs[i].set_title(titles[i])
    axs[i].set_xlabel('Time')
    axs[i].set_ylabel('Amplitude')

    if (i == 0):
        axs[i].plot(x, y)
        axs[i].stem(xp, yp, use_line_collection=True)
    else:
        axs[i].plot(xs, ys)
        # axs[i].stem(xp, yp, use_line_collection=True)

plt.tight_layout()
plt.show()