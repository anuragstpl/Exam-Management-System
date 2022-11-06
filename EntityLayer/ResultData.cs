using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class ResultData
    {
        public int ResultID { get; set; }
        public string Username { get; set; }
        public Nullable<int> QuestionnaireID { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<int> Total { get; set; }
        public Nullable<int> CorrectAnswer { get; set; }
        public Nullable<int> InCorrectAnswer { get; set; }
        public string SubmissionTime { get; set; }
    }
}
