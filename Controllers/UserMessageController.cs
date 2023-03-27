using AutoMapper;
using lagalt_web_api.Models.DTO.UserMessageDTO;
using lagalt_web_api.Models;
using lagalt_web_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace lagalt_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    [Consumes("Application/json")]
    public class UserMessageController
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IRepositories _repositories;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        public UserMessageController(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        [HttpGet("{projectId}")]
        public  IEnumerable<UserMessageWithUsernameDTO>  GetUserMessages(int projectId)
        {
            // TODO: Write new method for retrieving projects by id instead of filtering the whole set with linq.
            var userMessages = _repositories.UserMessages.GetAll().Include(x => x.User).Include(x=>x.Project).ToList().Where(usermessage=>usermessage.ProjectId == projectId);
            var userMessagesDTOs = _mapper.Map<IEnumerable<UserMessageWithUsernameDTO>>(userMessages);
            return userMessagesDTOs;
        }

        [HttpPost]
        public ActionResult<UserMessage> PostUserMessage(UserMessageUserWithMessageDTO userMessageWithIdAndMessage)
        {
            var userMessage = _mapper.Map<UserMessage>(userMessageWithIdAndMessage);
            return _repositories.UserMessages.Create(userMessage);
            
        }
    }
}