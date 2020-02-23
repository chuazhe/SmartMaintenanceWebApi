using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Net.Http;
using System.Net;
using SmartMaintenanceWebApi.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Diagnostics;
using Hangfire;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartMaintenanceWebApi.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {

        // The data structure expected by the service
        // The data structure expected by the service
        internal class InputData
        {
            [JsonProperty("data")]
            // The service used by this example expects an array containing
            //   one or more arrays of doubles
            internal ReadingData[] data;
        }

        [HttpGet("predict/{setting1}/{setting2}/{setting3}/{s1}/{s2}/{s3}/{s4}/{s5}/{s6}/{s7}/{s8}/{s9}/{s10}/{s11}/{s12}/{s13}/{s14}/{s15}/{s16}/{s17}/{s18}/{s19}/{s20}/{s21}")]
        public IActionResult GetPredictResult(int setting1,
                     int setting2,
                     int setting3,
                     int s1,
                     int s2,
                     int s3,
                     int s4,
                     int s5,
                     int s6,
                     int s7,
                     int s8,
                     int s9,
                     int s10,
                     int s11,
                     int s12,
                     int s13,
                     int s14,
                     int s15,
                     int s16,
                     int s17,
                     int s18,
                    int s19,
                     int s20,
                     int s21   )
        {
            {
                // Set the scoring URI and authentication key or token
                string scoringUri = "http://e1bfa688-0391-4596-89db-95e8d12b8f76.southeastasia.azurecontainer.io/score";

               ReadingData a = new ReadingData();

                a.setting1 = setting1;
                a.setting2 = setting2;
                a.setting3 = setting3;
                a.s1 = s1;
                a.s2 = s2;
                a.s3 = s3;
                a.s4 = s4;
                a.s5 = s5;
                a.s6 = s6;
                a.s7 = s7;
                a.s8 = s8;
                a.s9 = s9;
                a.s10 = s10;
                a.s11 = s11;
                a.s12 = s12;
                a.s13 = s13;
                a.s14 = s14;
                a.s15 = s15;
                a.s16 = s16;
                a.s17 = s17;
                a.s18 = s18;
                a.s19 = s19;
                a.s20 = s20;
                a.s21 = s21;

                InputData payload = new InputData();
                payload.data = new ReadingData[] {a};

                // Create the HTTP client
                HttpClient client = new HttpClient();

                // Make the request
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, new Uri(scoringUri));
                    request.Content = new StringContent(JsonConvert.SerializeObject(payload));
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = client.SendAsync(request).Result;
                    var content = response.Content.ReadAsStringAsync().Result;
                    // Display the response from the web service
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    return Ok(content);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.Message);
                }

                return BadRequest();

            }
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /*
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value"+id;

        }
        */

        [HttpPost("sendnoti")]
        public async Task<HttpResponseMessage> Post2([FromBody] NotificationsMessage item)
        {
            var user = "Test User";
            var pns = "fcm";
            var message = item.msg;

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
                    var notif = "{ \"data\" : {\"message\":\"" + message + "\"}}";
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


        [HttpPost("setnoti/{second}/{AircraftId}")]
        public void setNoti(int second, int AircraftId)
        {
            NotificationsMessage item = new NotificationsMessage();
            item.msg = "Maintenance of Aircraft " +AircraftId + " is scheduled to be held now.";

            
            BackgroundJob.Schedule(() => Debug.WriteLine("check"),
TimeSpan.FromSeconds(1));


            BackgroundJob.Schedule(() => Post2(item),
TimeSpan.FromSeconds(second));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
