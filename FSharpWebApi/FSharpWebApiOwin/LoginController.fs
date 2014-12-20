namespace FSharpWebApiOwin

open System.Web.Http
open System.Security.Claims
open Microsoft.AspNet.Identity
open System.Web
open Microsoft.AspNet.Identity
open Microsoft.Owin.Security

type LoginController() =
    inherit ApiController()

    member private __.signIntoMiddleware() =
        let claims = [ new Claim(ClaimTypes.Name, "Marcus"); new Claim(ClaimTypes.Email, "someone@somewhere.com")]
        let authType = DefaultAuthenticationTypes.ApplicationCookie // must match middleware configuration
        let id = new ClaimsIdentity(claims, authType)
        let authManager = HttpContext.Current.GetOwinContext().Authentication

        let authProperties = new AuthenticationProperties() // optional
        authProperties.IsPersistent <- true
        authManager.SignIn(authProperties, id) // issues a cookie based on authType

    [<Route("Login/Login")>]
    [<HttpGet>]
    member __.Login() =
        match __.User.Identity.IsAuthenticated with
        | false -> __.Unauthorized([]) :> IHttpActionResult
        | _ -> __.Ok(__.User.Identity.Name) :> IHttpActionResult

    [<Route("Login/LoginExternal")>]
    [<HttpGet>]
    member __.LoginExternal(returnUrl:string) =
        __.signIntoMiddleware()
        __.Ok()

    [<Route("Login/Logout")>]
    [<HttpGet>]
    member __.Logout() =
        HttpContext.Current.GetOwinContext().Authentication.SignOut([||])
        __.Ok()