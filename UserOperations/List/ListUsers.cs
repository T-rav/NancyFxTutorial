using Nancy;
using UserOperations.Boundry;

namespace UserOperations.List
{
    public class ListUsers : NancyModule
    {
        public ListUsers(IUserRepository userRepository) //: this(new UserRepository())
        {
            Get["/api/users"] = _ =>
            {
                var result = userRepository.Get_List_Of();

                return Response.AsJson(result);
            };
        }
    }
}