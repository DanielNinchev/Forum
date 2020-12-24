using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    public class LogInMenuCommand : MenuCommand
    {
        public LogInMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {

        }
    }
}
