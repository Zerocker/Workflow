#!/usr/bin/env python3
# coding: utf-8

import numpy as np
import matplotlib.pyplot as plt
import matplotlib.gridspec as gridspec
import argparse
from matplotlib.widgets import Slider, TextBox
from scipy import integrate

parser = argparse.ArgumentParser(description='Signal recovery using a Fourier series')
parser.add_argument('-m', dest='m_harmonics', type=int, default=10,
                    help='Number of calculated harmonics')
parser.add_argument('-n', dest='n_value', type=float, default=2,
                    help='N value for N * pi')

args = parser.parse_args()

# Consts
M = args.m_harmonics
T = args.n_value*np.pi
print("N >", T)

# ---------------------------------------------------------------------
# Just a function
def f_abs(x):
    return np.abs(x)

# For Ak
def calc_c(k, L, func, sincos):
    comb_func = lambda t: func(t) * sincos((k*np.pi*t)/(L))
    result = integrate.quad(comb_func, -L, L)[0]
    return (1/L) * float(result)

# For A0
def calc_0(L, func):
    result = integrate.quad(func, -L, L)[0]
    return 1/(2*L) * float(result)

# Recreate signal with fourier series
def recreate_func(t, a, b, L):
    sum_m = 0.0
    for k in range(1, len(a)):
        sum_m += a[k]*np.cos((k*np.pi*t)/(L)) + b[k]*np.sin((k*np.pi*t)/(L))
    return a[0] + sum_m

# ---------------------------------------------------------------------
# Calculating a-coefs and b-coefs
a = [calc_c(k, T, f_abs, np.cos) for k in np.arange(1, M+1)]
# a = [calc_a(k) for k in np.arange(1, M+1)]
a.insert(0, calc_0(T, f_abs))
b = np.zeros(M+1)

# print("len(a) matches len(b):", len(a) == len(b))
print("a >", *["{0:.2f}".format(i) for i in a])
print("b >", *["{0:.2f}".format(i) for i in b])

# X-values
x = np.arange(-10, 10, 1/500.0)
# Y-values
y = recreate_func(x, a, b, T)

# Harmonics
y_ = []
for k in range(0, len(a)):
    _ = a[0] + a[k]*np.cos(k*x) + b[k]*np.sin(k*x)
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
    ax4.set_ylim(-10, 10)
    ax4.set_xlabel('Time')
    ax4.set_ylabel('Amplitude')
    ax4.plot(x, y_[int(val)])

update(0)

ax_period = plt.axes([0.25, 0.1, 0.65, 0.03], facecolor='lightgoldenrodyellow')
s_period = Slider(ax_period, 'Change harmonic', 0, len(y_)-1, valinit=0, valstep=1)
s_period.on_changed(update)

plt.show()