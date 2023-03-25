using AutoMapper;
using lagalt_web_api.Models.DTO.UserMessageDTO;
using lagalt_web_api.Models;
using lagalt_web_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public  IEnumerable<UserMessageWithUsernameDTO>  GetUserMessages()
        {
            var userMessages = _repositories.UserMessages.GetAll().Include(x => x.User).ToList();
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