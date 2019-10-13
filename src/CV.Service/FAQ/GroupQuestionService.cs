using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Data.Entities.FAQ;
using CV.Data.Enum;
using CV.Data.Model.FAQ;
using CV.Service.Interface.FAQ;
using CV.Utils.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV.Service.FAQ
{
    public class GroupQuestionService : IGroupQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<GroupQuestion> _groupQuestionRepo;
        private readonly IUnitOfWork _uow;

        public GroupQuestionService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _groupQuestionRepo = _uow.GetRepository<GroupQuestion>();
        }

        public void Delete(string id, string userId)
        {
            try
            {
                var gQuestion = _groupQuestionRepo.GetById(id);
                gQuestion.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                gQuestion.DeletedBy = userId;
                _groupQuestionRepo.Update(gQuestion);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<GroupQuestionModel> GetAll(Languages? lang, bool allowInclude = false)
        {
            var query = _groupQuestionRepo.TableNoTracking;

            if (lang != null)
                query = query.Where(x => x.Lang == lang.Value);

            if (allowInclude)
                query = query.Include(x => x.Question);

            return query.ProjectTo<GroupQuestionModel>(_mapper.ConfigurationProvider).ToList();
        }

        public GroupQuestionModel GetGroupQuestion(string id)
        {
            var query = _groupQuestionRepo.GetById(id);
            return _mapper.Map<GroupQuestionModel>(query);
        }

        public GroupQuestionModel Insert(string userCurrentId, GroupQuestionModel groupQuestion)
        {
            try
            {
                var newGQuestion = _mapper.Map<GroupQuestion>(groupQuestion);
                newGQuestion.CreatedBy = userCurrentId;
                newGQuestion.Slug = StringHelper.ToUrlFriendly(groupQuestion.Name);
                _groupQuestionRepo.Insert(newGQuestion);
                return groupQuestion;
            }
            catch
            {
                throw;
            }
        }

        public GroupQuestionModel Update(string groupQuestionId, string userCurrentId, GroupQuestionModel groupQuestion)
        {
            try
            {
                var updateGQuestion = _groupQuestionRepo.GetById(groupQuestionId);

                _mapper.Map(groupQuestion, updateGQuestion);
                updateGQuestion.LastUpdatedBy = userCurrentId;
                _groupQuestionRepo.Update(updateGQuestion);

                return groupQuestion;
            }
            catch
            {
                throw;
            }
        }
    }
}
