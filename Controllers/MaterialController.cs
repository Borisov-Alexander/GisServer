using GisSystemServer.Entity;
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
    [RoutePrefix("api/Material")]
    public class MaterialController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private IMaterialRepository _materialRepository;
        public MaterialController(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
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
        [Route("addMaterial")]
        public void addmaterial(Material material)
        {
            
             _materialRepository.addMaterial(material);
        }
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("getAllMaterial")]
        public List<Material> getAllMaterial()
        {
            return _materialRepository.getAllMaterial();
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("getMaterialByEmail")]
        public List<Material> getMaterialByEmail()
        {
            return _materialRepository.getAllMaterial();
        }



    }
}