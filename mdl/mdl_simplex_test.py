# -*- coding: utf-8 -*-

class Simplex:
    def __init__(self, source):
        self.m = len(source)
        self.n = len(source[0])
        
        self.table = [[0 for j in range(self.m)] for i in range(self.n + self.m - 1)]
        self.basis = []
        
        for i in range(self.m):
            for j in range(len(self.table[0])):
                if (j < self.n):
                    self.table[i][j] = source[i][j]
            
            if ((self.n + i) < len(self.table[0])):
                self.table[i][self.n + i] = 1
                self.basis += [self.n + i]
                
        self.n = len(self.table[0])
    
    def calculate(self, result):
        col, row = 0, 0
        
        while not self.check_end():
            col = self.find_main_col()
            row = self.find_main_row(col)
            self.basis[row] = col
            
            new_table = [[0 for j in range(self.m)] for i in range(self.n)]
            
            for j in range(self.n):
                new_table[row][j] = self.table[row][j] / self.table[row][col]
                
            for i in range(self.m):
                if (i == row):
                    continue
                for j in range(self.n):
                    new_table[i][j] = self.table[i][j] - self.table[i][col] * new_table[row][j]
                
            self.table = new_table[:]
            
        for i in range(len(result)):
            k = self.basis.index(i + 1)
            if (k != -1):
                result[i] = self.table[k][0]
            else:
                result[i] = 0
                
        return self.table
             
    def find_main_row(self, col):
        row = 0
        
        for i in range(0, self.m-1):
            if (self.table[i][col] > 0):
                row = i
                break
        
        for i in range(row+1, self.m-1):
            if ((self.table[i][col] > 0) and ((self.table[i][0] / self.table[i][row]) < (self.table[row][0] / self.table[row][col]))):
                row = i
        
        return row

    def find_main_col(self):
        col = 1
        
        for j in range(2, self.n):
            if (self.table[self.m-1][j] < self.table[self.m-1][col]):
                col = j
        
        return col
    
    def check_end(self):
        flag = True
        
        for j in range(1, self.n):
            if (self.table[self.m-1][j] < 0):
                flag = False
                break
        
        return flag
    
def main():
    src = [[1, -3, 5, -1, 2],
           [1, -1, 1, 1, 1, 4],
           [0, 1, -1, 0, 0]]
    r = [0 for i in range(4)]
    
    sx = Simplex(src)
    print("Table: {0}".format(sx.calculate(r)))
    print("Result: {0}".format(r))
    
if __name__ == '__main__':
    main()
