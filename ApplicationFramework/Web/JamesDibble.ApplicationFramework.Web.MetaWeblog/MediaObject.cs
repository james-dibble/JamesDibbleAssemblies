using CookComputing.XmlRpc;

[XmlRpcMissingMapping(MappingAction.Ignore)]
public struct MediaObject
{
    public string name;
    public string type;
    public byte[] bits;
}