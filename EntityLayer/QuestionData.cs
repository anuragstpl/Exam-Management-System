using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class QuestionData
    {
        public int QuestionID { get; set; }
        public string Question1 { get; set; }
        public string Createdon { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> QuestionnaireID { get; set; }
    }
}
