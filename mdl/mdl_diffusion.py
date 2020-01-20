# -*- coding: utf-8 -*-

import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation
import random as rnd
from math import sin,cos
from time import time, sleep

# --------------------------------------------------------------

# Крайние значения
minv, maxv = 0.0, 20.0
# Генератор СЧ
rnd.seed(int(time()))
# Кол-во точек
N = 50

# Точка и её движение
class dot(object):
    def __init__(self, x1, x2):
        self.x = rnd.uniform(x1, x2)
        self.y = rnd.uniform(minv, maxv)
        self.velx = self.new_vel()
        self.vely = self.new_vel()

    def new_vel(self):
        return (rnd.random() - 0.5)

    def move(self):
        rad = rnd.uniform(0, 1)
        step_x = self.new_vel()
        step_y = self.new_vel()

        if (rad > 0.8):
            self.x += step_x
            self.y += step_y
        elif (rad < 0.8):
            self.x -= step_x
            self.y -= step_y

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

# Анимация движения точек
def animate(i):
    for i in range(N):
        blu_dots[i].move()
        red_dots[i].move()
    
    b.set_data([dot.x for dot in blu_dots],
               [dot.y for dot in blu_dots])
    r.set_data([dot.x for dot in red_dots],
               [dot.y for dot in red_dots])           

# Синие точки
blu_dots = [dot(minv, maxv / 2) for i in range(N)]
# Красные точки
red_dots = [dot(maxv / 2, maxv) for i in range(N)]

fig = plt.figure()
ax = plt.axes(xlim = (minv, maxv), ylim = (minv, maxv))
b, = ax.plot([dot.x for dot in blu_dots],
             [dot.y for dot in blu_dots], 'bo')
r, = ax.plot([dot.x for dot in red_dots],
             [dot.y for dot in red_dots], 'ro')             

anim = animation.FuncAnimation(fig, animate, frames = 200, interval = 20)

plt.show()