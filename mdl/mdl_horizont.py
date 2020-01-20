#!/usr/bin/env python3
# -*- coding: utf-8 -*-

import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation
from math import cos, sin, pi

VEL = 5.0
KI = 0
KII = 0
HEIGHT = 20
ANGLE = 56
MASS = 1
#-------------
HSIZE = HEIGHT * 2
WSIZE = VEL * 3
GV = 9.80666

class dot(object):
    def __init__(self, h, v, angle, m):
        self.x = 0.0
        self.y = h
        self.velx = v * cos(angle * pi / 180)
        self.vely = v * sin(angle * pi / 180)
        self.accx = 0.0
        self.accy = GV
        self.tau = 0.0
        self.mass = m

    def move(self):
        self.x = self.x + self.velx * self.tau + (self.accx * self.tau**2)/2
        self.y = self.y + self.vely * self.tau + (self.accy * self.tau**2)/2
        self.velx = self.velx + self.accx * self.tau
        self.vely = self.vely + self.accy * self.tau
        self.accx = -(KI * self.velx + KII * self.velx**2) / self.mass
        self.accy = -(self.mass * GV - KI * self.vely - KII * self.vely**2) / self.mass

    def str(self):
        return f"xy: ({self.x}, {self.y}), vel: ({self.velx}, {self.vely}), acc: ({self.accx}, {self.accy}), tau: {self.tau}, m: {self.mass}"

def animate(i):
    if (dot.y > 0.0):
        dot.tau += 0.0001
        dot.move()

    d.set_data(dot.x, dot.y)

dot = dot(HEIGHT, VEL, ANGLE, MASS)
fig = plt.figure()
ax = plt.axes(xlim = (0, WSIZE), ylim = (0, HSIZE))
d, = ax.plot(dot.x, dot.y, 'bo')

anim = animation.FuncAnimation(fig, animate, frames = 120, interval = 20)
plt.show()