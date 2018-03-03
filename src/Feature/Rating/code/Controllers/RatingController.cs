using Hackathon.Boilerplate.Feature.Rating.Repositories;
using Sitecore.XA.Foundation.Mvc.Controllers;
using System.Web.Mvc;

namespace Hackathon.Boilerplate.Feature.Rating.Controllers
{
    public class RatingController : StandardController
    {
        private readonly IRatingRepository _ratingRepository;

        /// <summary>
        /// Instantiates the Rating Repository using Dependancy Injection
        /// </summary>
        /// <param name="ratingRepository"></param>
        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        /// <summary>
        /// Action Methods gets called when Rating Component renders
        /// </summary>
        /// <returns>Renders the rating Component</returns>
        public override ActionResult Index()
        {
            return (ActionResult)this.PartialView("Rating", this.GetModel());
        }

        /// <summary>
        /// Saves the Rating Information to Custom database
        /// Method gets called from the Ajax call when user Rates the Page
        /// </summary>
        /// <param name="currentItemId"></param>
        /// <param name="CurrentTemplateId"></param>
        /// <param name="rating"></param>
        /// <returns>Returs boolean JsonResult whether success or Failure</returns>
        public JsonResult SaveRating(string currentItemId, string CurrentTemplateId, int rating)
        {
            var response = _ratingRepository.SaveRating(currentItemId, CurrentTemplateId, rating);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets Rating Information of a Perticlar Page Item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>Returns the JsonResult of Rating Information</returns>
        public JsonResult GetRatingByItemId(string itemId)
        {
            var response = _ratingRepository.GetRatingByItemId(itemId);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        /// Get Rating Information of all the Page Items Based on the TemplateID
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public JsonResult GetRatingByTemplateId(string templateId)
        {
            var response = _ratingRepository.GetRatingByTemplateId(templateId);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creates xConnect Contact
        /// </summary>
        /// <param name="user"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public JsonResult CreateContact(string user, string email)
        {
            var response = _ratingRepository.CreateContact(user, email);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        
    }
}