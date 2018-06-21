using ListifyWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.OAuth;

namespace ListifyWebApp.Controllers.api
{
    /// <summary>
    /// This Controller is used for Register, Login and List Items
    /// </summary>
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return Request.GetOwinContext().Authentication;
            }
        }
        private ApplicationDbContext _dbContext = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AccountController()
        {
            _dbContext = new ApplicationDbContext();            
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        /// <summary>
        /// SignInManager is used to create a SignIn Manager using GetOwinContext for the current Http request
        /// </summary>
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return Request.GetOwinContext().Get<ApplicationSignInManager>();
            }            
        }

        // POST api/User/Register
        /// <summary>
        /// This is used for user to Register an account
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("Register")]

        public async Task<HttpResponseMessage> RegisterUser(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return await this.BadRequest(this.ModelState).ExecuteAsync(new CancellationToken());
            }

            var user = new ApplicationUser
            {
                UserName = model.Name,
                Email = model.Email,
            };
            IdentityResult result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded )
            {
                var resultResponse = new {  message = "Registered Successfully" };
                HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.OK, resultResponse);
                return response1;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, " UserName or email is already taken");
                return response;
            }
        }

        private IdentityResult CreateAsync(ApplicationUser user, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This SignOut is used for users to logout their account
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpPost, System.Web.Http.AllowAnonymous, System.Web.Http.Route("logout")]
        public HttpResponseMessage SignOut()
        {
            this.AuthenticationManager.SignOut(CookieAuthenticationDefaults.AuthenticationType);

            var resultResponse = new { message = "Loggedout Successfully" };
            HttpResponseMessage response2 = Request.CreateResponse(HttpStatusCode.OK, resultResponse);
            return response2;
        }

        /// <summary>
        /// This is useful for user to Login his account
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("Login")]
        public async Task<HttpResponseMessage> Login(LoginViewModel login)
        {
            try
            {
                var _userEntity = await UserManager.FindByEmailAsync(login.Email);
                if (_userEntity != null)
                {
                    var result = SignInManager.PasswordSignIn(_userEntity.UserName, login.Password, false, false);
                   
                    if (result == Microsoft.AspNet.Identity.Owin.SignInStatus.Success)
                    {
                        var userResult = UserManager.Find(_userEntity.UserName, login.Password);
                        ClaimsIdentity oAuthIdentity = await userResult.GenerateUserIdentityAsync(UserManager);
                        var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
                        var token = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
                        string id = User.Identity.GetUserId();
                        id = RequestContext.Principal.Identity.GetUserId();
                        var resultResponse = new { accesstoken = token, /*userid = userResult.Id,*/ message = "LoggedIn Successfully" };
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, resultResponse);
                        return response;
                    }
                    else
                    {
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid user data");
                        return response;
                    }
                }
                else
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid user data");
                    return response;
                }
            }
            catch(Exception e)
            {
                e.StackTrace.ToString();
            }
            HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid user data");
            return response1;
            //IdentityResult result = await UserManager.get.GetLoginsAsync((_toDoEntity, login.Password);

        }
    }
}

   