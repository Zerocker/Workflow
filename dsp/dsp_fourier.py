#!/usr/bin/env python3
# coding: utf-8

import numpy as np
import matplotlib.pyplot as plt
import matplotlib.gridspec as gridspec
import argparse
from matplotlib.widgets import Slider, TextBox

parser = argparse.ArgumentParser(description='Signal recovery using a Fourier series')
parser.add_argument('-m', dest='m_harmonics', type=int, default=10, required=True,
                    help='Number of calculated harmonics')

args = parser.parse_args()

# Consts
M = args.m_harmonics

# Recreate signal function with FFT
def f(t, a, b):
    sum_m = 0.0
    for k in range(1, len(a)):
        sum_m += a[k]*np.cos(k*t) + b[k]*np.sin(k*t)
    return a[0] * 0.5 + sum_m

# ---------------------------------------------------------------------
# Random a-coefs and b-coefs
a = np.random.uniform(-1.0, 1.0, M+1)
b = np.random.uniform(-1.0, 1.0, M+1)

print("a >", a)
print("b >", b)

# X-values
x = np.arange(-np.pi, np.pi, 1/500.0)
# Y-values
y = f(x, a, b)

# Harmonics
y_ = []
for k in range(0, len(a)):
    _ = a[0]*0.5 + a[k]*np.cos(k*x) + b[k]*np.sin(k*x)
    y_ += [_]
    
# ---------------------------------------------------------------------
titles = [f'Recovered signal (M={M})', "A(k)", "B(k)", "Arbitrary Harmonic"]
z = [i for i in range(M+1)]

ax1 = plt.subplot(2, 2, 1)
ax1.grid(True)
ax1.axhline(y=0, color='k')
ax1.set_title(titles[1])
ax1.set_xlabel('k')
ax1.set_xticks(z, minor=True)
ax1.stem(z, a, use_line_collection=True)

ax2 = plt.subplot(2, 2, 2)
ax2.grid(True)
ax2.axhline(y=0, color='k')
ax2.set_title(titles[2])
ax2.set_xlabel('k')
ax2.set_xticks(z[1:], minor=True)
ax2.stem(z[1:], b[1:], use_line_collection=True)

ax3 = plt.subplot(2, 2, (3, 4))
ax3.grid(True)
ax3.axhline(y=0, color='k')
ax3.set_title(titles[0])
ax3.set_xlabel('Time')
ax3.set_ylabel('Value')
ax3.plot(x, y)

plt.subplots_adjust(top=0.92, bottom=0.13, left=0.13, right=0.92, hspace=0.5,
                    wspace=0.5)

fig1, ax4 = plt.subplots(figsize=(8, 5))
fig1.subplots_adjust(top=0.9, bottom=0.3, left=0.1, right=0.9)

def update(val): 
    ax4.clear()
    ax4.grid(True)
    ax4.axhline(y=0, color='k')
    ax4.set_title(titles[3])
    ax4.set_ylim(-5, 5)
    ax4.set_xlabel('Time')
    ax4.set_ylabel('Amplitude')
    ax4.plot(x, y_[int(val)])

update(0)

ax_period = plt.axes([0.25, 0.1, 0.65, 0.03], facecolor='lightgoldenrodyellow')
s_period = Slider(ax_period, 'Change harmonic', 0, len(y_)-1, valinit=0, valstep=1)
s_period.on_changed(update)

plt.show()