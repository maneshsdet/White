using System;
using System.Collections.Generic;
using System.Text;

namespace CommonComponents
{
    public static class RegressionQueries
    {

        public static string CGI_MMS_Account(string email) => "select wu.FirstName as wuFirstName, wu.LastName as wuLastName,wu.Email as wuEmail, p.FirstName as peFirstName, p.LastName as peLastName, p.Country as peCountry,"
                                                            + " p.AddressLine1 as peAddressLine1, p.City as peCity, p.State as peState, p.ZipCode as peZipCode,"
                                                            + " p.Email1 as peEmail, p.PhoneAreaCode as pePhoneAreaCode, p.Phone as pePhone"
                                                            + " from CGIWeb..WebUser wu "
                                                            + " join MMS..person p on wu.LinkID = p.ID"
                                                            + " where wu.Email ='" + email + "'";
        public static string RegistrationNum(string ordernumber) => "select RegistrationNumber from MMS..RegistrationNumber where ImisOrderId = '" + ordernumber + "'";

        public static string SSICorrectAnswers(string examsession) => "SELECT eq.Question, eqa.AnswerText FROM   MMS..ExamQuestion eq"
                                                                + " JOIN MMS..ExamQuestionAnswers eqa"
                                                                + " ON eq.ExamID = eqa.ExamID"
                                                                + " AND eq.Sequence = eqa.QuestionSequence"
                                                                + " join MMS..ClassExam ce on ce.ExamID = eq.ExamID"
                                                                + " WHERE eqa.CorrectAnswer = 1"
                                                                + " and  ce.ClassID = '" + examsession + "'";
        public static string FHLessonLocationUpdate(string location, string key) => "update ds set lessonlocation = " + location
                                                                                + " from nraef..dotnetscorm_userscodata ds join nraef..lmscourseassignment a on a.usercourseid=ds.eventid"
                                                                                + " where a.licensekey = '" + key + "'";

        public static string CorrectAnswers(string email) => "Select Distinct eq.Question, eqa.AnswerText FROM   MMS..ExamQuestion eq,MMS..ExamQuestionAnswers eqa,MMS..ClassExam ce"
                                                                + " Where eq.ExamID = eqa.ExamID"
                                                                + " AND eq.Sequence = eqa.QuestionSequence"
                                                                + " AND ce.ExamID = eq.ExamID"
                                                                + " AND eqa.CorrectAnswer = 1"
                                                                + " AND eq.ExamID in (Select Distinct ExamID from mms..StagingAreaExamRecord SAER, CGIWeb..WebUser WU Where SAER.PersonID = WU.LinkID"
                                                                + " And saer.importProcess = 'Web' and WU.Email = '" + email + "')";

        public static string AnswerIdentifier(string email, string question) => "Select AnswerIdentifier FROM   MMS..ExamQuestion eq,MMS..ExamQuestionAnswers eqa,MMS..ClassExam ce"
                                                               + " Where eq.ExamID = eqa.ExamID"
                                                               + " AND eq.Sequence = eqa.QuestionSequence"
                                                               + " AND ce.ExamID = eq.ExamID"
                                                               + " AND eqa.CorrectAnswer = 1"
                                                               + " AND eq.Question like N'%" + question + "%'"
                                                               + " AND eq.ExamID in (Select Distinct ExamID from mms..StagingAreaExamRecord SAER, CGIWeb..WebUser WU Where SAER.PersonID = WU.LinkID"
                                                               + " And saer.importProcess = 'Web' and WU.Email = '" + email + "')";

        public static string SecurityQuizAnswers(string email) => "Select QuestionSequence,AnswerIdentifier from mms..ExamQuestionAnswers"
                                                                + " where ExamID in ( select ExamID from mms..stagingareaexamrecord"
                                                                + " Where PersonID in ( Select LinkID from CGIWeb..webuser where Email = '" + email + "')) and CorrectAnswer = 1";

        public static string ExamForm(string email, string courseid, string language) => "Select ExamName from  mms..stagingareaexamrecord SAER, CGIWeb..WebUser Wu ,MMS..Exam  Ex" +
                                                        " where PersonID = LinkID" +
                                                        " and Wu.Email = '" + email + "'" +
                                                        " and ExamID = Ex.ID" +
                                                        " and CourseId = '" + courseid + "'" +
                                                        " and DeliveryType = 'web'" +
                                                        " and Language like'%" + language + "%'";
        public static string CRCorrectAnswers(string examsession) => "SELECT eq.Question, eqa.AnswerText FROM   MMS..ExamQuestion eq, MMS..ExamQuestionAnswers eqa, MMS..ClassExam ce"
                                                                    + " WHERE eq.ExamID = eqa.ExamID"
                                                                    + " AND eq.Sequence = eqa.QuestionSequence"
                                                                    + " AND ce.ExamID = eq.ExamID"
                                                                    + " AND eqa.CorrectAnswer = 1"
                                                                    + " and  ce.ClassID = '" + examsession + "'";
        public static string RegNum(int DefId) => "Select top 1 RegistrationNumber from mms..RegistrationNumber where  Status = 'Available' and RegistrationNumberDefinitionID =" + DefId;

        public static string UpdateCourseStatus(string key) => "update a set"
                                                           + " lessonstatus='completed'"
                                                           + " from NRAEF..DotNetSCORM_UserSCOData a where EventID  in (select UserCourseID from NRAEF..LMSCourseAssignment where LicenseKey = '" + key + "')";

        public static string PingUser => "select Top 1 Email from CGIWeb..webuser where Email like 'nraregression+%' ORDER BY NEWID()";
        public static string PingPortalUser => "select Top 1 Email from CGIWeb..webuser where Email like 'nraportal+%' ORDER BY NEWID()";
        public static string LegacyUser(int rownum) => "Select UserID from (select ROW_NUMBER() OVER(ORDER BY DateCreated Desc) AS Row#, UserID from CGIWeb..WebUser where UserId like 'AT%' and Email in ('bamin@restaurant.org','nasundaram@restaurant.org') and Email not like 'nraregressio%')  as temp where Row# = " + rownum;
    }


}
