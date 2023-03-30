using Microsoft.AspNetCore.Mvc;
using lagalt_web_api.Models;
using AutoMapper;
using lagalt_web_api.Repositories;
using lagalt_web_api.Models.DTO.UserDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectReadDTO;
using Microsoft.EntityFrameworkCore;
using lagalt_web_api.Models.DTO.SkillDTO;
using Newtonsoft.Json;
using lagalt_web_api.Repositories.API;
using System.Net.Http.Headers;
using System.Net;
using NuGet.Protocol;

namespace lagalt_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    [Consumes("Application/json")]
    public class SkillsController : ControllerBase
    {

        private readonly IRepositories _repositories;

        private readonly IMapper _mapper;

        public ISkillsAPIRepository SkillsAPIRepository { get; }
        public IHttpClientFactory HttpClientFactory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillsController"/> class.
        /// </summary>
        /// <param name="repositories">The repositories.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="skillsAPIRepository">The skills API repository.</param>
        public SkillsController(IRepositories repositories, IMapper mapper, IHttpClientFactory httpClientFactory, ISkillsAPIRepository skillsAPIRepository)
        {
            _repositories = repositories;
            _mapper = mapper;
            HttpClientFactory = httpClientFactory;
            SkillsAPIRepository = skillsAPIRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<SkillReadDTO>> GetSkills()
        {
            var skills = _repositories.Skills.GetAll();
            var skillsDTO = skills.Select(skill => _mapper.Map<SkillReadDTO>(skill));
            return Ok(skillsDTO);
        }

        [HttpGet("titles")]
        public async Task<IEnumerable<string>> GetSkillTitles(string skillTitle)
        {
            try
            {
                return await SkillsAPIRepository.GetSkillTitles(skillTitle);
            }
            catch (Exception e) {
                string errorMessage = e.Message;
                return new List<string> { errorMessage };
            }
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<SkillReadDTO>> GetSkillByName(string name)
        {
            var skills = _repositories.Skills.GetAll().Where(sk => sk.Name.Contains(name));
            var skillsDTO = skills.Select(skill => _mapper.Map<SkillReadDTO>(skill));

            return Ok(skillsDTO);
        }

        [HttpGet("id/{id}")]
        public ActionResult<SkillReadDTO> GetSkillById(int id)
        {
            var skillDTO = _mapper.Map<SkillReadDTO>(_repositories.Skills.GetAll()
                .Where(sk => sk.Id == id)
                .FirstOrDefault());

            return Ok(skillDTO);
        }
    }
}
