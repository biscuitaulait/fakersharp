using Newtonsoft.Json.Linq;
using System.Net;

namespace FakerSharp
{
    public class Person
    {
        public string Title { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Gender { get; private set; }
        public string Email { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public int Age { get; private set; }
        public DateTime DOB { get; private set; }
        public string Nation { get; private set; }

        public Person()
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("https://randomuser.me/api/");

            JObject obj = JObject.Parse(JObject.Parse(json)["results"][0].ToString());

            Title = obj["name"]["title"].ToString();
            Name = obj["name"]["first"].ToString();
            LastName = obj["name"]["last"].ToString(); 
            Email = obj["email"].ToString();
            Country = obj["location"]["country"].ToString();
            State = obj["location"]["state"].ToString();
            City = obj["location"]["city"].ToString();
            Street = obj["location"]["street"]["name"].ToString();
            Age = int.Parse(obj["dob"]["age"].ToString());
            DOB = DateTime.Parse(obj["dob"]["date"].ToString());
            Nation = obj["nat"].ToString();
        }
    }
}