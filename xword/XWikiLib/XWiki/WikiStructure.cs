﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XWiki
{
    /// <summary>
    /// Class used to store data about the wiki structure.
    /// Contains the list of spaces and documents.
    /// </summary>
    [Serializable]
    public class WikiStructure
    {
        /// <summary>
        /// A list with all spaces in the wiki.
        /// </summary>
        public List<Space> spaces;
        /// <summary>
        /// Default constructor. Instantiates the spaces list.
        /// </summary>
        public WikiStructure()
        {
            spaces = new List<Space>();
        }

        /// <summary>
        /// Gets all document instances in the wiki.
        /// </summary>
        /// <returns>A list with all document instances.</returns>
        public List<XWikiDocument> GetAllDocuments()
        {
            List<XWikiDocument> allDocs = new List<XWikiDocument>();
            foreach (Space space in this.spaces)
            {
                foreach (XWikiDocument doc in space.documents)
                {
                    allDocs.Add(doc);
                }
            }
            return allDocs;
        }

        /// <summary>
        /// Removes a XWikiDocument instance from the wiki structure.
        /// This has no effect on the server. It only affects the document list
        /// Word works with.
        /// </summary>
        public void RemoveXWikiDocument(XWikiDocument doc)
        {
            foreach (Space space in spaces)
            {
                if (space.name == doc.space)
                {
                    space.documents.Remove(doc);
                }
            }
        }
    }
}