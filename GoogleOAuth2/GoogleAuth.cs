using System;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Drive.v2.Data;

using System.Threading;
using GoogleOAuth2.Models;

namespace GoogleOAuth2
{

    public class GoogleAuth
    {
        private static string clientId = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";      // From https://console.developers.google.com
        private static string clientSecret = "XXXXXXXXXXXXXXXXX";          // From https://console.developers.google.com

        private static Google.Apis.Drive.v2.DriveService service;

        public static UserCredential credential;

        public static string REFRESH_TOKEN;

        public static void GetService_v2()
        {

            try
            {
                //Scopes for use with the Google Drive API
                string[] scopes = new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile };
                
                using (var cts = new CancellationTokenSource())
                {
                    cts.CancelAfter(TimeSpan.FromMinutes(2));

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                    {
                        ClientId = clientId,
                        ClientSecret = clientSecret
                    }, scopes, Environment.UserName, CancellationToken.None, new FileDataStore("GoogleDrive.Auth.Store")).Result;
                }
            } catch (Exception ex)
            {

            }

            
        }

        public static void StartService()
        {
            service = new Google.Apis.Drive.v2.DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GoogleDriveRestAPI-v2",
            });
        }

        public static List<GoogleDriveFile> GetDriveFiles()
        {

            // Define parameters of request.
            Google.Apis.Drive.v2.FilesResource.ListRequest FileListRequest = service.Files.List();

            // List files.
            FileList files = FileListRequest.Execute();
            List<GoogleDriveFile> FileList = new List<GoogleDriveFile>();

            if (files != null)
            {
                foreach (File file in files.Items)
                {
                    GoogleDriveFile File = new GoogleDriveFile
                    {
                        id = file.Id,
                        name = file.OriginalFilename,
                        size = file.FileSize,
                        version = file.Version,
                        createdTime = file.CreatedDate
                    };
                    FileList.Add(File);
                }
            }
            return FileList;
        }
        
    }

}