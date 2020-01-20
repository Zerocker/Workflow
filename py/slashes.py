from random import choice
from os import system
from time import sleep

slashes = ["\\", "/"]

system("cls")

for i in range(1024):
    
    print(choice(slashes), end = '')

    if ((i + 1) % 32 == 0): print()
    
    sleep(0.03)
