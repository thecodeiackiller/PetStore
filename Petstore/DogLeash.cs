using Petstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore
{
    public class DogLeash : Product
    {
        public int LengthInches { get; set; }
        public string? Material { get; set; }

        // Need to add a validator for dog leash here
    }
}
