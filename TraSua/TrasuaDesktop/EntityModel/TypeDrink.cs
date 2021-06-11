namespace TrasuaDesktop.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TypeDrink
    {
       public TypeDrink()
        {
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int AccountCreate { get; set; }

        public DateTime TimeCreate { get; set; }

        public int AccountChange { get; set; }

        public DateTime TimeChange { get; set; }
    }
}
