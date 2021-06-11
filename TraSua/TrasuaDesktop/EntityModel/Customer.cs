namespace TrasuaDesktop.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Customer
    {
        public int ID { get; set; }

        public string FullName { get; set; }

        public bool Sex { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public DateTime TimeSignUp { get; set; }

        public int EmployeeAccept { get; set; }

        public int AccountID { get; set; }
    }
}
