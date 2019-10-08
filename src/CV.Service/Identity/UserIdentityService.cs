using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Data.Entities.Identity;
using CV.Data.Model.Identity;
using CV.Service.Interface.Identity;
using CV.Utils.Helper;
using CV.Utils.Utils.Web.Page;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CV.Service.Identity
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserIdentityService(UserManager<AppUser> userManager, IMapper mapper, IUnitOfWork uow)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public PagedResult<AppUserModel> GetAll(int page = 1, int pageSize = 20, string filter = "")
        {
            var query = _userManager.Users.Where(x => x.DeletedDate == null);

            query = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var paginationSet = new PagedResult<AppUserModel>()
            {
                Results = query.ProjectTo<AppUserModel>(_mapper.ConfigurationProvider).ToList(),
                CurrentPage = page,
                RowCount = query.Count(),
                PageSize = pageSize
            };
            return paginationSet;
        }

        public AppUserModel GetUser(string id)
        {
            var user = _userManager.FindByIdAsync(id);
            user.Wait();
            var userModel = _mapper.Map<AppUserModel>(user.Result);
            var claims = _userManager.GetClaimsAsync(user.Result);
            claims.Wait();
            userModel.Claims = _mapper.Map<IEnumerable<ClaimRequirementModel>>(claims.Result);
            return userModel;
        }

        public AppUserModel Insert(AppUserModel user)
        {
            try
            {
                var newUser = new AppUser();

                newUser.UserName = user.UserName;

                newUser.FirstName = user.FirstName;

                newUser.LastName = user.LastName;

                newUser.Email = user.Email;

                _userManager.CreateAsync(newUser, user.Password).Wait();

                foreach (var item in user.Claims)
                {
                    _userManager.AddClaimAsync(newUser, new Claim(item.ClaimName, item.ClaimValue)).Wait();
                }

                return user;
            }
            catch
            {
                throw;
            }
        }



        public async Task<AppUserUpdateModel> Update(string id, AppUserUpdateModel user)
        {
            try
            {
                var updateUser = await _userManager.FindByIdAsync(id);

                updateUser.LastName = user.LastName;
                updateUser.FirstName = user.FirstName;
                updateUser.Email = user.Email;
                updateUser.UpdatedDate = CoreHelper.SystemTimeNowUTCTimeZoneLocal;

                await _userManager.UpdateAsync(updateUser);

                var claims = await _userManager.GetClaimsAsync(updateUser);

                await _userManager.RemoveClaimsAsync(updateUser, claims);

                foreach (var item in user.Claims)
                {
                    _userManager.AddClaimAsync(updateUser, new Claim(item.ClaimName, item.ClaimValue)).Wait();
                }

                return user;

            }
            catch
            {
                throw;
            }
        }
    }
}
