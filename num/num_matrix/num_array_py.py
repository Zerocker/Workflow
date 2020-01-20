# -*- coding: utf-8 -*-
# >--------------------------

import numpy as np

Input = [[1, 0, 0, -2, 9],
         [0, 1, 0, 1, -3],
         [0, 0, 1, 2, 3],
         [-1, -5, -7, 8, 6],
         [-1, -8, 8, -9, 1]]

Arr = np.matrix(Input)
print(Arr)
print()
np.set_printoptions(precision=2)
Arr = np.linalg.inv(Arr)
print(Arr)

N = int(input())
