# BlazorVisualStudioBug
This project shows an error in Blazor compiling using pre-release Aug 2019.

I think that the bug is related to the @ref changes in this pre-release.

The error manifests itself in 2 ways:

1)  Open the file  BlazorApp1/Pages/EditFields.razor in Visual Studio and scroll down to line 34 which contains a @ref attribute.  VS will hang and crash.

2) Rebuild and get the error:

        Severity	Code	Description	Project	File	Line	Suppression State
        Error		rzc generate exited with code 1.	BlazorApp1	C:\Program Files\dotnet\sdk\3.0.100-preview8-013656\Sdks\Microsoft.NET.Sdk.Razor\build\netstandard2.0\Microsoft.NET.Sdk.Razor.CodeGeneration.targets	150	


Output: Build 

        1>------ Rebuild All started: Project: BlazorApp1, Configuration: Debug Any CPU ------
        1>You are using a preview version of .NET Core. See: https://aka.ms/dotnet-core-preview
        1>Pages\CreateBase.cs(26,30,26,45): warning CS1998: This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        1>Specified argument was out of the range of valid values. (Parameter 'index')
        1>   at Microsoft.AspNetCore.Razor.Language.Intermediate.IntermediateNodeCollection.get_Item(Int32 index)
        1>   at Microsoft.AspNetCore.Razor.Language.Components.ComponentReferenceCaptureLoweringPass.ExecuteCore(RazorCodeDocument codeDocument, DocumentIntermediateNode documentNode)
        1>   at Microsoft.AspNetCore.Razor.Language.IntermediateNodePassBase.Execute(RazorCodeDocument codeDocument, DocumentIntermediateNode documentNode)
        1>   at Microsoft.AspNetCore.Razor.Language.DefaultRazorOptimizationPhase.ExecuteCore(RazorCodeDocument codeDocument)
        1>   at Microsoft.AspNetCore.Razor.Language.RazorEnginePhaseBase.Execute(RazorCodeDocument codeDocument)
        1>   at Microsoft.AspNetCore.Razor.Language.DefaultRazorEngine.Process(RazorCodeDocument document)
        1>   at Microsoft.AspNetCore.Razor.Language.DefaultRazorProjectEngine.ProcessCore(RazorCodeDocument codeDocument)
        1>   at Microsoft.AspNetCore.Razor.Language.RazorProjectEngine.Process(RazorProjectItem projectItem)
        1>   at Microsoft.AspNetCore.Razor.Tools.GenerateCommand.<>c__DisplayClass46_0.<GenerateCode>b__0(Int32 i)
        1>   at System.Threading.Tasks.Parallel.<>c__DisplayClass19_0`1.<ForWorker>b__1(RangeWorker& currentWorker, Int32 timeout, Boolean& replicationDelegateYieldedBeforeCompletion)
        1>--- End of stack trace from previous location where exception was thrown ---
        1>   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw(Exception source)
        1>   at System.Threading.Tasks.Parallel.<>c__DisplayClass19_0`1.<ForWorker>b__1(RangeWorker& currentWorker, Int32 timeout, Boolean& replicationDelegateYieldedBeforeCompletion)
        1>   at System.Threading.Tasks.TaskReplicator.Replica`1.ExecuteAction(Boolean& yieldedBeforeCompletion)
        1>   at System.Threading.Tasks.TaskReplicator.Replica.Execute()
        1>C:\Program Files\dotnet\sdk\3.0.100-preview8-013656\Sdks\Microsoft.NET.Sdk.Razor\build\netstandard2.0\Microsoft.NET.Sdk.Razor.CodeGeneration.targets(150,5): error : rzc generate exited with code 1.
        1>Done building project "BlazorApp1.csproj" -- FAILED.
        ========== Rebuild All: 0 succeeded, 1 failed, 0 skipped ==========



