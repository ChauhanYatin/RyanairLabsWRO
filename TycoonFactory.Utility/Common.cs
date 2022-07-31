using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TycoonFactory.Utility
{
    public static class Common
    {
        public static string GetHHMM(int val)
        {
            string workHours = "00:00";
            if (val > 0)
            {
                TimeSpan spWorkMin = TimeSpan.FromMinutes(val);
                workHours = spWorkMin.ToString(@"hh\:mm");
            }
            return workHours;
        }

        public static class WorkType
        {
            public static string Component = "Component";
            public static string Machine = "Machine";
        }

        public static class Status
        {
            public static string Success = "Success";
            public static string Failed = "Failed";
        }
    }
}
