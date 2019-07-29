using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHJ.FileManagement.SerialNumbers
{
    public static class SerialNumberFactory
    {
        public static string Create()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return $"{i - DateTime.Now.Ticks:x}";
        }
    }
}
