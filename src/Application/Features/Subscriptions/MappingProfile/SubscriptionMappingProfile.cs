using Application.Features.Subscriptions.Commands.CreateSubscription;
using Application.Features.Subscriptions.Commands.UpdateSubscription;
using Application.Features.Subscriptions.Dtos;

namespace Application.Features.Subscriptions.MappingProfile
{
    public class SubscriptionMappingProfile : Profile
    {
        public SubscriptionMappingProfile()
        {
            CreateMap<CreateSubscriptionCommand, Subscription>();
            CreateMap<UpdateSubscriptionCommand, Subscription>();
            CreateMap<Subscription, SubscriptionDto>();
        }
    }
}
