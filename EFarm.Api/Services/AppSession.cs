
namespace EFarm.Api.Services
{
	public class AppSession:IAppSession
	{
		readonly IHttpContextAccessor _contextAccessor;

		public AppSession(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}

		public string UserId
		{
			get
			{
				var 	userId = $"{Guid.NewGuid()}";
				if (_contextAccessor.HttpContext == null || _contextAccessor.HttpContext.Request==null)
				{
					CreateUser(userId);
					return userId;
				}
				var request = _contextAccessor.HttpContext.Request;
				if (request.Cookies["user"] == null)
				{
					CreateUser(userId); return userId;
				}
				else return request.Cookies["user"];
				 
			}
		
		}

		private void CreateUser(string userId)
		{
			if (_contextAccessor.HttpContext != null)
			_contextAccessor.HttpContext.Response.Cookies.Append("user", userId);
		}
	}
}
