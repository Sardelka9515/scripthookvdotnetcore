using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHVDN
{
    public static unsafe partial class NativeMemory
    {
        public static string PtrToStringUTF8(IntPtr ptr) => Marshaller.PtrToStringUTF8(ptr);
        
        /// <summary>
        /// Searches the specific address space of the current process for a memory pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="mask">The pattern mask.</param>
        /// <param name="startAddress">The address to start searching at.</param>
        /// <param name="size">The size where the pattern search will be performed from <paramref name="startAddress"/>.</param>
        /// <returns>The address of a region matching the pattern or <see langword="null" /> if none was found.</returns>
        public static unsafe byte* FindPattern(string pattern, string mask, IntPtr startAddress, ulong size)
        {
            // Convert pattern to byte array and check for invalid byte (overflow).
            var patternBytes = pattern.Select(x => checked((byte)x)).ToArray();
            var patternId = $"{typeof(NativeMemory).FullName}.Patterns.{BitConverter.ToString(patternBytes)}.{mask}.{startAddress}.{size}";

            // Try to find cached offset
            var cached = Core.GetPtr(patternId);
            if (cached != default)
                return (byte*)cached;

            ulong address = (ulong)startAddress.ToInt64();
            ulong endAddress = address + size;

            for (; address < endAddress; address++)
            {
                for (int i = 0; i < patternBytes.Length; i++)
                {
                    if (mask[i] != '?' && ((byte*)address)[i] != patternBytes[i])
                        break;
                    else if (i + 1 == patternBytes.Length)
                    {
                        Core.SetPtr(patternId, (IntPtr)address);
                        return (byte*)address;
                    }
                }
            }

            return null;
        }
    }
}
