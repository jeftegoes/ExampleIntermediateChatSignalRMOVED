using System.Collections.Generic;
using System.Linq;
using ExampleIntermediateChatSignalR.Models;

namespace ExampleIntermediateChatSignalR.Repository
{
    public class ConnectionRepository
    {
        private readonly Dictionary<string, User> connections = new Dictionary<string, User>();

        public void Add(string uniqueID, User user)
        {
            if(!connections.ContainsKey(uniqueID))
                connections.Add(uniqueID, user);
        }

        public string GetUserId(long id)
        {
            return connections.Where(c => c.Value.Key == id).FirstOrDefault().Key;
        }

        public List<User> GetUsers()
        {
            return connections.Values.ToList();
        }
    }
}