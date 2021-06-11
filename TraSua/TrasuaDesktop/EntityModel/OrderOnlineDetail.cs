namespace TrasuaDesktop.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderOnlineDetail
    {
        public int ID_Detail { get; set; }

        public int OrderOnlineID { get; set; }

        public int ItemOrderID { get; set; }

        public int NumberOrder { get; set; }

        public int Price { get; set; }

        public int TotalMoneyDetail { get; set; }

        public int TypeItem { get; set; }
    }
}
