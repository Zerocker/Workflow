#!/usr/bin/env python3
# coding: utf

import sys
import numpy as np
import matplotlib.pyplot as plt
from matplotlib.patches import Circle

# Возвращает вектор электрического поля E=(Ex,Ey) в зависимости от q и r0
def E(q, r0, x, y):
    den = np.hypot(x-r0[0], y-r0[1])**3
    return q * (x - r0[0]) / den, q * (y - r0[1]) / den

# Сетка из точек x, y
nx, ny = 64, 64
x = np.linspace(-2, 2, nx)
y = np.linspace(-2, 2, ny)
X, Y = np.meshgrid(x, y)

# Кол-во зарядов (не считая центрального)
count = 3
# Основной знак заряда
q = 1
# Плостность выводимого на экран поля 
dens = 4

# Ставим один заряд в центр поля (q - заряд, (x, y) - коор-ты расположения)
charges = [(-q, (0.0, 0.0))]
# Создаём мультиполь с count зарядами одинакового знака, равномерно 
# расположенными на равностороннем треугольнике.
for i in range(count):
    charges += [(q, (np.cos(2*np.pi*i/count), np.sin(2*np.pi*i/count)))]

# Вычисляем поле векторов E=(Ex, Ey)
Ex, Ey = np.zeros((ny, nx)), np.zeros((ny, nx))
for charge in charges:
    ex, ey = E(*charge, x=X, y=Y)
    Ex += ex
    Ey += ey

fig = plt.figure()
ax = fig.add_subplot(111)

# Построим линии тока с помощью соответствующей цветовой карты и стиля стрелки
color = 2 * np.log(np.hypot(Ex, Ey))
ax.streamplot(x, y, Ex, Ey, color=color, linewidth=1, cmap=plt.cm.inferno,
              density=dens, arrowstyle='->', arrowsize=1)

charge_colors = {True: '#aa0000', False: '#0000aa'}
# Добавим заполненные круги для изображения самих зарядов
for q, pos in charges:
    ax.add_artist(Circle(pos, 0.05, color=charge_colors[q>0]))

ax.set_xlabel('$x-axis$')
ax.set_ylabel('$y-axis$')
ax.set_xlim(-2,2)
ax.set_ylim(-2,2)
ax.set_aspect('equal')
plt.show()