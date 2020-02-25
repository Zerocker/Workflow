#!/usr/bin/env python3
# coding: utf-8

import numpy as np
import matplotlib.pyplot as plt

# Sine wave parameters
frequency = 2
amplitude = 5
sample_rate = 32
T = 1 / frequency
Ts = 1 / sample_rate

_min = 0
_max = 1

# Sine function
def sinf(t):
    return amplitude * np.sin(2*np.pi*frequency*t)

# Nyquist–Shannon sampling theorem
def sin_nsst(t, sr, fs):
    ts = np.arange(_min, _max+fs, fs)
    sm = 0
    for k in range(-len(ts), len(ts)):
        sm += sinf(k/sr) * np.sinc(k - sr*t)

    return ts, sm

# Analog sine wave
x = np.linspace(_min, _max, sample_rate)
y = sinf(x)

# Recontructed sine wave
xs, sm =  sin_nsst(x, sample_rate, Ts)
ys = sinf(xs)

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
        axs[i].stem(x, y, markerfmt="", use_line_collection=True)
        axs[i].plot(x, sm, 'o')
    else:
        axs[i].stem(xs, ys, markerfmt="", use_line_collection=True)

plt.tight_layout()
plt.show()