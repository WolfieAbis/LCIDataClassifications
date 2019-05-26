using System;
using System.Collections.Generic;
using System.Text;

namespace LCIData.Interface
{
    public interface IRepositoryWrapper
    {
        ITweetRepository Tweet { get; }

        void save();
    }
}
