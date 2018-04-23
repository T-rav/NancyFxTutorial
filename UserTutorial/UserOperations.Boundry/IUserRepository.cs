using System.Collections.Generic;

namespace UserOperations.Boundry
{
    public interface IUserRepository
    {
        bool Delete(int id);
        User Get(int id);
        List<User> Get_List_Of();
        int Save(User user);
    }
}