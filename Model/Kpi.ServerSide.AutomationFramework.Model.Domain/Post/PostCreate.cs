using System;
using System.Collections.Generic;
using System.Text;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.Post
{
    public class PostCreate
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}
