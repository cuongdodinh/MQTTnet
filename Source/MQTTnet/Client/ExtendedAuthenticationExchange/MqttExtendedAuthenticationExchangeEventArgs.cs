// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using MQTTnet.Packets;
using MQTTnet.Protocol;

namespace MQTTnet.Client
{
    public sealed class MqttExtendedAuthenticationExchangeEventArgs : EventArgs
    {
        static readonly IReadOnlyCollection<MqttUserProperty> EmptyUserProperties = new List<MqttUserProperty>();

        public MqttExtendedAuthenticationExchangeEventArgs(MqttAuthPacket authPacket)
        {
            if (authPacket == null)
            {
                throw new ArgumentNullException(nameof(authPacket));
            }

            ReasonCode = authPacket.ReasonCode;
            ReasonString = authPacket.ReasonString;
            AuthenticationMethod = authPacket.AuthenticationMethod;
            AuthenticationData = authPacket.AuthenticationData;
            UserProperties = authPacket.UserProperties ?? EmptyUserProperties;
        }

        /// <summary>
        ///     Gets the authentication data.
        ///     <remarks>MQTT 5.0.0+ feature.</remarks>
        /// </summary>
        public byte[] AuthenticationData { get; }

        /// <summary>
        ///     Gets the authentication method.
        ///     <remarks>MQTT 5.0.0+ feature.</remarks>
        /// </summary>
        public string AuthenticationMethod { get; }

        /// <summary>
        ///     Gets the reason code.
        ///     <remarks>MQTT 5.0.0+ feature.</remarks>
        /// </summary>
        public MqttAuthenticateReasonCode ReasonCode { get; }

        /// <summary>
        ///     Gets the reason string.
        ///     <remarks>MQTT 5.0.0+ feature.</remarks>
        /// </summary>
        public string ReasonString { get; }

        /// <summary>
        ///     Gets or sets the user properties.
        ///     <remarks>MQTT 5.0.0+ feature.</remarks>
        /// </summary>
        public IReadOnlyCollection<MqttUserProperty> UserProperties { get; }

        /// <summary>
        /// Gets the response which will be sent to the server.
        /// </summary>
        public MqttExtendedAuthenticationExchangeResponse Response { get; } = new MqttExtendedAuthenticationExchangeResponse();
    }
}