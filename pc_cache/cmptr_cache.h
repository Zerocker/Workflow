#include <iostream>
#include <vector>
#include <chrono>

// Phenom 9850
// L1 - 4x64 KB
// L2 - 4x512 KB
// L3 - 2048 KB
// Total: 4352 KB

using namespace std::chrono;

using i32 = std::int32_t;
using i64 = std::int64_t;
using u8 = std::uint8_t;
using u32 = std::uint32_t;
using u64 = std::uint64_t;
using f32 = float;

using tuple = std::vector<u32>;

constexpr auto KB = 1024;
constexpr auto MB = 1024 * 1024;
constexpr auto SIZE = 8 * MB;
constexpr auto REPS = 1024 * MB;
constexpr auto TIMES = 1;

u32 sizes[] = { 1 * KB, 4 * KB, 8 * KB, 16 * KB, 24 * KB, 32 * KB, 64 * KB, 128 * KB, 256 * KB, 512 * KB,
				1 * MB, 2 * MB, 4 * MB, 6 * MB, 8 * MB };