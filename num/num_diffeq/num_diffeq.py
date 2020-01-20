## -*- coding: utf-8 -*-
import numpy as np
from os import system
from math import sin, cos

X0 = 0.0
Y0 = 1.0
H = 0.1
EPS = 3
N = 10

f = lambda x, y: (5.0*x*x + 2.0) * sin(y)

X = [round( X0 + (H*i), 1 ) for i in range(N+1)]

## ------------------------------------------------------------- ##

# Метод Эйлера
def euler(func, x):
    Y = [Y0]
    
    for i in range(len(x) - 1):
        Y += [Y[i] + H * func(x[i], Y[i])]

    return [round(item, EPS) for item in Y]

# Модифиц. метод Эйлера
def euler_mod(func, x):
    Y = [Y0]
    
    for i in range(len(x) - 1):
        Y += [Y[i] + H * func(x[i] + H/2, \
              Y[i] + H/2 * func(x[i], Y[i]))]

    return [round(item, EPS) for item in Y]

# Метод Рунге-Кутта
def runge_kutta(func, x):
    Y = [Y0]
    
    for i in range(3):
        z1 = H * func(x[i], Y[i])
        z2 = H * func(x[i] + H/2, Y[i] + z1/2)
        z3 = H * func(x[i] + H/2, Y[i] + z2/2)
        z4 = H * func(x[i] + H, Y[i] + z3)
        
        Y += [Y[i] + (z1 + 2*z2 + 2*z3 + z4) / 6]

    return [round(item, EPS) for item in Y]

# Метод Адамса
def adams(func, x):
    Y = runge_kutta(func, x)
    
    for i in range(3, N):
        t = 55 * func(x[i], Y[i]) - 59 * func(x[i-1], Y[i-1]) + \
            37 * func(x[i-2], Y[i-2]) - 9 * func(x[i-3], Y[i-3])

        Y += [Y[i] + H / 24 * t]
    
    return [round(item, EPS) for item in Y]

## ------------------------------------------------------------- ##
Y1 = euler(f, X)
Y2 = euler_mod(f, X)
Y3 = adams(f, X)

index = [i for i in range(N+1)]
data = [index, X, Y1, Y2, Y3]

system("cls")
for row in data:
    for val in row:
        print(f'{val:12}', end = "")
    print()