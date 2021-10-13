using System;


namespace TestAPI.Entities
{
    public class Sales
    {
        public Int64 id { get; set; }
        public virtual Int64 productid { get; set; }
        public virtual Int64 clientid { get; set; }
        public int quantity { get; set; }
        public float totalAmount { get; set; }
        public Client client { get; set; }
        public Product product { get; set; }
    }
}
