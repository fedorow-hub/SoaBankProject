﻿using ClientBankApp.Models.Root;

namespace ClientBankApp.Models.Client.ValueObjects
{
	public class Lastname : ValueObject
	{
		public string Name { get; }

		private Lastname(string name)
		{
			Name = name;
		}

		public static Lastname SetName(string name)
		{
			if (IsName(name))
			{
				return new Lastname(name);
			}
			throw new ArgumentException($"Фамилия \"{nameof(name)}\" не корректна");
		}

		public static bool IsName(string name)
		{
			if (name.Length <= 0) return false;
			return char.IsUpper(name[0]) && name.Length > 2;
		}

		protected override IEnumerable<object> GetEqalityComponents()
		{
			yield return Name;
		}

		public override string ToString()
		{
			return $"{Name}";
		}
	}
}
