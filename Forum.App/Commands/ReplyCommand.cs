using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    public class ReplyCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private ICommandFactory commandFactory;

        public ReplyCommand(ISession session, IPostService postService, ICommandFactory commandFactory)
        {
            this.session = session;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }
        public IMenu Execute(params string[] args)
        {
            int userId = this.session.UserId;
            string postId = args[0];
            string content = args[1];

            this.postService.AddReplyToPost(int.Parse(postId), content, userId);

            this.session.Back();
            ICommand command = this.commandFactory.CreateCommand("ViewPostMenu");

            return command.Execute(postId);
        }
    }
}
