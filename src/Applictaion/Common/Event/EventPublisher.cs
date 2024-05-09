using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applictaion.Common.Event
{
    public class EventPublisher : IEventPublisher
    {
        IPublisher _mediator;
        public EventPublisher(IPublisher mediator)
        {

            _mediator = mediator;
        }
       

        public void Publish(IDomainEvent[] events)
        {
            foreach (var @event in events)
            {
                _mediator.Publish(@event).Wait();
            }
        }
    }
}
