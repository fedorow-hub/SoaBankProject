﻿using ClientBankApp.Infrastructure.Commands.Base;
using System.Windows;

namespace ClientBankApp.Infrastructure.Commands
{
	public class CloseApplicationCommand : Command
	{
		public override bool CanExecute(object? parameter) => true;

		public override void Execute(object? parameter)
		{
			Application.Current.Shutdown();
		}
	}
}
