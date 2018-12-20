#ifndef MEMORYUNIT_H
#define MEMORYUNIT_H

class MemoryUnit
{
public:
    MemoryUnit();

    /*  Очищает память калькулятора */
    void MemoryClear();

    /*  Сохраняет число, отображенное
     *  в данный момент на дисплее калькулятора в память */
    void MemorySave(double &value);

    /*  Считывает число из ячейки памяти. */
    double MemoryRead();

protected:
    double MemorySlot_; // Ячейка памяти
};

#endif // MEMORYUNIT_H
