using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookPages.Utils.Reflection
{
    public static class ReflectionUtils
    {
        public static void ClonePublicProperties<TSource, TDest>(TSource sourceObject, TDest destObject)
        {
            PropertyInfo[] sourceProperties = typeof(TSource).GetProperties();
            PropertyInfo[] destProperties = typeof(TDest).GetProperties();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                String sourcePropName = sourceProperty.Name;

                foreach (PropertyInfo destProperty in destProperties)
                {
                    String destPropName = destProperty.Name;

                    if (sourcePropName.Equals(destPropName) && sourceProperty.GetMethod.IsPublic && destProperty.GetMethod.IsPublic)
                    {
                        destProperty.SetValue(destObject, sourceProperty.GetValue(sourceObject));
                    }
                }
            }
        }
    }
}
