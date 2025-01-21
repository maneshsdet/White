using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using OpenQA.Selenium;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CommonComponents
{
    public static class ExamAnswers
    {
        public static Dictionary<string, string> examAnswerinfo = new Dictionary<string, string>();
        public static Dictionary<string, string> securityAnswerinfo = new Dictionary<string, string>();
        public static Dictionary<string, string> answerinfo = new Dictionary<string, string>();
        public static Dictionary<string, string> securityquizinfo = new Dictionary<string, string>();
        public static Random rnd = new Random();
        public static string Answers(IWebDriver _driver, string email, string finishID, string accesscode, string confirmationCLASS)
        {
            try
            {
                //if (email.StartsWith("EI_"))
                answerinfo = DBConnection.RetrieveKVPDict(RegressionQueries.CorrectAnswers(email), "Question", "AnswerText");
                //else
                //    answerinfo = 
                Wait.DefaultWait(2);
                //Wait.WaitForElementClickable(_driver, _driver.FindElement(By.Id("" + nextID + "")), 20);
                Wait.WaitForElementClickable(_driver, _driver.FindElement(By.XPath("//a[contains(@id,'_cmdNext')]")), 20);
                int i = 0;
                while (i < answerinfo.Count)
                {
                    try
                    {
                        //_driver.FindElement(By.XPath("//label[contains(.,'" + answerinfo[_driver.FindElement(By.Id("" + questionID + "")).Text] + "')]")).Click();
                        _driver.FindElement(By.XPath("//label[contains(.,'" + answerinfo[_driver.FindElement(By.XPath("//span[contains(@id,'lblQuestionText')]")).Text] + "')]")).Click();
                        i++;
                        if (i != answerinfo.Count - 1)
                            //Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.XPath("//label[contains(.,'" + answerinfo[_driver.FindElement(By.Id("" + questionID + "")).Text] + "')]")), 20);
                            Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.XPath("//label[contains(.,'" + answerinfo[_driver.FindElement(By.XPath("//span[contains(@id,'lblQuestionText')]")).Text] + "')]")), 20);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            //if (answerinfo[_driver.FindElement(By.Id("" + questionID + "")).Text].Contains("'"))
                            if (answerinfo[_driver.FindElement(By.XPath("//span[contains(@id,'lblQuestionText')]")).Text].Contains("'"))
                            {
                                //_driver.FindElement(By.XPath("//label[contains(.,'" + answerinfo[_driver.FindElement(By.Id("" + questionID + "")).Text].Split('\'')[0] + "')]")).Click();
                                _driver.FindElement(By.XPath("//label[contains(.,'" + answerinfo[_driver.FindElement(By.XPath("//span[contains(@id,'lblQuestionText')]")).Text].Split('\'')[0] + "')]")).Click();
                                i++;
                                Wait.DefaultWait(1);
                            }
                        }
                        catch (Exception)
                        {
                            try
                            {
                                _driver.FindElement(By.XPath("//label[contains(.,'" + securityAnswerinfo[_driver.FindElement(By.XPath("//span[contains(@id,'lblQuestionText')]")).Text] + "')]")).Click();
                            }
                            catch (Exception)
                            {
                                //_driver.FindElement(By.Id("" + answerID + "" + Constants.rand.Next(0, 3))).Click();
                                _driver.FindElement(By.Id("" + _driver.FindElement(By.XPath("//input[contains(@id,'QuestionAnswer_')]")).GetAttribute("id").Remove(_driver.FindElement(By.XPath("//input[contains(@id,'QuestionAnswer_')]")).GetAttribute("id").Length - 1) + "" + Constants.rand.Next(0, 3))).Click();
                                Wait.DefaultWait(1);
                                i++;
                            }
                        }
                    }
                    //_driver.FindElement(By.Id("" + nextID + "")).Click();
                    _driver.FindElement(By.XPath("//a[contains(@id,'_cmdNext')]")).Click();
                    //  i++;
                }
                Wait.DefaultWait(8);

                if (!string.IsNullOrEmpty(accesscode))
                    _driver.FindElement(By.Id("" + finishID + "")).SendKeys(accesscode);
                //_driver.FindElement(By.Id("" + gradeexamID + "")).Click();
                _driver.FindElement(By.XPath("//a[contains(@id,'cmdGradeExam')]")).Click();
                Wait.DefaultWait(6);
                return _driver.FindElement(By.XPath("//div[@class='" + confirmationCLASS + "']")).Text;
            }
            catch (Exception e)
            {
                Assertions.FailCase(MethodBase.GetCurrentMethod().Name, e.Message, _driver);
                return null;
            }
        }

        public static void AHLEI_Answers(IWebDriver _driver, string exam)
        {
            try
            {
                Dictionary<string, string> answerinfo;

                switch (exam)
                {
                    case "70_714_14_16_10_03_EN": //Food Safety and Quality Management, Third Edition Exam (ExamFlex)
                        answerinfo = EI_ExamAnswers.EI_70_714_14_16_10_03_EN;
                        break;

                    case "70_701_14_16_10_06_EN": //Supervision in the Hospitality Industry, Sixth Edition Exam (ExamFlex)
                        answerinfo = EI_ExamAnswers.EI_70_701_14_16_10_06_EN;
                        break;

                    default: ////Food Safety and Quality Management, Third Edition Exam (ExamFlex)
                        answerinfo = EI_ExamAnswers.EI_70_714_14_16_10_03_EN;
                        break;
                }

                Wait.DefaultWait(2);

                //Start exam
                int i = 0;
                while (i < answerinfo.Count)
                {
                    try
                    {
                        Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.ClassName("next-question")), 10);
                        IWebElement NextQuestion = _driver.FindElement(By.ClassName("next-question"));
                        var _question_element = _driver.FindElement(By.ClassName("questionStem"));
                        var question_text = _question_element.Text;
                        string answer_text;
                        IWebElement answer_element;

                        //assign answer text to local variable
                        answerinfo.TryGetValue(question_text, out answer_text);

                        //Account for answers with single quotes causing issues with the XPath string
                        if (answer_text.Contains("'"))
                        {
                            answer_text = answer_text.Split("'")[0];
                        }

                        //Find Answer element based on the answer text
                        Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.XPath("//label[contains(.,'" + answer_text + "')]")), 10);
                        answer_element = _driver.FindElement(By.XPath("//label[contains(.,'" + answer_text + "')]"));

                        //Click the correct answer
                        JavaScript.JsClick(_driver, answer_element);
                        i++;

                        //Move to next Question
                        NextQuestion.Click();
                    }
                    catch (Exception e1)
                    {
                        try
                        {
                            //If something goes wrong such as the exam question is not recognized, pick a random answer then click next
                            var rand_selection = rnd.Next(0, 3);
                            Wait.WaitForElementDispalyed(_driver, _driver.FindElements(By.ClassName("choice"))[rand_selection], 10);
                            var random_answer = _driver.FindElements(By.ClassName("choice"))[rand_selection];
                            JavaScript.JsClick(_driver, random_answer);

                            Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.ClassName("next-question")), 10);
                            IWebElement NextQuestion = _driver.FindElement(By.ClassName("next-question"));
                            NextQuestion.Click();
                            i++;

                        }
                        catch (Exception e2)
                        {
                            //In the worst case we still want to click next and keep the exam going
                            Wait.DefaultWait(1);
                            Wait.WaitForElementDispalyed(_driver, _driver.FindElement(By.ClassName("next-question")), 10);
                            IWebElement NextQuestion = _driver.FindElement(By.ClassName("next-question"));
                            NextQuestion.Click();
                            i++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Assertions.FailCase(MethodBase.GetCurrentMethod().Name, e.Message, _driver);
            }
        }

        public static void SecurityAnswers(IWebDriver _driver, string questionId, string answerId, string nextId, string finishId)
        {
            Wait.WaitForElementClickable(_driver, _driver.FindElement(By.Id("" + nextId + "")), 20);
            securityAnswerinfo.Clear();
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    int k = Constants.rand.Next(0, 3);
                    securityAnswerinfo.Add(_driver.FindElement(By.Id("" + questionId + "")).Text, _driver.FindElement(By.XPath("//label[@for='" + answerId + "" + k + "']")).GetAttribute("innerHTML"));
                    _driver.FindElement(By.Id("" + answerId + "" + k)).Click();
                    Wait.DefaultWait(1);
                    _driver.FindElement(By.Id("" + nextId + "")).Click();
                }
                catch (Exception)
                {
                    if (_driver.FindElement(By.Id("" + finishId + "")).Displayed)
                    {
                        _driver.FindElement(By.Id("" + finishId + "")).Click();
                        break;
                    }
                }
            }
        }

        public static void SecurityQuiz(IWebDriver _driver, string questionId, string answerId, string nextId, string finishId, string email)
        {
            securityquizinfo = DBConnection.RetrieveKVPDict(RegressionQueries.SecurityQuizAnswers(email), "QuestionSequence", "AnswerIdentifier");
            Wait.WaitForElementClickable(_driver, _driver.FindElement(By.Id("" + nextId + "")), 20);
            for (int i = 0; i < securityquizinfo.Count; i++)
            {
                try
                {
                    _driver.FindElement(By.Id("" + answerId + "" + AnswersMapping[securityquizinfo[(i + 1).ToString()]])).Click();
                    Wait.DefaultWait(1);
                    _driver.FindElement(By.Id("" + nextId + "")).Click();
                }
                catch (Exception e)
                {
                    try
                    {
                        _driver.FindElement(By.Id("" + answerId + "" + AnswersMapping[Constants.rand.Next(1, 4).ToString()])).Click();
                        Wait.DefaultWait(1);
                        _driver.FindElement(By.Id("" + nextId + "")).Click();
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine(e1.Message);
                    }
                }

            }

            try
            {
                if (_driver.FindElement(By.Id("" + finishId + "")).Displayed)
                {
                    _driver.FindElement(By.Id("" + finishId + "")).Click();
                }
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
            }
        }

        public static void SecurityQuizFail(IWebDriver _driver, string questionId, string answerId, string nextId, string finishId, string email)
        {
            securityquizinfo = DBConnection.RetrieveKVPDict(RegressionQueries.SecurityQuizAnswers(email), "QuestionSequence", "AnswerIdentifier");
            Wait.WaitForElementClickable(_driver, _driver.FindElement(By.Id("" + nextId + "")), 20);
            for (int i = 0; i < securityquizinfo.Count; i++)
            {
                try
                {
                    // _driver.FindElement(By.Id("" + answerId + "" + AnswersMapping[Constants.rand.Next(1, 4).ToString()])).Click();
                    _driver.FindElement(By.Id("" + answerId + "" + Constants.rand.Next(0, 1).ToString())).Click();
                    Wait.DefaultWait(1);
                    _driver.FindElement(By.Id("" + nextId + "")).Click();
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.Message);
                }

            }

            try
            {
                if (_driver.FindElement(By.Id("" + finishId + "")).Displayed)
                {
                    _driver.FindElement(By.Id("" + finishId + "")).Click();
                }
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
            }
        }

        public static string FailAnswers(IWebDriver _driver, string email, string finishID, string accesscode, string confirmationCLASS)
        {
            try
            {
                //if (email.StartsWith("EI_"))
                answerinfo = DBConnection.RetrieveKVPDict(RegressionQueries.CorrectAnswers(email), "Question", "AnswerText");
                //else
                //    answerinfo = 
                Wait.DefaultWait(2);
                //Wait.WaitForElementClickable(_driver, _driver.FindElement(By.Id("" + nextID + "")), 20);
                Wait.WaitForElementClickable(_driver, _driver.FindElement(By.XPath("//a[contains(@id,'_cmdNext')]")), 20);
                int i = 0;
                while (i < answerinfo.Count)
                {
                    try
                    {
                        _driver.FindElement(By.XPath("//label[contains(.,'" + securityAnswerinfo[_driver.FindElement(By.XPath("//span[contains(@id,'lblQuestionText')]")).Text] + "')]")).Click();
                        Wait.DefaultWait(1);
                    }
                    catch
                    {
                        _driver.FindElement(By.Id("" + _driver.FindElement(By.XPath("//input[contains(@id,'QuestionAnswer_')]")).GetAttribute("id").Remove(_driver.FindElement(By.XPath("//input[contains(@id,'QuestionAnswer_')]")).GetAttribute("id").Length - 1) + "" + Constants.rand.Next(0, 0))).Click();
                        Wait.DefaultWait(1);
                        i++;
                    }
                    _driver.FindElement(By.XPath("//a[contains(@id,'_cmdNext')]")).Click();
                }
                Wait.DefaultWait(8);

                if (!string.IsNullOrEmpty(accesscode))
                    _driver.FindElement(By.Id("" + finishID + "")).SendKeys(accesscode);
                //_driver.FindElement(By.Id("" + gradeexamID + "")).Click();
                _driver.FindElement(By.XPath("//a[contains(@id,'cmdGradeExam')]")).Click();
                Wait.DefaultWait(6);
                return _driver.FindElement(By.XPath("//div[@class='" + confirmationCLASS + "']")).Text;
            }
            catch (Exception e)
            {
                Assertions.FailCase(MethodBase.GetCurrentMethod().Name, e.Message, _driver);
                return null;
            }
        }
        public static Dictionary<string, int> AnswersMapping = new Dictionary<string, int>()
        {
            {"A",0},
            {"B",1},
            {"C",2},
            {"D",3}
        };

        public static Dictionary<string, int> WrongAnswersMapping = new Dictionary<string, int>()
        {
            {"A",1},
            {"B",2},
            {"C",3},
            {"D",0}
        };
        public static string ExactPassAnwers(IWebDriver _driver, string email, string finishID, string accesscode, string confirmationCLASS)
        {
            try
            {
                answerinfo = DBConnection.RetrieveKVPDict(RegressionQueries.CorrectAnswers(email), "Question", "AnswerText");
                //    answerinfo = 
                Wait.DefaultWait(2);
                Wait.WaitForElementClickable(_driver, _driver.FindElement(By.XPath("//a[contains(@id,'_cmdNext')]")), 20);
                int i = 0;
                int perccount = int.Parse(DBConnection.SelectColumnValue("Select PassingScore*NumberOfQuestions/100 as percentagepass from mms.. Exam Where Status = 'Active' and CourseId = '115' and DeliveryType = 'web' and  Language like '%Viet%'"));
                //int perccount = 3;
                while (i < answerinfo.Count)
                {
                    if (i < perccount)
                    {
                        try
                        {
                            _driver.FindElement(By.XPath("//label[contains(.,'" + answerinfo[_driver.FindElement(By.XPath("//span[contains(@id,'lblQuestionText')]")).Text] + "')]")).Click();
                            i++;
                            Wait.DefaultWait(1);
                        }
                        catch (Exception)
                        {
                            try
                            {
                                if (answerinfo[_driver.FindElement(By.XPath("//span[contains(@id,'lblQuestionText')]")).Text].Contains("'"))
                                {
                                    _driver.FindElement(By.XPath("//label[contains(.,'" + answerinfo[_driver.FindElement(By.XPath("//span[contains(@id,'lblQuestionText')]")).Text].Split('\'')[0] + "')]")).Click();
                                    i++;
                                    Wait.DefaultWait(1);
                                }
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    _driver.FindElement(By.XPath("//label[contains(.,'" + securityAnswerinfo[_driver.FindElement(By.XPath("//span[contains(@id,'lblQuestionText')]")).Text] + "')]")).Click();
                                }
                                catch (Exception)
                                {
                                    _driver.FindElement(By.Id("" + _driver.FindElement(By.XPath("//input[contains(@id,'QuestionAnswer_')]")).GetAttribute("id").Remove(_driver.FindElement(By.XPath("//input[contains(@id,'QuestionAnswer_')]")).GetAttribute("id").Length - 1) + "" + Constants.rand.Next(0, 3))).Click();
                                    Wait.DefaultWait(1);
                                    i++;
                                }
                            }
                        }
                    }
                    else
                    {
                        _driver.FindElement(By.Id("" + _driver.FindElement(By.XPath("//input[contains(@id,'QuestionAnswer_')]")).GetAttribute("id").Remove(_driver.FindElement(By.XPath("//input[contains(@id,'QuestionAnswer_')]")).GetAttribute("id").Length - 1) + "" + WrongAnswersMapping[DBConnection.SelectColumnValue(RegressionQueries.AnswerIdentifier(email, _driver.FindElement(By.XPath("//span[contains(@id,'lblQuestionText')]")).Text))])).Click();
                        Wait.DefaultWait(1);
                        i++;
                    }
                    _driver.FindElement(By.XPath("//a[contains(@id,'_cmdNext')]")).Click();
                }
                Wait.DefaultWait(8);

                if (!string.IsNullOrEmpty(accesscode))
                    _driver.FindElement(By.Id("" + finishID + "")).SendKeys(accesscode);
                //_driver.FindElement(By.Id("" + gradeexamID + "")).Click();
                _driver.FindElement(By.XPath("//a[contains(@id,'cmdGradeExam')]")).Click();
                Wait.DefaultWait(6);
                return _driver.FindElement(By.XPath("//div[@class='" + confirmationCLASS + "']")).Text;
            }
            catch (Exception e)
            {
                Assertions.FailCase(MethodBase.GetCurrentMethod().Name, e.Message, _driver);
                return null;
            }
        }
    }
}
