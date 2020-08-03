namespace Fingerprint_Scanner_Service
{
    class FingerprintScannerInfo
    {
        public static bool Status { get; set; }
        public static bool CanBeRegistered { get; set; }
        //false: чтение отпечатка
        //true: чтение отпечатка для регистрации
    }
}
