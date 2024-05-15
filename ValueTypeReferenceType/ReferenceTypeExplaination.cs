namespace ValueTypeReferenceType;

public class ReferenceTypeExplaination
{
    public void Explain()
    {
        Console.WriteLine("Giai thich ve reference type");

        var origin = new ReferenceClass { Name = "Name" };

        var setNameObj = SetName(origin);

        Console.WriteLine("Doi ten doi tuong origin");

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        Console.WriteLine("Khoi tao gia tri moi cua setNameObj");

        setNameObj = new ReferenceClass { Name = "New" };

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        Console.WriteLine("Khoi tao gia tri moi obj trong ham SetName");

        var setNameNew = SetNameAndNew(origin);

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameNew.Name}");

        Console.WriteLine("================");
    }

    public void ExplainRef()
    {
        Console.WriteLine("Giai thich ve reference type voi ref");

        var origin = new ReferenceClass { Name = "Name" };

        var setNameObj = SetNameRef(ref origin);

        Console.WriteLine("Doi ten doi tuong origin");

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        Console.WriteLine("Khoi tao gia tri moi obj trong ham SetName");

        setNameObj = new ReferenceClass { Name = "New" };

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        Console.WriteLine("Khoi tao gia tri moi obj trong ham SetName");

        var setNameNew = SetNameRefAndNew(ref origin);

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameNew.Name}");

        Console.WriteLine("================");
    }

    public void ExplainOut()
    {
        Console.WriteLine("Giai thich ve reference type voi out");

        var origin = new ReferenceClass { Name = "Name" };

        ReferenceClass outObj;

        var setNameObj = SetNameOut(origin, out outObj);

        Console.WriteLine("Doi ten doi tuong origin");

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        Console.WriteLine($"outObj: {outObj.Name}");

        Console.WriteLine("Doi ten tung obj");

        origin.Name += "origin";

        setNameObj.Name += "setNameReturn";

        outObj.Name += "outVar";

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        Console.WriteLine($"outObj: {outObj.Name}");

        Console.WriteLine("Khoi tao doi tuong moi cho out va return");

        outObj = new ReferenceClass { Name = "out" };

        setNameObj = new ReferenceClass { Name = "setNameReturn" };

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        Console.WriteLine($"outObj: {outObj.Name}");

        Console.WriteLine("Dat bien out bang bien ref");

        ReferenceClass out2 = new ReferenceClass { Name = "out" };

        var return2 = SetNameRefOut(ref origin, out out2);

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {return2.Name}");

        Console.WriteLine($"outObj: {out2.Name}");

        Console.WriteLine("doi gia tri out2, return2");

        out2.Name += "out2";

        return2.Name += "return2";

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {return2.Name}");

        Console.WriteLine($"outObj: {out2.Name}");

        Console.WriteLine("Khoi tao gia tri moi cho out2, return2");

        out2 = new ReferenceClass { Name = "out2" };

        return2 = new ReferenceClass { Name = "return2" };

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {return2.Name}");

        Console.WriteLine($"outObj: {out2.Name}");
    }

    private ReferenceClass SetName(ReferenceClass obj)
    {
        obj.Name += "Changed";

        return obj;
    }

    private ReferenceClass SetNameAndNew(ReferenceClass obj)
    {
        obj.Name += "Changed";

        obj = new ReferenceClass { Name = "NewInstance" };

        return obj;
    }

    private ReferenceClass SetNameRef(ref ReferenceClass obj)
    {
        obj.Name += "Changed";

        return obj;
    }

    private ReferenceClass SetNameRefAndNew(ref ReferenceClass obj)
    {
        obj.Name += "Changed";

        obj = new ReferenceClass { Name = "NewInstance" };

        return obj;
    }

    private ReferenceClass SetNameOut(ReferenceClass obj, out ReferenceClass outObj)
    {
        outObj = obj;

        outObj.Name += "Changed";

        return outObj;
    }

    private ReferenceClass SetNameRefOut(ref ReferenceClass obj, out ReferenceClass outObj)
    {
        outObj = obj;

        outObj.Name += "Changed";

        return outObj;
    }

    private class ReferenceClass
    {
        public string Name { get; set; } = string.Empty;
    }
}
