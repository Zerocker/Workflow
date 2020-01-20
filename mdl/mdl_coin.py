import math
import matplotlib.pyplot as plt
from random import randint



# Орёл = 0
# Решка = 1

n = 1000
N = []
P = []
No = []
Nr = []
Po = []
Pr = []
O = 0
R = 0
for i in range(1, n+1):
    moneta = randint(0, 1)
    if (moneta == 0):
        O += 1
    else:
        R += 1
    Po.append(O/i)
    Pr.append(R/i)
    N.append(i)



plt.plot(N, Po, label = 'Orel')
plt.plot(N, Pr, label = 'Reshka')
plt.xlabel('N')
plt.ylabel('P')
plt.legend()
plt.show()