using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;

namespace SimplicityCommLib
{
    public static class Constants
    {
        public static class Products
        {
            public static int EAS = 1;
            public static int HEALTH_AND_SAFETY = 2;
            public static int HANDY_GAS = 3;
            public static int HANDY_SERVE = 4;
            public static int HANDY_LEC = 5;
        }
        public static class Configuration
        {
            public static string PHYSICAL_PATH = "PhysicalPath";
            public static int CACHE_TIMEOUT = 10;
            public static int SessionTimeoutInMinutes = 20;
        }
        
        public static class Roles
        {
            public static string Admin = "Admin";
            public static string User = "User";
        }
        public static class AddressCategories
        {
            public static int CompanyAddress = 1;
            public static int UserAddress = 2;
            public static int DepartmentAddress = 3;
        }
        public static class HS
        {
            public static class DocumentTypes
            {
                public static string RISK_ASSESSMENTS = "Risk Assessments";
                public static string COSHH_DOCUMENTS = "COSHH Documents";
            }
            public static class SectionTypes
            {
                public static string FREE_TEXT = "FREE_TEXT";
                public static string MULTIPLE_SELECT_LIST = "MULTIPLE_SELECT_LIST";
                public static string NOT_APPLICABLE = "NOT_APPLICABLE";
                private static Dictionary<string, ListItem[]> docTypeSections = GetDocTypeSections();
                private static Dictionary<string, ListItem[]> GetDocTypeSections()
                {
                    Dictionary<string, ListItem[]> sections = new Dictionary<string, ListItem[]>();

                    sections.Add(DocumentTypes.RISK_ASSESSMENTS, new ListItem[1]);
                    sections[DocumentTypes.RISK_ASSESSMENTS][0] = new ListItem("Free Text", FREE_TEXT);

                    sections.Add(DocumentTypes.COSHH_DOCUMENTS, new ListItem[2]);
                    sections[DocumentTypes.COSHH_DOCUMENTS][0] = new ListItem("Free Text", FREE_TEXT);
                    sections[DocumentTypes.COSHH_DOCUMENTS][1] = new ListItem("Multiple Select List", MULTIPLE_SELECT_LIST);

                    return sections;
                }
                public static ListItem[] GetSections(string documentType)
                {
                    if (docTypeSections.ContainsKey(documentType))
                    {
                        return docTypeSections[documentType];
                    }
                    ListItem[] listItems = new ListItem[1];
                    listItems[0] = new ListItem("[-- N/A --]", NOT_APPLICABLE);
                    return listItems;
                }
            }
            public static class DocumentTypeCategories
            {
                public static string COSHH = "COSHH";
                public static string METHOD_STATEMENT = "Method Statement";
                public static string SIGNAGE = "Signage";
            }
            public static class Default
            {
                public static string NOT_SET = "[Not Set]";
            }
        }
        /*public static enum AddressCategories
        {
            CompanyAddress,
            UserAddress
        }*/
    }
}
