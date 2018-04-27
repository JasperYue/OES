using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Common
{
    public class Constants
    {
        public const char SIGN_CIRCLE = '●';
        public const char SIGN_AND = '&';
        public const char SIGN_EQUALS = '=';
        public const char SIGN_COMMA = ',';
        public const char SIGN_SLASH = '/';
        public const char SIGN_SUB_LINE = '_';
        public const char SIGN_PERCENT = '%';

        public static readonly Color COLOR_BLACK = Color.FromArgb(0, 0, 0);
        public static readonly Color COLOR_GREY = Color.FromArgb(157, 157, 157);
        public static readonly Color COLOR_HOME_GREY = Color.FromArgb(210, 218, 227);
        public static readonly Color COLOR_WHITE = Color.FromArgb(255, 255, 255);
        public static readonly Color COLOR_ORANGE = Color.FromArgb(254, 153, 1);
        public static readonly Color COLOR_BLUE = Color.FromArgb(46, 67, 88);
        public static readonly Color COLOR_BLUE_BORDER = ColorTranslator.FromHtml("#296793");
        public static readonly Color COLOR_RED = ColorTranslator.FromHtml("#B91F1F");

        public const string ENTITY_USER = "User";
        public const string ENTITY_EXAM = "Exam";
        public const string ENTITY_RESULT = "Result";

        public const string USER_NAME = "Username";
        public const string PASSWORD = "Password";

        public const string TIP_INPUT_WORD = "Please input the keyword";
        public const string TIP_TIME_NODAY = "00:00:00";
        public const string TIP_TIME_HASDAY = "00:00:00:00";

        public const string LOGGER = "Logging";

        public const string DEFAULT_TIME_BEGIN = "2000-01-01";
        public const string DEFAULT_TIME_END = "2050-01-01";

        public const string ENTITY_NOT_FOUND = "Entity {0} not found!";
        public const string USER_NOT_EXIST = "Username does not exist";
        public const string PASSWORD_NOT_CORRENT = "Login password is incorrect";
        public const string INPUT_NOT_EMPTY = "Username or Password can not be empty!";

        public const string NO_RECORD = "No Record On This Condition!";
        public const string ERROR_OCCURRED = "An unknown error occurred!";

        public const string XML_ID = "ID";
        public const string XML_FILE_USER = "\\User.xml";
        public const string XML_FILE_BEAN = "\\Bean.xml";

        public const string DB_TAB = "@Tab";
        public const string DB_FIELD = "@StrField";
        public const string DB_WHERE = "@StrWhere";
        public const string DB_PAGE_NO = "@PageNo";
        public const string DB_PAGE_SIZE = "@PageSize";
        public const string DB_SORT = "@Sort";
        public const string DB_TOTAL_ITEM = "@TotalItem";

        public const string DB_EXAM_ID = "@ExamId";
        public const string DB_EXAM_ANSWER = "@AnswerStr";
        public const string DB_RESULT_SCORE = "@Score";
        public const string DB_USER_ID = "@UserId";
    }

    public enum Status
    {
        No_Pass,
        Pass,
        Do_it,
        Continue,
        Not_Attend
    }

    public enum Role
    {
        Student,
        Teacher
    }

}
