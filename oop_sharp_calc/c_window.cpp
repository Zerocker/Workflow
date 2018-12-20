#include "c_window.h"
#include "ui_c_window.h"

#define MAX_DIGITS 15

CalculatorWindow::CalculatorWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::CalculatorWindow)
{
    ui->setupUi(this);
    ui->newLCD->setStyleSheet("QLabel {"
                              "background-color: white;"
                              "border-style: solid;"
                              "border-width: 1px;"
                              "border-color: black; "
                              "}");
    Memory_     = new MemoryUnit();
    Calculator_ = new Calculator();
    operationJustCompleted = false;
}

CalculatorWindow::~CalculatorWindow()
{
    delete ui;
    delete Calculator_;
    delete Memory_;
}

// ---------------------------------------------------
// ---[ FUNCTIONS ]-----------------------------------
// ---------------------------------------------------

void CalculatorWindow::DisplayOnLCD(const QString &string)
{
    if (operationJustCompleted)
    {
        operationJustCompleted = false;
        ui->newLCD->setText("");
        //ui->testLCD->setText("");
    }

    QString Current = ui->newLCD->text();

    if ((Current == "0") || (Current == "Error"))
        ui->newLCD->setText("0");

    if (Current.size() <= 12)
    {
        if ((Current != "0"))
        {
            ui->newLCD->setText(Current + string);
        }
        else
        {
            ui->newLCD->setText(string);
        }
    }
}

void CalculatorWindow::LoadToCalculator(char slot)
{
    double Number = ui->newLCD->text().toDouble();

    switch (slot) {
        case 0:
            Calculator_->SetFirstNum(Number);
        break;
        case 1:
            Calculator_->SetSecondNum(Number);
        break;
    }
}

// ---------------------------------------------------
// ---[ CE, AC, DOT, SIGN ]---------------------------
// ---------------------------------------------------

void CalculatorWindow::on_Button_ClearEntry_clicked()
{
    Calculator_->ClearSlots();
    operationJustCompleted = false;
    ui->newLCD->setText("0");
}

void CalculatorWindow::on_Button_AllClear_clicked()
{
    on_Button_MC_clicked();
    Calculator_->ClearSlots();
    operationJustCompleted = false;
    ui->testLCD->setText("");
    ui->newLCD->setText("0");
}
void CalculatorWindow::on_SignedButton_clicked()
{
    QString Current = ui->newLCD->text();

    if (Current.contains("-"))
        ui->newLCD->setText(Current.remove(0, 1));
    else
        ui->newLCD->setText("-" + Current);
}

void CalculatorWindow::on_DotButton_clicked()
{
    QString Current = ui->newLCD->text();

    if (!Current.contains("."))
        ui->newLCD->setText(Current + ".");
}

// ---------------------------------------------------
// ---[ 0, 1, 2, 4, 5, 6, 7, 8, 9 ]-------------------
// ---------------------------------------------------

void CalculatorWindow::on_Button_0_clicked()
{
    DisplayOnLCD("0");
}

void CalculatorWindow::on_Button_1_clicked()
{
    DisplayOnLCD("1");
}

void CalculatorWindow::on_Button_2_clicked()
{
    DisplayOnLCD("2");
}

void CalculatorWindow::on_Button_3_clicked()
{
    DisplayOnLCD("3");
}

void CalculatorWindow::on_Button_4_clicked()
{
    DisplayOnLCD("4");
}

void CalculatorWindow::on_Button_5_clicked()
{
    DisplayOnLCD("5");
}

void CalculatorWindow::on_Button_6_clicked()
{
    DisplayOnLCD("6");
}

void CalculatorWindow::on_Button_7_clicked()
{
    DisplayOnLCD("7");
}

void CalculatorWindow::on_Button_8_clicked()
{
    DisplayOnLCD("8");
}

void CalculatorWindow::on_Button_9_clicked()
{
    DisplayOnLCD("9");
}

// ---------------------------------------------------
// ---[ UNARY:  Sqrt, Ln, Exp, Sin, Cos, Tan ]--------
// ---------------------------------------------------

void CalculatorWindow::MathUnary(mathID operation)
{
    LoadToCalculator(0);
    Calculator_->setOperation(operation);
    try
    {
        switch (operation)
        {
            case Sqrt:
                Calculator_->Sqrt();
            break;

            case Ln:
                Calculator_->Ln();
            break;

            case Exp:
                Calculator_->Exp();
            break;

            case Sin:
                Calculator_->Sin();
            break;

            case Cos:
                Calculator_->Cos();
            break;

            case Tan:
                Calculator_->Tan();
            break;
        }
        ui->newLCD->setText(QString::number(Calculator_->Result()));
        WriteLastOperation();
    }
    catch (errorID Type)
    {
        if ((Type == OutOfScope) || (Type == NegativeRoot))
        {
            ui->newLCD->setText("Error");
        }
    }
    operationJustCompleted = true;
}

void CalculatorWindow::on_Button_Sqrt_clicked()
{
    MathUnary(Sqrt);
}

void CalculatorWindow::on_Button_Ln_clicked()
{
    MathUnary(Ln);
}

void CalculatorWindow::on_Button_Exp_clicked()
{
    MathUnary(Exp);
}

void CalculatorWindow::on_Button_Sin_clicked()
{
    MathUnary(Sin);
}

void CalculatorWindow::on_Button_Cos_clicked()
{
    MathUnary(Cos);
}

void CalculatorWindow::on_Button_Tang_clicked()
{
    MathUnary(Tan);
}

// ---------------------------------------------------
// ---[ BINARY:  Add, Sub, Mult, Div, Pow ]-----------
// ---------------------------------------------------

void CalculatorWindow::InputBinary(mathID operation)
{
    LoadToCalculator(0);
    Calculator_->setOperation(operation);
    operationJustCompleted = true;
}

void CalculatorWindow::MathBinary()
{
    LoadToCalculator(1);
    try
    {
        switch (Calculator_->Operation())
        {
            case Add:
                Calculator_->Add();
            break;

            case Sub:
                Calculator_->Sub();
            break;

            case Mult:
                Calculator_->Mult();
            break;

            case Div:
                Calculator_->Div();
            break;

            case Pow:
                Calculator_->Pow();
            break;
        }
        ui->newLCD->setText(QString::number(Calculator_->Result()));
        WriteLastOperation();
    }
    catch (errorID Type)
    {
        if (Type == ZeroDivision)
        {
            ui->newLCD->setText("Error");
        }
    }
    operationJustCompleted = true;
}

void CalculatorWindow::on_Button_Plus_clicked()
{   
    InputBinary(Add);
    ui->testLCD->setText("+");
}

void CalculatorWindow::on_Button_Minus_clicked()
{
    InputBinary(Sub);
    ui->testLCD->setText("-");
}

void CalculatorWindow::on_Button_Mult_clicked()
{
    InputBinary(Mult);
    ui->testLCD->setText("x");
}

void CalculatorWindow::on_Button_Div_clicked()
{
    InputBinary(Div);
    ui->testLCD->setText("÷");
}

void CalculatorWindow::on_Button_Pow_clicked()
{
    InputBinary(Pow);
    ui->testLCD->setText("^");
}

void CalculatorWindow::on_Button_Equals_clicked()
{
    MathBinary();
}

// ---------------------------------------------------
// ---[ MEMORY:  MC, MS, MR ]-------------------------
// ---------------------------------------------------

void CalculatorWindow::on_Button_MC_clicked()
{
    Memory_->MemoryClear();
    ui->testLCD_M->setText("");
}

void CalculatorWindow::on_Button_MS_clicked()
{
    double SavedNumber = ui->newLCD->text().toDouble();
    Memory_->MemorySave(SavedNumber);
    ui->testLCD_M->setText("M");
}

void CalculatorWindow::on_Button_MR_clicked()
{
    double ReadedNumber = Memory_->MemoryRead();
    ui->newLCD->setText(QString::number(ReadedNumber));
}

// ---------------------------------------------------
// ---[ LAST OPERATION ]------------------------------
// ---------------------------------------------------

void CalculatorWindow::WriteLastOperation()
{
    QString Operation;
    QString Output;
    bool isUnary = false;

    switch (Calculator_->Operation())
	{
    case Add:
        Operation = "+";
		break;

    case Sub:
        Operation = "-";
		break;

    case Mult:
        Operation = "*";
		break;

    case Div:
        Operation = "/";
		break;

    case Pow:
        Operation = "^";
		break;

    case Sqrt:
        Operation = "sqrt";
        isUnary = true;
		break;

    case Exp:
        Operation = "exp";
        isUnary = true;
		break;

    case Sin:
        Operation = "sin";
        isUnary = true;
		break;

    case Tan:
        Operation = "tan";
        isUnary = true;
		break;

    case Cos:
        Operation = "cos";
        isUnary = true;
		break;

    case Ln:
        Operation = "ln";
        isUnary = true;
		break;
	}

    if (isUnary)
	{
        Output = QString("%1(%2) = ").arg(Operation, QString::number(Calculator_->First_Number()));
	}
	else
	{
        Output = QString("%1 %2 %3 = ").arg(QString::number(Calculator_->First_Number()), Operation, QString::number(Calculator_->Second_Number()));
	}
    Output += QString::number(Calculator_->Result());
    ui->testLCD->setText(Output);
}
