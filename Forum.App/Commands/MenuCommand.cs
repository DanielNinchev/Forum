using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    public abstract class MenuCommand : ICommand
    {
        private IMenuFactory menuFactory;
        public MenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = menuFactory.CreateMenu(menuName);

            return menu;
        }
    }
}
