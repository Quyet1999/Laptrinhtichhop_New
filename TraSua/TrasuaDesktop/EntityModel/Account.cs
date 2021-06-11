namespace TrasuaDesktop.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Account
    {
        public Account()
        {
           
        }
        public int ID { get; set; }

        public int GroupID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool StatusAccount { get; set; }

        public bool StatusLog { get; set; }
    }
}
