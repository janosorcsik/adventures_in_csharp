internal static partial class Sample
{
    public static void HtmlExtension()
    {
        Console.WriteLine("Html extension:");

        var m = new Model("János");
        var h = Html.TextBoxFor(m, x => x.Name);
        Console.WriteLine(h);

        Console.WriteLine();
    }
}

internal record Model(string Name);