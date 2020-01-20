# -*- coding: utf-8 -*-
#!/usr/bin/env python3

import math
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation

A = 1
R = 2
N = 100
T = 50
B = 1.1

def sim_Nt(n, b):
    return (n*R) / (1 + (A*n)**b)

Nt = [N]
for i in range(1, T): 
    Nt += [sim_Nt(Nt[i-1], B)]
    
fig = plt.figure()
plt.xlabel('t')
plt.ylabel('N')
plt.plot(Nt)

plt.show()
