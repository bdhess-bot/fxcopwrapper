using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.FxCop.Sdk;

namespace FxCopWrapper
{
    public class LogicInsertionRule : BaseIntrospectionRule
    {
        public LogicInsertionRule() :
            base("LogicInsertionRule", "FxCopWrapper.LogicInsertionRules", typeof(LogicInsertionRule).Assembly)
        {
            InsertLogic();
        }

        private static void InsertLogic()
        {
            Assembly usageRulesAssembly = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "Rules", "UsageRules.dll"));
            string baseClass = "Microsoft.FxCop.Rules.Usage.AttributeStringLiteralsShouldParseCorrectly";
            Type baseType = usageRulesAssembly.GetType(baseClass);

            BaseIntrospectionRule rule = (BaseIntrospectionRule)Activator.CreateInstance(baseType);
            rule.BeforeAnalysis();

            Type valueKind = usageRulesAssembly.GetType(baseClass + "+ValueKind");
            FieldInfo nameException = valueKind.GetField("m_nameExceptions", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo valueKinds = baseType.GetField("s_valueKinds", BindingFlags.Static | BindingFlags.NonPublic);
            IEnumerable createdKinds = (IEnumerable)valueKinds.GetValue(null);

            Type versionValueKind = usageRulesAssembly.GetType(baseClass + "+VersionValueKind");
            object target = createdKinds.Cast<object>().Where(x => x.GetType() == versionValueKind).Single();

            nameException.SetValue(target, new[] { "InformationalVersion" });
        }
    }
}
