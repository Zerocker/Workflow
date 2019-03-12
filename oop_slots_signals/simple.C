#include "simple.h"

Simple::Simple(QObject *parent) : QObject(parent)
{

}

void Simple::SetValue()
{
    srand(static_cast<uint32_t>(time(nullptr)));
    Value_ = rand() % 1024;
}

uint32_t Simple::GetValue()
{
    return Value_;
}
