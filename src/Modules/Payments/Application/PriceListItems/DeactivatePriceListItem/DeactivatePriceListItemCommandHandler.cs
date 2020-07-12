﻿using System.Threading;
using System.Threading.Tasks;
using CompanyName.MyMeetings.Modules.Payments.Application.Configuration.Commands;
using CompanyName.MyMeetings.Modules.Payments.Domain.PriceListItems;
using CompanyName.MyMeetings.Modules.Payments.Domain.SeedWork;
using MediatR;

namespace CompanyName.MyMeetings.Modules.Payments.Application.PriceListItems.DeactivatePriceListItem
{
    public class DeactivatePriceListItemCommandHandler : ICommandHandler<DeactivatePriceListItemCommand>
    {
        private readonly IAggregateStore _aggregateStore;

        public DeactivatePriceListItemCommandHandler(IAggregateStore aggregateStore)
        {
            _aggregateStore = aggregateStore;
        }

        public async Task<Unit> Handle(DeactivatePriceListItemCommand command, CancellationToken cancellationToken)
        {
            var priceListItem = await _aggregateStore.Load(new PriceListItemId(command.PriceListItemId));
            
            priceListItem.Deactivate();
            
            _aggregateStore.AppendChanges(priceListItem);
            
            return Unit.Value;
        }
    }
}