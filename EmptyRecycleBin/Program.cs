using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace EmptyRecycleBin
{
    class Program
    {
        enum RecycleFlags : uint
        { 
            SHERB_NOTIFICATION = 0x00000001, // No Confirmation dialog when emptying the recycle bin
            SHERB_NOPROGRESSUI = 0x00000002, // No progress tracking window during the emptying of the recycle bin
            SHERB_NOSOUND = 0x00000004 // No sound when the emptying of the recycle bin is complete.
        }

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        static void Main(string[] args)
        {
            try
            {
                uint result = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOTIFICATION);

                Console.WriteLine(string.Format("Done ! Empty the RecycleBin"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Failed ! {0} Empty the RecycleBin", ex.Message));
            }

            Console.ReadKey();
        }
    }
}
