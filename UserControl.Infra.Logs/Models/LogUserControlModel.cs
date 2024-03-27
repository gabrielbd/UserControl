using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControl.Infra.Logs.Models
{
    public class LogUserControlModel
    {
        public Guid? Id { get; set; }
        public string? Operation { get; set; }
        public string? Details { get; set; }
        public DateTime? DateAndTime { get; set; }
        public Guid? IdUser { get; set; }

    }
}
