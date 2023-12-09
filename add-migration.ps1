[CmdletBinding()]
param (
    [Parameter()]
    [string]
    $MigrationName
)

dotnet tool restore

dotnet ef migrations add $MigrationName `
    --project $(Join-Path -Path $PSScriptRoot -ChildPath 'src/Database') `
    --startup-project $(Join-Path -Path $PSScriptRoot -ChildPath 'src/Backend')


dotnet ef migrations script `
    --project $(Join-Path -Path $PSScriptRoot -ChildPath 'src/Database') `
    --startup-project $(Join-Path -Path $PSScriptRoot -ChildPath 'src/Backend') `
    --idempotent `
    --output $(Join-Path -Path $PSScriptRoot -ChildPath 'src/Database/Migrations/all-idempotent.sql')
