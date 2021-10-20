using LiteDB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bad_eend.Data;
using Newtonsoft.Json.Linq;


namespace Bad_eend
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
                IOptionsMonitor<AuthenticationSchemeOptions> options,
                ILoggerFactory logger,
                UrlEncoder encoder,
                ISystemClock clock
                ) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Response.Headers.Add("WWW-Authenticate", "Basic");

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization header missing."));
            }

            // Get authorization key
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var authHeaderRegex = new Regex(@"Basic (.*)");

            if (!authHeaderRegex.IsMatch(authorizationHeader))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization code not formatted properly."));
            }

            var authBase64 = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderRegex.Replace(authorizationHeader, "$1")));
            var authSplit = authBase64.Split(Convert.ToChar(":"), 2);
            var authUsername = authSplit[0];
            var authPassword = authSplit.Length > 1 ? authSplit[1] : throw new Exception("Unable to get password");

            HashingHandler hasher = new HashingHandler();
     
            /*
            BadeendCredentialsDatabase db = new BadeendCredentialsDatabase(); // Dit kan niet want dan kan die in de main database class der ni aan

            List<string> creds = db.FindCredentials(authUsername);
            // creds[0] = password, creds[1] = salt,  creds[2] = role


            if (creds.Count > 0)
            {
                if (creds[0] == hasher.Encrypt_Data(authPassword + creds[1]))
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, authUsername));

                    if (creds[2] == "Root") claims.Add(new Claim(ClaimTypes.Role, "Root"));
                    if (creds[2] == "Admin") claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    if (creds[2] == "User") claims.Add(new Claim(ClaimTypes.Role, "User"));

                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Custom"));

                    return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
                }
               
            }
            return Task.FromResult(AuthenticateResult.Fail("The username or password is not correct."));
            */
            
            string rootData = @"{
                'Username': 'root',
                'Password': '08659fe5d318651296ee8eb351b8d34ca1720581026a28fe905c69ea13602b3a',
                 'Salt': 'uTRr7isPV/O+dEOkk4XGfY3tzoQ/OlOEFYX1R9YIk04=',
                 'Role': 'Root'
                }";

            var jsonRoot = JObject.Parse(rootData);
            string adminData = @"{
                'Username': 'admin',
                'Password': '262927a38c69b057420387d7f2964a374f394c2ff0028d1e576b6128c6fae802',
                 'Salt': 'wTW3SU0kr03Sw5aBqyghjCv0WVW8VU1uVszOj0/NM3I=',
                 'Role': 'Admin'
                }";

            var jsonAdmin = JObject.Parse(adminData);
            string userData = @"{
                'Username': 'user',
                'Password': '8211a1d5b3f4242978f5251085dbe0f732a42839332153abe3fa94b522588fff2',
                 'Salt': 'xag7XHvw4ns/x0qLT7T1ZoPoHSOuYYpGesPXn7nZRGE=',
                 'Role': 'User'
                }";

            var jsonUser = JObject.Parse(userData);

            List<JObject> creds = new List<JObject>() { jsonRoot, jsonAdmin, jsonUser};

            int index = -1;
            switch (authUsername)
            {
                case "root":
                    index = 0;
                    break;
                case "admin":
                    index = 1;
                    break;
                case "user":
                    index = 2;
                    break;
                default:
                    break;
            }

            if (creds[index]["Password"].ToString() == hasher.Encrypt_Data(authPassword + creds[index]["Salt"].ToString()))
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, authUsername));

                    if (creds[index]["Role"].ToString() == "Root") claims.Add(new Claim(ClaimTypes.Role, "Root"));
                    if (creds[index]["Role"].ToString() == "Admin") claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    if (creds[index]["Role"].ToString() == "User") claims.Add(new Claim(ClaimTypes.Role, "User"));

                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Custom"));

                    return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
                }

            
            return Task.FromResult(AuthenticateResult.Fail("The username or password is not correct."));
            
        }
    }
}
