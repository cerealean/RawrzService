using RawrzMe.Library.Daos;

namespace RawrzMe.Library.Services
{
    public class Login
    {
        public Models.User AttemptLogin(Models.Login loginModel)
        {
            using (var dao = new UserDao())
            {
                return dao.GetUserByUsername(loginModel.Username);
            }
        }
    }
}
