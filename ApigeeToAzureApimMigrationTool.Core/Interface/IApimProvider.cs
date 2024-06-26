﻿using Azure.ResourceManager.ApiManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApigeeToAzureApimMigrationTool.Core.Interface
{
    public interface IApimProvider
    {
        string ApimName { get; }
        string ApimUrl { get; }
        Task<ApiResource> CreateApi(string apiName, string apiDisplayName, string apiDescription, string apimName,
            string revision, string apiPath, string backendUrl, string? oauthConfigurationName);
        Task<ApiManagementProductResource> CreateProduct(string name, string displayName, string description, string apimName);
        Task CreatePolicyFragment(string policyFragmentName, string apimName, string policyFragmentXml, string policyFragmentDescription);
        Task CreatePolicy(XDocument policyXml);
        Task CreateOrUpdateOperation(string apiName, string description, string httpVerb);
        Task CreateOrUpdateOperationPolicy(XDocument operationPolicyXml, string operationName, string operationDescription, string httpVerb, string proxyPath);
        Task AddApiToProduct(string apiId);
        Task AddNamedValue(string apimName, string proxyName, string mapIdentifier, string keyName, bool isSecret, string value, int index = 1);
        Task UpdateApiSubscriptionSetting(string apimName, string proxyName, string headerName = "", string queryParameterName = "");

        string RemoveTrailingSpecialCharacters(string input);

    }
}
