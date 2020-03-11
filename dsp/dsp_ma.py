#!/usr/bin/env python3
# coding: utf-8

import numpy as np
import matplotlib.pyplot as plt
from scipy.stats import norm
from collections import deque

# Parameters
noise_ratio = 1.5
window_size = 5
frequency = 2
amplitude = 5
sample_rate = 256

_min = 0
_max = 1

# Random function
def randf(t, ratio):
    return np.random.normal(0, 1, t.shape) * ratio

# Sine wave
def sinf(t):
    return amplitude * ( np.sin(2*np.pi*frequency*t) )

# Gaussian distribution
def gaussian(x, mu, sig):
    return np.exp(-np.power(x - mu, 2.) / (2 * np.power(sig, 2.)))

# Moving average
def moving_avg(data, k):
    # f_sum = np.zeros((len(data),))
    # for i in range(len(data)):
    #     wnd = data[i:(i+k)]
    #     f_sum[i] = np.sum(wnd)
    # return f_sum / k

    cumsum = np.cumsum(np.insert(data, 0, [0]*k))
    avg = cumsum[k:] - cumsum[:-k]
    return (avg) / float(k)

# Weighted moving average
def moving_avg_weight(x, y, k):
    # w = gaussian(x, -1, 1)
    # f_sum = np.zeros((len(y),))
    # for i in range(len(y)):
    #     wnd = y[i:(i+k)]
    #     f_sum[i] = w[i] * np.sum(wnd)
    # return f_sum / k

    w = gaussian(x, 0, 1)
    cumsum = np.cumsum(np.insert(y, 0, [0]*k))
    avg = cumsum[k:] - cumsum[:-k]
    result = []
    
    for i in range(len(avg)):
        result += [ (w[i] * avg[i]) / float(k) ]
    return result

def moving_avg_perf(data, k):
    weight = np.ones(int(k))/float(k)    
    return np.convolve(data, weight, mode='same')

# ---------------------------------------------------------------------

# Original func
x = np.linspace(_min, _max, sample_rate)
y = sinf(x) + randf(x, noise_ratio)

ys = moving_avg(y, window_size)
yx = moving_avg_weight(x, y, window_size)

# ---------------------------------------------------------------------

# Drawing routine
fig, axs = plt.subplots(3, sharex=True, sharey=True)
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
        axs[i].plot(x, y)
    elif (i == 1):
        axs[i].plot(x, ys)
    else:
        axs[i].plot(x, yx)

plt.tight_layout()
plt.show()