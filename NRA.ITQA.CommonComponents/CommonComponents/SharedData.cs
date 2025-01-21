using System;
using System.Collections.Generic;
using System.Text;
using static CommonComponents.Constants;

namespace CommonComponents
{
    public static class SharedData
    {
        public static string RandomState()
        {
            List<string> stateDictionary = new List<string>();

            stateDictionary.Add("Oregon");
            stateDictionary.Add("Montana");
            stateDictionary.Add("Washington");
            stateDictionary.Add("California");
            stateDictionary.Add("Idaho");
            stateDictionary.Add("Wyoming");
            stateDictionary.Add("North Dakota");
            stateDictionary.Add("South Dakota");
            stateDictionary.Add("Minnesota");
            stateDictionary.Add("Nevada");
            stateDictionary.Add("Utah");
            stateDictionary.Add("Arizona");
            stateDictionary.Add("Colorado");
            stateDictionary.Add("New Mexico");
            stateDictionary.Add("Texas");
            stateDictionary.Add("Alaska");
            stateDictionary.Add("Nebraska");
            stateDictionary.Add("Kansas");
            stateDictionary.Add("Oklahoma");
            stateDictionary.Add("Iowa");
            stateDictionary.Add("Missouri");
            stateDictionary.Add("Wisconsin");
            stateDictionary.Add("Arkansas");
            stateDictionary.Add("Louisiana");
            stateDictionary.Add("Mississippi");
            stateDictionary.Add("Alabama");
            stateDictionary.Add("Georgia");
            stateDictionary.Add("Tennessee");
            stateDictionary.Add("Indiana");
            stateDictionary.Add("Illinois");
            stateDictionary.Add("Ohio");
            stateDictionary.Add("Michigan");
            stateDictionary.Add("Kentucky");
            stateDictionary.Add("North Carolina");
            stateDictionary.Add("West Virginia");
            stateDictionary.Add("Florida");
            stateDictionary.Add("Rhode Island");
            stateDictionary.Add("Hawaii");
            stateDictionary.Add("South Carolina");
            stateDictionary.Add("New Hampshire");
            stateDictionary.Add("Vermont");
            stateDictionary.Add("Maine");
            stateDictionary.Add("Massachusetts");
            stateDictionary.Add("New York");
            stateDictionary.Add("Pennsylvania");
            stateDictionary.Add("Connecticut");
            stateDictionary.Add("New Jersey");
            stateDictionary.Add("Delaware");
            stateDictionary.Add("District of Columbia");
            stateDictionary.Add("Maryland");
            stateDictionary.Add("Virginia");

            return stateDictionary[rand.Next(stateDictionary.Count)];
        }

        public static IDictionary<string, Tuple<string, string, string, string, float>> GetAddress()
        {
            return new Dictionary<string, Tuple<string, string, string, string, float>>
            {
                { "Alabama", new Tuple<string,string,string, string, float>("5461 West Shades Valley Drive","","Montgomery", "36108", 9f) },
                { "Alaska", new Tuple<string,string,string, string, float>("600 West 19th Avenue","APT B","Anchorage", "99503", 8.5f) },
                { "Arizona", new Tuple<string,string,string, string, float>("5928 West Mauna Loa Lane","","Glendale", "85306", 8.6f) },
                { "Arkansas", new Tuple<string,string,string, string, float>("481 East Redbud Lane","","Fayetteville", "72703", 9f) },
                { "California", new Tuple<string,string,string, string, float>("6214 Herzog Street","","Oakland", "94608", 8.5f) },
                { "Colorado", new Tuple<string,string,string, string, float>("7256 West 84th Way","#918","Arvada", "80003", 7.65f) },
                { "Connecticut", new Tuple<string,string,string, string, float>("200 Boulder Road","","Manchester", "06040", 6.35f) },
                { "Delaware", new Tuple<string,string,string, string, float>("3160 Lake Floyd Circle","","Newark", "19711", 0f) },
                { "District of Columbia", new Tuple<string,string,string, string, float>("3179 18th Street Northwest","","Washington", "20010", 5.75f) },
                { "Florida", new Tuple<string,string,string, string, float>("3718 Bay Tree Road","","Lynn Haven", "32444", 7.5f) },
                { "Georgia", new Tuple<string,string,string, string, float>("43 Henderson Avenue","","Savannah", "31406", 8f) },
                { "Hawaii", new Tuple<string,string,string, string, float>("3627 Randall Drive","","Waipahu", "96797", 4.5f) },
                { "Idaho", new Tuple<string,string,string, string, float>("3260 Seltice Way","","Post Falls", "83854", 6f) },
                { "Illinois", new Tuple<string,string,string, string, float>("233 S. Wacker Drive","Suite 3600","Chicago", "60606", 9.25f) },
                { "Indiana", new Tuple<string,string,string, string, float>("4957 Graystone Lakes","","Cicero", "46034", 7f) },
                { "Iowa", new Tuple<string,string,string, string, float>("2013 Tecumsah Lane","","Mount Pleasant", "52641", 7f) },
                { "Kansas", new Tuple<string,string,string, string, float>("323 Sherman Street","","Hope", "67451", 7.5f) },
                { "Kentucky", new Tuple<string,string,string, string, float>("5311 Chenoweth Park Lane","","Louisville", "40291", 6f) },
                { "Louisiana", new Tuple<string,string,string, string, float>("3618 Big Indian","","Kenner", "70062", 9f) },
                { "Maine", new Tuple<string,string,string, string, float>("89 Summer Ave","","Fort Kent", "04743", 5.5f) },
                { "Maryland", new Tuple<string,string,string, string, float>("1960 Sigfrid Court","","Annapolis", "21401", 6f) },
                { "Massachusetts", new Tuple<string,string,string, string, float>("62 Prospect Avenue","#1","Quincy", "02170", 6.25f) },
                { "Michigan", new Tuple<string,string,string, string, float>("4771 Bryan Street","","Filer City", "49634", 6f) },
                { "Minnesota", new Tuple<string,string,string, string, float>("377 Mcwhorter Road","","Swan River", "55784", 7.38f) },
                { "Mississippi", new Tuple<string,string,string, string, float>("1685 Oswalt Rd","","Columbus", "39702", 7.0f) },
                { "Missouri", new Tuple<string,string,string, string, float>("36 Traders Alley","","Odessa", "64076", 8.68f) },
                { "Montana", new Tuple<string,string,string, string, float>("592 Coolidge Street","","Cut Bank", "59427", 0f) },
                { "Nebraska", new Tuple<string,string,string, string, float>("4698 Commerce Boulevard","","Dixon", "68732", 7f) },
                { "Nevada", new Tuple<string,string,string, string, float>("3843 Hall Street","","Las Vegas", "89104", 7.73f) },
                { "New Hampshire", new Tuple<string,string,string, string, float>("30 Greenview Dr","#39","Manchester", "03102", 0f) },
                { "New Jersey", new Tuple<string,string,string, string, float>("2225 Williams Mine Road","","New Brunswick", "08901", 7f) },
                { "New Mexico", new Tuple<string,string,string, string, float>("1288 Bird Street","","Aztec", "87410", 7f) },
                { "New York", new Tuple<string,string,string, string, float>("3570 Stanley Avenue","","NewYork", "10014", 8.88f) },
                { "North Carolina", new Tuple<string,string,string, string, float>("369 Rockford Mountain Lane","","Raleigh", "27604", 6.75f) },
                { "North Dakota", new Tuple<string,string,string, string, float>("3117 Sycamore Circle","","Bismarck", "58506", 7f) },
                { "Ohio", new Tuple<string,string,string, string, float>("2246 Sunny Glen Lane","","Cleveland", "44115", 8f) },
                { "Oklahoma", new Tuple<string,string,string, string, float>("1401 Saint George Avenue","","Moore", "73160", 8.52f) },
                { "Oregon", new Tuple<string,string,string, string, float>("1874 Wilson Street","","Portland", "97215", 0f) },
                { "Pennsylvania", new Tuple<string,string,string, string, float>("3441 Henry Ford Avenue","","United", "15689", 7f) },
                { "Rhode Island", new Tuple<string,string,string, string, float>("10 Beach St","","Little Compton", "02837", 7f) },
                { "South Carolina", new Tuple<string,string,string, string, float>("4125 Mill Street","","Greenwood", "29646", 7f) },
                { "South Dakota", new Tuple<string,string,string, string, float>("3495 Leroy Lane","","Hudson", "57034", 4f) },
                { "Tennessee", new Tuple<string,string,string, string, float>("2623 Buffalo Creek Road","","Nashville", "37210", 9.25f) },
                { "Texas", new Tuple<string,string,string, string, float>("1168 Burwell Heights Road","","Nederland", "77627", 8.25f) },
                { "Utah", new Tuple<string,string,string, string, float>("2077 Kemper Lane","","Salt Lake City", "84104", 6.3f) },
                { "Vermont", new Tuple<string,string,string, string, float>("1689 Fisher Pond Road","","Saint Albans City", "05478", 7f) },
                { "Virginia", new Tuple<string,string,string, string, float>("657 Minute Men Rd","","Virginia Beach", "23462", 5.3f) },
                { "Washington", new Tuple<string,string,string, string, float>("8629 E D St","","Tacoma", "98445", 9.5f) },
                { "West Virginia", new Tuple<string,string,string, string, float>("2058 Pinecrest Dr","","Morgantown", "26505", 6f) },
                { "Wisconsin", new Tuple<string,string,string, string, float>("4047 County Rd WW","","Wausau", "54401", 5.6f) },
                { "Wyoming", new Tuple<string,string,string, string, float>("145 N. Durbin Street","","Casper", "82601", 4f) }
                };
        }

        public static IDictionary<string, Tuple<string, string, string>> EIProductsdict()
        {
            return new Dictionary<string, Tuple<string, string, string>>
           {
            { "Food Safety and Quality Management Exam 3rd Ed", new Tuple<string, string, string>( "Food Safety and Quality Management - R&D", "70-714-14-16-10-03-EN", "Food Safety and Quality Management Exam 3rd Ed" ) },
            { "Hospitality Sales and Marketing Exam 6th Ed", new Tuple<string, string, string>( "Academic Instructor - Unified Exams (1st Attempt)", "70-703-14-16-10-06-EN", "Hospitality Sales and Marketing Online Exam" ) },
            { "Purchasing for Food Service Operations Exam 1st Ed", new Tuple<string, string, string>( "Purchasing for Food Service Operations - R&D", "70-729-14-16-10-01-EN", "Purchasing for Food Service Operations Exam 1st Ed" ) },
            { "Managing Front Office Operations Exam 10th Ed", new Tuple<string, string, string>( "Managing Front Office Operations - R&D", "70-708-14-16-10-10-EN", "Managing Front Office Operations Exam 10th Ed" ) },
            { "Management of Food and Beverage Operations Exam 6th Ed", new Tuple<string, string, string>( "Management of Food and Beverage Operations - R&D", "70-707-14-16-10-07", "Management of Food and Beverage Operations Exam 6th Ed" ) },
            { "BT3 Test SKU_Exam_365Day-Expiration", new Tuple<string, string, string>( "AHLEI 2.0 Short Exam", "12345-01", "AHLEI 2.0 Short Exam, 2-day" ) }
           };
        }

        public static Dictionary<string, string> USStateAbbr()
        {
            Dictionary<string, string> stateAbbreviations = new Dictionary<string, string>();
            stateAbbreviations.Add("ALABAMA", "AL");
            stateAbbreviations.Add("ALASKA", "AK"); stateAbbreviations.Add("AMERICAN SAMOA", "AS");
            stateAbbreviations.Add("ARIZONA", "AZ");
            stateAbbreviations.Add("ARKANSAS", "AR");
            stateAbbreviations.Add("CALIFORNIA", "CA");
            stateAbbreviations.Add("COLORADO", "CO");
            stateAbbreviations.Add("CONNECTICUT", "CT");
            stateAbbreviations.Add("DELAWARE", "DE");
            stateAbbreviations.Add("DISTRICT OF COLUMBIA", "DC");
            stateAbbreviations.Add("FEDERATED STATES OF MICRONESIA", "FM");
            stateAbbreviations.Add("FLORIDA", "FL");
            stateAbbreviations.Add("GEORGIA", "GA");
            stateAbbreviations.Add("GUAM", "GU");
            stateAbbreviations.Add("HAWAII", "HI");
            stateAbbreviations.Add("IDAHO", "ID");
            stateAbbreviations.Add("ILLINOIS", "IL");
            stateAbbreviations.Add("INDIANA", "IN");
            stateAbbreviations.Add("IOWA", "IA");
            stateAbbreviations.Add("KANSAS", "KS");
            stateAbbreviations.Add("KENTUCKY", "KY");
            stateAbbreviations.Add("LOUISIANA", "LA");
            stateAbbreviations.Add("MAINE", "ME");
            stateAbbreviations.Add("MARSHALL ISLANDS", "MH");
            stateAbbreviations.Add("MARYLAND", "MD");
            stateAbbreviations.Add("MASSACHUSETTS", "MA");
            stateAbbreviations.Add("MICHIGAN", "MI");
            stateAbbreviations.Add("MINNESOTA", "MN");
            stateAbbreviations.Add("MISSISSIPPI", "MS");
            stateAbbreviations.Add("MISSOURI", "MO");
            stateAbbreviations.Add("MONTANA", "MT");
            stateAbbreviations.Add("NEBRASKA", "NE");
            stateAbbreviations.Add("NEVADA", "NV");
            stateAbbreviations.Add("NEW HAMPSHIRE", "NH");
            stateAbbreviations.Add("NEW JERSEY", "NJ");
            stateAbbreviations.Add("NEW MEXICO", "NM");
            stateAbbreviations.Add("NEW YORK", "NY");
            stateAbbreviations.Add("NORTH CAROLINA", "NC");
            stateAbbreviations.Add("NORTH DAKOTA", "ND");
            stateAbbreviations.Add("NORTHERN MARIANA ISLANDS", "MP");
            stateAbbreviations.Add("OHIO", "OH");
            stateAbbreviations.Add("OKLAHOMA", "OK");
            stateAbbreviations.Add("OREGON", "OR");
            stateAbbreviations.Add("PALAU", "PW");
            stateAbbreviations.Add("PENNSYLVANIA", "PA");
            stateAbbreviations.Add("PUERTO RICO", "PR");
            stateAbbreviations.Add("RHODE ISLAND", "RI");
            stateAbbreviations.Add("SOUTH CAROLINA", "SC");
            stateAbbreviations.Add("SOUTH DAKOTA", "SD");
            stateAbbreviations.Add("TENNESSEE", "TN");
            stateAbbreviations.Add("TEXAS", "TX");
            stateAbbreviations.Add("UTAH", "UT");
            stateAbbreviations.Add("VERMONT", "VT");
            stateAbbreviations.Add("VIRGIN ISLANDS", "VI");
            stateAbbreviations.Add("VIRGINIA", "VA");
            stateAbbreviations.Add("WASHINGTON", "WA");
            stateAbbreviations.Add("WEST VIRGINIA", "WV");
            stateAbbreviations.Add("WISCONSIN", "WI");
            stateAbbreviations.Add("WYOMING", "WY");
            stateAbbreviations.Add("SAN DIEGO", "San Diego");
            stateAbbreviations.Add("GENERIC", "GE");
            return stateAbbreviations;

        }

        public static Dictionary<string, string> LanguageDict()
        {
            return new Dictionary<string, string>
            {
                {"Traditional_Chinese","ServSafe International™ Food Safety Traditional Chinese"},
                {"English", "ServSafe International™ Food Safety Exam-English"},
                {"Spanish", "ServSafe International™ Food Safety Exam-Spanish"},
                {"English-UK", "ServSafe International™ Food Safety Exam-UK"},
                {"Simplified_Chinese", "ServSafe International™ Food Safety Simplified Chinese"},
                {"English-Canada", "ServSafe International™ Food Safety Exam-Canada English"},
                {"French-Canada", "ServSafe International™ Food Safety Exam-Canada French"}
            };
        }

        public static Dictionary<string, string> ExamLanguageDict()
        {
            return new Dictionary<string, string>
            {
                {"KOREAN","축하합니다!"},
                {"ENGLISH", "Congratulations"},
                {"INSTRUCTOR", "Congratulations"},
                {"SPANISH", "Felicitaciones"},
                {"VIETNAMESE", "Xin chúc mừng"},
                {"SIMPLIFIED CHINESE", "恭喜您!"},
                {"CHINESE", "恭喜您!"}

            };
        }


        public static Dictionary<string, Tuple<string, string>> SiteDict()
        {
            return new Dictionary<string, Tuple<string, string>>
            {
                {"CR",new Tuple<string,string>("ProStart","Logout")},
                {"SS", new Tuple<string,string>("ServSafe","Account-link")},
                {"SSI", new Tuple<string,string>("SSI","username")},
                {"MF",  new Tuple<string,string>("ManageFirst","login")},
                { "TB", new Tuple<string,string>("Textbooks","Logout") }

             };
        }
        public static string RandomLanguage()
        {
            List<string> langList = new List<string>();
            langList.Add("English");
            langList.Add("Traditional_Chinese");
            langList.Add("English-UK");
            langList.Add("Simplified_Chinese");
            langList.Add("Spanish");
            return langList[rand.Next(langList.Count)];
        }
        public static string CREdition()
        {
            List<string> editionList = new List<string>();

            //editionList.Add("First");
            editionList.Add("Second");
            return editionList[rand.Next(editionList.Count)];
        }

        public static string CRLevel()
        {
            List<string> levelList = new List<string>();

            levelList.Add("Level 1");
            levelList.Add("Level 2");
            return levelList[rand.Next(levelList.Count)];
        }

        public static string CRLanguage()
        {
            List<string> languageList = new List<string>();
            languageList.Add("English");
            languageList.Add("Spanish");
            return languageList[rand.Next(languageList.Count)];
        }

        public static string EmailType()
        {
            string[] types = { "Work", "Personal" };
            return types[rand.Next(types.Length)];
        }


        public static string AddressType()
        {
            string[] types = { "Home", "Business" };
            return types[rand.Next(types.Length)];
        }

        public static string JobRole()
        {
            string[] types = { "CEO/COO/CFO/President", "Corporate: SVP/ VP/Director", "Regional: Manager/Director/VP", "Manager/Assistant Manager", "Supervisor/Lead/Trainer", "Instructor/Proctor", "Staff/Professional", "Other" };
            //string[] types = { ""Academic Student"," };
            return types[rand.Next(types.Length)];
        }

        public static string CC()
        {
            string[] cctypes = { "3782 822463 10005", "3714 496353 98431", "6011 1111 1111 1117", "6011 0009 9013 9424", "5555 5555 5555 4444", "5105 1051 0510 5100", "4111 1111 1111 1111", "4012 8888 8888 1881" };
            return cctypes[rand.Next(cctypes.Length)];
        }

    }

}