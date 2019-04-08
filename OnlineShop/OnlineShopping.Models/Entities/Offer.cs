#region Usings

using System;

#endregion

namespace OnlineShopping.Models.Entities
{
    public enum OfferType
    {
        Value = 1,
        Percentage = 2
    }

    public class Offer
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
        public OfferType Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ValidUntil { get; set; }
        public decimal Value { get; set; }

        #region Foreign keys and Navigation
        
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        #endregion
    }
}