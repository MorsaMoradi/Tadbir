
using Tadbir.Domain.Consumer;

namespace Tadbir.Worker
{

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPersonConsumerService _personConsumerService;
        private readonly IServiceProvider _serviceProvider;
        public Worker(ILogger<Worker> logger, IPersonConsumerService personConsumerService, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _personConsumerService = personConsumerService;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _logger.LogInformation("starting new instance app");
            _personConsumerService.Listen();
         
        }
        public override void Dispose()
        {
            base.Dispose();
           
        }
    }
}