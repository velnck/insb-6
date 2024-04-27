using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace App
{
	public enum Role
	{
		User,
		Admin
	}
	public class User
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public Role Role { get; set; }
		[JsonProperty("Records")]
		public List<string> Records = new List<string>();

		public User(string username, string password, Role role, List<string> records)
		{
			Username = username;
			Password = password;
			Role = role;
			if (records != null)
			{
				Records = records;
			}
		}
		public bool CheckIsPasswordCorrect(string password)
		{
			return password == Password;
		}
		public void AddRecord(string record)
		{
			Records.Add(record);
		}
	}
	public class UsersList
	{
		private static List<User> _users = null;
		public static readonly string FileName = @"D:\univ\labs\s6\исоб\labs\lab4\App\data.json";

		public static User Find(string username)
		{
			if (_users == null)
			{
				LoadUsersList();
			}
			User user = _users.Find(u => u.Username == username);
			return user;
		}
		public static List<User> GetAll()
		{
			if (_users == null)
			{
				LoadUsersList();
			}
			return _users;
		}
		private static void LoadUsersList()
		{
			string str = File.ReadAllText(FileName);
			_users = JsonConvert.DeserializeObject<List<User>>(str);
		}
		public static void AddNewUser(string username, string password)
		{
			_users.Add(new User(username, password, Role.User, null));
		}
	}
}
