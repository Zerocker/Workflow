#ifndef SHARPCALC_H
#define SHARPCALC_H

#include "c_memoryunit.h"

enum errorID
/*  Код ошибок при вычислении */
{
    OutOfScope,
    ZeroDivision,
    NegativeRoot
};

enum mathID
/*  Коды операций калькулятора */
{
    Add,
    Sub,
    Mult,
    Div,
    Sqrt,
    Exp,
    Pow,
    Sin,
    Cos,
    Tan,
    Ln,
    None
};

class Calculator
{
public:
    Calculator();
    ~Calculator();

    /*  Очищает регистры калькулятора */
    void ClearSlots();

    /*  Устанавливает значение для регистра */
    void SetFirstNum(double &value);
    void SetSecondNum(double &value);

    /*  Возвращает значение регистра */
    double First_Number();
    double Second_Number();

    /*  Сложение */
    void Add();
    /*  Вычитание */
    void Sub();
    /*  Деление */
    void Div();
    /*  Умножение */
    void Mult();

    /*  Корень числа */
    void Sqrt();
    /*  Экспонента */
    void Exp();
    /*  Возведение в степень */
    void Pow();

    /*  Синус числа (в радианах) */
    void Sin();
    /*  Косинус числа (в радианах) */
    void Cos();
    /*  Тангенс числа (в радианах) */
    void Tan();
    /*  Натуральный логарифм числа */
    void Ln();

    double Result() {return Result_; }

    mathID Operation() {return Operation_; }
    void setOperation(mathID operation) { Operation_ = operation; }

protected:
    double  First_;         // Основной регистр
    double  Second_;        // Дополнительный регистр
    double  Result_;        // Регистр результата
    mathID  Operation_;     // Код операции
};

#endif // SHARPCALC_H
