using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    public class LogOutMenuCommand : MenuCommand
    {
        public LogOutMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
