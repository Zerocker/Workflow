#ifndef CALCULATORWINDOW_H
#define CALCULATORWINDOW_H

#include <QMainWindow>
#include "c_calculator.h"

namespace Ui {
class CalculatorWindow;
}

class CalculatorWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit CalculatorWindow(QWidget *parent = nullptr);
    ~CalculatorWindow();

private:
    void DisplayOnLCD(const QString &string);
    void LoadToCalculator(char slot);

    void MathUnary(mathID operation);
    void InputBinary(mathID operation);
    void MathBinary();
    void WriteLastOperation();

private slots:
    void on_Button_Equals_clicked();

    void on_Button_0_clicked();

    void on_Button_1_clicked();

    void on_Button_2_clicked();

    void on_Button_3_clicked();

    void on_Button_4_clicked();

    void on_Button_5_clicked();

    void on_Button_6_clicked();

    void on_Button_7_clicked();

    void on_Button_8_clicked();

    void on_Button_9_clicked();

    void on_SignedButton_clicked();

    void on_Button_ClearEntry_clicked();

    void on_Button_AllClear_clicked();

    void on_Button_Plus_clicked();

    void on_Button_Sin_clicked();

    void on_Button_Exp_clicked();

    void on_Button_Sqrt_clicked();

    void on_Button_Cos_clicked();

    void on_Button_Tang_clicked();

    void on_Button_Ln_clicked();

    void on_DotButton_clicked();

    void on_Button_MS_clicked();

    void on_Button_MC_clicked();

    void on_Button_MR_clicked();

    void on_Button_Minus_clicked();

    void on_Button_Mult_clicked();

    void on_Button_Div_clicked();

    void on_Button_Pow_clicked();

private:
    Ui::CalculatorWindow *ui;
    Calculator* Calculator_;
    MemoryUnit* Memory_;
    bool operationJustCompleted;
};

#endif // CALCULATORWINDOW_H
