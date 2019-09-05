using System;
using System.Reflection;

namespace Rafitec.Cloud.Api_Rafitec.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}