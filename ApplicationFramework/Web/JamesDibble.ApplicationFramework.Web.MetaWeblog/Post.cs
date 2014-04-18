using System;

using CookComputing.XmlRpc;

[XmlRpcMissingMapping(MappingAction.Ignore)]
public class Post
{
    [XmlRpcMember("postid")]
    public string ID { get; set; }

    [XmlRpcMember("title")]
    public string Title { get; set; }

    [XmlRpcMember("author")]
    public string Author { get; set; }

    [XmlRpcMember("wp_slug")]
    public string Slug { get; set; }

    [XmlRpcMember("description")]
    public string Content { get; set; }

    [XmlRpcMember("dateCreated")]
    public DateTime PubDate { get; set; }

    [XmlRpcMember("dateModified")]
    public DateTime LastModified { get; set; }

    [XmlRpcMember("categories")]
    public string[] Categories { get; set; }
}