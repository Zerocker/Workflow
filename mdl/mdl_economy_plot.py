# coding: utf

import math
import numpy as np
import matplotlib.pyplot as plt

x_max = 5000
y_max = 5000

labor_1 = 0.1
labor_2 = 0.2
labor_total = 400

consum_1 = 0.05
consum_2 = 0.02
consum_total = 100

limit = 3000
min_amount = 2000

supply_1 = 5000
supply_2 = 2500

tX = [labor_total / labor_1, 0]
tY = [0, labor_total / labor_2]
cX = [consum_total / consum_1, 0]
cY = [0, consum_total / consum_2]
limX = [limit, 0]
limY = [0, limit]
minX = [min_amount, 0]
minY = [0, min_amount]

A = np.array([[labor_1, labor_2], [consum_1, consum_2]])
B = np.array([labor_total, consum_total])

A = np.linalg.inv(A)
R = A.dot(B)
print("Макс. результат =", R)

plt.grid(True)
plt.xlim(0, x_max)
plt.ylim(0, y_max)
plt.plot(tX, tY, label = 'Labor')
plt.plot(cX, cY, label = 'Consumption')
plt.axvline(x=supply_1 / 5, color='y')
plt.axhline(y=supply_2 / 5, color='y')
plt.plot(limX, limY, label = 'Limit')
plt.plot(minX, minY, label = 'Amount')
plt.xlabel('X')
plt.ylabel('Y')
plt.legend()
plt.show()