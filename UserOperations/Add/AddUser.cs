using Nancy;
using Nancy.ModelBinding;
using UserOperations.Boundry;

namespace UserOperations.Add
{
    public class AddUser : NancyModule
    {
        private readonly IUserRepository _userRepository;

        private AddUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AddUser() : this(new UserRepository())
        {
            Post["/api/users"] = parameters =>
            {
                var input = this.Bind<User>();
                var id = _userRepository.Save(input);

                var result = new { Id = id };

                return Response.AsJson(result);
            };
        }
    }
}