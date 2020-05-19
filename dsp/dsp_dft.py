#!/usr/bin/env python3
# coding: utf-8

import numpy as np
import matplotlib.pyplot as plt
import matplotlib.gridspec as gridspec
import argparse
from matplotlib.widgets import Slider, TextBox

parser = argparse.ArgumentParser(description='Signal recovery using DFT')
parser.add_argument('-n', dest='n_points', type=int, default=20,
                    help='Number of discrete points')

args = parser.parse_args()

# Consts
N = args.n_points

def periodically_continued(a, b):
    interval = b - a
    return lambda f: lambda x: f((x - a) % interval + a)

def iexp(n):
    return complex(np.cos(n), np.sin(n))

def dft(xs):
    n, r = len(xs), []
    for i in range(n):
        sum_d = 0.0
        for k in range(n):
            sum_d += xs[k] * iexp(-2 * np.pi * k * i / n)
        r += [sum_d]
    return r

def dft_inv(ys):
    n, r = len(ys), []
    for i in range(n):
        sum_d = 0.0
        for k in range(n):
            sum_d += ys[k] * iexp(2 * np.pi * k * i / n)
        sum_d /= n
        r += [sum_d]
    return r

# ---------------------------------------------------------------------
# Main function
fabs = periodically_continued(0, 2*np.pi)(lambda x: abs(x))

# X-values
x = np.linspace(0, 18, N)
# Y-values
y = fabs(x)

print("-" * 80)
print(f"{'x':>8} | {'y':>8}")
for i, val in enumerate(y):
    print(f"{i:>8} | {val:>8.2f}")
print("-" * 80)

yfreq = dft(y)
ywave = dft_inv(yfreq)

# Spectrum
y_ = []
for i in range(N):
    s = []
    for k in range(N):
        s += [y[k] * iexp(-2 * np.pi * k * i / N)]
    y_ += [s]
    
# ---------------------------------------------------------------------
titles = [f'Recovered signal (N={N})', "Signal Spectrum"]

ax1 = plt.subplot(1, 1, 1)
ax1.grid(True)
ax1.axhline(y=0, color='k')
ax1.set_title(titles[0])
ax1.set_xlabel('Time')
ax1.set_ylabel('Value')
ax1.stem(x, ywave, use_line_collection=True)

plt.subplots_adjust(top=0.92, bottom=0.13, left=0.13, right=0.92, hspace=0.5,
                    wspace=0.5)

fig1, ax4 = plt.subplots(figsize=(8, 5))
fig1.subplots_adjust(top=0.9, bottom=0.3, left=0.1, right=0.9)

def update(val): 
    ax4.clear()
    ax4.grid(True)
    ax4.axhline(y=0, color='k')
    ax4.set_title(titles[1])
    ax4.set_xlabel('Time')
    ax4.set_ylabel('Amplitude')
    ax4.plot(x, y_[int(val)])

update(0)

ax_period = plt.axes([0.25, 0.1, 0.65, 0.03], facecolor='lightgoldenrodyellow')
s_period = Slider(ax_period, 'Change harmonic', 0, len(y_)-1, valinit=0, valstep=1)
s_period.on_changed(update)

plt.show()