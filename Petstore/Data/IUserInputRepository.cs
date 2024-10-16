using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Data
{
    public interface IUserInputRepository
    {
        public string GetInput();
    }
}
