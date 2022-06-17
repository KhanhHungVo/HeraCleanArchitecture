$ErrorActionPreference='Stop'
Push-Location $PSScriptRoot
$projectPath = "../src/hera.infrastructure/Hera.Infrastructure.csproj" 
$startUpProjectPath = "../src/hera.webapi/Hera.WebApi.csproj" 
$context = "HeraDbContext"

ls
dotnet new tool-manifest --force
dotnet tool install dotnet-ef
dotnet ef migrations script --idempotent --startup-project $startUpProjectPath  --project $projectPath --context $context --output ..\Hera-sqlmigration.sql

$configToolsPath="./.config"
if (Test-Path -Path $configToolsPath) {
    Write-Host "Removing migration tool config folder..." -NoNewline
    Remove-Item $configToolsPath -Recurse -Force
    Write-Host "Done"
}

Pop-Location