namespace ValueTypeReferenceType;

public class ReferenceTypeExplaination
{
    public void Explain()
    {
        Console.WriteLine("Giai thich ve reference type");

        // vì là kiểu reference, khi truyền vào hàm, ta thấy có 2 điểm sau:
        // giống với kiểu giá trị, giá trị của origin cũng được copy vào hàm
        // nhưng giá trị này là địa chỉ của object instance trong Heap
        // vì thế khi đổi giá trị property của object, khi ra ngoài hàm,
        // thay đổi này được giữ nguyên vì nó được thực hiện trong Heap
        // và origin trong Stack vẫn là địa chỉ của instance trong Heap
        var origin = new ReferenceClass { Name = "Name" };

        var setNameObj = SetName(origin);

        Console.WriteLine("Doi ten doi tuong origin");

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        // Giá trị trả về của hàm là giá trị của origin trong Stack
        // giá trị này được gán cho ô nhớ của setNameObj trong Stack
        // origin và setNameObj là hai biến có hai vị trí trong Stack
        // và có cùng giá trị là địa chỉ của instance trong Heap
        // khi gán new instance cho setNameObj, giá trị của setNameObj trong Stack
        // sẽ chuyển thành địa chỉ của new instance trong Heap
        Console.WriteLine("Khoi tao gia tri moi cua setNameObj");

        setNameObj = new ReferenceClass { Name = "New" };

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        // Đoạn này để chứng minh giá trị của origin truyền vào hàm đã được copy
        // obj là biến cục bộ mới, được nhận giá trị của origin mà thôi
        // khi gán new instance cho obj, giá trị của obj chuyển thành địa chỉ
        // của new instance trong Heap, không phải origin được cập nhật
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

        // đoạn đầu tiên sẽ thay đổi Name với param truyền vào là ref origin
        // đoạn này không khác đoạn không dùng ref, vì cùng sử dụng chung một giá trị trong Stack
        // giá trị này trỏ đến instance trong Heap
        // giá trị trả về của hàm là giá trị trong Stack, là địa chỉ của instance trong Heap
        // giá trị này được gán vào ô nhớ của setNameObj trong Stack (không dùng ô nhớ của origin)
        var setNameObj = SetNameRef(ref origin);

        Console.WriteLine("Doi ten doi tuong origin");

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        // đoạn này để chứng minh setNameObj và origin có 2 ô nhớ riêng có cùng giá trị
        // là địa chỉ của instance trong Heap
        // gán new instance cho setNameObj, giá trị của setNameObj trong Stack sẽ là
        // địa chỉ của new instance trong Heap
        Console.WriteLine("Khoi tao gia tri moi obj sau khi goi SetName");

        setNameObj = new ReferenceClass { Name = "New" };

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        // Trong ví dụ này, hàm SetNameRefAndNew sẽ thay đổi Name của origin
        // sau đó gán origin bằng đối tượng mới và trả về origin.
        // Như vậy, giá trị của origin trong Stack bị thay đổi vì chúng ta truyền ref origin vào hàm
        // giá trị trong Stack này trỏ đến vùng nhớ của instance của ReferenceClass trong Heap
        // giá trị này thành giá trị trả về, gán cho setNameNew
        // vậy setNameNew có một ô nhớ trong Stack có giá trị giống như origin và cùng trỏ tới new instance
        Console.WriteLine("Khoi tao gia tri moi obj trong ham SetName");

        var setNameNew = SetNameRefAndNew(ref origin);

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameNew.Name}");

        Console.WriteLine("================");
    }

    public void ExplainOut()
    {
        // về cơ bản, toàn bộ hàm này để chứng minh out an toàn hơn ref
        // out đòi hỏi lập trình viên phải tạo biến để truyền vào
        // vì có biến mới nên biến này có ô nhớ riêng trong Stack
        // bảo vệ giá trị của origin trong Stack không bị xâm hại
        Console.WriteLine("Giai thich ve reference type voi out");

        // biến out nhận giá trị của origin trong Stack, có ô nhớ riêng trong Stack
        // setNameObj nhận giá trị của origin trong Stack, có ô nhớ riêng trong Stack
        // ba biến này độc lập nhưng có cùng giá trị trong Stack là địa chỉ của instance trong Heap
        var origin = new ReferenceClass { Name = "Name" };

        ReferenceClass outObj;

        var setNameObj = SetNameOut(origin, out outObj);

        Console.WriteLine("Doi ten doi tuong origin");

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        Console.WriteLine($"outObj: {outObj.Name}");

        // Vì cả 3 biến dù độc lập nhưng đều trỏ đến cùng 1 instance trong Heap
        // đổi property là cùng thao tác trên 1 instance
        Console.WriteLine("Doi ten tung obj");

        origin.Name += "origin";

        setNameObj.Name += "setNameReturn";

        outObj.Name += "outVar";

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        Console.WriteLine($"outObj: {outObj.Name}");

        // Vì 3 biến độc lập, có 3 ô nhớ riêng trong Stack
        // khi gán new instance cho out và return
        // 3 biến này sẽ có giá trị trong Stack là 3 địa chỉ của 3 instance trong Heap
        Console.WriteLine("Khoi tao doi tuong moi cho out va return");

        outObj = new ReferenceClass { Name = "out" };

        setNameObj = new ReferenceClass { Name = "setNameReturn" };

        Console.WriteLine($"origin: {origin.Name}");

        Console.WriteLine($"setName: {setNameObj.Name}");

        Console.WriteLine($"outObj: {outObj.Name}");

        // đoạn này để cho thấy, 3 biến là độc lập
        // khi gán giá trị thì chỉ giá trị trong Stack được copy sang
        // kết quả là giống với các trường hợp trên
        Console.WriteLine("Dat bien out bang bien ref");

        ReferenceClass out2;

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
