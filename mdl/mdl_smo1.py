# coding: utf

import math
import numpy as np
import matplotlib.pyplot as plt
import scipy.integrate as integrate
import scipy.special as special

def lt(t):
    if (0 <= t < 50 ):
        return 0.02 * t
    elif (50 <= t < 100):
        return 0.5

def ut(t):
    return (t - 100.0)**2.0 / 10000.0

T = [i for i in range(100)]
P0, P1 = [], []

for t in range(100):
    p0 = ut(t) / (lt(t) + ut(t))
    p1 = lt(t) / (lt(t) + ut(t))

    P0 += [p0]
    P1 += [p1]

plt.grid(True)
plt.xlim(0, 100)
plt.ylim(0.0, 1.0)
plt.plot(T, P0)
plt.plot(T, P1)
plt.xlabel('X')
plt.ylabel('Y')
plt.legend()
plt.show()