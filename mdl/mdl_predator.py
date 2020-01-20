import math
import numpy as np
from scipy.integrate import solve_ivp
import matplotlib.pyplot as plt

"""
Провести моделирование динамики численности 
популяций в системе «хищник-жертва» (модель (7.34)) 
при значениях параметров r = 5, a = 0,1,  q = 2,  f = 0,6. 
Проанализировать зависимость исхода 
эволюции от соотношения значений параметров N0 и C0. 
"""

r = 5       # Рождаемость
q = 2       # Смертность
a = 0.10    # Эффективность поиска
f = 0.6     # Эффективность перехода пищи в потомство
N0 = 100    # Численность жертвы
C0 = 10     # Численность хищников

st = 0.0        # Начальное время
et = 1000.0     # Конечное время
dt = 10         # Шаг во времени

t_span = [st, et+dt]
t_list = np.arange(st, et+dt, dt)

# Описание системы дифф. уравнений
def sim_pp(t, argc):
    # Входные параметры
    N, C = argc

    # Уравнения
    dn_dt = (r * N) - (a * C * N)
    dc_dt = (f * a * C * N) - (q * C)

    return [dn_dt, dc_dt]

result = solve_ivp(sim_pp, t_span, [N0, C0], t_eval = t_list)
n_list = result.y[0,:]
c_list = result.y[1,:]

plt.plot(t_list, n_list, label = 'Prey')
plt.plot(t_list, c_list, label = 'Predator')
plt.xlabel('Time')
plt.ylabel('Population')
plt.legend()
plt.show()