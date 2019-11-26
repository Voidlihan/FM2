using FarmersMarket.DataAccess;
using FarmersMarket.Domain;
using FarmersMarket.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static BCrypt.Net.BCrypt;

namespace FarmersMarket.Services
{
	public class AuthService : IAuthService
	{
		private readonly FarmersMarketContext context;

		public AuthService(FarmersMarketContext context)
		{
			this.context = context;
		}

		public User SignUp(string email, string password)
		{
			if (!IsValidEmail(email) || !IsValidPassword(password)) return null;
			if (isExist(email)) return null;

			var newUser = new User
			{
				Login = email.ToLower(),
				Password = HashPassword(password)
			};

			var customer = new Customer
			{
				User = newUser
			};

			context.Users.Add(newUser);
			context.SaveChanges();
			return newUser;
		}

		public bool isExist(string email)
		{
			var user = context.Users.SingleOrDefault(user => user.Login == email.ToLower());
			return !(user == null);
		}

		public User SignIn(string email, string password)
		{
			var user = context.Users.SingleOrDefault(user => user.Login == email.ToLower());
			return user == null || !Verify(password, user.Password) ? null : user;
		}

		private bool IsValidEmail(string email)
		{
			string emailFormat = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
				@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

			return Regex.IsMatch(email, emailFormat);
		}

		private bool IsValidPassword(string password)
		{
			if (password.Trim().Length >= 6) return true;
			return false;
		}
	}
}
