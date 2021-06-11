namespace TrasuaDesktop.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Topping
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public bool Status { get; set; }

        public int AccountCreate { get; set; }

        public int AccountChange { get; set; }

        public DateTime TimeCreate { get; set; }

        public DateTime TimeChange { get; set; }

        public byte[] Image { get; set; }
    }
}
