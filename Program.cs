using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Globalization;
namespace Checkyouright
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"data source=DESKTOP-S9H4K5P\SQLEXPRESS;database=ClaimManagement;user id=sa;password=manager@123");
            string inputfilepath = @"D:\InputFilePath";
            string inputfilepathxml = @"D:\InputFilePath\722728Emp.xml";
            string archivefilepath = @"D:\DestPath\";
            string logfilepath = @"D:\LoggingPath\";
            string logfilename = "invalidlog.txt";
            //List<Claim> fulldata = Readdatafromfile(inputfilepath);
            //InsertrecordintDB(con,fulldata);
            //List<Claim> fetch = FetchDataFromDatabase(con);
            //List<Claim> fulldataxml = ReaddatafromXmlFile(inputfilepathxml);
            //Logging(fetch, logfilepath, logfilename);
            //movefiletodirectory(inputfilepath, archivefilepath);

            #region EmailValidation
            //string email = "kous-hik.@gmail.com.co";
            //string emailpatern = @"^([\w\.\-]+)@([\w\-]+)((\.[\w]{2,3})+)$";
            //if (Regex.Match(email, emailpatern).Success)
            //{
            //    if (email.EndsWith(".com") || email.EndsWith(".co.in") || email.EndsWith(".co.uk"))
            //    {

            //    }
            //}
            //else
            //{

            //}
            #endregion

            #region Datevalidationcheck
            //string inputDate1 = "12/23/2012";
            //string inputdate2 = "12/23/2012";
            //DateTime outdate;
            //if ((DateTime.TryParseExact(inputDate1, "MM/DD/YYYY", CultureInfo.InvariantCulture,DateTimeStyles.None, out outdate))||(DateTime.TryParseExact(inputdate2,"MM/dd/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out outdate)))
            //{
            //    if (Convert.ToDateTime(inputDate1.ToString()).AddMonths(3) > (Convert.ToDateTime(inputdate2.ToString())))
            //    {
            //        string strdate = Convert.ToDateTime(inputDate1.ToString()).AddMonths(3).ToString("MM/dd/yyyy");
            //    }
            //}
            #endregion

            #region websitevalidation
            //string websiteInput = "www.gmail.com";
            ////string websiteInput = "http://www.gmail.com";
            //string regwebPatern = @"^((http|https)://)?([\w]+\.)+(\w+)$";
            //if (Regex.Match(websiteInput, regwebPatern).Success)
            //{
            //    string str1 = "fdff";
            //}
            #endregion

            #region numbervalidation
            //string inputNumber = "CP001";
            //if (inputNumber.StartsWith("CP"))
            //{
            //    int numberout;
            //    int numericpart = inputNumber.Substring(2).Length;
            //    if (Int32.TryParse(inputNumber.Substring(2), out numberout))
            //    {
            //        string abc = "123";
            //    }
            //}
            #endregion
        }

        #region fetchdatafromtextFile
        static List<Claim> Readdatafromfile(string inputpath)
        {
            List<Claim> claimlist = new List<Claim>();
            if (Directory.Exists(inputpath))
            {

                string[] allfile = Directory.GetFiles(inputpath, "CP*.txt");
                foreach (string s in allfile)
                {
                    StreamReader streamReader = new StreamReader(s);
                    string fulltext = streamReader.ReadToEnd();
                    string[] splitnewline = fulltext.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in splitnewline)
                    {
                        string[] splitperfect = item.Split(',');
                        claimlist.Add(new Claim()
                        {
                            ClaimId = splitperfect[0],
                            Email = splitperfect[1],
                            Name = splitperfect[2],
                            Salary = splitperfect[3],
                            Doj = splitperfect[4]
                        });
                    }
                }
            }
            else
            {

            }
            return claimlist;
        }
        #endregion
        #region fetchdatafromXml
        //static List<Claim> ReaddatafromXmlFile(string inputxml)
        //{
        //    List<Claim> claimsxml = new List<Claim>();
        //    IEnumerable<XElement> total = XElement.Load(inputxml).Elements();
        //    foreach (var item in total)
        //    {
        //        claimsxml.Add(new Claim() {
        //            ClaimId = item.Element("ClaimId").Value,
        //            Email = item.Element("Email").Value,
        //            Name = item.Element("Name").Value,
        //            Salary = item.Element("Salary").Value,
        //            Doj = item.Element("Doj").Value,
        //        });
        //    }
        //    return claimsxml;
        //}
        #endregion
        #region insertdataintoDatabase
        //static void InsertrecordintDB(SqlConnection con,List<Claim> allclaim)
        //{
        //    foreach (var item in allclaim)
        //    {
        //        SqlCommand cmd = new SqlCommand("Insert Into tblClaim values(@ClaimId,@Email,@Name,@Salary,@Doj)", con);

        //        cmd.Parameters.Add(new SqlParameter("@ClaimId",item.ClaimId));
        //        cmd.Parameters.Add(new SqlParameter("@Email", item.Email));
        //        cmd.Parameters.Add(new SqlParameter("@Name",item.Name));
        //        cmd.Parameters.Add(new SqlParameter("@Salary",Convert.ToDouble(item.Salary)));
        //        cmd.Parameters.Add(new SqlParameter("@Doj",Convert.ToDateTime(item.Doj)));
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}
        #endregion

        #region fetchdatafromDatabase
        //static List<Claim> FetchDataFromDatabase(SqlConnection con)
        //{
        //    List<Claim> fetchlist = new List<Claim>();
        //    SqlCommand cmd = new SqlCommand("Select * from tblClaim",con);
        //    DataTable dt = new DataTable();
        //    con.Open();
        //    SqlDataAdapter dr = new SqlDataAdapter(cmd);

        //    dr.Fill(dt);
        //    foreach (DataRow drw in dt.Rows)
        //    {
        //        fetchlist.Add(new Claim() {
        //            ClaimId = drw["ClaimId"].ToString(),
        //            Email = drw["Email"].ToString(),
        //            Name = drw["Name"].ToString(),
        //            Salary = drw["Salary"].ToString(),
        //            Doj=drw["Doj"].ToString()

        //        });
        //    }
        //    return fetchlist;
        //}
        #endregion

        #region writeintoTextFile
        //static void Logging(List<Claim> claims,string archivepath,string filename)
        //{
        //    if (File.Exists(archivepath + filename))
        //    {
        //        File.Delete(archivepath + filename);

        //    }
        //    StreamWriter streamWriter = new StreamWriter(archivepath + filename, false, Encoding.Default);
        //    foreach (var item in claims)
        //    {
        //        streamWriter.WriteLine(item.ClaimId +","+item.Email);
        //        streamWriter.Flush();
        //    }
        //    streamWriter.Close();
        //}
        #endregion

        #region arachiveFile
        //static void movefiletodirectory(string inputfile,string destfilepath)
        //{
        //    if (Directory.Exists(inputfile))
        //    {
        //        string[] allfile = Directory.GetFiles(inputfile,"CP*.txt");
        //        foreach (var item in allfile)
        //        {
        //            string inpfilename = Path.GetFileName(item);
        //            string[] newfilesplit = inpfilename.Split('.');
        //            string destfilename = destfilepath + newfilesplit[0] + "_Processed." + newfilesplit[1];
        //            if (File.Exists(destfilename))
        //            {
        //                File.Delete(destfilename);
        //            }
        //            File.Copy(item, destfilename);
        //        }
        //    }
        //    else
        //    {

        //    }
        //}

        #endregion

    }
}
