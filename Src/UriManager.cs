﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversalForumClient.Core
{
    public static class UriManager
    {
        private static string ForumNamePlaceHolder = "_ForumName_";
        private static string ForumPagePlaceHolder = "_ForumPage_";

        private static string ThreadNamePlaceHolder = "_ThreadName_";
        private static string ThreadPagePlaceHolder = "_ThreadPage_";

        private static string Home = $"{string.Empty}";
        private static string Forum = $"forums/{ForumNamePlaceHolder}/page-{ForumPagePlaceHolder}";
        private static string Thread = $"threads/{ThreadNamePlaceHolder}/page-{ThreadPagePlaceHolder}";

        public static string ForumUri(string forumName, int forumPage)
        {
            if (string.IsNullOrEmpty(forumName))
            {
                return Home;
            }
            else
            {
                return Forum.Replace(ForumNamePlaceHolder, forumName)
                            .Replace(ForumPagePlaceHolder, forumPage.ToString());
            }
        }

        public static string ThreadUri(string threadName, int threadPage)
        {
            return Thread.Replace(ThreadNamePlaceHolder, threadName)
                         .Replace(ThreadPagePlaceHolder, threadPage.ToString());
        }
    }
}
