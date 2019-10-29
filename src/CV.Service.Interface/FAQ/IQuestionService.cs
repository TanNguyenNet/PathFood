using CV.Data.Enum;
using CV.Data.Model.FAQ;
using CV.Utils.Utils.Web.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.FAQ
{
    public interface IQuestionService
    {
        QuestionModel GetQuestion(string id);

        QuestionModel GetQuestionSlug(string slug);

        PagedResult<QuestionModel> GetPagedAll(int page = 1, int pageSize = 20, string filter = "",bool include = false);

        IEnumerable<QuestionModel> GetAll(string filter = "", Languages? lang = Languages.Vi);

        QuestionModel Insert(string userCurrent, QuestionModel question);

        QuestionModel Update(string id, string userCurrentId, QuestionModel question);

        void Delete(string id, string userId);
    }
}
