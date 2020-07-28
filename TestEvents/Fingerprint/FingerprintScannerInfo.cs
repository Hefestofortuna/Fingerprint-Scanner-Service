using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEvents
{
    class FingerprintScannerInfo
    {
        public static bool Status { get; set; }
        //false: чтение отпечатка
        //true: чтение отпечатка для регистрации
    }
}
