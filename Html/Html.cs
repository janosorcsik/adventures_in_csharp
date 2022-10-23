using System.Linq.Expressions;
using System.Reflection;

static class Html
{
    public static string TextBoxFor<T, K>(T model, Expression<Func<T, K>> exp)
    {
        var mBody = (MemberExpression)exp.Body;
        var name = mBody.Member.Name;
        var pi = mBody.Member as PropertyInfo;

        var value = pi.GetValue(model, null);

        return $"<input type='text' id='{name}' name='{name}' value='{value}'>";
    }
}
