using ContactWebAPIServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactWebAPIServices.Controllers
{
    /// <summary>
    /// Contact - This class has Http Get, Post, Put and Delete request handler to handel clint's contact table related request.
    /// </summary>
    public class ContactController : ApiController
    {
        #region Http methods
        /// <summary>
        /// Contact - This method id used to select all contact list.</summary>
        /// <returns>Http action result contains contact model list</returns>
        public IHttpActionResult Get()
        {
            var lContactList = ContactServices.GetContacts();
            return Ok(lContactList);
        }

        /// <summary>
        /// Contact - This method is used to select contact by id.</summary>
        /// <param name="id">Contact id</param>
        /// <returns>Http action result contains contact model</returns>
        public IHttpActionResult Get(int id)
        {
            var lContactDetails = ContactServices.GetContact(id);
            if (lContactDetails == null)
                return NotFound();
            else
                return Ok(lContactDetails);
        }

        /// <summary>
        /// Contact - This method is used to update contact.</summary>
        /// <param name="abusContact">Contact model</param>
        /// <returns>Http action result contains true if record updated else false</returns>
        public IHttpActionResult Put(ContactViewModel abusContact)
        {
            bool lblnIsSuccess;
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");

            lblnIsSuccess = ContactServices.UpdateContact(abusContact);
            if (lblnIsSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Contact - This method is used to create/add contact.</summary>
        /// <param name="abusContact">Contact model</param>
        /// <returns>Http action result contains true if record created/added else false</returns>
        public IHttpActionResult Post(ContactViewModel abusContact)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            return Ok(ContactServices.AddContact(abusContact));
        }

        /// <summary> 
        /// Contact - This method is used to delete contact by id.</summary>
        /// <param name="id">Contact id</param>
        /// <returns>Http action result contains true if record deleted else false</returns>
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            return Ok(ContactServices.DeleteContact(id));
        }

        #endregion Http methods
    }
}