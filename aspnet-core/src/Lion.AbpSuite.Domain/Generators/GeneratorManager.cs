using Scriban;
using Scriban.Runtime;
using Template = Scriban.Template;

namespace Lion.AbpSuite.Generators;

public class GeneratorManager : AbpSuiteDomainService
{
    public async Task<string> RenderAsync(string templateContent, object model)
    {
        try
        {
            var template = Template.Parse(templateContent);
            var context = new TemplateContext();
            var scriptObject = new ScriptObject();
            scriptObject.Import(model, renamer: member => member.Name);
            context.PushGlobal(scriptObject);
            context.MemberRenamer = member => member.Name;
            var result = await template.RenderAsync(context);
            return result;
        }
        catch (Exception e)
        {
            return $"请检查模板是否正确:{e.Message}";
        }
    }
}