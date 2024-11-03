using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.TableDetailDto
{
    public class UpdateTableDetailDto
    {
        public int TableDetailID { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }

    }
}
