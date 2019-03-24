## -*- coding: utf-8 -*-
Point = 4
Phi = (5 ** 0.5 - 1) / 2
Eps = 0.001

############################################

def findPair(func):
    dX = 0.1
    XC = 0.5
    XL = XC - dX
    XR = XC + dX
    
    while not (func(XL) > func(XC) and func(XR) > func(XC)):
        
        if (func(XL) > func(XC) and func(XC) > func(XR)):
            XN = XR + 2 * dX
            XL = XC
            XC = XR
            XR = XN
            dX = 2 * dX
        elif (func(XL) < func(XC) and func(XC) < func(XR)):
            XN = XL - 2 * dX
            XR = XC
            XC = XL
            XL = XN
            dX = 2 * dX
    
    return [round(XL, Point), round(XR, Point)]

def goldRatio(pair, func):
    A = pair[0]
    B = pair[1]
    
    while not (B - A < 2 * Eps):
        P = A * Phi + B * (1 - Phi)
        Q = A * (1 - Phi) + B * Phi
        
        if (func(P) < func(Q)):
            B = Q
        elif (func(P) > func(Q)):
            A = P
    
    return round((A + B) / 2, Point)

def dichotomy(pair, func):
    A = pair[0]
    B = pair[1]
    
    while not (B - A < 2 * Eps):
        P = A * 0.75 + B * 0.25
        R = A * 0.25 + B * 0.75
        Q = (A + B) / 2 
        
        if (func(P) < func(Q) < func(R)):
            B = Q
        elif (func(P) > func(Q) > func(R)):
            A = Q
        else:
            A = P
            B = R
    
    return round((A + B) / 2, Point)    

############################################

#F = lambda x: (4*x*x + 17) / (x*x + 5)
F = lambda x: (2*x*x - 2*x + 3)**0.5
Pair = findPair(F)
x1 = goldRatio(Pair, F)
x2 = dichotomy(Pair, F)

print(f"f(x) = (4*x^2 + 17) / (x^2 + 5)")
print(f"Interval: {Pair}")
print(f"Golden Ratio: {x1}")
print(f"Dichotomy: {x2}")