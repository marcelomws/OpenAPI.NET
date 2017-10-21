﻿//---------------------------------------------------------------------
// <copyright file="OpenApiOperation.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Microsoft.OpenApi
{
    /// <summary>
    /// Operation Object.
    /// </summary>
    public class OpenApiOperation : IOpenApiExtension
    {
        public IList<OpenApiTag> Tags { get; set; } = new List<OpenApiTag>();
        public string Summary { get; set; }
        public string Description { get; set; }
        public OpenApiExternalDocs ExternalDocs { get; set; } 
        public string OperationId { get; set; }
        public IList<OpenApiParameter> Parameters { get; set; } = new List<OpenApiParameter>();
        public OpenApiRequestBody RequestBody { get; set; }
        public IDictionary<string, OpenApiResponse> Responses { get; set; } = new Dictionary<string, OpenApiResponse>();
        public IDictionary<string, OpenApiCallback> Callbacks { get; set; } = new Dictionary<string, OpenApiCallback>();

        public const bool DeprecatedDefault = false;
        public bool Deprecated { get; set; } = DeprecatedDefault;
        public IList<OpenApiSecurityRequirement> Security { get; set; } = new List<OpenApiSecurityRequirement>();
        public IList<OpenApiServer> Servers { get; set; } = new List<OpenApiServer>();
        public IDictionary<string, IOpenApiAny> Extensions { get; set; }

        public void CreateResponse(string key, Action<OpenApiResponse> configure)
        {
            var response = new OpenApiResponse();
            configure(response);
            Responses.Add(key, response);
        }
    }
}
