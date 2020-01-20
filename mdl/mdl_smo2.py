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
    return 0.004 * (100-t)

T = [i for i in range(100)]
P0, P1, PX = [], [], []

for t in range(100):
    p0 = ut(t) * 0.2 / (lt(t) + ut(t))
    px = ut(t) * 0.8 / (lt(t) + ut(t))
    p1 = lt(t) * 0.25 / (lt(t) + ut(t))

    P0 += [p0]
    P1 += [p1]
    PX += [px]

plt.grid(True)
plt.xlim(0, 100)
plt.ylim(0.0, 1.0)
plt.plot(T, P0)
plt.plot(T, P1)
plt.plot(T, PX)
plt.xlabel('X')
plt.ylabel('Y')
plt.legend()
plt.show()