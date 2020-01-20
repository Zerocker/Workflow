from random import uniform
import matplotlib.pyplot as plt
from numpy import array
from math import sin

def integrate(func, a, b, n, N = 100):
    sum = 0
    
    i_vals, k_vals = [], []
    
    for i in range(1, n+1):
        x = uniform(a, b)
        sum += func(x)
        
        if i % N == 0:
            z = (float(b-a)/i)*sum
            i_vals += [z]
            k_vals += [i]
    return k_vals, i_vals

a, b = 0.8, 1.6
target = lambda x: sin(x) / (1 + sin(x))

k, I = integrate(target, a, b, 10**6, N=10**4)
error = 0.379711 -  array(I)

plt.xlabel('N')
plt.ylabel('Error')
plt.plot(k, error)
plt.show()