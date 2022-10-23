using System.Linq.Expressions;
using System.Reflection;

internal static class Html
{
    public static string TextBoxFor<T, TK>(T model, Expression<Func<T, TK>> exp)
    {
        var mBody = (MemberExpression)exp.Body;
        var name = mBody.Member.Name;
        var pi = mBody.Member as PropertyInfo;

        var value = pi?.GetValue(model, null);

        return $"<input type='text' id='{name}' name='{name}' value='{value}'>";
    }
}