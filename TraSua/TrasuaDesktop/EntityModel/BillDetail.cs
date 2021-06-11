namespace TrasuaDesktop.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class BillDetail
    {
        public int ID_Detail { get; set; }

        public int BillID { get; set; }

        public int ItemID { get; set; }

        public int NumberItem { get; set; }

        public int Price { get; set; }

        public int TotalMoneyDetail { get; set; }

        public bool TypeItem { get; set; }
    }
}
