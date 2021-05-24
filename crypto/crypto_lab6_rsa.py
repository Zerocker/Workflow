#!/usr/bin/python3
# coding: utf-8

import random

def gcd(a, b):
    while b != 0:
        a, b = b, a % b
    return a

def egcd(a, b):
    if (a == 0):
        return (b, 0, 1)
    else:
        g, y, x = egcd(b % a, a)
        return (g, x - (b // a) * y, y)

def generate_prime(n):
    while True:
        p = random.randint(2**(n-1), 2**n)
        if is_prime(p):
            return p

def is_prime(num):
    if num == 2:
        return True
    if num < 2 or num % 2 == 0:
        return False
    for n in range(3, int(num**0.5)+2, 2):
        if num % n == 0:
            return False
    return True

def mult_inv(a, n):
    g, x, y = egcd(a, n)
    if (g != 1):
        raise Exception
    else:
        return x % n

def generate_keypair(p, q):
    n = p * q
    phi = (p-1) * (q-1)

    while True:
        e = random.randint(1, phi)
        g = gcd(e, phi)
        if (g == 1):
            break

    d = mult_inv(e, phi)
    return (e, d, n)


text = input("> ").upper()
plain_text = [int(i) for i in bytes(text, "cp1251")]

p = generate_prime(8)
q = generate_prime(8)
e, d, n = generate_keypair(p, q)

print("p =", p)
print("q =", q)
print("e =", e)
print("d =", d)
print("n =", n)
print('-' * 40)

cipher_text = [num**e % n for num in plain_text]
decipher_text = [num**d % n for num in cipher_text]

print("txt =", plain_text)
print("enc =", cipher_text)
print("dec =", decipher_text)