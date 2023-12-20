namespace Common.Api;

public class ApiWithSessionController : ApiController
{
    protected Session GetSession()
    {
        // HttpContext.User.
        // TODO: Add logic
        return new Session(1);
    }
    
    protected long GetUserId()
    {
        return GetSession().UserId;
    }
}