namespace TrasuaDesktop.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Bill
    {
        public Bill()
        {
        }

        public int ID { get; set; }

        public int EmployeeCreate { get; set; }

        public DateTime TimeCreate { get; set; }

        public int CustomerID { get; set; }

        public int TotalMoney { get; set; }

        public bool StatusBill { get; set; }
    }
}
