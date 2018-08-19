﻿using PrtgAPI.Tests.UnitTests.InfrastructureTests.Support;

namespace PrtgAPI.Tests.UnitTests.Support.TestResponses
{
    class GroupDeepNestingGrandChildScenario : GroupDeepNestingChildScenario
    {
        protected override IWebResponse GetResponse(string address, Content content)
        {
            switch (requestNum)
            {
                case 1: //Get the "Servers" group
                case 2: //Get all groups under the "Servers" group
                case 3: //Get all groups under the "Windows Servers" group
                    return base.GetResponse(address, content);
                case 4: //Get all groups under the "Domain Controllers" group
                    AssertGroupRequest(address, content, "filter_parentid=2003");

                    return GetGroupResponse(DomainControllerDCs);
                case 5: //Get all groups from under the "Server 2003 DCs" group. Say there aren't any
                    AssertGroupRequest(address, content, "filter_parentid=2006");

                    return GetGroupResponse(null);
                case 6: //Get all groups from under the "Server 2008 DCs" group. Say there aren't any
                    AssertGroupRequest(address, content, "filter_parentid=2007");

                    return GetGroupResponse(null);
                case 7: //Get all groups from under the "Server 2012 DCs" group. Say there aren't any
                    AssertGroupRequest(address, content, "filter_parentid=2008");

                    return GetGroupResponse(null);
                case 8: //Get all groups from under the "Exchange Servers" group. Say there aren't any
                    AssertGroupRequest(address, content, "filter_parentid=2004");

                    return GetGroupResponse(null);
                case 9: //Get all groups from under the "SQL Servers" group. Say there aren't any
                    AssertGroupRequest(address, content, "filter_parentid=2005");

                    return GetGroupResponse(null);
                default:
                    throw UnknownRequest(address);
            }
        }
    }
}
