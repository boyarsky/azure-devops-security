﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Waddle.Dtos;
using Waddle.Supports;

namespace Waddle
{
    public class ReleaseService : RestServiceBase
    {
        public ReleaseService(string adoUrl, string pat)
            : base(adoUrl, pat)
        {

        }

        public async Task<VstsFolderCollection> ListFoldersAsync(Guid projectId, string path = "")
        {
            var requestPath = $"{projectId}/_apis/release/folders/{path}?api-version=6.0-preview.2";
            var folders = await GetAzureDevOpsVsrmUri()
                .GetRestAsync<VstsFolderCollection>(requestPath, await GetBearerTokenAsync());

            return folders;
        }
    }
}