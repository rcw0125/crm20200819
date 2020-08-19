using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public static class AUTOMAPING
    {
        public static T Mapping<T>(object source) where T : class
        {
            Type t = typeof(T);
            if (source == null)
            {
                return default(T);
            }

            T target = (T)t.Assembly.CreateInstance(t.FullName);

            #region Mapping Properties
            PropertyInfo[] targetProps = t.GetProperties();
            if (targetProps != null && targetProps.Length > 0)
            {
                string targetPropName;  //目标属性名称
                PropertyInfo sourceProp;
                object sourcePropValue;
                foreach (PropertyInfo targetProp in targetProps)
                {
                    //优先使用数据成员的别名，如果没有别名则使用属性名
                    object[] targetPropAliasAttrs = targetProp.GetCustomAttributes(typeof(DataMemberAttribute), true);
                    if (targetPropAliasAttrs != null && targetPropAliasAttrs.Length > 0)
                        targetPropName = ((DataMemberAttribute)targetPropAliasAttrs[0]).Alias;
                    else
                        targetPropName = targetProp.Name;

                    //检索源属性
                    sourceProp = source.GetType().GetProperty(targetPropName);
                    if (sourceProp != null && sourceProp.CanRead && targetProp.CanRead)
                    {
                        sourcePropValue = sourceProp.GetValue(source, null);
                        //属性类型一致时，直接填充属性值                     
                        if (targetProp.PropertyType == sourceProp.PropertyType)
                            targetProp.SetValue(target, sourcePropValue, null);
                        else if (targetProp.PropertyType.Name == "Nullable`1"
                            && sourceProp.PropertyType.Name == "Int32")
                        {
                            short value = Convert.ToInt16(sourcePropValue);
                            targetProp.SetValue(target, value);
                        }
                        else if (targetProp.PropertyType.Name == "Nullable`1"
                            && sourceProp.PropertyType.Name == "DateTime")
                        {
                            string str = Convert.ToDateTime(sourcePropValue).ToString("yyyy-MM-dd");
                            DateTime value = Convert.ToDateTime(str);
                            targetProp.SetValue(target, value);
                        }
                    }
                }
            }

            #endregion


            #region Mapping Fields
            FieldInfo[] targetFields = t.GetFields();
            if (targetFields != null && targetFields.Length > 0)
            {
                string targetFieldName;
                FieldInfo sourceField;
                foreach (FieldInfo targetField in targetFields)
                {
                    if (!targetField.IsInitOnly && !targetField.IsLiteral)
                    {//字段可以被赋值
                        object[] targetFieldAttrs = targetField.GetCustomAttributes(typeof(DataMemberAttribute), true);
                        if (targetFieldAttrs != null && targetFieldAttrs.Length > 0)
                            targetFieldName = ((DataMemberAttribute)targetFieldAttrs[0]).Alias;
                        else
                            targetFieldName = targetField.Name;

                        sourceField = source.GetType().GetField(targetFieldName);
                        if (sourceField != null)
                        {
                            //数据类型相同时映射值
                            if (targetField.FieldType == sourceField.FieldType)
                                targetField.SetValue(target, sourceField.GetValue(source));
                        }
                    }
                }
            }
            #endregion
            return target;
        }
    }
}
