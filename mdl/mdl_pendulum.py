# -*- coding: utf-8 -*-
#!/usr/bin/env python3

"""
    Ограничиваясь тремя членами ряда Фурье, исследовать зависимость 
    амплитуд гармоник а1, а2 и а3 от длины нити подвеса при амплитуде колебаний равной pi/2. 
"""

import math
import numpy as np
from scipy.integrate import solve_ivp
import matplotlib.pyplot as plt
import matplotlib.animation as animation

st = 0.0                 # Start time
et = 30.0                # End time
ts = 0.01                # Time step
g = 9.81                 # Gravity
L = 1                    # Length
b = 0.5                  # ?
m = 1                    # Mass
theta1_ini = np.pi/2     # Amplitude
theta2_ini = 1           # Angular vecolity

def sim_pen_q(t, theta):
    dtheta2_dt = (-b/m)*theta[1] + (-g/L)*np.sin(theta[0])
    dtheta1_dt = theta[1]
    return [dtheta1_dt, dtheta2_dt]

theta_ini = [theta1_ini, theta2_ini]

t_span = [st, et+ts]
t = np.arange(st, et+ts, ts)

sim_points = len(t)
l = np.arange(0, sim_points, 1)

theta_both = solve_ivp(sim_pen_q, t_span, theta_ini, t_eval = t)
theta1 = theta_both.y[0,:]
theta2 = theta_both.y[1,:]

plt.plot(t, theta1, label = 'AD')
plt.plot(t, theta2, label = 'AV')
plt.xlabel('Time(s)')
plt.ylabel('AD & AV')
plt.legend()
plt.show()

x = L*np.sin(theta1)
y = -L*np.cos(theta1)

fig =  plt.figure()
plt.xlim(-L-0.5, L+0.5)
plt.ylim(-L-0.5, L+0.5)

v, = plt.plot( [0, x[0]], [0, y[0]] )
b, = plt.plot(x[0], y[0], 'bo', markersize = 20)

def animate(i):
    b.set_data(x[i],y[i])
    v.set_data([0, x[i]], [0, y[i]])
    
plt.xlabel('x')
plt.ylabel('y')

anim = animation.FuncAnimation(fig, animate, frames = 1024, interval = 10)

plt.show()