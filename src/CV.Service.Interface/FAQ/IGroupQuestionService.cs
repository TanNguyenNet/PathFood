using CV.Data.Enum;
using CV.Data.Model.FAQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.FAQ
{
    public interface IGroupQuestionService
    {
        GroupQuestionModel GetGroupQuestion(string id);

        IEnumerable<GroupQuestionModel> GetAll(Languages? lang);

        GroupQuestionModel Insert(string userCurrentId, GroupQuestionModel groupQuestion);

        GroupQuestionModel Update(string groupQuestionId, string userCurrentId, GroupQuestionModel groupQuestion);

        void Delete(string id, string userId);
    }
}
