# coding: utf

import math
import numpy as np
import matplotlib.pyplot as plt
import scipy.integrate as integrate
import scipy.special as special

T = [i for i in range(100)]
N = []
P = []

def lt(t):
    if (0 <= t < 50 ):
        return 0.02 * t
    elif (50 <= t < 100):
       return 0.5

for t in range(100):
    N += [lt(t)]

for i in range(100):
    P += [N[i]*(-1)+1]

plt.grid(True)
plt.xlim(0, 100)
plt.ylim(0.0, 1.0)
plt.plot(T, N)
plt.plot(T, P)
plt.xlabel('X')
plt.ylabel('Y')
plt.legend()
plt.show()