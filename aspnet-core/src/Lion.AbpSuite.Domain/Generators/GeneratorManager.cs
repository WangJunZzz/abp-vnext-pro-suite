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
            Logger.LogError(e, "生成代码时发生异常");
            return string.Empty;
        }
    }
    
    // public string RenderAsync(string templateContent, object model)
    // {
    //     if (templateContent.IsNullOrWhiteSpace())
    //     {
    //         throw new UserFriendlyException("模板内容不能为空");
    //     }
    //
    //     if (model == null)
    //     {
    //         throw new UserFriendlyException("模板模型不能为空");
    //     }
    //     Template.NamingConvention = new CSharpNamingConvention();
    //     var template = DotLiquid.Template.Parse(templateContent); // Parses and compiles the template
    //     return template.Render(Hash.FromAnonymousObject(model)); // => "hi tobi"
    // }
}