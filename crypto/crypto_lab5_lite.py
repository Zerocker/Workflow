#!/usr/bin/python3
# coding: utf-8

def bezout(a, b, x = 0, px = 1, y = 1, py = 0):
    if (b > a):
        a, b = b, a

    r = a % b
    if (r == 0):
        return b, x, y
    q = a // b
    
    next = (x, y, q*x + px, q*y + py)
    
    print("px", px)
    print("py", py)
    print("x:", next[0])
    print("y:", next[1])
    print("nx:", next[2])
    print("ny:", next[3])
    print("*" * 10)

    px, py, x, y = next
    return bezout(b, r, x, px, y, py)

a = int(input("a = "))
b = int(input("b = "))

res = bezout(a, b)
print(f'GCD of {a} and {b} is {res[0]}, x = {res[1]} and y = -{res[2]}')