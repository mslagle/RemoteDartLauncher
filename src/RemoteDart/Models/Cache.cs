using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteDart.Models
{
    public static class Cache
    {
        public static DartStatus Status { get; set; }
    }

    public enum DartStatus
    {
        Ready,
        Pending,
        Fired
    }
}
