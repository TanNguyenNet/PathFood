using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Data.Entities.FAQ;
using CV.Data.Model.FAQ;
using CV.Service.Interface.FAQ;
using CV.Utils.Helper;
using CV.Utils.Utils.Web.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV.Service.FAQ
{
    public class QuestionService : IQuestionService
    {

        private readonly IMapper _mapper;
        private readonly IRepository<Question> _questionRepo;
        private readonly IUnitOfWork _uow;

        public QuestionService(IMapper mapper,IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _questionRepo = _uow.GetRepository<Question>();

        }

        public void Delete(string id, string userId)
        {
            try
            {
                var question = _questionRepo.GetById(id);
                question.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                question.DeletedBy = userId;
                _questionRepo.Update(question);
            }
            catch
            {

                throw;
            }
        }

        public PagedResult<QuestionModel> GetAll(int page = 1, int pageSize = 20, string filter = "")
        {
            var query = _questionRepo.TableNoTracking;

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Name.Contains(filter));

            query = query.OrderBy(x => x.Name)
               .Skip((page - 1) * pageSize).Take(pageSize);

            var paginationSet = new PagedResult<QuestionModel>()
            {
                Results = query.ProjectTo<QuestionModel>(_mapper.ConfigurationProvider).ToList(),
                CurrentPage = page,
                RowCount = query.Count(),
                PageSize = pageSize
            };
            return paginationSet;
        }

        public QuestionModel GetQuestion(string id)
        {
            var query = _questionRepo.GetById(id);

            return _mapper.Map<QuestionModel>(query);
        }

        public QuestionModel GetQuestionSlug(string slug)
        {
            var query = _questionRepo.TableNoTracking.Where(x => x.Slug == slug).FirstOrDefault();

            return _mapper.Map<QuestionModel>(query);
        }

        public QuestionModel Insert(string userCurrent, QuestionModel question)
        {
            try
            {
                var newQuestion = _mapper.Map<Question>(question);

                newQuestion.CreatedBy = userCurrent;
                _questionRepo.Insert(newQuestion);

                return question;
            }
            catch
            {
                throw;
            }
        }

        public QuestionModel Update(string id, string userCurrentId, QuestionModel question)
        {
            try
            {
                var updateQuestion = _questionRepo.GetById(id);

                _mapper.Map(question, updateQuestion);
                updateQuestion.LastUpdatedBy = userCurrentId;

                _questionRepo.Update(updateQuestion);
                return question;
            }
            catch
            {

                throw;
            }
        }
    }
}
