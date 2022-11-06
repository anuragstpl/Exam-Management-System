using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class QuestionAnswerData
    {
        public int AnswerID { get; set; }
        public int QuestionID { get; set; }
        public string AnswerOne { get; set; }
        public string AnswerTwo { get; set; }
        public string AnswerThree { get; set; }
        public string AnswerFour { get; set; }
        public string CorrectAnswer { get; set; }
        public Nullable<int> Reward { get; set; }

        public string Question1 { get; set; }
        public string Createdon { get; set; }
        public string CreatedBy { get; set; }
        public string GivenAnswer { get; set; }
    }
}
