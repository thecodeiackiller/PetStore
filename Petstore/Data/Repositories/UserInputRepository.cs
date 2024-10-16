using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Data.Repositories
{
    public class UserInputRepository : IUserInputRepository
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
