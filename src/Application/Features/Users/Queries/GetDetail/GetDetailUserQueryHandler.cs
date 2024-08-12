namespace Application.Features.Users.Queries.GetDetail
{
    public class GetDetailUserQueryHandler : IRequestHandler<GetDetailUserQuery, UserDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetDetailUserQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<UserDto> Handle(GetDetailUserQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.FindByIdAsync<User>(request.id);
            return mapper.Map<UserDto>(user);
        }
    }
}
