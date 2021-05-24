#!/usr/bin/python3
# coding: utf-8

import random
from math import sqrt

def egcd(a, b):
    if a == 0:
        return (b, 0, 1)
    else:
        g, y, x = egcd(b % a, a)
        return (g, x - (b // a) * y, y)

def modinv(a, m):
    g, x, y = egcd(a, m)
    if g != 1:
        raise Exception('modular inverse does not exist')
    else:
        return x % m

def bitfield(n):
    n = format(n, '08b')
    return [1 if digit is '1' else 0 for digit in n]

def compose(lhs, rhs):
    if (len(lhs) != len(rhs)):
        return 0
    return sum(i[0] * i[1] for i in zip(lhs, rhs))

def knapsack(n):
    s = []
    for i in range(n):
        rang = range((2**i - 1) * 2**n + 1, 2**i * 2**n)
        si = random.choice(rang)
        s += [si]
    return s

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

def decompose(n, vals):
    bits = ''
    for k in vals[::-1]:
        if (k <= n):
            bits = '1' + bits
            n -= k
        else:
            bits = '0' + bits
    return int(bits, 2)

def generate_keypair(size):
    r = random.randint(1, 2**size)
    k = knapsack(size)
    m = sum(k) + r
    n = next_prime(m // r)
    
    p = [(ki*n) % m for ki in k]
    return k, p, m, n

def encrypt(msg, key):
    cipher = []
    for char in msg:
        bits = bitfield(char)
        resb = compose(key, bits)
        cipher += [resb]
    return cipher

def decrypt(msg, key, m, n):
    decipher = []
    for ci in msg:
        sm = (ci * modinv(n, m)) % m
        char = decompose(sm, key)
        decipher += [char]
    return decipher


text = input("> ").upper()
plain_text = [int(i) for i in bytes(text, "cp1251")]

private, public, m, n = generate_keypair(8)

print("p =", private)
print("q =", public)
print("m =", m)
print("n =", n)
print('-' * 40)

cipher_text = encrypt(plain_text, public)
decipher_text = decrypt(cipher_text, private, m, n)

print("txt =", plain_text)
print("enc =", cipher_text)
print("dec =", decipher_text)