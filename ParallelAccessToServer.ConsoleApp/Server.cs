using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ParallelAccessToServer.ConsoleApp
{
    internal class Server
    {
        private static int _count;
        private static ReaderWriterLock _locker = new();

        public static int GetCount()
        {
            try
            {
                _locker.AcquireReaderLock(Timeout.InfiniteTimeSpan);

                return _count;
            }
            finally
            {
                _locker.ReleaseReaderLock();
            }
        }

        public static void AddToCount(int value)
        {
            _locker.AcquireWriterLock(Timeout.InfiniteTimeSpan);
            _count += value;
            _locker.ReleaseWriterLock();
        }
    }
}

