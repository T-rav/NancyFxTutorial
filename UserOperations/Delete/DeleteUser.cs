using Nancy;
using UserOperations.Boundry;

namespace UserOperations.Delete
{
    public class DeleteUser : NancyModule
    {
        public DeleteUser(IUserRepository userRepository)
        {
            Delete["/api/users/{Id}"] = parameters =>
            {
                var id = parameters.Id;
                var deleteSuccessful = userRepository.Delete(id);
                return deleteSuccessful ? HttpStatusCode.OK : HttpStatusCode.Gone;
            };
        }
    }
}