using Hackathon.Boilerplate.Feature.Rating.Models;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using System.Collections.Generic;

namespace Hackathon.Boilerplate.Feature.Rating.Repositories
{
    /// <summary>
    /// Inteface for shopping tools respository
    /// </summary>
    public interface IRatingRepository : IModelRepository
    {
        bool SaveRating(string itemId, string templateId, int rating);
        RatingDetails GetRatingByItemId(string itemId);
        List<RatingModel> GetRatingByTemplateId(string templateId);
        bool CreateContact(string user, string email);
    }
}