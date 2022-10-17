﻿using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AHM.Total.Travel.Api.ModelsAPI;
using AHM.Total.Travel.Api.ServiceAPI;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AHM.Total.Travel.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class NotificationsController : ControllerBase
    {
        readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("installations")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> UpdateInstallation(
     [Required] DeviceInstallation deviceInstallation)
        {
            var success = await _notificationService
                .CreateOrUpdateInstallationAsync(deviceInstallation, HttpContext.RequestAborted);

            if (!success)
                return new UnprocessableEntityResult();

            return new OkResult();
        }

        [AllowAnonymous]
        [HttpDelete()]
        [Route("installations/{installationId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        public async Task<ActionResult> DeleteInstallation(
            [Required][FromRoute] string installationId)
        {
            var success = await _notificationService
                .DeleteInstallationByIdAsync(installationId, CancellationToken.None);

            if (!success)
                return new UnprocessableEntityResult();

            return new OkResult();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("requests")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> RequestPush(
            [Required] NotificationRequest notificationRequest)
        {
            if ((notificationRequest.Silent &&
                string.IsNullOrWhiteSpace(notificationRequest?.Action)) ||
                (!notificationRequest.Silent &&
                string.IsNullOrWhiteSpace(notificationRequest?.Text)))
                return new BadRequestResult();

            var success = await _notificationService
                .RequestNotificationAsync(notificationRequest, HttpContext.RequestAborted);

            if (!success)
                return new UnprocessableEntityResult();

            return new OkResult();
        }
    }
}
