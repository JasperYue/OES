using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CustomException
{
    public class ServiceException : FaultException
    {
        public ServiceException()
            : base() { }

        public ServiceException(string message)
            : base(message) { }
    }
}
