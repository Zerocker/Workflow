#!/usr/bin/python3
# coding: utf-8

import random
from math import sqrt

def is_prime(n):
    if (n <= 1):
        return False
    if (n <= 3):
        return True
     
    if (n % 2 == 0 or n % 3 == 0):
        return False
    for i in range(5, int(sqrt(n) + 1), 6):
        if (n % i == 0 or n % (i + 2) == 0):
            return False
    return True
 
def next_prime(N):
    if (N <= 1):
        return 2
    prime = N
    while True:
        prime += 1
        if (is_prime(prime)):
            break
    return prime

def gcd(a, b):
    if a < b:
        return gcd(b, a)
    elif a % b == 0:
        return b
    else:
        return gcd(b, a % b)

def power(a, b, c):
    x, y = 1, a
    while b > 0:
        if b % 2 == 0:
            x = (x * y) % c
        y = (y * y) % c
        b = int(b / 2)
    return x % c

def encrypt(msg, g, y, p):
    cipher = []
    for char in msg:
        k = random.randint(2, p)
        a = g**k % p
        b = (y**k * char) % p
        cipher += [(b, a)]
    return cipher

def decrypt(msg, x, p):
    decipher = []
    for b, a in msg:
        t = (b * a**(p-1-x)) % p
        decipher += [t]
    return decipher

def generate_keys(min, max):
    p = random.randint(min, max)
    p = next_prime(p)
    x = random.randint(min, p)

    while True:
        g = random.randint(min, p)
        if (gcd(g, p) == 1):
            break
    y = g**x % p
    return p, g, y, x


text = input("> ").upper()
plain_text = [int(i) for i in bytes(text, "cp1251")]

p, g, y, x = generate_keys(2**8, 2**16)
print("p =", p)
print("g =", g)
print("y =", y)
print("x =", x)
print('-' * 40)

cipher_text = encrypt(plain_text, g, y, p)
decipher_text = decrypt(cipher_text, x, p)

print("txt =", plain_text)
print("enc =", cipher_text)
print("dec =", decipher_text)