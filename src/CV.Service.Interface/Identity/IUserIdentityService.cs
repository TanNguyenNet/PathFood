using CV.Data.Model.Identity;
using CV.Utils.Utils.Web.Page;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CV.Service.Interface.Identity
{
    public interface IUserIdentityService
    {
        AppUserModel GetUser(string id);

        PagedResult<AppUserModel> GetAll(int page = 1, int pageSize = 20, string filter = "");

        AppUserModel Insert(AppUserModel user);

        Task<AppUserUpdateModel> Update(string id, AppUserUpdateModel user);

        

    }
}
