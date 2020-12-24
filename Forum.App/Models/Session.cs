namespace Forum.App.Models
{
	using Contracts;
	using DataModels;
    using System.Collections.Generic;
    using System.Linq;

	//Keeps information about whether the user is logged in or not, current menu, history
	// and some corresponding functionallity.
    public class Session : ISession
	{
		private User user;
		private Stack<IMenu> history;

        public Session()
        {
			history = new Stack<IMenu>();
        }
		public string Username => this.user?.Username;

		public int UserId => this.user?.Id ?? 0;

		public bool IsLoggedIn => this.user != null;
		public IMenu CurrentMenu => this.history.Peek();

		//If there are more than one menus in history it pops the last one, then peeks
		//the previous one, calls its Open() method and returns the menu.
		public IMenu Back()
		{
            if (history.Count > 1)
            {
				this.history.Pop();
            }

			IMenu menu = this.history.Peek();
			menu.Open();

			return menu;
		}

		public void LogIn(User user)
		{
			this.user = user;
		}

		public void LogOut()
		{
			this.user = null;
		}

		//Pushes a new menu to the history stack.
		public bool PushView(IMenu view)
		{
			//Making sure that we don't push two same menus in a row
			if (!this.history.Any() || this.history.Peek() != view)
			{
				this.history.Push(view);
				return true;
			}

			return false;
		}

		public void Reset()
		{
			this.user = null;
			this.history = new Stack<IMenu>();
		}
	}
}
