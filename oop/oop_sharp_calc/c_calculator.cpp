#include <cmath>
#include "c_calculator.h"

Calculator::Calculator()
    : First_(0), Second_(0), Result_(0), Operation_(None) {
}

Calculator::~Calculator()
{
}

void Calculator::ClearSlots()
{
    First_ = 0;
    Second_ = 0;
    Result_ = 0;
}

void Calculator::SetFirstNum(double &value)
{
    First_ = value;
}

void Calculator::SetSecondNum(double &value)
{
     Second_ = value;
}

double Calculator::First_Number()
{
    return First_;
}

double Calculator::Second_Number()
{
    return Second_;
}

void Calculator::Add()
{
    Result_ = First_ + Second_;
}

void Calculator::Sub()
{
    Result_ = First_ - Second_;
}

void Calculator::Div()
{
    Second_ != 0.0 ? Result_ = First_ / Second_ : throw ZeroDivision;
}

void Calculator::Mult()
{
     Result_ = First_ * Second_;
}

void Calculator::Sqrt()
{
    First_ >= 0.0 ? Result_ = sqrt(First_) : throw NegativeRoot;
}

void Calculator::Exp()
{
    Result_ = exp(First_);
}

void Calculator::Pow()
{
    Result_ = pow(First_, Second_);
}

void Calculator::Sin()
{
    Result_ = sin(First_);
}

void Calculator::Cos()
{
    Result_ = cos(First_);
}

void Calculator::Tan()
{
    Result_ = tan(First_);
}

void Calculator::Ln()
{
    First_ > 0.0 ? Result_ = log(First_) : throw OutOfScope;
}
