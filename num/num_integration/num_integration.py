## -*- coding: utf-8 -*-

from math import sin, sqrt
from numpy import arange
from os import system

def trapezoid(f, a, b, n):
    h = (b - a) / n
    w = 0.0

    for k in arange(1.0, n):
        x = a + float(k) * h
        w += f(x)
    w = (2.0 * w + f(a) + f(b)) * h / 2.0
    return w

def simpson(f, a, b, m):
    n = 2.0 * m
    h = (b - a) / n
    s, s1, s2 = 0.0, 0.0, 0.0
    
    for k in arange(1.0, m + 1.0):
        x = a + (2 * k - 1) * h
        s1 += f(x)
    for k in arange(1.0, m):
        x = a + 2 * k * h
        s2 += f(x)
    s = (4 * s1 + 2 * s2 + f(a) + f(b)) * h / 3
    return s

## --------------------------------------------------------- ##

fa = lambda x: 1 / sqrt(2*x*x - 2)
fb = lambda x: sin(x**3) / (x**2 + 1)  

ra = trapezoid(fa, 3.6, 4.4, 2)
rb = simpson(fb, 2.4, 3.2, 8)

system("cls")
print(f"A. f(x) = 1 / sqrt(2x^2 - 2), a = 3.6, b = 4.4, n = 2")
print(f"    Trapezoid method: {ra} \n")
print(f"B. f(x) = sin(x^3) / (x^2 + 1), a = 2.4, b = 3.2, n = 8")
print(f"    Simpson's method: {rb}")
