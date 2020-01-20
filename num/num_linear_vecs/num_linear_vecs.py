# -*- coding: utf-8 -*-
import numpy as np

arr = np.array([
    [2, -1, -2, 3, 0],
    [2, 5, 4, -4, -1],
    [3, 5, 3, 0, -4],
    [3, 3, 3, 2, -3],
    [5, 4, 5, -1, 1] 
])

y = [ np.array([1, 0, 0, 0, 0]) ]
for k in range(1, len(arr) + 1): 
    temp = arr.dot(y[k-1])
    y.append(temp)
y = y[::-1]
c = np.array(y.pop(0))
y = np.array(y)
y = np.transpose(y)

print(y)
print(c)
print(np.linalg.solve(y, c))
    
# x^5 - 44x^4 -203x^3 + 211x^2 - 75x + 13 = 0 