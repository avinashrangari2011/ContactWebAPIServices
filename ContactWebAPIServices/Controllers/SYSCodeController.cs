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
    /// SYSCode -  This class has Http Get, Post, Put and Delete request handler to handel clint's system related request
    /// </summary>
    public class SYSCodeController : ApiController
    {
        #region Http methods
       
        /// <summary>
        /// SYSCode - This method id used to select all system code list.</summary>
        /// <returns>Http action result contains contact model list</returns> 
        public IHttpActionResult Get()
        {
            return Ok(SYSCode.GetSYSCode());
        }

        /// <summary>
        /// SYSCode - This method id used to select all system code item.</summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            return Ok(SYSCode.GetSYSCodeByCodeID(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeGroupID"></param>
        /// <returns></returns>
        public IHttpActionResult Get(string CodeGroupID)
        {
            return Ok(SYSCode.GetSYSCodeByGroupID(CodeGroupID));
        }

        #endregion Http methods
    }
}