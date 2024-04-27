using Newtonsoft.Json;
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
		[JsonIgnore]
		public bool IsLoggedIn { get; set; } = false;

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
			if (IsLoggedIn)
			{
				Records.Add(record);
			}
			else
			{
				throw new Exception("User is not logged in.");
			}
		}
	}
	public class UsersList
	{
		private static List<User> _users = null;
		public static readonly string FileName = @"D:\univ\labs\s6\исоб\labs\lab4\App\data.json";

		private static User Find(string username)
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

		internal static User? LogIn(string username, string password)
		{
			User user = Find(username);
			if (user == null)
			{
				throw new Exception("User not found.");
			}
			else if (user.IsLoggedIn) {
				throw new Exception("User is already logged in.");
			}
			else
			{
				if (user.CheckIsPasswordCorrect(password))
				{
					user.IsLoggedIn = true;
					return user;
				}
				else
				{
					return null;
				}
			}
		}

		internal static bool Exists(string username)
		{
			return Find(username) != null;
		}

		internal static void LogOut(User user)
		{
			user.IsLoggedIn = false;
		}
	}
}
