using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.ServiceModel;
using log4net;

namespace CustomException
{
    public class ExceptionHandler
    {

        public static void ReturnErrMsg(Exception ex, out string msg)
        {
            ILog log = LogManager.GetLogger(Constants.LOGGER);

            msg = ex is FaultException ? ex.Message : Constants.ERROR_OCCURRED;

            log.Error(ex.GetType() + "\t" + ex.Message + "\t" + ex.Data);
        }
    }
}
