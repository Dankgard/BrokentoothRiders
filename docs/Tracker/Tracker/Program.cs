﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Web;

namespace Tracker
{
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }

    class Program
    {
        static void Main() {
            Account account = new Account
            {
                Email = "lope@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
    {
        "User 121321",
        "Admin"
    }
            };

            string json = JsonConvert.SerializeObject(account, Formatting.Indented);

            File.WriteAllText("../Files/text.json", json);
            string json2 = File.ReadAllText("../Files/text.json");

            // Deserealizar
            Account acc = JsonConvert.DeserializeObject<Account>(json2);
            Console.WriteLine(acc.Email);
        }
    }
}
