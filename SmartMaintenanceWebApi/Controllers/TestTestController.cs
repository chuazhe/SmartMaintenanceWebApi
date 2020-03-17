using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMaintenanceWebApi.Models;

namespace SmartMaintenanceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestTestController : ControllerBase
    {

        [HttpPost("sendnoti")]
        public async Task<HttpResponseMessage> Post2([FromBody] NotificationsMessage item)
        {
            var user = "Test User";
            var pns = "fcm";
            var message = item.msg;
            var manager = item.manager;

            Microsoft.Azure.NotificationHubs.NotificationOutcome outcome = null;
            HttpStatusCode ret = HttpStatusCode.InternalServerError;

            switch (pns.ToLower())
            {
                case "wns":
                    // Windows 8.1 / Windows Phone 8.1
                    var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" +
                                "From " + user + ": " + message + "</text></binding></visual></toast>";
                    outcome = await Notifications.Instance.Hub.SendWindowsNativeNotificationAsync(toast);
                    break;
                case "apns":
                    // iOS
                    var alert = "{\"aps\":{\"alert\":\"" + "From " + user + ": " + message + "\"}}";
                    outcome = await Notifications.Instance.Hub.SendAppleNativeNotificationAsync(alert);
                    break;
                case "fcm":
                    // Android
                    var notif = "{ \"data\" : {\"message\":\"" + message + "\",\"manager\":\"" + manager + "\"}}";
                    outcome = await Notifications.Instance.Hub.SendFcmNativeNotificationAsync(notif);
                    break;
            }

            if (outcome == null)
            {
                return new HttpResponseMessage(ret);
            }

            if (!(outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Abandoned
                || outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Unknown))
            {
                ret = HttpStatusCode.OK;
            }

            return new HttpResponseMessage(ret);


        }
    }
}