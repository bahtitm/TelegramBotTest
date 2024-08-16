namespace Application.Features.Subscriptions.Commands.DeleteSubscription
{
    public record DeleteSubscriptionCommand(uint id) : IRequest;
}
