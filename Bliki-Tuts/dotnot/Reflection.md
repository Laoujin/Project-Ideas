Reflection
==========

Type type = value.GetType();
Type type = typeof(SomeType);

Properties
----------
foreach (var prop in GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
{
    if (prop.PropertyType.GetGenericArguments().Length == 1)
    {
        Type entityType = prop.PropertyType.GetGenericArguments()[0];
        Type testDbSet = typeof(TestDbSet<>).MakeGenericType(entityType);
        prop.SetValue(this, Activator.CreateInstance(testDbSet));
    }
}

Generics
--------