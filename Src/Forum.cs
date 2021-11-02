﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ForumConnector
{
    public class Forum
    {
        private HttpClient _httpClient;

        public string Id { get; private set; }

        public Forum(HttpClient httpClient, string forumId)
        {
            _httpClient = httpClient;
            
            Id = forumId;
        }

        public async Task<Forum[]> GetChildForums()
        {
            List<Forum> forums = new List<Forum>();

            var html_sourcce = await FetchHtmlSource(1);

            string[] forumIds = ExtractChildForumIds(html_sourcce);

            foreach (var forumId in forumIds)
            {
                forums.Add(new Forum(_httpClient, forumId));
            }

            return forums.ToArray();
        }

        public async Task<int> GetTotalPage()
        {
            // TODO
            return 1;
        }

        public async Task<Thread[]> GetThreads(int pageIndex)
        {
            List<Thread> threads = new List<Thread>();

            var html_sourcce = await FetchHtmlSource(pageIndex);

            string[] threadIds = ExtractThreadIds(html_sourcce);

            foreach (var threadId in threadIds)
            {
                threads.Add(new Thread(_httpClient, threadId));
            }

            return threads.ToArray();
        }

        private string[] ExtractChildForumIds(string html_source)
        {
            List<string> forumIds = new List<string>();

            // TODO

            return forumIds.ToArray();
        }

        private string[] ExtractThreadIds(string html_source)
        {
            List<string> threadIds = new List<string>();

            // TODO

            return threadIds.ToArray();
        }

        private async Task<string> FetchHtmlSource(int pageIndex)
        {
            string html_source = string.Empty;

            string uri = string.Format("forums/{0}/page-{1}", Id, pageIndex);

            var checkResponse = await _httpClient.GetAsync(uri);
            if (checkResponse.IsSuccessStatusCode)
            {
                html_source = await checkResponse.Content.ReadAsStringAsync();
            }

            return html_source;
        }
    }
}
