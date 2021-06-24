using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LidlStore.API.HealthCheck
{
    public class HealthCheckReponse
    {
        public string Status { get; set; }
        public IEnumerable<IndividualHealthCheckResponse> HealthChecks { get; set; }
        public TimeSpan HealthCheckDuration { get; set; }
    }
}
