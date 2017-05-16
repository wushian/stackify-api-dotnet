﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace StackifyLib.Utils
{
    public static class SequentialGuid
    {
#if NET451 || NET45
        [DllImport("rpcrt4.dll", SetLastError = true)]
        private static extern int UuidCreateSequential(out Guid guid);
#endif
        public static Guid NewGuid()
        {
#if NET451 || NET45
            const int RPC_S_OK = 0;
            Guid guid;
            int result = UuidCreateSequential(out guid);
            if (result == RPC_S_OK)
            {
                return guid;
            }
#endif
            return Guid.NewGuid();
        }
    }
}
