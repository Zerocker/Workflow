using System;

namespace crypto_lab4
{
    public static partial class Des
    {
        public static ulong Encrypt(ulong input, ulong key)
        {
            /* initial permutation */
            ulong initPrem = 0;
            for (int i = 0; i < Ip.Length; i++)
            {
                initPrem <<= 1;
                initPrem |= (input >> (64 - Ip[i])) & Lb64Mask;
            }
            
            Console.WriteLine($"IP: {initPrem:x8}");

            uint l = (uint) ((initPrem >> 32) & L64Mask);
            uint r = (uint) (initPrem & L64Mask);

            /* initial key schedule calculation */
            ulong permutedChoice1 = 0;
            for (int i = 0; i < Pc1.Length; i++)
            {
                permutedChoice1 <<= 1;
                permutedChoice1 |= (key >> (64 - Pc1[i])) & Lb64Mask;
            }

            uint c = (uint) ((permutedChoice1 >> 28) & L56Mask);
            uint d = (uint) (permutedChoice1 & L56Mask);

            /* Calculation of the 16 keys */
            ulong[] subKeys = new ulong[IterationShift.Length];
            for (int i = 0; i < IterationShift.Length; i++)
            {
                /* key schedule */
                // shifting Ci and Di
                for (int j = 0; j < IterationShift[i]; j++)
                {
                    c = 0x0fffffff & (c << 1) | 0x00000001 & (c >> 27);
                    d = 0x0fffffff & (d << 1) | 0x00000001 & (d >> 27);
                }

                ulong permutedChoice2 = (((ulong) c) << 28) | (ulong) d;

                for (int j = 0; j < Pc2.Length; j++)
                {
                    subKeys[i] <<= 1;
                    subKeys[i] |= (permutedChoice2 >> (56 - Pc2[j])) & Lb64Mask;
                }
                
                Console.WriteLine($"k{i}: {subKeys[i]:x8}");
            }
            Console.WriteLine($"-----------------------------------------------------");
            
            for (int i = 0; i < IterationShift.Length; i++)
            {
                uint sOutput = 0;

                /* f(R,k) function */
                ulong sInput = 0;
                for (int j = 0; j < E.Length; j++)
                {
                    sInput <<= 1;
                    sInput |= ((r >> (32 - E[j])) & Lb32Mask);
                }

                // Encryption
                // XORing expanded Ri with Ki
                sInput ^= subKeys[i];

                /* S-Box Tables */
                for (int j = 0; j < S.GetLength(0); j++)
                {
                    // 00 00 RCCC CR00 00 00 00 00 00 - s_input
                    // 00 00 1000 0100 00 00 00 00 00 - row mask
                    // 00 00 0111 1000 00 00 00 00 00 - column mask
                    
                    byte row = (byte) ((sInput & (RowMask >> 6 * j)) >> 42 - 6 * j);
                    row = (byte) ((row >> 4) | row & 0x01);

                    byte column = (byte) ((sInput & (ColumnMask >> 6 * j)) >> 43 - 6 * j);

                    sOutput <<= 4;
                    sOutput |= (uint) (S[j, 16 * row + column] & 0x0f);
                }

                uint fFuncResult = 0;
                for (int j = 0; j < P.Length; j++)
                {
                    fFuncResult <<= 1;
                    fFuncResult |= (sOutput >> (32 - P[j]) & Lb32Mask);
                }
                
                Console.WriteLine($"H{i}: {r:x8}");
                Console.WriteLine($"L{i}: {l:x8}");
                Console.WriteLine($"F(k{i}, L{i}): {fFuncResult:x8}");

                uint temp = r;
                r = l ^ fFuncResult;
                l = temp;

                Console.WriteLine($"H{i} ^ F(k{i}, L{i}): {r:x8}");
                Console.WriteLine($"-----------------------------------------------------");
            }
            
            ulong preOutput = (((ulong) r) << 32) | (ulong) l;

            /* inverse initial permutation */
            ulong invInitPerm = 0;
            for (int i = 0; i < Pi.Length; i++)
            {
                invInitPerm <<= 1;
                invInitPerm |= (preOutput >> (64 - Pi[i])) & Lb64Mask;
            }
            return invInitPerm;
        }
    }
}