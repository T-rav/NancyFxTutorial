using Nancy;
using UserOperations.Boundry;

namespace UserOperations.Delete
{
    public class DeleteUser : NancyModule
    {
        private readonly IUserRepository _userRepository;

        private DeleteUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public DeleteUser() : this(new UserRepository())
        {
            Delete["/api/users/{Id}"] = parameters =>
            {
                var id = parameters.Id;
                var deleteSuccessful = _userRepository.Delete(id);
                return deleteSuccessful ? HttpStatusCode.OK : HttpStatusCode.Gone;
            };
        }
    }
}