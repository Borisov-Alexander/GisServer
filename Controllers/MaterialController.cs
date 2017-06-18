using GisSystemServer.Entity;
using GisSystemServer.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

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

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("MaterialByName/{name}/info")]
        public List<Material> MaterialByname(string name)
        {
            return _materialRepository.getMaterialByName(name);
        }
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("MaterialById/{id}/info")]
        public List<Material> MaterialById(int id)
        {
            return _materialRepository.MaterialById(id);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("getMaterialCount")]
        public Count getFactoryByEmail()
        {
            return _materialRepository.materialCount(User.Identity.GetUserName());
        }


        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("MinCostMaterial/{name}/info")]
        public Material MinCostMaterial(string name)
        {
            return _materialRepository.getMinCostMaterial(name);
        }


    }
}