﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrtgAPI.Helpers;
using PrtgAPI.Tests.UnitTests.InfrastructureTests.Support;
using PrtgAPI.Tests.UnitTests.ObjectTests.TestItems;

namespace PrtgAPI.Tests.UnitTests.ObjectTests.TestResponses
{
    public class SetNotificationTriggerResponse : MultiTypeResponse
    {
        protected override IWebResponse GetResponse(ref string address, string function)
        {
            switch (function)
            {
                case nameof(HtmlFunction.EditSettings):
                    return new BasicResponse(string.Empty);
                case nameof(XmlFunction.TableData):
                    return GetTableResponse(address);
                case nameof(JsonFunction.Triggers):
                    return GetSupportedTriggersResponse();
                case nameof(HtmlFunction.ChannelEdit):
                    return new ChannelResponse(new ChannelItem());
                case nameof(HtmlFunction.RemoveSubObject):
                    return new BasicResponse(string.Empty);
                default:
                    throw GetUnknownFunctionException(function);
            }
        }

        private IWebResponse GetTableResponse(string address)
        {
            var components = UrlHelpers.CrackUrl(address);

            Content content = components["content"].ToEnum<Content>();

            switch (content)
            {
                case Content.Sensors:
                    if (components["filter_objid"] == "1")
                        return new SensorResponse();
                    return new SensorResponse(new SensorItem());
                case Content.Channels:
                    return new ChannelResponse(new ChannelItem());
                case Content.Triggers:
                    return new NotificationTriggerResponse(NotificationTriggerItem.StateTrigger());
                default:
                    throw new NotImplementedException($"Unknown content '{content}' requested from {nameof(SetNotificationTriggerResponse)}");
            }
        }

        private IWebResponse GetSupportedTriggersResponse()
        {
            return new BasicResponse("{ \"supported\": [\"threshold\"] }");
        }
    }
}
