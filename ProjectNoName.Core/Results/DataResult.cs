using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNoName.Core.Results
{
    public class DataResult<T> : Result
    {
        public T Data { get; }
        public DataResult(T Data, bool Success, string Message) : base(Success, Message)
        {
            this.Data = Data;
        }
    }
}
