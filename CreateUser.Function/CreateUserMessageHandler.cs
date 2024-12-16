using Microsoft.Extensions.Logging;

namespace CreateUser.Function
{
    public class CreateUserMessageHandler : IHandleMessages<Core.Services.Common.Account.Commands.CreateUser>
    {
        private readonly ILogger<CreateUserMessageHandler> _logger;

        public CreateUserMessageHandler(ILogger<CreateUserMessageHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(Core.Services.Common.Account.Commands.CreateUser message, IMessageHandlerContext context)
        {
            //    public class CreateUserService(string connectionString, IMessageSession messageSession, ILogger logger, IVehicleService vehicleService) : ICreateUserService
            //    Task<string> UserCreate(CreateUser userCommand, string authorization)
            //    return string like, "Error inserting user", "User created successfully", "Internal server error

            try
            {
                var initMethodMessage = $"Function: CreateUser Handler Message: {message}";
                _logger.LogInformation(initMethodMessage);

                // Call library command
                await LibraryEventHandler.UserCreate(message, message.AccessToken);

                // ?? OR perform Send
                // ??pass access token via CreateUser 

                //SendCreateUserCommand(message, context); //, authorization);

                // Log event
                _logger.LogInformation("CreateUser event processed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing CreateUser event.");

            }
        }

        private Task SendCreateUserCommand(Core.Services.Common.Account.Commands.CreateUser message, IMessageHandlerContext context)
        {
            var createUserCommand = new Core.Services.Common.Account.Commands.CreateUser
            {
                SessionId = message.SessionId,
                NewUser = message.NewUser,
                UserId = message.UserId
            };

            return context.Send(createUserCommand);
        }
    }
}
