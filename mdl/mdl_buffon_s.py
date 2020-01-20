# -*- coding: utf-8 -*-

import math, sys, time, os
import numpy as np
from numpy import random as rnd

BOUND = 10
BORDER = 0.05 * BOUND
NEEDLES = 10000
NEEDLE_LEN =1
FLOORBRD_W = 2

class Needle:
    def __init__(self, x=None, y=None, alpha=None, length=NEEDLE_LEN) :
        if x is None :
            x = rnd.uniform(0, BOUND)    
        if y is None :
            y = rnd.uniform(0, BOUND)    
        if alpha is None :
            # angle - (pi, 2pi)
            alpha = rnd.uniform(0, math.pi)  
        
        self.center = np.array([x, y])  
        self.comp = np.array([length/2 * math.cos(alpha), length/2 * math.sin(alpha)])
        self.endPoints = np.array([np.add(self.center, -1 * np.array(self.comp)), np.add(self.center, self.comp)])

    def intersects(self, y):
        return self.endPoints[0][1] < y and self.endPoints[1][1] > y

class Simulation :
    def __init__(self) :
        self.floorboards = []
        self.boards = int ((BOUND / FLOORBRD_W) + 1)
        self.needles = []
        self.collisions = 0

    def setBoards(self) :
        for j in range(self.boards) :
            self.floorboards += [0 + j * FLOORBRD_W]
    
    def tossNeedle(self) :
        needle = Needle()
        self.needles += [needle]
        
        for k in range (self.boards) :
            if needle.intersects(self.floorboards[k]):
                self.collisions += 1

    def update(self, needlesTossed = 0) :
        
        if self.collisions == 0 :
            sim_pi = 0
        else:
            sim_pi = (2 * NEEDLE_LEN * needlesTossed) / (FLOORBRD_W * self.collisions)  #from wikipedia page
        
        error = abs(((math.pi - sim_pi) / math.pi) * 100)   #oercent error formula
        
        return (f"Col: {self.collisions:6}, total: {needlesTossed:6}, " +  
                    f"approx: {sim_pi:.16f}, error: {error:.4f}%   ")
    
    def run(self, iteration) : 
        for i in range(NEEDLES) :
            self.tossNeedle()
            result = self.update(i + 1)
            sys.stdout.write(f"[{iteration+1:2}] ")
            print(result, end = '\r')
        print()

def main():
    
    for i in range(10):
        bsim = Simulation()
        bsim.setBoards()
        bsim.run(i)
        
        global NEEDLES
        NEEDLES += 10000

if __name__ == "__main__":
    main()
    input("Press any key to exit...")