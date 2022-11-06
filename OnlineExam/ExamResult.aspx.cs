﻿using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBidding
{
    public partial class ExamResult : System.Web.UI.Page
    {
        QuestionnaireHelper questionnaireHelper = new QuestionnaireHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<QuestionAnswerData> lstQuestionnaireData = (List<QuestionAnswerData>)Session["questionnaire"];
            int marks = 0,correctanswers=0,incorrectanswers=0;
            foreach (QuestionAnswerData item in lstQuestionnaireData)
            {
                if (!String.IsNullOrEmpty(item.GivenAnswer))
                {
                    if (item.GivenAnswer.Trim().Equals(item.CorrectAnswer.Replace("Answer", "").Trim()))
                    {
                        marks += Convert.ToInt32(item.Reward);
                        correctanswers++;
                    }
                    else
                    {
                        incorrectanswers++;
                    }
                }
                else
                {
                    incorrectanswers++;
                }
            }
            lblScore.Text = marks.ToString();
            lblTotal.Text = "/" + lstQuestionnaireData.Sum(x => Convert.ToInt32(x.Reward)).ToString();
            lblCorrectAnswer.Text = correctanswers.ToString();
            lblIncorrectAnswer.Text = incorrectanswers.ToString();

            ResultData resData = new ResultData();
            resData.CorrectAnswer = correctanswers;
            resData.InCorrectAnswer = incorrectanswers;
            resData.QuestionnaireID = lstQuestionnaireData.FirstOrDefault().QuestionID;
            resData.Score = marks;
            resData.Total = lstQuestionnaireData.Sum(x => Convert.ToInt32(x.Reward));
            resData.Username = Session["Username"].ToString();
            questionnaireHelper.SaveResults(resData);
        }
    }
}