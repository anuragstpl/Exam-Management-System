using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class QuestionnaireData
    {
        public int QuestionnaireID { get; set; }
        public string Name { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Subject { get; set; }
    }
}
