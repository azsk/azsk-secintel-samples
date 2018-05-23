using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Xml;

namespace SecIntelSample
{
    public class AppSecGeneralSample
    {
        public void XmlSample()
        {
            XmlDocument xmlDoc = new XmlDocument();

            //  appsec_xml_doc_resolver
            xmlDoc.XmlResolver = null;

            XmlReaderSettings readerSettings = new XmlReaderSettings();

            //  appsec_xml_readerset_prohibitdtd
            readerSettings.ProhibitDtd = false;

            //  appsec_xml_doc_dtdprocessing_parse
            readerSettings.DtdProcessing = DtdProcessing.Parse;

        }

        public void IOSamlpe()
        {
            //  appsec_io_path_combine
            var path = Path.Combine("LocA", "LocB");

        }

        public void SqlSample()
        {
            // appsec_sql_cmd_combo_one
            // appsec_sql_cmd_combo_two
            var sqlCmd = new SqlCommand("somestatement");

            // appsec_sql_cmd_text
            sqlCmd.CommandType = CommandType.Text;

            // appsec_sql_cmd_sp
            sqlCmd.CommandType = CommandType.StoredProcedure;

            var dbContext = new DbContext("ConnStr");

            // appsec_ef_db_sqlcmd
            dbContext.Database.ExecuteSqlCommand("somestatement");

            // appsec_ef_db_sqlcmdasync
            dbContext.Database.ExecuteSqlCommandAsync("somestatement");
        }

        public void WebRequestHttpsSample()
        {
            // appsec_webrequest_https_default
            var request = (HttpWebRequest) WebRequest.Create("http://someapi/");

            // appsec_httprequestmessage_https_combo_one
            // appsec_httprequestmessage_https_combo_two
            var reqMessage = new HttpRequestMessage(HttpMethod.Get, "http://someuri");

            // appsec_httprequestmessage_https_requesturi
            reqMessage.RequestUri = new Uri("http://someuri");
        }

        public void WebClientHttpsSample()
        {
            var webClient = new WebClient();

            // appsec_webclient_https_baseaddress
            webClient.BaseAddress = "http://someapi/";

            // appsec_webclient_https_downloaddata
            webClient.DownloadData("http://someapi/");

            // appsec_webclient_https_downloadfile
            webClient.DownloadFile("http://somefileuri/", "somefile");
            
            // appsec_webclient_https_downloadstring
            webClient.DownloadString("http://someuri/");

            // appsec_webclient_https_uploaddata
            webClient.UploadData("http://someuri/", new byte[]{});

            // appsec_webclient_https_uploadfile
            webClient.UploadFile("http://someuri/", "somefile");

            // appsec_webclient_https_uploadstring
            webClient.UploadString("http://someuri/", "somestring");

            // appsec_webclient_https_uploadvalues
            webClient.UploadValues("http://someuri/", new NameValueCollection());
        }

        public void HttpClientHttpsSample()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://someuri");

            // appsec_httpclient_https_deleteasync
            httpClient.DeleteAsync("http://someuri");

            // appsec_httpclient_https_getasync
            httpClient.GetAsync("http://someuri");

            // appsec_httpclient_https_getbytearrayasync
            httpClient.GetByteArrayAsync("http://someuri");

            // appsec_httpclient_https_getstreamasync
            httpClient.GetStreamAsync("http://someuri");

            // appsec_httpclient_https_getstringasync
            httpClient.GetStringAsync("http://someuri");

            // appsec_httpclient_https_postasync
            httpClient.PostAsync("http://someuri", null);

            // appsec_httpclient_https_putasync
            httpClient.PutAsync("http://someuri", null);
        }

        public void DpApiSample()
        {
            // appsec_dataprotect_localmachine
            ProtectedData.Protect(new byte[] {}, new byte[] {}, DataProtectionScope.LocalMachine);
        }
    }
}