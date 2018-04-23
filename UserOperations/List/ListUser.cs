using Nancy;
using UserOperations.Boundry;

namespace UserOperations.List
{
    public class ListUser : NancyModule
    {
        private readonly IUserRepository _userRepository;

        private ListUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ListUser() : this(new UserRepository())
        {
            Get["/api/users/{Id}"] = parameters =>
            {
                var id = parameters.Id;
                User user = _userRepository.Get(id);
                if (UserNotFound(user))
                {
                    return HttpStatusCode.NotFound;
                }

                return Response.AsJson(user);
            };
        }

        private bool UserNotFound(User user)
        {
            return user == UserTypes.NotFound
        }
        
    }
}