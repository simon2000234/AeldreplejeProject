using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ValidationAPI.Core.Entity;

namespace LoadBalancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private HttpClient _client;
        private LoadBalancer _balancer;
        private string _link;
        public ValidationController()
        {
            _client = new HttpClient();
            _balancer = LoadBalancer.GetInstance();
            _link = _balancer.GetHost();
        }


        [HttpPost]
        [Route("GroupCreate")]
        public ActionResult ValidateGroupCreate([FromBody] Group content)
        {
            try
            {
                string json = JsonConvert.SerializeObject(content);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Content = data,
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(_link + "/api/Validator/GroupCreate")
                };
                var result = _client.SendAsync(request).Result;

                if (result.IsSuccessStatusCode)
                {
                    return Ok();
                }

                throw new InvalidDataException(result.ReasonPhrase);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("GroupUpdate")]
        public ActionResult ValidateGroupUpdate([FromBody] Group content)
        {
            try
            {
                string json = JsonConvert.SerializeObject(content);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Content = data,
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(_link + "/api/Validator/GroupUpdate")
                };
                var result = _client.SendAsync(request).Result;

                if (result.IsSuccessStatusCode)
                {
                    return Ok();
                }

                throw new InvalidDataException(result.ReasonPhrase);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
