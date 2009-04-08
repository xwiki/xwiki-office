﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace XWiki.XmlRpc
{
    /// <summary>
    /// Proxy for connecting to XWiki via XML-RPC
    /// </summary>
    public interface IXWikiProxy : IXmlRpcProxy
    {
        /// <summary>
        /// Authenticates a user to the XWiki Server.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password for the user.</param>
        /// <returns>
        /// The authentication token. 
        /// The token will be reused in all methods that require authentication
        /// </returns>
        [XmlRpcMethod("confluence1.login")]
        String Login(String username, String password);

        /// <summary>
        /// Gets a list containg all spaces names in the wiki.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <returns>A list with all the spaces in the wiki.</returns>
        [XmlRpcMethod("confluence1.getSpaces")]
        SpaceSummary[] GetSpaces(String token);

        /// <summary>
        /// Gets the summary data for a space.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="spaceId">The id of the space.</param>
        /// <returns>The data regarding a space.</returns>
        [XmlRpcMethod("confluence1.getSpace")]
        SpaceSummary GetSpace(String token, String spaceId);

        /// <summary>
        /// Gets the data of a page.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="pageId">The id of the page.</param>
        /// <returns>The data of the page.</returns>
        [XmlRpcMethod("confluence1.getPage")]
        Page GetPage(String token, String pageId);

        /// <summary>
        /// Gets a summary data for the pages in a space.
        /// </summary>
        /// <param name="token">The authentication space.</param>
        /// <param name="spaceId">The id of the page.</param>
        /// <returns>Summary data for the pages in the specified space.</returns>
        [XmlRpcMethod("confluence1.getPages")]
        PageSummary[] GetPages(String token, String spaceId);
    }
}