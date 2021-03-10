using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using AeldreplejeCore.Core.Application.Validators;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Newtonsoft.Json;

namespace AeldreplejeCore.Core.Application.Impl
{
    public class GroupService: IGroupService
    {
        private IGroupRepo _groupepository;
        private HttpClient _client;

        public GroupService(IGroupRepo groupRepository)
        {
            _groupepository = groupRepository;
            _client = new HttpClient();
        }

        public List<Group> GetAllGroups()
        {
            return _groupepository.GetAllGroups();
        }

        public Group GetGroup(int id)
        {
            return _groupepository.GetGroup(id);
        }

        public Group CreateGroup(Group group)
        {
            string json = JsonConvert.SerializeObject(group);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = data,
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:44303/api/Validation/GroupCreate")
            };
            var result = _client.SendAsync(request).Result;

            if (result.IsSuccessStatusCode)
            {
                return _groupepository.CreateGroup(group);
            }

            throw new InvalidDataException(result.ReasonPhrase);
        }

        public Group UpdateGroup(Group group)
        {
            GroupServiceValidator.ValidateUpdateGroup(group);
            return _groupepository.UpdateGroup(group);
        }

        public Group DeleteGroup(int id)
        {
            return _groupepository.DeleteGroup(id);
        }
    }
}