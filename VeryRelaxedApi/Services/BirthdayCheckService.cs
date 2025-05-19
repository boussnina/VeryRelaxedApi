using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VeryRelaxedApi.BusinessLogic;
using VeryRelaxedApi.Repository;

public class BirthdayCheckService : BackgroundService
{
    private readonly ILogger<BirthdayCheckService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public BirthdayCheckService(ILogger<BirthdayCheckService> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("BirthdayCheckService started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.Now;
            var nextRun = DateTime.Today.AddDays(1).AddHours(6); // 6:00 AM tomorrow
            var delay = nextRun - now;

            _logger.LogInformation("Next birthday check scheduled for {time}", nextRun);
            await Task.Delay(delay, stoppingToken);

            using var scope = _scopeFactory.CreateScope();
            var refereeLogic = scope.ServiceProvider.GetRequiredService<IRefereeBusinessLogic>();

            var birthdayCoaches = await refereeLogic.GetRefereesWithBirthdayToday();

            foreach (var coach in birthdayCoaches)
            {
                _logger.LogInformation("🎉 It's {CoachName}'s birthday today!", coach.Name);
                // Do something: send email, update DB, etc.
            }
        }
    }
}
