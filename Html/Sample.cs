internal static partial class Sample
{
    public static void HtmlExtension()
    {
        Console.WriteLine("Html extension:");

        var m = new Model { Name = "János" };
        var h = Html.TextBoxFor(m, m => m.Name);
        Console.WriteLine(h);

        Console.WriteLine();
    }
}