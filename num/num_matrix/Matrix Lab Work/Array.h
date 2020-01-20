#ifndef MATRIX_H
#define MATRIX_H

#include <iostream>
#include <vector>

using namespace std;
typedef vector<double> cArray;
typedef vector<vector<double> > cMatrix;

cMatrix sub(const cMatrix &Arr, const cMatrix &Brr);
cMatrix mul(const cMatrix &Arr, const cMatrix &Brr);
cMatrix inv3(cMatrix Arr);
cMatrix inv2(const cMatrix &Arr);

cMatrix split(const cMatrix &Arr, size_t eSize, const unsigned short key);
cMatrix merge(const cMatrix &X, const cMatrix &Y, const cMatrix &U, const cMatrix &V);

cMatrix makeX(const cMatrix &M, const cMatrix &N, const cMatrix &P, const cMatrix &Q);
cMatrix makeV(const cMatrix &M, const cMatrix &N, const cMatrix &P, const cMatrix &Q);
cMatrix makeU(const cMatrix &V, const cMatrix &P, const cMatrix &M);
cMatrix makeY(const cMatrix &X, const cMatrix &N, const cMatrix &Q);

void print(const cArray &Arr);
void print(const cMatrix &Mrr);

#endif // MATRIX_H
