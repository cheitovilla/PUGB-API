using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Attributes
{
    public string createdAt;

    public Attributes(string createdAt)
    {
        this.createdAt = createdAt;
    }
}

[Serializable]
public class Datum
{
    public string type;
    public string id;
    public Attributes attributes;

    public Datum(string type, string id, Attributes attributes)
    {
        this.type = type;
        this.id = id;
        this.attributes = attributes;
    }

}

[Serializable]
public class Links
{
    public string self;

    public Links(string self)
    {
        this.self = self;
    }
}

[Serializable]
public class Meta
{
}

[Serializable]
public class DataPugb
{
    public List<Datum> data;
    public Links links;
    public Meta meta;

    public DataPugb(List<Datum> data, Links links, Meta meta)
    {
        this.data = data;
        this.links = links;
        this.meta = meta;
    }
}


