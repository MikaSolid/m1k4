﻿using System;

namespace m1k4.Model
{
    public class InvoiceStatus
    {
        public int InvoiceId { get; set; }

        public InvoiceStatusType Status { get; set; }
        
        public DateTime DateTime { get; set; }
    }
}
