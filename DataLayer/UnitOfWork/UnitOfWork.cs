using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        ExamSystemEntities context = new ExamSystemEntities();

        OnlineExamRepository<User> userRepository;
        OnlineExamRepository<Questionnaire> questionnaireRepository;
        OnlineExamRepository<Question> questionRepository;
        OnlineExamRepository<Answer> answerRepository;
        OnlineExamRepository<Result> resultRepository;

        public OnlineExamRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new OnlineExamRepository<User>(context);
                return userRepository;
            }
        }

        public OnlineExamRepository<Questionnaire> QuestionnaireRepository
        {
            get
            {
                if (this.questionnaireRepository == null)
                    this.questionnaireRepository = new OnlineExamRepository<Questionnaire>(context);
                return questionnaireRepository;
            }
        }

        public OnlineExamRepository<Question> QuestionRepository
        {
            get
            {
                if (this.questionRepository == null)
                    this.questionRepository = new OnlineExamRepository<Question>(context);
                return questionRepository;
            }
        }

        public OnlineExamRepository<Answer> AnswerRepository
        {
            get
            {
                if (this.answerRepository == null)
                    this.answerRepository = new OnlineExamRepository<Answer>(context);
                return answerRepository;
            }
        }

        public OnlineExamRepository<Result> ResultRepository
        {
            get
            {
                if (this.resultRepository == null)
                    this.resultRepository = new OnlineExamRepository<Result>(context);
                return resultRepository;
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<T> SQLQuery<T>(string sql)
        {
            return context.Database.SqlQuery<T>(sql);
        }

        public virtual IEnumerable<T> SQLQueryWithParameters<T>(string sql, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(sql, parameters);
        }

    }
}
