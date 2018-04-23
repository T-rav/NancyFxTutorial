using System.Collections.Generic;
using System.Linq;
using UserOperations.Boundry;

namespace UserOperations
{
    public class UserRepository : IUserRepository
    {
        private static int _id = 1;
        private static readonly IDictionary<int, User> UserCollection = new Dictionary<int, User>();

        public int Save(User user)
        {
            user.Id = _id++;
            UserCollection.Add(user.Id, user);
            return user.Id;
        }

        public List<User> Get_List_Of()
        {
            return UserCollection.Values.ToList();
        }

        public User Get(int id)
        {
            User user;
            if (UserCollection.TryGetValue(id, out user))
            {
                return user;
            }

            return UserTypes.NotFound;
        }

        public bool Delete(int id)
        {
            User user;
            if (UserCollection.TryGetValue(id, out user))
            {
                return UserCollection.Remove(id);
            }

            return false;
        }
    }
}