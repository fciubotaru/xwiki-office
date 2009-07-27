﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XWiki
{
    /// <summary>
    /// Describes a space in a XWiki server.
    /// </summary>
    [Serializable]
    public class Space
    {
        /// <summary>
        /// The name of the space.
        /// </summary>
        [XmlAttribute]
        public String name;

        /// <summary>
        /// Specifies if the space should be visible to the user.
        /// </summary>
        [XmlAttribute]
        public bool hidden;

        /// <summary>
        /// Specifies if the space is published on wiki, or if it is a new local one.
        /// Default is TRUE, since the majority of spaces are from the server.
        /// FALSE only for new added spaces.
        /// </summary>
        [XmlAttribute]
        public bool published=true;

        /// <summary>
        /// The list of documents in the space.
        /// </summary>
        public List<XWikiDocument> documents;
        
        /// <summary>
        /// Default constructor. Creates a new instance of the Space class.
        /// </summary>
        public Space()
        {
            name = "";
            hidden = false;
            documents = new List<XWikiDocument>();
        }

        /// <summary>
        /// Gets the unpublished XWiki documents in the Space instance.
        /// </summary>
        /// <returns>A list of unpublished XWiki documents.</returns>
        public List<XWikiDocument> GetUnpublishedDocuments()
        {
            //The list of unpublished documents to be returned
            List<XWikiDocument> docs = new List<XWikiDocument>();
            foreach (XWikiDocument doc in documents)
            {
                if (!doc.published)
                {
                    docs.Add(doc);
                }
            }
            return docs;
        }

        /// <summary>
        /// Adds a collection of XWiki documents to the space instance.
        /// </summary>
        /// <param name="_documents">A collection containing XWiki documents.</param>
        public void AddDocuments(IEnumerable<XWikiDocument> _documents)
        {
            documents.AddRange(_documents);
        }

        /// <summary>
        /// Adds a collection of XWiki documents to the space instance.
        /// </summary>
        /// <param name="_documents">A collection containing XWiki documents names.</param>
        public void AddDocuments(IEnumerable<String> _documents)
        {
            foreach (String documentName in _documents)
            {
                XWikiDocument doc = new XWikiDocument();
                doc.name = documentName;
                doc.space = this.name;
                doc.published = true;
                documents.Add(doc);
            }
        }
    }
}