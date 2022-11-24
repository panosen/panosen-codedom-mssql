@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.Mssql\bin\Release\Panosen.CodeDom.Mssql.*.nupkg D:\LocalSavoryNuget\

move /Y Panosen.CodeDom.Mssql.Engine\bin\Release\Panosen.CodeDom.Mssql.Engine.*.nupkg D:\LocalSavoryNuget\

pause