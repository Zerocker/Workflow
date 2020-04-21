#!/usr/bin/env python3
# coding: utf-8

import numpy as np
import matplotlib.pyplot as plt
import matplotlib.gridspec as gridspec
import argparse
from matplotlib.widgets import Slider, TextBox

parser = argparse.ArgumentParser(description='Time-synchronous averaging program')
parser.add_argument('--n', dest='n', type=int, default=10, help='Number of periods for calculating the TSA')
parser.add_argument('--noise', dest='noise', type=float, default=0.5, help='Noise ratio in the result signal')
parser.add_argument('--freq', dest='freq', type=int, default=5, help='Frequency of sine wave (Hz)')
parser.add_argument('--amp', dest='amp', type=int, default=1, help='Amplitude of sine wave (float)')
parser.add_argument('--rate', dest='rate', type=int, default=500, help='Sample rate (Hz)')

args = parser.parse_args()

# Parameters
N = args.n
noise_ratio = args.noise
frequency = args.freq
amplitude = args.amp
sample_rate = args.rate

# Const
T = 1 / frequency

# Random function
def randf(t, ratio):
    return np.random.normal(0, 1, t.shape) * ratio

# Wave function
def wavef(t):
    return amplitude * ( np.sin(2* np.pi * frequency * t) )

# ---------------------------------------------------------------------

# Time (x-axis)
x = np.linspace(0, T, sample_rate)

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

titles = ['Original signal (one period)', f'Sum of periods ({N})', f'Smoothed period (TSA N={N})']

fig, ax = plt.subplots(figsize=(8, 5))
fig.subplots_adjust(top=0.9, bottom=0.3, left=0.1, right=0.9)

def update(val): 
    ax.clear()
    ax.grid(True)
    ax.axhline(y=0, color='k')
    ax.set_title(titles[0])
    ax.set_xlabel('Time')
    ax.set_ylabel('Amplitude')
    ax.set_xlim([0, T])
    ax.plot(x, y_[int(val)])

update(0)

ax_period = plt.axes([0.25, 0.1, 0.65, 0.03], facecolor='lightgoldenrodyellow')
s_period = Slider(ax_period, 'Change period', 0, len(y_)-1, valinit=0, valstep=1)
s_period.on_changed(update)

# ---------------------------------------------------------------------

fig2, axs = plt.subplots(2, figsize=(8, 5))
fig2.subplots_adjust(wspace=0.9, hspace=0.2)

for i in range(2):
    axs[i].grid(True)
    axs[i].axhline(y=0, color='k')

    axs[i].set_title(titles[i+1])
    axs[i].set_xlabel('Time')
    axs[i].set_ylabel('Amplitude')
    axs[i].set_xlim([0, T])

    if (i == 0):
        for j in range(N):
            axs[i].plot(x, y_[j])
    else:
        axs[i].plot(x, y_tsa)

plt.tight_layout()
plt.show()