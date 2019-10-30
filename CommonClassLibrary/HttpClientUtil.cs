using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace CommonClassLibrary
{
    public class HttpClientUtil
    {

        //private static string xiazhi_tomcat_url = Properties.Settings.Default.xiazhi_server_url;
        //private static string xiazhi_server_url = xiazhi_tomcat_url + "resteasy";
        private static string xiazhi_tomcat_url = "http://localhost:5000/";
        private static string xiazhi_server_url = xiazhi_tomcat_url + "Api";
        // REST @GET 方法，根据泛型自动转换成实体，支持List<T>
        public static T doGetMethodToObj<T>(string metodUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(xiazhi_server_url + metodUrl);
            request.Method = "get";
            request.ContentType = "application/json;charset=UTF-8";
            HttpWebResponse response = null;

            try
            {

                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
                //MessageBox.Show(e.Message + " - " + getRestErrorMessage(response));
                return default(T);
            }
            string json = getResponseString(response);
            return JsonConvert.DeserializeObject<T>(json);
        }

        // 将 HttpWebResponse 返回结果转换成 string
        private static string getResponseString(HttpWebResponse response)
        {
            string json = null;
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8")))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }

        // 获取异常信息
        private static string getRestErrorMessage(HttpWebResponse errorResponse)
        {
            string errorhtml = getResponseString(errorResponse);
            string errorkey = "spi.UnhandledException:";
            errorhtml = errorhtml.Substring(errorhtml.IndexOf(errorkey) + errorkey.Length);
            errorhtml = errorhtml.Substring(0, errorhtml.IndexOf("\n"));
            return errorhtml;
        }

        // REST @POST 方法
        public static T doPostMethodToObj<T>(string metodUrl, string jsonBody)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(xiazhi_server_url + metodUrl);
            request.Method = "post";
            request.ContentType = "application/json;charset=UTF-8";
            var stream = request.GetRequestStream();
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(jsonBody);
                writer.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string json = getResponseString(response);
            return JsonConvert.DeserializeObject<T>(json);
        }

        // REST @PUT 方法
        public static string doPutMethod(string metodUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(xiazhi_server_url + metodUrl);
            request.Method = "put";
            request.ContentType = "application/json;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8")))
            {
                return reader.ReadToEnd();
            }
        }

        // REST @PUT 方法，带发送内容主体
        public static T doPutMethodToObj<T>(string metodUrl, string jsonBody)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(xiazhi_server_url + metodUrl);
            request.Method = "put";
            request.ContentType = "application/json;charset=UTF-8";
            var stream = request.GetRequestStream();
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(jsonBody);
                writer.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string json = getResponseString(response);
            return JsonConvert.DeserializeObject<T>(json);
        }

        // REST @PUT 方法，带发送内容主体
        public static bool doPutMethodToObj(string metodUrl, string jsonBody)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(xiazhi_server_url + metodUrl);
            request.Method = "put";
            request.ContentType = "application/json;charset=UTF-8";
            var stream = request.GetRequestStream();
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(jsonBody);
                writer.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode==HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }
        // REST @DELETE 方法
        public static bool doDeleteMethod(string metodUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(xiazhi_server_url + metodUrl);
            request.Method = "delete";
            request.ContentType = "application/json;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
            //using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8")))
            //{
            //    string responseString = reader.ReadToEnd();
            //    //if (responseString.Equals("1"))
            //    //{
            //    //    return true;
            //    //}
            //    //return false;
            //}
        }
        //// REST @DELETE 方法
        //public static bool doDeleteMethod(string metodUrl)
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(xiazhi_server_url + metodUrl);
        //    request.Method = "delete";
        //    request.ContentType = "application/json;charset=UTF-8";
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8")))
        //    {
        //        string responseString = reader.ReadToEnd();
        //        //if (responseString.Equals("1"))
        //        //{
        //        //    return true;
        //        //}
        //        //return false;
        //    }
        //}
        //根据实体，反射遍历实体所有属性，动态生成DataTable
        public static DataTable toDataTable(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                FieldInfo[] fieldInfos = list[0].GetType().GetFields();
                foreach (FieldInfo fi in fieldInfos)
                {
                    //if (fi.Name.Length > 4 && fi.Name.LastIndexOf("Date") == fi.Name.Length - 4)
                    //{
                    //    result.Columns.Add(fi.Name, "".GetType());
                    //    continue;
                    //}
                    //if (fi.Name.Length > 4 && fi.Name.LastIndexOf("Time") == fi.Name.Length - 4)
                    //{
                    //    result.Columns.Add(fi.Name, "".GetType());
                    //    continue;
                    //}
                    //if (fi.Name.IndexOf("imagepath") >= 0)
                    //{
                    //    result.Columns.Add(fi.Name, Image.FromFile("1.jpg").GetType());
                    //    continue;
                    //}
                    result.Columns.Add(fi.Name, fi.FieldType);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (FieldInfo fi in fieldInfos)
                    {
                        object obj = fi.GetValue(list[i]);
                        if (null == obj)
                        {
                            tempList.Add(obj);
                            continue;
                        }
                        //if (fi.Name.Length > 4 && fi.Name.LastIndexOf("Date") == fi.Name.Length - 4)
                        //{
                        //    int dateInt = (int)obj;
                        //    if (0 == dateInt)
                        //    {
                        //        tempList.Add("");
                        //        continue;
                        //    }
                        //    obj = DateTimeUtil.convertIntDatetime(dateInt).ToShortDateString();
                        //}
                        //if (fi.Name.Length > 4 && fi.Name.LastIndexOf("Time") == fi.Name.Length - 4)
                        //{
                        //    int dateInt = int.Parse(obj.ToString());
                        //    if (0 == dateInt)
                        //    {
                        //        tempList.Add("");
                        //        continue;
                        //    }
                        //    obj = DateTimeUtil.convertIntDatetime(dateInt).ToString();
                        //}
                        //if (fi.Name.IndexOf("imagepath") >= 0)
                        //{
                        //    if (null == obj)
                        //    {
                        //        tempList.Add("");
                        //        continue;
                        //    }
                        //    WebClient myWebClient = new WebClient();
                        //    MemoryStream ms = new MemoryStream(myWebClient.DownloadData(xiazhi_tomcat_url + obj.ToString()));
                        //    obj = Image.FromStream(ms);
                        //}
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.TableName = list[0].GetType().Name;
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
        ////根据实体，反射遍历实体所有属性，动态生成DataTable
        //public static DataTable toDataTable(IList list)
        //{
        //    DataTable result = new DataTable();
        //    if (list.Count > 0)
        //    {
        //        FieldInfo[] fieldInfos = list[0].GetType().GetFields();
        //        foreach (FieldInfo fi in fieldInfos)
        //        {
        //            if (fi.Name.Length > 4 && fi.Name.LastIndexOf("Date") == fi.Name.Length - 4)
        //            {
        //                result.Columns.Add(fi.Name, "".GetType());
        //                continue;
        //            }
        //            if (fi.Name.Length > 4 && fi.Name.LastIndexOf("Time") == fi.Name.Length - 4)
        //            {
        //                result.Columns.Add(fi.Name, "".GetType());
        //                continue;
        //            }
        //            if (fi.Name.IndexOf("imagepath") >= 0)
        //            {
        //                result.Columns.Add(fi.Name, Image.FromFile("1.jpg").GetType());
        //                continue;
        //            }
        //            result.Columns.Add(fi.Name, fi.FieldType);
        //        }

        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            ArrayList tempList = new ArrayList();
        //            foreach (FieldInfo fi in fieldInfos)
        //            {
        //                object obj = fi.GetValue(list[i]);
        //                if (null == obj)
        //                {
        //                    tempList.Add(obj);
        //                    continue;
        //                }
        //                if (fi.Name.Length > 4 && fi.Name.LastIndexOf("Date") == fi.Name.Length - 4)
        //                {
        //                    int dateInt = (int)obj;
        //                    if (0 == dateInt)
        //                    {
        //                        tempList.Add("");
        //                        continue;
        //                    }
        //                    obj = DateTimeUtil.convertIntDatetime(dateInt).ToShortDateString();
        //                }
        //                if (fi.Name.Length > 4 && fi.Name.LastIndexOf("Time") == fi.Name.Length - 4)
        //                {
        //                    int dateInt = int.Parse(obj.ToString());
        //                    if (0 == dateInt)
        //                    {
        //                        tempList.Add("");
        //                        continue;
        //                    }
        //                    obj = DateTimeUtil.convertIntDatetime(dateInt).ToString();
        //                }
        //                if (fi.Name.IndexOf("imagepath") >= 0)
        //                {
        //                    if (null == obj)
        //                    {
        //                        tempList.Add("");
        //                        continue;
        //                    }
        //                    WebClient myWebClient = new WebClient();
        //                    MemoryStream ms = new MemoryStream(myWebClient.DownloadData(xiazhi_tomcat_url + obj.ToString()));
        //                    obj = Image.FromStream(ms);
        //                }
        //                tempList.Add(obj);
        //            }
        //            object[] array = tempList.ToArray();
        //            result.LoadDataRow(array, true);
        //        }
        //    }
        //    return result;
        //}

    }
}
