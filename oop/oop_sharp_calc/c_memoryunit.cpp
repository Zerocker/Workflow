#include "c_memoryunit.h"

MemoryUnit::MemoryUnit() : MemorySlot_(0) {}

void MemoryUnit::MemoryClear()
{
    MemorySlot_ = 0;
}

void MemoryUnit::MemorySave(double &value)
{
    MemorySlot_ = value;
}

double MemoryUnit::MemoryRead()
{
    return MemorySlot_;
}
