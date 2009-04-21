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
        /// Gets a summary data about the server.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <returns>Summary data about the server.</returns>
        [XmlRpcMethod("confluence1.getServerInfo")]
        ServerInfo GetServerInfo(String token);

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
        /// <param name="token">The authentication page.</param>
        /// <param name="spaceId">The id of the page.</param>
        /// <returns>Summary data for the pages in the specified space.</returns>
        [XmlRpcMethod("confluence1.getPages")]
        PageSummary[] GetPages(String token, String spaceId);

        /// <summary>
        /// Stores the content of a wiki page to the server.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="page">Page object conatining the information about the page, including the content.</param>
        /// <returns>A new instance of the page containing the updated info.</returns>
        [XmlRpcMethod("confluence1.storePage")]
        Page StorePage(String token, Page page);

        /// <summary>
        /// Stores the content of a wiki page to the server.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="page">Page object conatining the information about the page, including the content.</param>
        /// <param name="checkVersion">
        /// When true checks if the page already exists 
        /// and saves the content only if the page doesn't exist yet.
        /// When false the content is saved no matter if the page already exists or not.
        /// </param>
        /// <returns>A new instance of the page containing the updated info.</returns>
        [XmlRpcMethod("confluence1.storePage")]
        Page StorePage(String token, Page page, bool checkVersion);

        /// <summary>
        /// Gets the rendered content of a page.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="space">The space the contains the rendered page.</param>
        /// <param name="pageId">The id of the page.</param>
        /// <param name="content">The unrendered content of the page.</param>
        /// <returns>The rendered content of the page.</returns>
        [XmlRpcMethod("confluence1.renderContent")]
        String RenderContent(String token, String space, String pageId, String content);

        /// <summary>
        /// Removes a page from the wiki.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="pageId">The id of the page.</param>
        /// <returns>True if the page was removed successfully. False otherwise.</returns>
        [XmlRpcMethod("confluence1.removePage")]
        bool RemovePage(String token, String pageId);

        /// <summary>
        /// Gets the history of a page.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="pageId">The id of the page.</param>
        /// <returns>The history of the page.</returns>
        [XmlRpcMethod("confluence1.getPageHistory")]
        PageHistorySummary[] GetPageHistory(String token, String pageId);

        /// <summary>
        /// Gets the history of the last modified pages.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="date">The date since when the history should be retrieved.</param>
        /// <param name="numberOfResults">The number of results.</param>
        /// <param name="start">The start offset.</param>
        /// <param name="fromLatest">Specifies if the retrived data should be start with the lates modification.</param>
        /// <returns>A history summary of the last modifications.</returns>
        [XmlRpcMethod("confluence1.getModifiedPagesHistory")]
        PageHistorySummary[] GetModifiedPagesHistory(String token, DateTime date, int numberOfResults, int start,
            bool fromLatest);

        /// <summary>
        /// Gets the information about a XWiki class.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="className">The name of the XWiki class.</param>
        /// <returns>A XWikiClass instance containing the description of the class.</returns>
        [XmlRpcMethod("confluence1.getClass")]
        XWikiClass GetClass(String token, String className);

        /// <summary>
        /// Gets a summary about the existing XWiki classes on the current server.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <returns>A summary about the existing XWiki classes on the current server.</returns>
        [XmlRpcMethod("confluence1.getClasses")]
        XWikiClassSummary[] GetClasses(String token);

        /// <summary>
        /// Gets the list of attachments from a wiki page.
        /// </summary>
        /// <param name="token">The authentication page.</param>
        /// <param name="pageId">The id of the page containing the attachment</param>
        /// <returns></returns>
        [XmlRpcMethod("confluence1.getAttachments")]
        Attachment[] GetAttachments(String token, String pageId);

        /// <summary>
        /// Attaches a file to a wiki page.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="contentId"></param>
        /// <param name="attachment">Attachment instance specifiing the filename and other attributes.</param>
        /// <param name="attachmentData">The binary data for the attachment.</param>
        /// <returns>A new instance of an Attachment containing all attributes for the attached file.</returns>
        [XmlRpcMethod("confluence1.addAttachment")]
        Attachment AddAttachment(String token, int contentId, Attachment attachment, byte[] attachmentData);

        /// <summary>
        /// Gets the binary data of an attachment.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="pageId">The id of the page.</param>
        /// <param name="fileName">The name of the attached file.</param>
        /// <param name="versionNumber">The version of the attachment.</param>
        /// <returns>The binary data of the attachment.</returns>
        [XmlRpcMethod("confluence1.getAttachmentData")]
        byte[] GetAttachmentData(String token, String pageId, String fileName, String versionNumber);

        /// <summary>
        /// Removes an attachment from a page
        /// </summary>
        /// <param name="token">The autehntication token.</param>
        /// <param name="pageId">The id of the page.</param>
        /// <param name="fileName">The name of the attached file.</param>
        /// <returns>True if the attachement was successfully removed. False otherwise.</returns>
        [XmlRpcMethod("confluence1.removeAttachment")]
        Boolean RemoveAttachment(String token, String pageId, String fileName);
    }
}