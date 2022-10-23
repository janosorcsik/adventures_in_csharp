using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

public class Mock<T> where T : class
{
    private readonly TypeBuilder _tb;

    public Mock()
    {
        var type = typeof(T);

        var name = new AssemblyName($"{type.FullName}Mock");
        var ab = AssemblyBuilder.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
        var module = ab.DefineDynamicModule(name.Name!);

        _tb = module.DefineType($"{type.Name}Mock", TypeAttributes.Public | TypeAttributes.Class);

        _tb.AddInterfaceImplementation(type);
    }

    public Mock<T> Set(Expression<Action<T>> exp, Type type)
    {
        var mce = (MethodCallExpression)exp.Body;
        var methodName = mce.Method.Name;

        var method = type.GetMethod(methodName);

        if (method is not null)
        {
            var mb = _tb.DefineMethod(methodName, MethodAttributes.Public | MethodAttributes.Virtual, method.ReturnType,
                method.GetParameters().Select(x => x.ParameterType).ToArray());

            var ig = mb.GetILGenerator();
            ig.Emit(OpCodes.Ldarg_0);
            ig.EmitCall(OpCodes.Call, method, null);
            ig.Emit(OpCodes.Ret);
        }

        return this;
    }

    public T Build()
    {
        var type = _tb.CreateType()!;
        return (Activator.CreateInstance(type) as T)!;
    }
}