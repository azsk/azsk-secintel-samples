using System;

namespace SecIntelSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Click on a statement below and press F12 or right click and select "Go To Definition" to go to its definition

            AzureStorageSample.GetAccountSASToken();
            AzureStorageSample.CreateBlobContainer();

            AzureStorageSample.GetAccountSASTokenErrorAboutInsecureProtocol();
            AzureStorageSample.GetAccountSASTokenWarnAboutExpiry();
            AzureStorageSample.CreateBlobContainerBlobAccessType();
            AzureStorageSample.CreateBlobContainerPublicAccessType();

            var dummy = AzureActiveDirectorySample.GetGroupsAsync(Guid.Empty.ToString()).Result;
            AzureActiveDirectorySample.GetAuthToken();

            AzureActiveDirectorySample.NewAuthenticationContextWithAuthorityValidationDisabled();
            AzureActiveDirectorySample.NewAuthenticationContextWithCustomTokenCache();
            AzureActiveDirectorySample.AccessTokenAccess();

           (new AzureServiceBusSample()).RunUsingRelay("", "");
        }
    }
}