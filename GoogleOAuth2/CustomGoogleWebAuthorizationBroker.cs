using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Util.Store;

namespace GoogleOAuth2
{
    public class CustomGoogleWebAuthorizationBroker : GoogleWebAuthorizationBroker
    {
        public static string RedirectUri = "http://localhost:50459/signed";

        public new static async Task<UserCredential> AuthorizeAsync(ClientSecrets clientSecrets, IEnumerable<string> scopes, string user, CancellationToken taskCancellationToken, IDataStore dataStore = null)
        {
            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = clientSecrets,
                Scopes = scopes,
                DataStore = dataStore ?? new FileDataStore(Folder)
            };
            return await AuthorizeAsyncCore(initializer, scopes, user, taskCancellationToken, dataStore).ConfigureAwait(false);
        }

        private static async Task<UserCredential> AuthorizeAsyncCore(GoogleAuthorizationCodeFlow.Initializer initializer, IEnumerable<string> scopes, string user, CancellationToken taskCancellationToken, IDataStore dataStore)
        {
            var flow = new CustomAuthorizationCodeFlow(initializer);
            return await new AuthorizationCodeInstalledApp(flow, new LocalServerCodeReceiver()).AuthorizeAsync(user, taskCancellationToken).ConfigureAwait(false);
        }
    }

    public class CustomAuthorizationCodeFlow : GoogleAuthorizationCodeFlow
    {
        public CustomAuthorizationCodeFlow(Initializer initializer)
            : base(initializer) { }

        public override AuthorizationCodeRequestUrl CreateAuthorizationCodeRequest(string redirectUri)
        {
            return base.CreateAuthorizationCodeRequest(CustomGoogleWebAuthorizationBroker.RedirectUri);
        }
    }

}