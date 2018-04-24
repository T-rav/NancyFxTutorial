using Nancy;
using UserOperations.Boundry;

namespace UserOperations.List
{
    public class ListUser : NancyModule
    {
        public ListUser(IUserRepository userRepository)
        {
            Get["/api/users/{Id}"] = parameters =>
            {
                var id = parameters.Id;
                User user = userRepository.Get(id);
                if (UserNotFound(user))
                {
                    return HttpStatusCode.NotFound;
                }

                return Response.AsJson(user);
            };
        }

        private bool UserNotFound(User user)
        {
            return user == UserTypes.NotFound;
        }
    }
}