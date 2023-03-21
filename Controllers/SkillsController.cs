using Microsoft.AspNetCore.Mvc;
using lagalt_web_api.Models;
using AutoMapper;
using lagalt_web_api.Repositories;
using lagalt_web_api.Models.DTO.UserDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectReadDTO;
using Microsoft.EntityFrameworkCore;
using lagalt_web_api.Models.DTO.SkillDTO;

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


        public SkillsController(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<SkillReadDTO>> GetSkills()
        {
            var skills = _repositories.Skills.GetAll();
            var skillsDTO = skills.Select(skill => _mapper.Map<SkillReadDTO>(skill));
            return Ok(skillsDTO);
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
