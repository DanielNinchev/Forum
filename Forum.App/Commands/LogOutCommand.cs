using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    public class LogOutCommand : ICommand
    {
        private IMenuFactory menuFactory;
        private ISession session;

        public LogOutCommand(ISession session, IMenuFactory menuFactory)
        {
            this.session = session;
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params string[] args)
        {
            this.session.Reset();

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}
