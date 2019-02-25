#pragma once
#include <iostream>
#include <iomanip>
#include <fstream>
#include <sstream>
#include <cmath>
#include "Types.h"

const i32 I32_MIN = -9;
const i32 I32_MAX = 9;

void fillArray(i32** Array, u32 Size);

string toString(i32** Array, u32 Size);

i32 findMaxSum(i32** Array, u32 Size);

i32 multUnsigned(i32** Array, u32 Size);