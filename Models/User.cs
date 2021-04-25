using System;

namespace ExampleIntermediateChatSignalR.Models
{
    public class User
    {
        public string Name { get; set; }
        public long Key { get; set; }
        public DateTime DtConnection { get; set; }
    }
}