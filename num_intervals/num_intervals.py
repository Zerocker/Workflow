from math import log

F = lambda x: -4 * x**3 + x**2 - 5*x + 4
Fs = lambda x: -12 * x**2 + 2*x - 5
Fss = lambda x: 2 - 24*x

#F = lambda x: 7 * x + 5**x - 2
#Fs = lambda x: 5**x * log(5) + 7 
#Fss = lambda x: 5**x * log(5) * log(5)

Eps = 0.001

A = 0.0
B = 1.0
Final = 0.0
NewA, NewB = 0.0, 0.0
DoMath = True

while (DoMath):
    
    if (F(A) * Fss(A) > 0):
        NewA = A - F(A) / Fs(A);
        NewB = (A * F(B) - B * F(A)) / (F(B) - F(A))
    elif (F(B) * Fss(B) > 0):
        NewB = B - F(B) / Fs(B);
        NewA = (A * F(B) - B * F(A)) / (F(B) - F(A))
    
    A, B = NewA, NewB
    
    if ( abs(B - A) < 2 * Eps):
        Final = (A + B) / 2
        DoMath = False
        
    print(f" [{A:.5f}, {B:.5f}] ")

print(f"Final: {Final:.5f}")
        
    
        
    
