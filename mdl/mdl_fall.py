#!/usr/bin/env python3
# -*- coding: utf-8 -*-

import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation
from math import cos, sin, pi

KI = 20
KII = 0
HEIGHT = 40
MASS = 1
#-------------
SIZE = 50
GV = 9.80666

class dot(object):
    def __init__(self, h, m):
        self.y = h
        self.vely = 0.0
        self.accy = 0.0
        self.tau = 0.0
        self.mass = m

    def move(self):
        self.y = self.y + self.vely * self.tau + (self.accy * self.tau**2)/2
        self.vely = self.vely + self.accy * self.tau
        self.accy = -(self.mass * GV - KI * self.vely - KII * self.vely**2) / self.mass

def animate(i):
    if (dot.y > 0.0):
        dot.tau += 0.0001
        dot.move()

    d.set_data(SIZE / 2, dot.y)

dot = dot(HEIGHT, MASS)
fig = plt.figure()
ax = plt.axes(xlim = (0, SIZE), ylim = (0, SIZE))
d, = ax.plot(SIZE / 2, dot.y, 'bo')

anim = animation.FuncAnimation(fig, animate, frames = 120, interval = 20)
plt.show()