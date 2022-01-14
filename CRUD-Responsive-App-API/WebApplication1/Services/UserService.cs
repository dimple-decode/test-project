using AutoMapper;
using CRUD_Reponsive_Web_API.Entities;
using CRUD_Reponsive_Web_API.Interfaces;
using CRUD_Reponsive_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_Reponsive_Web_API.Services
{
    public class UserService : IUserService
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public UserService(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddUser(UserModel user, bool forUnitTest = false)
        {
            try
            {
                bool isSuccess = false;
                if (!forUnitTest)
                {
                    user.Id = Guid.NewGuid().ToString();
                    user.Document.DocumentId = Guid.NewGuid().ToString();
                    var userEntity = _mapper.Map<User>(user);
                    var document = _mapper.Map<Document>(user.Document);
                    userEntity.Document = document;
                    await _context.Users.AddAsync(userEntity);
                    isSuccess = await _context.SaveChangesAsync() > 0 ? true : false;
                }

                if (forUnitTest) return false; else return isSuccess;
            }
            catch(Exception e)
            {
                return false;
            }
           
        }

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user != null)
            {
                _context.Remove(user);
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }

            return false;
        }

        public async Task<bool> EditUser(string id, UserModel user)
        {
            var userDetail = await _context.Users.Include(x=>x.Document).FirstOrDefaultAsync(x=>x.Id.Equals(id));
            try
            {
                if (userDetail != null)
                {
                    userDetail.FirstName = user.FirstName;
                    userDetail.DateOfBirth = user.DateOfBirth;
                    userDetail.LastName = user.LastName;
                    userDetail.Document = _mapper.Map<Document>(user.Document);
                    _context.Users.Update(userDetail);
                    return await _context.SaveChangesAsync() > 0 ? true : false;
                }
                return false;
            }
         
            catch(Exception e)
            {
                return false;
            }
           
        }

        public async Task<UserModel> GetUser(string id)
        {
            var user = await _context.Users.Include(x=>x.Document).FirstOrDefaultAsync(x=>x.Id.Equals(id));
            return _mapper.Map<UserModel>(user); ;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var users = await _context.Users.Include(x=>x.Document).ToListAsync();
            return _mapper.Map<List<UserModel>>(users);
        }
    }
}
