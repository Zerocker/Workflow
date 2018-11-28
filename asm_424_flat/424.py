import math

s = 17
t = 12

def sin(x):
    return x - (x**3 // 6) + (x**5 // 120)

def func(a, b, c):
    up = 2*a - b - sin(c)        
    down = 5 + abs(c)
    
    #print(f"sin: {sin(c)}")
    #print(f"up: {up}")
    #print(f"down: {down}")     
    
    return up / down

A = func(t, -2*s, 1)
B = func(2, t, s-t)
R = A + B

print(A)
print(B)
print(R)
    