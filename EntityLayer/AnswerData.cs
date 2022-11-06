using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class AnswerData
    {
        public int AnswerID { get; set; }
        public int QuestionID { get; set; }
        public string AnswerOne { get; set; }
        public string AnswerTwo { get; set; }
        public string AnswerThree { get; set; }
        public string AnswerFour { get; set; }
        public string CorrectAnswer { get; set; }
        public Nullable<int> Reward { get; set; }
    }
}
