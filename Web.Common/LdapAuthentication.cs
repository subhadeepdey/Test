using System;
using System.Text;
using System.Collections;
using System.DirectoryServices;
using System.Web;
using System.Web.Security;

namespace Web.Common
{
    public class LdapAuthentication
    {
        private String _path;
        private String _filterAttribute;

        public LdapAuthentication(String path)
        {
            _path = path;
        }


        public static string GetUserID()
        {
            if (HttpContext.Current.Session["UserID"] != null)
                return HttpContext.Current.Session["UserID"].ToString();

            return null;
        }
        public static string GetFullName()
        {
            if (HttpContext.Current.Session["FullName"] != null)
                return HttpContext.Current.Session["FullName"].ToString();

            return string.Empty;
        }
        public bool IsAuthenticated(String domain, String username, String pwd)
        {
            String domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd, AuthenticationTypes.Secure);

            try
            {
                //Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);
                search.FindOne();
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                var x = entry.Properties["fullname"].Value;
                if (null == result)
                {
                    return false;
                }
                else
                {
                    HttpContext.Current.Session["UserID"] = domain + @"\" + username;
                    HttpContext.Current.Session["FullName"] = (String)result.Properties["cn"][0];
                }

                //Update the new path to the user in the directory.
                _path = result.Path;

                _filterAttribute = (String)result.Properties["cn"][0];
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public String GetGroups(String domain, String username, String pwd)
        {
            String domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd, AuthenticationTypes.Secure);

            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(cn=" + _filterAttribute + ")";
            search.PropertiesToLoad.Add("memberOf");
            StringBuilder groupNames = new StringBuilder();

            try
            {
                SearchResult result = search.FindOne();

                int propertyCount = result.Properties["memberOf"].Count;

                String dn;
                int equalsIndex, commaIndex;

                for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
                {
                    dn = (String)result.Properties["memberOf"][propertyCounter];

                    equalsIndex = dn.IndexOf("=", 1);
                    commaIndex = dn.IndexOf(",", 1);
                    if (-1 == equalsIndex)
                    {
                        return null;
                    }

                    groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
                    groupNames.Append("|");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error obtaining group names. " + ex.Message);
            }
            return groupNames.ToString();
        }

        public static void Clear()
        {
            HttpContext.Current.Session["UserID"] = null;
            HttpContext.Current.Session["FullName"] = null;

        }
    }
}