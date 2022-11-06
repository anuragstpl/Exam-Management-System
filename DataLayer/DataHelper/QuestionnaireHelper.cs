using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.UnitOfWork;
using EntityLayer;

namespace DataLayer.DataHelper
{

    public class QuestionnaireHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;
        public bool AddQuestionnaire(QuestionnaireData questionnaire)
        {
            bool isQuestionnaireAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Questionnaire questionnairedb = new Questionnaire();
                    questionnairedb.CreatedBy = questionnaire.CreatedBy;
                    questionnairedb.CreatedOn = DateTime.Now.ToString();
                    questionnairedb.Name = questionnaire.Name;
                    questionnairedb.Subject = questionnaire.Subject;
                    uow.QuestionnaireRepository.Insert(questionnairedb);
                    uow.Save();
                    isQuestionnaireAdded = true;
                }
                catch
                {
                    isQuestionnaireAdded = false;
                }
            }

            return isQuestionnaireAdded;
        }

        public List<QuestionnaireData> GetAllQuestionnaire()
        {
            List<QuestionnaireData> lstQuestionnaire = new List<QuestionnaireData>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstQuestionnaire = uow.QuestionnaireRepository.Get().Select(usd => new QuestionnaireData
                    {
                        CreatedBy = usd.CreatedBy,
                        CreatedOn = usd.CreatedOn,
                        Name = usd.Name,
                        QuestionnaireID = usd.QuestionnaireID,
                        Subject = usd.Subject
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstQuestionnaire;
        }

        public int AddQuestion(QuestionData question)
        {
            int QuestionID = 0;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Question questiondb = new Question();
                    questiondb.CreatedBy = question.CreatedBy;
                    questiondb.Createdon = DateTime.Now.ToString();
                    questiondb.Question1 = question.Question1;
                    questiondb.QuestionnaireID = question.QuestionnaireID;
                    uow.QuestionRepository.Insert(questiondb);
                    uow.Save();
                    QuestionID = questiondb.QuestionID;
                }
                catch
                {

                }
            }

            return QuestionID;
        }

        public bool EditQuestion(QuestionData question)
        {
            bool IsQuestionEdited = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Question questiondb = uow.QuestionRepository.Get().Where(u => u.QuestionID.Equals(question.QuestionID)).FirstOrDefault();
                    questiondb.CreatedBy = question.CreatedBy;
                    questiondb.Createdon = DateTime.Now.ToString();
                    questiondb.Question1 = question.Question1;
                    uow.QuestionRepository.Update(questiondb);
                    uow.Save();
                    IsQuestionEdited = true;
                }
                catch
                {

                }
            }

            return IsQuestionEdited;
        }

        public bool AddAnswer(AnswerData answer)
        {
            bool isAnswerAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Answer answerdb = new Answer();
                    answerdb.AnswerOne = answer.AnswerOne;
                    answerdb.AnswerTwo = answer.AnswerTwo;
                    answerdb.AnswerThree = answer.AnswerThree;
                    answerdb.AnswerFour = answer.AnswerFour;
                    answerdb.CorrectAnswer = answer.CorrectAnswer;
                    answerdb.QuestionID = answer.QuestionID;
                    answerdb.Reward = answer.Reward;
                    uow.AnswerRepository.Insert(answerdb);
                    uow.Save();
                    isAnswerAdded = true;
                }
                catch
                {
                    isAnswerAdded = false;
                }
            }

            return isAnswerAdded;
        }

        public bool EditAnswer(AnswerData answer)
        {
            bool isAnswerAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Answer answerdb = uow.AnswerRepository.Get().Where(u => u.QuestionID.Equals(answer.QuestionID)).FirstOrDefault();
                    answerdb.AnswerOne = answer.AnswerOne;
                    answerdb.AnswerTwo = answer.AnswerTwo;
                    answerdb.AnswerThree = answer.AnswerThree;
                    answerdb.AnswerFour = answer.AnswerFour;
                    answerdb.CorrectAnswer = answer.CorrectAnswer;
                    answerdb.Reward = answer.Reward;
                    uow.AnswerRepository.Update(answerdb);
                    uow.Save();
                    isAnswerAdded = true;
                }
                catch
                {
                    isAnswerAdded = false;
                }
            }

            return isAnswerAdded;
        }

        public List<QuestionAnswerData> GetAllQA(int QuestionnaireID)
        {
            List<QuestionAnswerData> lstQAData = new List<QuestionAnswerData>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstQAData = uow.QuestionnaireRepository.SQLQuery<QuestionAnswerData>("Select Question as Question1,* from Question qa inner join Answer an on qa.QuestionID=an.QuestionID where qa.QuestionnaireID=" + QuestionnaireID).ToList();
                }
                catch
                {

                }
            }
            return lstQAData;
        }

        public bool SaveResults(ResultData resData)
        {
            bool isSaveResults = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Result result = new Result();
                    result.CorrectAnswer = resData.CorrectAnswer;
                    result.InCorrectAnswer = resData.InCorrectAnswer;
                    result.QuestionnaireID = resData.QuestionnaireID;
                    result.Score = resData.Score;
                    result.SubmissionTime = DateTime.Now.ToString();
                    result.Total = resData.Total;
                    result.Username = resData.Username;
                    uow.ResultRepository.Insert(result);
                    uow.Save();
                    isSaveResults = true;
                }
                catch
                {
                    isSaveResults = false;
                }
            }

            return isSaveResults;
        }

        public List<ResultData> GetAllResults()
        {
            List<ResultData> lstresultData = new List<ResultData>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstresultData = uow.ResultRepository.SQLQuery<ResultData>("Select * from Results;").ToList();
                }
                catch
                {

                }
            }
            return lstresultData;
        }
    }
}
