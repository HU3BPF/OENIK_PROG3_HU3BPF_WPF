using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMKWH0_HFT_2021221.Client
{
    public class EntityNotFound : Exception
    {
        public EntityNotFound()
        {

        }
        public EntityNotFound(string message) : base(message)
        {

        }
        public override string Message => "Entity not found!";
    }
    public class EntityIsAvailable : Exception
    {
        public EntityIsAvailable()
        {

        }
        public EntityIsAvailable(string message) : base(message)
        {

        }
        public override string Message => "Entity is available!";
    }
}
