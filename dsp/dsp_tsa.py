#!/usr/bin/env python3
# coding: utf-8

import numpy as np
import matplotlib.pyplot as plt

# Parameters
N = 1000
noise_ratio = 0.5
frequency = 5
amplitude = 1
sample_rate = 500

# Consts
T = 1 / frequency
_min = 0
_max = 1

# Random function
def randf(t, ratio):
    return np.random.normal(0, 1, t.shape) * ratio

# Wave function
def wavef(t):
    return amplitude * ( np.sin(2* np.pi * frequency * t) )

# ---------------------------------------------------------------------

# Time (x-axis)
x = np.arange(_min, _max, 1/sample_rate)

# Number of function's periods
y_ = []
for i in range(N):
    y_ += [wavef(x) + randf(x, noise_ratio)]

# Average sum
y_tsa = []
for i in range(len(y_[0])):
    total = 0
    for row in y_:
        total += row[i]
    y_tsa += [total / N]

# ---------------------------------------------------------------------

# Drawing routine
plots = 3
fig, axs = plt.subplots(plots)
fig.subplots_adjust(wspace=0.9, hspace=0.2)
titles = ['Original signal', 'Sum of signals', f'Smoothed signal (TSA N={N})']

for i in range(plots):
    axs[i].grid(True)
    axs[i].axhline(y=0, color='k')

    axs[i].set_title(titles[i])
    axs[i].set_xlabel('Time')
    axs[i].set_ylabel('Amplitude')
    # axs[i].set_ylim([-amplitude*4, amplitude*4])
    axs[i].set_xlim([0, T])

    if (i == 0):
        axs[i].plot(x, y_[0])
    elif (i == 1):
        for j in range(N):
            axs[i].plot(x, y_[j])
    else:
        axs[i].plot(x, y_tsa)

plt.tight_layout()
plt.show()