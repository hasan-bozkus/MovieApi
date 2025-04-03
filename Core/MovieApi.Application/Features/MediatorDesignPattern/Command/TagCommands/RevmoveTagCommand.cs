using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Command.TagCommands
{
    public class RevmoveTagCommand : IRequest
    {
        public RevmoveTagCommand(int tagId)
        {
            TagId = tagId;
        }

        public int TagId { get; set; }
    }
}
