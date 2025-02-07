using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Shared.Responses
{
    public class Response : ErrorStore
    {
        public bool IsSuccess => !HasError;

        public Response() : base() { }
    }
}
