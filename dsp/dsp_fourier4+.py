#!/usr/bin/env python3
# coding: utf-8

import argparse
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.gridspec as gridspec
from math import atan2
from matplotlib.widgets import Slider, TextBox

parser = argparse.ArgumentParser(description='Signal recovery using a Fourier series')
parser.add_argument('-d', dest='d_values', type=int, default=100,
                    help='Number of discrete points')
parser.add_argument('-m', dest='m_harmonics', type=int, default=20,
                    help='Number of calculated harmonics')

args = parser.parse_args()

# Consts
M = args.m_harmonics
D = args.d_values

# ---------------------------------------------------------------------
def periodically_continued(a, b):
    interval = b - a
    return lambda f: lambda x: f((x - a) % interval + a)

def p_mid(p, L, m):
    return (p - 0.5) * (L / m)

def calc_a0(L, m):
    sum_0 = 0.0
    for p in range(0, m):
        X = p_mid(p, L, m)
        fpX = fabs(X)
        sum_0 += fpX
    return (1/m) * sum_0

def calc_ak(k, L, m, sncs):
    sum_k = 0.0
    for p in range(0, m):
        X = p_mid(p, L, m)
        fpX = fabs(X)
        sncsX = sncs(k*X)
        sum_k += (fpX * sncsX)
    return (2/m) * sum_k

def recreate_func_float(t, n, L, m):
    harmonics = []
    w = (2.0*np.pi / L)
    
    a0 = calc_a0(L, m)
    sum_c = 0.0
    for k in range(1, n+1):
        ak1 = calc_ak(k, L, m, np.sin)
        ak2 = calc_ak(k, L, m, np.cos)
        ak = np.sqrt((ak1)**2 + (ak2)**2)
        phi = atan2(ak2, ak1)
        
        ft = ak * np.sin(k*w*t + phi)
        harmonics += [ft]
        sum_c += ft
        
    result = a0 + sum_c
    return result, harmonics

# ---------------------------------------------------------------------
# Freq and Period
T = 1 * np.pi

# Main function
fabs = periodically_continued(-T, T)(lambda x: abs(x))

# X-values
x = np.linspace(-12, 12, 10000)
yt = fabs(x)

# Y-values and Harmonics
y, y_ = recreate_func_float(x, M, T+T, D)

print(f"{'x':>9} | {'y':>9}")
for p in range(0, D):
    X = p_mid(p, T+T, D)
    fpX = fabs(X)

    a = f"{X:.4f}"
    b = f"{fpX:0.4f}"

    print(f"{a:>9} | {b:>9}")

# ---------------------------------------------------------------------
titles = [f'Reference signal (Points=10000)', f'Recovered signal (M={M}, Dpoints={D})', "Arbitrary Harmonic"]

ax1 = plt.subplot(2, 1, 1)
ax1.grid(True)
ax1.axhline(y=0, color='k')
ax1.set_title(titles[0])
ax1.set_xlabel('Time')
ax1.set_ylabel('Value')
ax1.plot(x, yt)

ax1 = plt.subplot(2, 1, 2)
ax1.grid(True)
ax1.axhline(y=0, color='k')
ax1.set_title(titles[1])
ax1.set_xlabel('Time')
ax1.set_ylabel('Value')
ax1.plot(x, y)

plt.subplots_adjust(top=0.92, bottom=0.13, left=0.13, right=0.92, hspace=0.5,
                    wspace=0.5)

fig1, ax4 = plt.subplots(figsize=(8, 5))
fig1.subplots_adjust(top=0.9, bottom=0.3, left=0.1, right=0.9)

def update(val): 
    ax4.clear()
    ax4.grid(True)
    ax4.axhline(y=0, color='k')
    ax4.set_title(titles[2])
    ax4.set_xlabel('Time')
    ax4.set_ylabel('Amplitude')
    ax4.plot(x, y_[int(val)])

update(0)

ax_period = plt.axes([0.25, 0.1, 0.65, 0.03], facecolor='lightgoldenrodyellow')
s_period = Slider(ax_period, 'Change harmonic', 0, len(y_)-1, valinit=0, valstep=1)
s_period.on_changed(update)

plt.show()