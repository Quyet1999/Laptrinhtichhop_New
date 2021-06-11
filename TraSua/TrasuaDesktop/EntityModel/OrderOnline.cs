namespace TrasuaDesktop.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderOnline
    {
        public OrderOnline()
        {
        }

        public int ID { get; set; }

        public int CustomerID { get; set; }

        public DateTime TimeOrder { get; set; }

        public int EmployeeAccept { get; set; }

        public DateTime TimeAccept { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int TotalMoney { get; set; }
    }
}
