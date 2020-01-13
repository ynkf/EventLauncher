using Eventlauncher.Web.Services.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eventlauncher.Web.Services
{
    public class AppointmentService : BackgroundService
    {
        private readonly ILogger<AppointmentService> _logger;
        private readonly ICalendarService _calendarService;
        private readonly IComputerService _computerService;

        public AppointmentService(
            ILogger<AppointmentService> logger,
            ICalendarService calendarService,
            IComputerService computerService)
        {
            _logger = logger;
            _calendarService = calendarService;
            _computerService = computerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var delayTime = TimeSpan.FromMinutes(5);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Worker running at: {DateTime.Now}");

                var allAppointments = await _calendarService.GetAllAppointmentsForRooms();
                _logger.LogInformation($"Found {allAppointments.Count} appointments");

                var computersToAwake = allAppointments
                    .Where(x => x.DateTime > DateTime.Now
                                && x.DateTime <= DateTime.Now.Add(delayTime))
                    .Select(x => x.Room.Computer)
                    .Distinct();
                _logger.LogInformation($"Found {computersToAwake.Count()} individual computers");

                foreach (var computer in computersToAwake)
                {
                    _logger.LogInformation($"Awakening computer with IP-address '{computer.IpAddress}'");
                    try
                    {
                        await _computerService.AwakeComputer(computer.IpAddress);
                    }
                    catch (Exception e)
                    {
                        _logger.LogWarning($"An error happened while awakening computer with IP-address '{computer.IpAddress}'{Environment.NewLine}{e}");
                    }
                }

                _logger.LogInformation($"Worker sleeping until {DateTime.Now + delayTime}");
                await Task.Delay(delayTime, stoppingToken);
            }
        }
    }
}