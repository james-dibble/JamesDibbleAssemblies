using System;
using CookComputing.XmlRpc;

public class MetaWeblogService : XmlRpcService, IMetaWeblog
{   
    public string AddPost(string blogid, string username, string password, Post post, bool publish)
    {
        return string.Empty; // Replace with real post id
    }

    public bool UpdatePost(string postid, string username, string password, Post post, bool publish)
    {
        return true;
    }

    public object GetPost(string postid, string username, string password)
    {
        return new
        {
            description = string.Empty,
            title = string.Empty,
            dateCreated = DateTime.MinValue,
            wp_slug = string.Empty,
            categories = new string[]{ },
            postid = postid
        };
    }

    public object[] GetCategories(string blogid, string username, string password)
    {
        return new [] { new { title = string.Empty /* Replace with category name. */ } };
    }

    public object[] GetRecentPosts(string blogid, string username, string password, int numberOfPosts)
    {
        return new [] 
        { 
            new
            {
                description = string.Empty,
                title = string.Empty,
                dateCreated = DateTime.MinValue,
                wp_slug = string.Empty,
                categories = new string[] { },
                postid = string.Empty
            } 
        };
    }

    public object NewMediaObject(string blogid, string username, string password, MediaObject mediaObject)
    {
        throw new System.NotImplementedException();
    }

    public bool DeletePost(string key, string postid, string username, string password, bool publish)
    {
        return true;
    }

    public object[] GetUsersBlogs(string key, string username, string password)
    {
        return new[] 
        { 
            new 
            {
                blogid = string.Empty,
                blogName = string.Empty,
                url = Context.Request.Url.Scheme + "://" + Context.Request.Url.Authority
            }
        };
    }
}