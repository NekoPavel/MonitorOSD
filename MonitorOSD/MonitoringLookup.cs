using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorOSD
{
    public class MonitoringLookup
    {
        public string id { get; set; }
        public string target { get; set; }
        public string hardwareModelName { get; set; }
        public int status { get; set; }
        public int steps { get; set; }
        public int currentStep { get; set; }
        public string currentStepName { get; set; }
        public object vmHost { get; set; }
        public object vmName { get; set; }
        public string dartIp { get; set; }
        public int dartPort { get; set; }
        public string dartTicket { get; set; }
        public object passphrase { get; set; }
        public object endDate { get; set; }
        public object createdDate { get; set; }
        public object lastReportedDate { get; set; }
        public string createdBy { get; set; }
        public object lastModifiedDate { get; set; }
        public string lastModifiedBy { get; set; }
        public int warnings { get; set; }
        public int errors { get; set; }
        public double progress { get; set; }
        public bool isUnresponsive { get; set; }
    }
}
