using Hackathon.Boilerplate.Feature.Rating.Repositories;
using Sitecore.XA.Foundation.Mvc.Controllers;
using System.Web.Mvc;

namespace Hackathon.Boilerplate.Feature.Rating.Controllers
{
    public class RatingController : StandardController
    {
        private readonly IRatingRepository _ratingRepository;//= new RatingRepository();

        /// <summary>
        /// Controller constructor
        /// </summary>        
        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        /// <summary>
        /// Index action method
        /// </summary>
        /// <returns>partial view will render the rating component return</returns>
        public override ActionResult Index()
        {

            return (ActionResult)this.PartialView("Rating", this.GetModel());
        }

        public JsonResult SaveRating(string currentItemId, string CurrentTemplateId, int rating)
        {
            var response = _ratingRepository.SaveRating(currentItemId, CurrentTemplateId, rating);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRatingByItemId(string itemId)
        {
            var response = _ratingRepository.GetRatingByItemId(itemId);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        

        public JsonResult GetRatingByTemplateId(string templateId)
        {
            var response = _ratingRepository.GetRatingByTemplateId(templateId);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateContact(string user, string email)
        {
            var response = _ratingRepository.CreateContact(user, email);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Getmodel method to get all model values.
        /// </summary>
        /// <returns>returns model object</returns>
        //protected override object GetModel()
        //{
        //    if (_ratingRepository != null)
        //    {
        //        return _ratingRepository.GetModel();
        //    }
        //    return null;
        //}
    }
}