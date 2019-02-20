using System.Runtime.Serialization;

namespace CrudASP_NET_CORE.Model
{
    public class Users
    {
        public long? Id { get; set; }
        public string login { get; set; }
        public string AccessKey { get; set; }

    }
}
