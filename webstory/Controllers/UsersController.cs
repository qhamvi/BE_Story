using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webstory.Dtos;
using webstory.Entities;
using webstory.Repositories;

namespace webstory.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly UUsersRepository User_Repository ;
        public UsersController(UUsersRepository repository)
        {
            this.User_Repository = repository ;
        }

        //GET /users
        [HttpGet]
        public IEnumerable<UserDto> GetUsers()
        {
            var users = User_Repository.GetUsers().Select(user => user.AsUserDto());
            return users ;
        }
        //GET /users / {idUser}
        [HttpGet("{idUser}")]
        public ActionResult<UserDto> GetUser(Guid idUser)
        {
            var user = User_Repository.GetUser(idUser);
            if (user is null)
            {
                return NotFound();
            }
            return user.AsUserDto() ;
        }
        //POST /users/admins COLLECTOR
        [HttpPost("admins")]
        public ActionResult<UserDto> CreateAdmin (CreateUserDto userDto)
        {
            User user = new User {
                 id = Guid.NewGuid(),
                username = userDto.username,
                password = userDto.password,
                idRole = "Admin",
                fullName = "",
                phone ="",
                email="",
                country="",
                createDate= DateTimeOffset.UtcNow,
                like=null,
                history=null
            };
            User_Repository.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new {idUser = user.id}, user.AsUserDto());
        }
        //POST /users/collectors COLLECTOR
        [HttpPost("collectors")]
        public ActionResult<UserDto> CreateCollector (CreateUserDto userDto)
        {
            User user = new User {
                 id = Guid.NewGuid(),
                username = userDto.username,
                password = userDto.password,
                idRole = "Collector",
                fullName = "",
                phone ="",
                email="",
                country="",
                createDate= DateTimeOffset.UtcNow,
                like=null,
                history=null
            };
            User_Repository.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new {idUser = user.id}, user.AsUserDto());
        }

        //POST /users /members /MEMBER
        [HttpPost("members")]
        public ActionResult<UserDto> CreateMember(CreateUserDto userDto)
        {
            User user = new User {
                id = Guid.NewGuid(),
                username = userDto.username,
                password = userDto.password,
                idRole = "Member",
                fullName = "",
                phone ="",
                email="",
                country="",
                createDate= DateTimeOffset.UtcNow,
                like=null,
                history=null
            };
            User_Repository.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new {idUser = user.id}, user.AsUserDto());

        }
        //PUT /users /{idUser} --Cai lai thong tin ca nhan
        [HttpPut("{idUser}")]
        public ActionResult<UserDto> UpdateUser(Guid idUser,UpdateUserDto userDto)
        {
            var existingUser = User_Repository.GetUser(idUser);
            if(existingUser is null)
            {
                return NotFound();
            }
            User updateUser = existingUser with
            {
                username = userDto.username,
                password = userDto.password,
                photo = userDto.photo,
                fullName = userDto.fullName,
                phone = userDto.phone,
                email = userDto.email,
                country = userDto.country,
                // like = userDto.like,
                // history = userDto.history
            };
            User_Repository.UpdateUser(updateUser);
            return NoContent();
        }
        //PUT /users /like/{idUser} // Cap nhat gia tri like (yeu thich)
        [HttpPut("like/{idUser}")]
        public ActionResult<UserDto> UpdateLike(Guid idUser,UpdateLikeDto userDto)
        {
            var existingUser = User_Repository.GetUser(idUser);
            if(existingUser is null)
            {
                return NotFound();
            }
            User updateUser = existingUser with
            {

                like = userDto.like
                
            };
            User_Repository.UpdateUser(updateUser);
            return NoContent();
        }
        //PUT /users/history/{idUser} --Cap nhat gia tri history
        [HttpPut("history/{idUser}")]
        public ActionResult<UserDto> UpdateHistory(Guid idUser, UpdateHistoryDto userDto)
        {
            var existingUser = User_Repository.GetUser(idUser);
            if (existingUser is null)
            {
                return NotFound() ;
            }
            User updateUser = existingUser with 
            {
                history = userDto.history
            };
            User_Repository.UpdateUser(updateUser);
            return NoContent() ;
        }
        //DELETE /users/{idUser} 
        [HttpDelete("{idUser}")]
        public ActionResult<UserDto> DeleteUser(Guid idUser)
        {
            var existingUser = User_Repository.GetUser(idUser);
            if(existingUser is null)
            {
                return NotFound() ;
            }
            User_Repository.DeleteUser(idUser);
            return NoContent() ;
        }
       
    }
}