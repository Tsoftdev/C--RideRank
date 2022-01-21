﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.StaticData
{
    public partial class CalcuttaRCResult
    {
        public int Id { get; set; }
        public string ParentEventId { get; set; }
        public string CompetitorId { get; set; }
        public string CompetitorName { get; set; }
        public int RowId { get; set; }
        public decimal Score { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
