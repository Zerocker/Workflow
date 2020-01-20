# -*- coding: utf-8 -*-

import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation
import random as rnd
from math import sin,cos
from time import time, sleep

N = 1000
minv, maxv = 0.0, 20.0
rnd.seed(int(time()))

class dot(object):
    def __init__(self, min_v, max_v):
        self.x = rnd.uniform(min_v, max_v)
        self.y = rnd.uniform(min_v, max_v)
        self.velx = self.new_vel()
        self.vely = self.new_vel()

    def new_vel(self):
        return (rnd.random() - 0.5)

    def move(self, r, hx, hy):
        if (r > 0.8): 
            self.x += hx
            self.y += hy
        elif (r < 0.8):
            self.x -= hx
            self.y -= hy

        if self.x >= maxv:
            self.x = maxv
            self.velx = -1 * self.velx
        if self.x <= minv:
            self.x = minv
            self.velx = -1 * self.velx
        if self.y >= maxv:
            self.y = maxv
            self.vely = -1 * self.vely
        if self.y <= minv:
            self.y = minv
            self.vely = -1 * self.vely

def animate(i):
    hx = rnd.random() - 0.5
    hy = rnd.random() - 0.5
    r = rnd.uniform(0, 1)
    for i in range(len(dots)):
        dots[i].move(r, hx, hy)
    
    d.set_data([dot.x for dot in dots],
               [dot.y for dot in dots])
    
    return d,

dots = [dot(minv, maxv) for i in range(N)]

fig = plt.figure()
ax = plt.axes(xlim = (minv, maxv), ylim = (minv, maxv))
d, = ax.plot([dot.x for dot in dots],
             [dot.y for dot in dots], 'ro')

anim = animation.FuncAnimation(fig, animate, frames = 200, interval = 20)

plt.show()