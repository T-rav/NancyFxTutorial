using System.Collections.Generic;
using System.Linq;
using UserOperations.Boundry;

namespace UserOperations
{
    public class UserRepository : IUserRepository
    {
        public static int Id = 1;
        private static readonly IDictionary<int, User> _userCollection = new Dictionary<int, User>();

        public int Save(User user)
        {
            user.Id = Id++;
            _userCollection.Add(user.Id, user);
            return user.Id;
        }

        public List<User> Get_List_Of()
        {
            return _userCollection.Values.ToList();
        }

        public User Get(int id)
        {
            User user;
            if (_userCollection.TryGetValue(id, out user))
            {
                return user;
            }

            return null;
        }

        public bool Delete(int id)
        {
            User user;
            if (_userCollection.TryGetValue(id, out user))
            {
                return _userCollection.Remove(id);
            }

            return false;
        }
    }
}