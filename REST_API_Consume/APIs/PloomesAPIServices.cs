using Newtonsoft.Json;
using REST_API_Consume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace REST_API_Consume.APIs
{
    public class PloomesAPIServices
    {
        private HttpClient _client;

        /// <summary>
        /// Configure the HttpClient
        /// </summary>
        /// <param name="options">Configure the HttpClient with this action</param>
        public PloomesAPIServices(Action<HttpClient> options)
        {
            _client = new HttpClient();
            options(_client);
        }

        public async Task<List<Contact>> FindAllContactsAsync()
        {
            var response = await _client.GetAsync(_client.BaseAddress + "Contacts");
            string contactsJson = await response.Content.ReadAsStringAsync();
            contactsJson = FormatResponseToArray(contactsJson);
            Contact[] contacts = JsonConvert.DeserializeObject<Contact[]>(contactsJson);
            return contacts.ToList();
        }

        public async Task<Contact> FindContacByIdtAsync(int id)
        {
            var response = await _client.GetAsync(_client.BaseAddress + $"Contacts?$filter=Id+eq+{id}");
            string contactJson = await response.Content.ReadAsStringAsync();
            contactJson = FormatResponseToArray(contactJson);
            Contact[] contacts = JsonConvert.DeserializeObject<Contact[]>(contactJson);
            return contacts[0];
        }

        public async System.Threading.Tasks.Task CreateContactAsync(Contact contact)
        {
            string jsonContact = JsonConvert.SerializeObject(contact);
            jsonContact = FormatResponseWithoutId(jsonContact);
            await _client.PostAsync(_client.BaseAddress + "Contacts", new StringContent(jsonContact));
        }


        public async Task<Deal> FindDealByIdAsync(int id)
        {
            var response = await _client.GetAsync(_client.BaseAddress + $"Deals?$filter=Id+eq+{id}");
            string contactJson = await response.Content.ReadAsStringAsync();
            contactJson = FormatResponseToArray(contactJson);
            Deal[] deals = JsonConvert.DeserializeObject<Deal[]>(contactJson);
            return deals[0];
        }

        public async Task<List<Models.Task>> FindAllDealTasksAsync(int dealId)
        {
            var response = await _client.GetAsync(_client.BaseAddress + $"Tasks?$filter=DealId+eq+{dealId}");
            string tasksJson = await response.Content.ReadAsStringAsync();
            tasksJson = FormatResponseToArray(tasksJson);
            Models.Task[] tasks = JsonConvert.DeserializeObject<Models.Task[]>(tasksJson);
            return tasks.ToList();
        }

        public async Task<List<Deal>> FindAllContactDealsAsync(int contactId)
        {
            var response = await _client.GetAsync(_client.BaseAddress + $"Deals?$filter=ContactId+eq+{contactId}");
            string dealsJson = await response.Content.ReadAsStringAsync();
            dealsJson = FormatResponseToArray(dealsJson);
            Deal[] deals = JsonConvert.DeserializeObject<Deal[]>(dealsJson);
            return deals.ToList();
        }

        public async System.Threading.Tasks.Task CreateDealAsync(Deal deal)
        {
            string jsonDeal = JsonConvert.SerializeObject(deal);
            await _client.PostAsync(_client.BaseAddress + "Deals", new StringContent(jsonDeal));
        }


        public async System.Threading.Tasks.Task UpdateDealAsync(Deal deal)
        {
            string jsonDeal = JsonConvert.SerializeObject(deal);
            await _client.PatchAsync(_client.BaseAddress + $"Deals({deal.Id})", new StringContent(jsonDeal));
        }

        public async System.Threading.Tasks.Task WinDealAsync(Deal deal)
        {
            string jsonDeal = JsonConvert.SerializeObject(deal);
            await _client.PostAsync(_client.BaseAddress + $"Deals({deal.Id})/Win", new StringContent(jsonDeal));
        }

        public async Task<Models.Task> FindTaskByIdAsync(int id)
        {
            var response = await _client.GetAsync(_client.BaseAddress + $"Tasks?$filter=Id+eq+{id}");
            string tasktJson = await response.Content.ReadAsStringAsync();
            tasktJson = FormatResponseToArray(tasktJson);
            Models.Task[] contacts = JsonConvert.DeserializeObject<Models.Task[]>(tasktJson);
            return contacts[0];
        }

        public async System.Threading.Tasks.Task CreateTaskAsync(Models.Task task)
        {
            string jsonTask = JsonConvert.SerializeObject(task);
            await _client.PostAsync(_client.BaseAddress + "Tasks", new StringContent(jsonTask));
        }

        public async System.Threading.Tasks.Task UpdateTaskAsync(Models.Task task)
        {
            string jsonDeal = JsonConvert.SerializeObject(task);
            await _client.PatchAsync(_client.BaseAddress + $"Tasks({task.Id})", new StringContent(jsonDeal));
        }

        public async System.Threading.Tasks.Task FinishTaskAsync(Models.Task task)
        {
            string jsonTask = JsonConvert.SerializeObject(task);
            await _client.PostAsync(_client.BaseAddress + $"Tasks({task.Id})/Finish", new StringContent(jsonTask));
        }

        public async System.Threading.Tasks.Task CreateInteractionRecordAsync(InteractionRecord interactionRecord)
        {
            string jsonInteractionRecord = JsonConvert.SerializeObject(interactionRecord);
            await _client.PostAsync(_client.BaseAddress + "InteractionRecords", new StringContent(jsonInteractionRecord));
        }

        private string FormatResponseToArray(string response)
        {
            int index = response.IndexOf('[');
            // Removes the "@odata.context"
            response = response.Remove(0, index);

            // Removes the last "}"
            response = response.Remove(response.Length - 1, 1);

            return response;
        }

        private string FormatResponseWithoutId(string response)
        {
            response = response.Remove(1, 10);
            return response;
        }
    }
}
