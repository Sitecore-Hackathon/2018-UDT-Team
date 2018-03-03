using Hackathon.Boilerplate.Feature.Rating.Models;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;
using Sitecore.XConnect.Schema;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Hackathon.Boilerplate.Feature.Rating.Repositories
{
    /// <summary>
    /// Respository class for content grid
    /// </summary>
    public class RatingRepository : ModelRepository, IRatingRepository
    {
        //private readonly string _customDatabase = Sitecore.Configuration.Settings.GetSetting(GenericConstants.CustomDatabase);
        private readonly string _customDatabase = "custom";
        /// <summary>
        /// Save Rating
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="templateId"></param>
        /// <param name="rating"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool SaveRating(string itemId, string templateId, int rating)
        {
            var itemGuid = new Guid();
            Guid.TryParse(itemId, out itemGuid);

            var templateGuid = new Guid();
            Guid.TryParse(templateId, out templateGuid);

            if (itemGuid == Guid.Empty || templateGuid == Guid.Empty || rating <= 0 || rating > 5)
            {
                return false;
            }

            try
            {
                var connString = ConfigurationManager.ConnectionStrings["custom"].ConnectionString;
                using (var myConnection = new SqlConnection(connString))
                {
                    myConnection.Open();
                    var myCommand = new SqlCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandText = "SaveRating";

                    var param = new SqlParameter("@ItemId", itemGuid);
                    param.DbType = DbType.Guid;
                    myCommand.Parameters.Add(param);

                    param = new SqlParameter("@TemplateId", templateGuid);
                    param.DbType = DbType.Guid;
                    myCommand.Parameters.Add(param);

                    param = new SqlParameter("@Rating", rating);
                    param.DbType = DbType.Int32;
                    myCommand.Parameters.Add(param);

                    myCommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        /// <summary>
        /// Get Rating By ItemId
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public RatingDetails GetRatingByItemId(string itemId)
        {
            try
            {
                var itemGuid = new Guid();
                Guid.TryParse(itemId, out itemGuid);

                if (itemGuid == Guid.Empty)
                {
                    return null;
                }

                RatingDetails ratingDetail = new RatingDetails();
                var connString = ConfigurationManager.ConnectionStrings[_customDatabase].ConnectionString;
                using (var myConnection = new SqlConnection(connString))
                {
                    myConnection.Open();
                    var myCommand = new SqlCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandText = "GetRatingByItemId";

                    var param = new SqlParameter("@ItemId", itemGuid);
                    param.DbType = DbType.Guid;
                    myCommand.Parameters.Add(param);

                    var reader = myCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        ratingDetail = new RatingDetails();
                        ratingDetail.Average = reader.GetInt32(0);
                        ratingDetail.TotalRating = reader.GetInt32(1);
                    }

                    return ratingDetail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Rating By TemplateId
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public List<RatingModel> GetRatingByTemplateId(string templateId)
        {
            try
            {
                var templateGuid = new Guid();
                Guid.TryParse(templateId, out templateGuid);

                if (templateGuid == Guid.Empty)
                {
                    return null;
                }

                var connString = ConfigurationManager.ConnectionStrings[_customDatabase].ConnectionString;
                using (var myConnection = new SqlConnection(connString))
                {
                    myConnection.Open();
                    var myCommand = new SqlCommand();
                    myCommand.Connection = myConnection;
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandText = "GetRatingByTemplateId";

                    var param = new SqlParameter("@TemplateId", templateGuid);
                    param.DbType = DbType.Guid;
                    myCommand.Parameters.Add(param);

                    var reader = myCommand.ExecuteReader();
                    var data = new List<RatingModel>();
                    while (reader.Read())
                    {
                        var d = new RatingModel();
                        d.ItemId = reader.GetGuid(0);
                        d.Average = reader.GetInt32(1);
                        d.TotalRating = reader.GetInt32(2);
                        data.Add(d);
                    }
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateContact(string user, string email)
        {
            bool response = false;
            AddContact(user, email);
            return response;
        }

        private static void AddContact(string user, string email)
        {
            using (var client = GetClient())
            {
                var identifiers = new ContactIdentifier[]
                {
                    new ContactIdentifier(GenericConstants.ContactSource, email, ContactIdentifierType.Known)
                };
                var contact = new Contact(identifiers);

                var personalInfoFacet = new PersonalInformation
                {
                    Nickname = email
                };
                client.SetFacet<PersonalInformation>(contact, PersonalInformation.DefaultFacetKey, personalInfoFacet);

                var emailFacet = new EmailAddressList(new EmailAddress(email, true), "email");
                client.SetFacet<EmailAddressList>(contact, EmailAddressList.DefaultFacetKey, emailFacet);

                client.AddContact(contact);
                client.Submit();
            }
        }

        private static XConnectClient GetClient()
        {
            var config = new XConnectClientConfiguration(
                new XdbRuntimeModel(CollectionModel.Model),
                new Uri(Sitecore.Configuration.Settings.GetSetting(GenericConstants.xconnectEndPoint)),
                new Uri(Sitecore.Configuration.Settings.GetSetting(GenericConstants.xconnectEndPoint)));

            try
            {
                config.Initialize();
            }
            catch (XdbModelConflictException ex)
            {
                //write into log
            }

            return new XConnectClient(config);
        }
    }
}