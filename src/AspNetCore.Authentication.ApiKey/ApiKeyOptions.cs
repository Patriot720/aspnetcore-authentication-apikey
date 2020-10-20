﻿// Copyright (c) Mihir Dilip. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for license information.

using Microsoft.AspNetCore.Authentication;
using System;

namespace AspNetCore.Authentication.ApiKey
{
    /// <summary>
    /// Inherited from <see cref="AuthenticationSchemeOptions"/> to allow extra option properties for 'ApiKey' authentication.
    /// </summary>
    public class ApiKeyOptions : AuthenticationSchemeOptions
	{
        /// <summary>
        /// This is required property. It is the name of the header or query parameter of the API Key.
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// Gets or sets the realm property. It is used with WWW-Authenticate response header when challenging un-authenticated requests.
        /// Required to be set if SuppressWWWAuthenticateHeader is not set to true.
        /// <see href="https://tools.ietf.org/html/rfc7235#section-2.2"/>
        /// </summary>
        public string Realm { get; set; }

        /// <summary>
        /// Default value is false.
        /// When set to true, it will NOT return WWW-Authenticate response header when challenging un-authenticated requests.
        /// When set to false, it will return WWW-Authenticate response header when challenging un-authenticated requests.
        /// It is normally used to disable browser prompt when doing ajax calls.
        /// <see href="https://tools.ietf.org/html/rfc7235#section-4.1"/>
        /// </summary>
        public bool SuppressWWWAuthenticateHeader { get; set; }

        /// <summary>
        /// The object provided by the application to process events raised by the api key authentication middleware.
        /// The application may implement the interface fully, or it may create an instance of <see cref="ApiKeyEvents"/>
        /// and assign delegates only to the events it wants to process.
        /// </summary>
        public new ApiKeyEvents Events
        {
            get => (ApiKeyEvents)base.Events;
            set => base.Events = value;
        }

        /// <summary>
        /// Default value is false. 
        /// If set to true, <see cref="IApiKey.Key"/> property returned from <see cref="IApiKeyProvider.ProvideAsync(string)"/> method is not compared with the key parsed from the request.
        /// This extra check did not existed in the previous version. So you if want to revert back to old version validation, please set this to true.
        /// </summary>
        public bool ForLegacyIgnoreExtraValidatedApiKeyCheck { get; set; }

        internal Type ApiKeyProviderType { get; set; } = null;
    }
}
