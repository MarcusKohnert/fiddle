namespace FSharpWebApiOwin

open System.Linq
open System.Web.Http.Results
open System.Web.Http
open System.Web
open System.Threading
open System.Net.Http
open System.Net
open System.Threading.Tasks
open Microsoft.AspNet.Identity
open Microsoft.Owin.Security.MicrosoftAccount
open System.Security.Claims
open System
open Microsoft.Owin.Security
open System.Security.Policy
open Microsoft.AspNet.Identity

type returnUrl = { ReturnUrl  : string; }
type redirectUri = { RedirectUri  : string; }

type ChallengeResult(provider, controller:ApiController) =
    interface IHttpActionResult with

        member __.ExecuteAsync(token:CancellationToken) =
            let auth = HttpContext.Current.GetOwinContext().Authentication

            let authProperties = new AuthenticationProperties()
            authProperties.RedirectUri <- "http://webApi.localtest.me:48213/Account/Callback?provider=Microsoft"

            auth.Challenge(authProperties, provider)

            let response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            response.RequestMessage <- controller.Request
            Task.FromResult(response)

type AccountController() =
    inherit ApiController()

    [<Route("Account/ExternalLogin")>]
    [<HttpGet>]
    member __.Login() =
        new ChallengeResult([|"Microsoft"|], __)

    [<Route("Account/Callback")>]
    [<HttpGet>]
    member __.CallbackMicrosoft(provider:string) =
        let auth = HttpContext.Current.GetOwinContext().Authentication
        let authResult = auth.AuthenticateAsync(DefaultAuthenticationTypes.ExternalCookie).Result
        auth.SignOut(DefaultAuthenticationTypes.ExternalCookie)

        let claims = authResult.Identity.Claims.ToList()
        claims.Add(new Claim(ClaimTypes.AuthenticationMethod, provider))

        let claimsIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie)
        auth.SignIn(claimsIdentity)

        __.Redirect("~/")