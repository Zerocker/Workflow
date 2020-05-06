#!/usr/bin/env python3
# coding: utf-8

import argparse
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.gridspec as gridspec
from scipy import integrate
from matplotlib.widgets import Slider, TextBox

parser = argparse.ArgumentParser(description='Signal recovery using a Fourier series')
parser.add_argument('-m', dest='m_harmonics', type=int, default=10,
                    help='Number of calculated harmonics')
parser.add_argument('-n', dest='n_value', type=float, default=1,
                    help='N value for N * pi')

args = parser.parse_args()

# Consts
M = args.m_harmonics
T = args.n_value*np.pi
print("N >", T)

def mod(a, b):
    return np.sqrt(a**2.0 + b**2.0)

def arg(a, b):
    return np.arctan(b / a)

def complex_quad(func, a, b, **kwargs):
    real = lambda x: np.real(func(x))
    imag = lambda x: np.imag(func(x))

    real_i = integrate.romberg(real, a, b, **kwargs)
    imag_i = integrate.romberg(imag, a, b, **kwargs)
    return real_i + 1j*imag_i

# ---------------------------------------------------------------------
# Just a function
def f_abs(x):
    return np.abs(x)

def Ck(k, L, func) -> complex:
    comb = lambda t: func(t) * np.exp((-1j * np.pi*k*t) / L)
    result = complex_quad(comb, -L, L)
    return (1/L) * result 

def recreate_func_complex(t, n, L) -> list:
    sum_c = 0.0
    for k in range(0, n):
        ck = Ck(k, L, f_abs)
        sum_c += ck * np.exp((1j * np.pi*k*t) / L)
    return sum_c

# ---------------------------------------------------------------------
# X-values
x = np.arange(-10, 10, 1/500.0)
# Y-values
y = recreate_func_complex(x, M, T)

y = [i-min(y) for i in y]

# Harmonics and coefs
y_, z, m, a, s = [], [], [], [], []
for k in range(0, M):
    ck =  Ck(k, T, f_abs)
    z +=  [k]
    m +=  [mod(ck.real, ck.imag)]
    a +=  [arg(ck.real, ck.imag)]
    s +=  [mod(ck.real, ck.imag)]
    y_ += [ck * np.exp((1j * np.pi*k*x) / T)]
s = np.multiply(s, s)

# ---------------------------------------------------------------------
titles = [f'Recovered signal (M={M})', "Amp", "Phase", "Power","Arbitrary Harmonic"]
# z = [i for i in range(M+1)]

ax0 = plt.subplot(2, 3, 1)
ax0.grid(True)
ax0.axhline(y=0, color='k')
ax0.set_title(titles[1])
ax0.set_xlabel('k')
ax0.set_xticks(z, minor=True)
ax0.stem(z, m, use_line_collection=True)

ax1 = plt.subplot(2, 3, 2)
ax1.grid(True)
ax1.axhline(y=0, color='k')
ax1.set_title(titles[2])
ax1.set_xlabel('k')
ax1.set_xticks(z, minor=True)
ax1.stem(z, a, use_line_collection=True)

ax2 = plt.subplot(2, 3, 3)
ax2.grid(True)
ax2.axhline(y=0, color='k')
ax2.set_title(titles[3])
ax2.set_xlabel('k')
ax2.set_xticks(z[1:], minor=True)
ax2.stem(z, s, use_line_collection=True)

ax3 = plt.subplot(2, 3, (4, 6))
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
    ax4.set_title(titles[4])
    ax4.set_ylim(-10, 10)
    ax4.set_xlabel('Time')
    ax4.set_ylabel('Amplitude')
    ax4.plot(x, y_[int(val)])

update(0)

ax_period = plt.axes([0.25, 0.1, 0.65, 0.03], facecolor='lightgoldenrodyellow')
s_period = Slider(ax_period, 'Change harmonic', 0, len(y_)-1, valinit=0, valstep=1)
s_period.on_changed(update)

plt.show()