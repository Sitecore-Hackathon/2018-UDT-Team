using Sitecore.XA.Foundation.Mvc.Models;
using System;

namespace Hackathon.Boilerplate.Feature.Rating.Models
{
    /// <summary>
    /// This model contains list of content tiles items
    /// </summary>
    public class RatingModel //: RenderingModelBase
    {
        public Guid ItemId { get; set; }
        public int Average { get; set; }
        public int TotalRating { get; set; }
    }
}