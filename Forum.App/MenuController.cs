﻿namespace Forum.App
{
	using System;

	using Microsoft.Extensions.DependencyInjection;

	using Contracts;
	using Menus;

	//Holds the functionality of navigating through menus.
	internal class MenuController : IMainController
	{
		private IServiceProvider serviceProvider;

		private IForumViewEngine viewEngine;
		private ISession session; //holds information about whether the user is logged in or not;
		private ICommandFactory commandFactory;
		private ILabelFactory labelFactory;

		public MenuController(ILabelFactory labelFactory, IServiceProvider serviceProvider, IForumViewEngine viewEngine, ISession session, ICommandFactory commandFactory)
		{
			this.serviceProvider = serviceProvider;
			this.viewEngine = viewEngine;
			this.session = session;
			this.commandFactory = commandFactory;
			this.labelFactory = labelFactory;

			//this.CurrentMenu = new MainMenu(session, labelFactory, commandFactory);

			this.InitializeSession();

			//this.RenderCurrentView();
		}

		private string Username { get; set; }

		//Replace CurrentMenu with this after implementing Session
		//private IMenu CurrentMenu => this.session.CurrentMenu;

		private IMenu CurrentMenu { get => this.session.CurrentMenu; }

		private void InitializeSession()
		{
			this.session.PushView(new MainMenu(this.session,
				this.serviceProvider.GetService<ILabelFactory>(),
				this.serviceProvider.GetService<ICommandFactory>()));

			this.RenderCurrentView();
		}

		private void RenderCurrentView()
		{
			//this.viewEngine.RenderMenu(this.CurrentMenu);
			this.viewEngine.RenderMenu(this.session.CurrentMenu);

		}

		public void MarkOption()
		{
			this.viewEngine.Mark(this.CurrentMenu.CurrentOption);

		}

		public void UnmarkOption()
		{
			this.viewEngine.Mark(this.CurrentMenu.CurrentOption, false);
		}

		public void NextOption()
		{
			this.CurrentMenu.NextOption();
		}

		public void PreviousOption()
		{
			this.CurrentMenu.PreviousOption();
		}

		public void Back()
		{
			this.session.Back();
			RenderCurrentView();
		}

		public void Execute()
		{
			this.session.PushView(this.CurrentMenu.ExecuteCommand());
			this.RenderCurrentView();
		}
	}
}