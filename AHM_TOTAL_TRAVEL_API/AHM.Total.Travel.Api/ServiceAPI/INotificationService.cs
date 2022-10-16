using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using AHM.Total.Travel.Api.ModelsAPI;


namespace AHM.Total.Travel.Api.ServiceAPI
{
    public interface INotificationService
    {
        Task<bool> CreateOrUpdateInstallationAsync(DeviceInstallation deviceInstallation, CancellationToken token);
        Task<bool> DeleteInstallationByIdAsync(string installationId, CancellationToken token);
        Task<bool> RequestNotificationAsync(NotificationRequest notificationRequest, CancellationToken token);
    }
}
