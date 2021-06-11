namespace TrasuaDesktop.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Session
    {
        public string SessionID { get; set; }

        public int AccountID { get; set; }

        public DateTime Timecreate { get; set; }

        public DateTime TimeEnd { get; set; }

        public bool Status { get; set; }
    }
}
