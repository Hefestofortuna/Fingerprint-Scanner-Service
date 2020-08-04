using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anviz.SDK;

namespace TestEvents.Fingerprint.module
{
    class AnzivDeviceUsage
    {
        private static readonly int[] Ports = { 5010, 5050 };

        /// <summary>
        /// Method to get the latest records from the device
        /// </summary>
        /// <param name="numPort">0 for 5010(default), 1 for 5050</param>
        /// <param name="isLatest">Need the latest records? True is default</param>
        /// <param name="isNeedToClearLatestRecords">Need the clear latest records? False is default</param>
        /// <returns>List of Records</returns>
        public static async Task<List<Anviz.SDK.Responses.Record>> GetRecords(int numPort = 0, bool isLatest = true, bool isNeedToClearLatestRecords = false)
        {
            var manager = new AnvizManager();
            manager.Listen(Ports[numPort]);
            Console.WriteLine($"Listening on port {Ports[numPort]}");
            using (var device = await manager.Accept())
            {
                device.DevicePing += (s, e) => Console.WriteLine("Device Ping Received");
                device.ReceivedPacket += (s, e) => Console.WriteLine("Received packet");
                device.DeviceError += (s, e) => throw e;
                var records = await device.DownloadRecords(isLatest); //true to get only new records
                if (isNeedToClearLatestRecords) await device.ClearNewRecords();
                return records;
            }
        }
        /// <summary>
        /// Adding new person to device
        /// </summary>
        /// <param name="numPort">0 for 5010(default), 1 for 5050</param>
        public static async Task AddPerson(ulong idPerson, string name, ulong password, int numPort = 0)
        {
            var manager = new AnvizManager();
            manager.Listen(Ports[numPort]);
            using (var device = await manager.Accept())
            {
                device.DevicePing += (s, e) => Console.WriteLine("Device Ping Received");
                device.ReceivedPacket += (s, e) => Console.WriteLine("Received packet");
                device.DeviceError += (s, e) => throw e;
                var employee = new Anviz.SDK.Responses.UserInfo(idPerson, name);
                employee.Password = password;
                await device.SetEmployeesData(employee);
                Console.WriteLine("User created, starting fp enroll");
                var fp = await device.EnrollFingerprint(employee.Id);
                await device.SetFingerprintTemplate(employee.Id, Anviz.SDK.Utils.Finger.RightIndex, fp);
            }
        }
        /// <summary>
        /// Getting Persons
        /// </summary>
        /// <param name="numPort">0 for 5010(default), 1 for 5050</param>
        public static async Task<Dictionary<ulong, string>> GetUsers(int numPort = 0)
        {
            var manager = new AnvizManager();
            manager.Listen(Ports[numPort]);
            using (var device = await manager.Accept())
            {
                var employees = await device.GetEmployeesData();
                var dict = new Dictionary<ulong, string>();
                foreach (var employee in employees)
                {
                    dict.Add(employee.Id, employee.Name);
                }
                return dict;
            }
        }
    }
}
