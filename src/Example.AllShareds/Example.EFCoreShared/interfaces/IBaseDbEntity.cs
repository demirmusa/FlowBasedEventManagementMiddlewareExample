using System;
using System.Collections.Generic;
using System.Text;

namespace Example.EFCoreShared.interfaces
{
    internal interface IBaseDbEntity
    {
        int ID { get; set; }
        DateTime CreationTime { get; set; }
        DateTime? LastUpdateTime { get; set; }
    }
}
