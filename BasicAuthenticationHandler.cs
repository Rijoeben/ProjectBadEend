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
     
            
            BadeendCredentialsDatabase db = new BadeendCredentialsDatabase();

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
            
        }
    }
}
