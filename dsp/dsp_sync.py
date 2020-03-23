#!/usr/bin/env python3
# coding: utf-8

import numpy as np
import matplotlib.pyplot as plt
from scipy.signal import square
from collections import deque

# Parameters
noise_ratio = 0.3
frequency = 10
amplitude = 1
sample_rate = 500

N = 10

T = 1 / frequency

_min = 0
_max = 20

# Random function
def randf(t, ratio):
    return np.random.normal(0, 1, t.shape) * ratio

# Wave function
def wavef(t):
    return amplitude * ( np.sin(2* np.pi * frequency * t) )

# ---------------------------------------------------------------------

# Original signal
x = np.arange(_min, _max, 1/sample_rate)
y = wavef(x) + randf(x, noise_ratio)

x_pulse = np.arange(_min, max(x), 1/N)
# y_pulse = np.zeros(len(x_pulse))
# for i in range(len(x_pulse)):

# ym = np.array(np.array_split(y, sample_rate))
# y_ = ym.sum(axis=0) / N

print(x_pulse)

# ---------------------------------------------------------------------

# Drawing routine
fig, axs = plt.subplots(2)
fig.subplots_adjust(wspace=0.9, hspace=0.2)
titles = ['Original signal', 'Smoothed signal (MA)', 'Smoothed signal (WMA)']

for i in range(2):
    axs[i].grid(True)
    axs[i].axhline(y=0, color='k')

    axs[i].set_title(titles[i])
    axs[i].set_xlabel('Time')
    axs[i].set_ylabel('Amplitude')
    axs[i].set_ylim([-amplitude*2, amplitude*2])
    axs[i].set_xlim([0, T])

    if (i == 0):
        axs[i].plot(x, y)
    # elif (i == 1):
    #     axs[i].plot(x[:Ns], y_)
    # else:
    #     axs[i].plot(x, yx)

plt.tight_layout()
plt.show()