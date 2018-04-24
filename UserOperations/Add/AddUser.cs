using Nancy;
using Nancy.ModelBinding;
using UserOperations.Boundry;

namespace UserOperations.Add
{
    public class AddUser : NancyModule
    {

        public AddUser(IUserRepository userRepository)
        {
            Post["/api/users"] = parameters =>
            {
                var input = this.Bind<User>();
                var id = userRepository.Save(input);

                var result = new { Id = id };

                return Response.AsJson(result);
            };
        }
    }
}