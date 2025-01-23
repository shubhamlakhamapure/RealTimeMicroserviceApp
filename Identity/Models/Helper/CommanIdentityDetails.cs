using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Identity.Models.Helper
{
    public static class CommanIdentityDetails
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";


        public static IEnumerable<IdentityResource> GetIdentityResources =>
         new List<IdentityResource>
            {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Email(),
                    new IdentityResources.Profile()
            };



        public static IEnumerable<ApiScope> GetApiScopes =>
                new List<ApiScope>
                {
                    new ApiScope(name: "imshubhamlack",   displayName: "Shubham Lakhamapure"),
                    new ApiScope(name: "read",   displayName: "Read your data."),
                    new ApiScope(name: "write",  displayName: "Write your data."),
                    new ApiScope(name: "delete", displayName: "Delete your data.")
                };


        public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "service.client",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "api1", "api2.read_only" }
            },

             new Client
            {
                ClientId = "imshubhamlack",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = { new Secret("secret".Sha256()) },

                RedirectUris = { "https://localhost:7171/signin-oidc" },

                PostLogoutRedirectUris = { "https://localhost:7171/signout-callback-oidc" },



                AllowedScopes =
                {
                     "imshubhamlack",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,

                    "api1", "api2.read_only"
                },
            }

        };





    }

}

