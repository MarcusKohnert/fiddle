namespace FSharpWebApiOwin

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

type returnUrl = { ReturnUrl  : string; }
type redirectUri = { RedirectUri  : string; }

type ChallengeResult(provider, controller:ApiController) =
    interface IHttpActionResult with

        member __.ExecuteAsync(token:CancellationToken) =
            let auth = HttpContext.Current.GetOwinContext().Authentication
            auth.Challenge(provider)

            let response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            response.RequestMessage <- controller.Request
            Task.FromResult(response)

type MicrosoftAuth() =
    inherit MicrosoftAccountAuthenticationProvider()

    override this.Authenticated(context:MicrosoftAccountAuthenticatedContext) =
            context.Identity.AddClaim(new Claim("ExternalAccessToken", context.AccessToken));
            new Task(fun () -> ())

type AccountController() =
    inherit ApiController()

    let externalLoginData(identity:ClaimsIdentity) =
        let providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
        (
            providerKeyClaim.Issuer,
            providerKeyClaim.Value,
            identity.FindFirstValue(ClaimTypes.Name),
            identity.FindFirstValue("ExternalAccessToken")
        )

    [<OverrideAuthentication>]
    [<HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)>]
    [<AllowAnonymous>]
    [<Route("ExternalLogin", Name = "ExternalLogin")>]
    member this.GetExternalLogin(provider, error) =
        let redirectUri = ""

        let authenticated = this.User.Identity.IsAuthenticated
        if authenticated = false then new ChallengeResult(provider, this) :> IHttpActionResult
        else
            let identity = this.User.Identity :?> ClaimsIdentity
            let (provider, providerKey, userName, externalAccessToken) = externalLoginData identity

            HttpContext.Current.GetOwinContext().Authentication.SignIn([| identity |])

            this.Ok() :> IHttpActionResult