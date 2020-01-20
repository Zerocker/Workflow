# -*- coding: utf-8 -*-
#!/usr/bin/env python3

import math
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation

G = 6.67 * 10**(-11)
#M = 5.9726 * 10**24
M = 1.98892 * 10**30
AU = (149.6e6 * 1000)

st = 0.0
dt = 10.0
et = 10.0 + 10**7

Vx = 0.0
Vy = 0.0
Bx = 935431
By = 84634

x = -1*AU
y = -3*AU

tmpX = 0.0
tmpY = 0.0

def dV(x, y, xy):
    return ((-1)*G*M * (xy / (math.sqrt((x**2 + y**2)**3))))

X, Y = [], []

for i in np.arange(st, et, dt):
    Vx += dV(Bx, By, x)
    Vy += dV(Bx, By, y)

    tmpX += Vx
    tmpY += Vy

    X += [tmpX]
    Y += [tmpY]

print(X[-1])
print(Y[-1])

grid = plt.grid(True)
#plt.xscale('log')
#plt.yscale('log')
plt.xlabel('t')
plt.ylabel('values')
plt.plot(X, '-b', label='X')
plt.plot(Y, '-r', label='Y')
plt.legend(loc='upper left')
plt.show()

# -------------------------------------------------------------

"""
def animate(i):
    #b.set_data(X[i], Y[i])
    return

fig = plt.figure()
ax = plt.axes(xlim = (-100, 100), ylim = (-100, 100))
s, = ax.plot(0, 0, 'yo', markersize = 10)
b, = ax.plot(X[0], Y[0], 'bo')

anim = animation.FuncAnimation(fig, animate, frames = len(X), interval = 20)

plt.show()
"""