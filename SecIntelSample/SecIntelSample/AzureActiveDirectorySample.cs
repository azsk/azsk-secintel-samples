using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.Azure.ActiveDirectory.GraphClient.Extensions;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace SecIntelSample
{
	// Azure Active Directory Samples

	public class AzureActiveDirectorySample
	{
		// Graph API - Fetching user's group membership sample
		// Rule ID: azure_aad_avoid_memberof
		public static async Task<object> GetGroupsAsync(string objectId)
		{
			IList<Group> groupMembership = new List<Group>();

			try
			{
				ActiveDirectoryClient client = new ActiveDirectoryClient(null, null);

				IUser user = await client.Users.GetByObjectId(objectId).ExecuteAsync();
				var userFetcher = (IUserFetcher)user;

				// Warning is generated when MemberOf is accessed as it returns non-transitive set

				IPagedCollection<IDirectoryObject> pagedCollection = await userFetcher.MemberOf.ExecuteAsync();
				do
				{
					List<IDirectoryObject> directoryObjects = pagedCollection.CurrentPage.ToList();
					foreach (IDirectoryObject directoryObject in directoryObjects)
					{
						if (directoryObject is Group)
						{
							var group = directoryObject as Group;
							groupMembership.Add(group);
						}
					}
					pagedCollection = await pagedCollection.GetNextPageAsync();
				} while (pagedCollection != null);
			}
			catch (Exception)
			{

			}
			return null;
		}


		// ADAL - Fetching token

		public static string GetAuthToken()
		{
			var credential = new ClientCredential("", "");

			var context = new AuthenticationContext("http://uri");

			// Warning generated due to authority validation is disabled

			context = new AuthenticationContext("", false);

			// Safe

			context = new AuthenticationContext("", true);

			// Warning generated due to usage of custom cache

			context = new AuthenticationContext("", true, new TokenCache());

			// Warning generated due to authority validation is disabled and usage of custom cache

			context = new AuthenticationContext("", false, new TokenCache());

			var authenticationResult =
				 context.AcquireTokenAsync("", credential).Result;

			// Warning generated as a cautionary note to securely handle

			var accessToken = authenticationResult.AccessToken;

			return accessToken;
		}


		// Rule ID: azure_aad_authority_validation_turned_off
		public static void NewAuthenticationContextWithAuthorityValidationDisabled()
		{
			var credential = new ClientCredential("", "");

			var context = new AuthenticationContext("http://uri");

			// Warning generated due to authority validation is disabled
			context = new AuthenticationContext("", false);
			// Safe
			context = new AuthenticationContext("", true);

			// Warning generated due to authority validation is disabled when using custom token cache
			context = new AuthenticationContext("", false, new TokenCache());
			// Safe
			context = new AuthenticationContext("", true, new TokenCache());

		}

		// Rule ID: azure_aad_avoid_custom_token_caching
		public static void NewAuthenticationContextWithCustomTokenCache()
		{
			var credential = new ClientCredential("", "");

			var context = new AuthenticationContext("http://uri");

			// Warning generated due to usage of custom cache
			context = new AuthenticationContext("", new TokenCache());
			// Safe
			context = new AuthenticationContext("");


			// Warning generated due to usage of custom cache
			context = new AuthenticationContext("", false, new TokenCache());
			// Safe
			context = new AuthenticationContext("", true);
		}


		// Rule ID: azure_adal_avoid_accesstoken_in_code
		public static string AccessTokenAccess()
		{
			var credential = new ClientCredential("", "");
			var context = new AuthenticationContext("http://uri");
			context = new AuthenticationContext("");
			var authenticationResult =
				 context.AcquireTokenAsync("", credential).Result;

			// Warning generated as a cautionary note to securely handle
			var accessToken = authenticationResult.AccessToken;
			return accessToken;
		}
	}
}