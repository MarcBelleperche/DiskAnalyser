using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskAnalysers
{
    public class Disks
    {
        public string name { get; set; }
        public double storage_tot { get; set; }
        public double storage_left { get; set; }
        public double storage_used { get; set; }


        /*        public Disks(string name, double usedstr, double leftstr)
                    {
                    this.name = name;
                    this.storage_left = leftstr;
                    this.storage_used = usedstr;
                    }*/
    }
}
