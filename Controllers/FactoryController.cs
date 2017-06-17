using GisSystemServer.Entity;
using GisSystemServer.Models;
using GisSystemServer.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GisSystemServer.Controllers
{
    [Authorize]
    [RoutePrefix("api/Factory")]
    public class FactoryController : ApiController
    {
        private const string LocalLoginProvider = "Local";        
        private IFactoryRepository _factoryRepository;
        public FactoryController(IFactoryRepository factoryRepository)
        {
            _factoryRepository = factoryRepository;
        }
        
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // Ошибки ModelState для отправки отсутствуют, поэтому просто возвращается пустой BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("AddFactory")]
        public void updUser(Factory fatory)
        {
            _factoryRepository.addFactory(fatory, User.Identity.GetUserName());
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("GetFactoryByEmail")]
        public List<Factory> getFactoryByEmail()
        {
           return _factoryRepository.getFactoryByEmail(User.Identity.GetUserName());
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("GetAllFactory")]
        public List<Factory> getAllFactory()
        {
            return _factoryRepository.getAllFactory();
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("FactoryById/{customerId}/info")]
        public Factory FactoryById(int customerId)
        {
            return _factoryRepository.getFactoryById(customerId);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("incrByMaterial/{customerId}/info")]
        public void incrByMaterial(int customerId)
        {
            _factoryRepository.incrByMaterial(customerId);
        }
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("incrByFactory/{customerId}/info")]
        public void incrByFactory(int customerId)
        {
            _factoryRepository.incrByFactory(customerId);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("GetViewsCount")]
        public Count GetViewsCount()
        {
            return _factoryRepository.viewsCount(User.Identity.GetUserName());
        }




    }
}