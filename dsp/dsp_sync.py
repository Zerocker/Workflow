#!/usr/bin/env python3
# coding: utf-8

import numpy as np
import matplotlib.pyplot as plt
from scipy.stats import norm
from collections import deque

# Parameters
noise_ratio = 1.5
frequency = 2
amplitude = 5
sample_rate = 256
N = 10

_min = -2
_max = 2

# Random function
def randf(t, ratio):
    return np.random.normal(0, 1, t.shape) * ratio

# Sine wave
def sinf(t):
    return amplitude * ( np.sin(2*np.pi*frequency*t) )

# ---------------------------------------------------------------------

# Original func
x = np.linspace(_min, _max, sample_rate)
y = sinf(x) + randf(x, noise_ratio)

xn = np.array_split(x, N)
yn = np.array_split(y, N)


# ---------------------------------------------------------------------

# Drawing routine
fig, axs = plt.subplots(3)
fig.subplots_adjust(wspace=0.9, hspace=0.2)
titles = ['Original signal', 'Smoothed signal (MA)', 'Smoothed signal (WMA)']

for i in range(3):
    axs[i].grid(True)
    axs[i].axhline(y=0, color='k')

    axs[i].set_title(titles[i])
    axs[i].set_xlabel('Time')
    axs[i].set_ylabel('Amplitude')
    axs[i].set_ylim([-amplitude*2, amplitude*2])

    if (i == 0):
        axs[i].plot(xn[0], ynn)
    # elif (i == 1):
    #     axs[i].plot(xn[0], ynn)
    # else:
    #     axs[i].plot(x, yx)

plt.tight_layout()
plt.show()