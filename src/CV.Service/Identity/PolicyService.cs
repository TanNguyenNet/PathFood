using AutoMapper;
using CV.Data.Authorization;
using CV.Data.Model.Identity;
using CV.Service.Interface.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CV.Service.Identity
{
    public class PolicyService : IPolicyService
    {
        private readonly IMapper _mapper;
        public PolicyService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<ClaimRequirementModel> GetAll()
        {
            var listClaim = new List<Claim>
            {
                new Claim(nameof(ContantPolicy.User),ContantPolicy.User.ReadUserData),
                new Claim(nameof(ContantPolicy.User),ContantPolicy.User.UpdateUserData),
                new Claim(nameof(ContantPolicy.User),ContantPolicy.User.InsertUserData),
                new Claim(nameof(ContantPolicy.User),ContantPolicy.User.DeleteUserData)
            };

            return _mapper.Map<IEnumerable<ClaimRequirementModel>>(listClaim);
        }
    }
}
