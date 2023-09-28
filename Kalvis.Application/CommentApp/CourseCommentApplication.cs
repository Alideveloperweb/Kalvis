using Kalvis.Common.Application;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel;
using Kalvis.Contract.CommentViewModel.CourseCommentViewModel.Interface;
using Kalvis.Domain.EducationEntities.CommentEntities;
using Kalvis.Domain.EducationEntities.CommentEntities.Interface;
using System.Collections.Generic;

namespace Kalvis.Application.CommentApp
{
    public class CourseCommentApplication : ICourseCommentApplication
    {

        #region Constracture
        private readonly ICourseCommentRepository _CommentRep;
        private readonly ICourseAnswerCommentRepository _AnswerRep;
        public CourseCommentApplication(
            ICourseCommentRepository CommentRep,
            ICourseAnswerCommentRepository _AnswerRep)
        {
            this._AnswerRep = _AnswerRep;
            this._CommentRep = CommentRep;
        }
        #endregion

        public List<GetAllCourseCommetItem> GetAllCourseComment(bool IsRemove)
        {
            return _CommentRep.GetAllCourseComment(IsRemove);
        }

        public GetCourseCommentItem GetCommentById(long CommentId)
        {
            return _CommentRep.GetCommentById(CommentId);
        }

        public OperationResult AcceptComment(GetCourseCommentItem GetComment)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("کامنت");
            CourseComment courseComment =
                _CommentRep.Get(GetComment.CommentId);

            if (courseComment == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            courseComment.Accept();

            bool Update = _CommentRep.Update(courseComment);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool Save = _CommentRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Update());

        }

        public OperationResult EditComment(GetCourseCommentItem GetComment)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("کامنت");

            CourseComment courseComment =
                _CommentRep.Get(GetComment.CommentId);

            if (courseComment == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            courseComment.Edit(GetComment.CommentText, true);

            bool Update = _CommentRep.Update(courseComment);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool Save = _CommentRep.SaveChanges();
            if (!Save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Update());

        }

        public List<GetAllCommentQueryItem> GetAllComment(long CourseID)
        {
            return _CommentRep.GetAllComment(CourseID);
        }

        public OperationResult CreateComment(CreateCommentAndAnswerItem Create)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("کامنت");

            CourseComment comment = new(Create.UserID,
                Create.Text, Create.CourseID);

            bool create = _CommentRep.Create(comment);
            if (!create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool save = _CommentRep.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Create());

        }

        public OperationResult CreateAnswer(CreateCommentAndAnswerItem Create)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("پاسخ");

            AnswerComment comment = new(Create.UserID,
                Create.Text, Create.CommentID);

            bool create = _AnswerRep.Create(comment);
            if (!create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool save = _AnswerRep.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Create());

        }
    }
}
