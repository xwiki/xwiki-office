﻿#region LGPL license
/*
 * See the NOTICE file distributed with this work for additional
 * information regarding copyright ownership.
 *
 * This is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as
 * published by the Free Software Foundation; either version 2.1 of
 * the License, or (at your option) any later version.
 *
 * This software is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this software; if not, write to the Free
 * Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
 * 02110-1301 USA, or see the FSF site: http://www.fsf.org.
 */
#endregion //license

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using TidyNet;
using TidyNet.Dom;
using ContentFiltering.Office.Word.Cleaners;

namespace XWiki.Html
{
    /// <summary>
    /// Provides functionalities for cleaning and repairing html code.
    /// </summary>
    public class HtmlUtil
    {
        /// <summary>
        /// Cleans a given html code. 
        /// </summary>
        /// <param name="htmlSource">The html code.</param>
        /// <returns>The cleaned html code.</returns>
        public String HtmlToXhtml(String htmlSource)
        {
            return new TidyHTMLCleaner(false).Clean(htmlSource);       
        }

        /// <summary>
        /// Cleans a Word html source.
        /// </summary>
        /// <param name="htmlSource">The initila html source.</param>
        /// <returns>The cleaned html.</returns>
        public String WordHtmlToXhtml(String htmlSource)
        {
            return new TidyHTMLCleaner(true).Clean(htmlSource);
        }


        /// <summary>
        /// Removes a char sequence that starts and ends with the given valaues.
        /// </summary>
        /// <param name="content">The initial content.</param>
        /// <param name="tagBegining">The begining of the char sequence.</param>
        /// <param name="tagEnding">The end of the char sequence.</param>
        /// <returns></returns>
        public String RemoveSpecificTagContent(String content, String tagBegining, String tagEnding)
        {
            bool foundTags = false;
            int startIndex = 0;
            int endIndex = 0;
            do
            {
                foundTags = false;
                startIndex = content.IndexOf(tagBegining, startIndex);
                if (startIndex >= 0)
                {
                    endIndex = content.IndexOf(tagEnding, startIndex + tagBegining.Length);
                    if (endIndex >= 0)
                    {
                        content = content.Remove(startIndex, endIndex - startIndex + tagEnding.Length);
                    }
                    foundTags = true;
                    startIndex = endIndex - (endIndex - startIndex + 1);
                }
            } while (foundTags);
            return content;
        }

        
        /// <summary>
        /// Indents the given html source.
        /// </summary>
        /// <param name="htmlSource">The html source.</param>
        /// <returns>A string with the new source.</returns>
        public String IndentContent(String htmlSource)
        {
            Tidy tidy = new Tidy();
            tidy.Options.IndentContent = true;
            TidyMessageCollection tmc = new TidyMessageCollection();
            MemoryStream input = new MemoryStream();
            MemoryStream output = new MemoryStream();

            byte[] byteArray = Encoding.Unicode.GetBytes(htmlSource);
            input.Write(byteArray, 0, byteArray.Length);
            input.Position = 0;
            tidy.Parse(input, output, tmc);

            htmlSource = Encoding.Unicode.GetString(output.ToArray());
            return htmlSource;
        }


        /// <summary>
        /// Replaces the body tag with a new given one.
        /// </summary>
        /// <param name="initialContent">The initial html code.</param>
        /// <param name="newBodyTag">The new body tag.</param>
        /// <returns>The new html code.</returns>
        public String ReplaceBody(String initialContent, String newBodyTag)
        {
            int startIndex, endIndex;
            startIndex = initialContent.IndexOf("<body");
            endIndex = initialContent.IndexOf(">", startIndex);
            String body = initialContent.Substring(startIndex, endIndex - startIndex + 1);
            return initialContent.Replace(body, newBodyTag);
        }
    }    
}
