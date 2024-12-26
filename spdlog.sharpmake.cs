using System.IO; // For Path.Combine
using Sharpmake; // Contains the entire Sharpmake object library.

[Generate]
public class SpdlogProject : BaseCppProject
{
    public SpdlogProject()
    {
        Name = "spdlog";
        SourceRootPath = @"[project.SharpmakeCsPath]\src";
        AddTargets(TargetUtil.DefaultTarget);
    }

    [Configure]
    public new void ConfigureAll(Project.Configuration conf, Target target)
    {
        base.ConfigureAll(conf, target);

        conf.SolutionFolder = Constants.EXTERNAL_VS_CATEGORY;

        conf.Output = Project.Configuration.OutputType.Lib;
        conf.TargetPath = @"[project.SharpmakeCsPath]\out\bin\[target.Platform]-[target.Optimization]";
        conf.IntermediatePath = @"[project.SharpmakeCsPath]\out\intermediate\[target.Platform]-[target.Optimization]";
        conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\include");

        conf.Defines.Add("SPDLOG_COMPILED_LIB");
    }
}