using Nancy;
using UserOperations.Boundry;

namespace UserOperations.List
{
    public class ListUsers : NancyModule
    {
        private readonly IUserRepository _userRepository;

        private ListUsers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ListUsers() : this(new UserRepository())
        {
            Get["/api/users"] = _ =>
            {
                var result = _userRepository.Get_List_Of();

                return Response.AsJson(result);
            };
        }
    }
}