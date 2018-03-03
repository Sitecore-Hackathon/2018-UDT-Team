using Sitecore.XA.Foundation.Mvc.Models;
using System;

namespace Hackathon.Boilerplate.Feature.Rating.Models
{
    /// <summary>
    /// This model contains list of content tiles items
    /// </summary>
    public class RatingDetails //: RenderingModelBase
    {
        public int TotalRating { get; set; }
        public int Average { get; set; }

        public string  AverageText {get;set;}
        public string TotalRatingText { get; set; }
    }
}