param($installPath, $toolsPath, $package, $project)

function DebugPrint
{
    Param
    (
        [parameter(Mandatory=$true)][NuGet.PackageManagement.VisualStudio.ScriptPackage] $packagex
    )
    Write-Host ($package | Format-Table | Out-String)

    Write-Host ($package | Format-List | Out-String)

    Write-Host ($package | Get-Member  -Force | Format-List | Out-String)

    $package | Get-Member  -Force

    $dds = $package.GetFiles()

    $dds

    ConvertTo-Json $package -Depth 2

}

$projectPath = $project.Properties.Item('FullPath').Value
$projectName = $project.ProjectName
$packageId = $package.Id
$packageVersion = $package.Version

Write-Output "********************************************************************"
Write-Output "********************** Coree.NuBuild init.ps1 **********************"
Write-Output ""
Write-Output "PackageId:      $packageId"
Write-Output "PackageVersion: $packageVersion"
Write-Output "InstallPath:    $installPath"
Write-Output "ToolsPath:      $toolsPath"
Write-Output "ProjectName:    $projectName"
Write-Output "ProjectPath:    $projectPath"


$path = "$projectPath\Coree.NuBuild.Defaults"
If(!(test-path -PathType container $path))
{
      New-Item -ItemType Directory -Path $path
}

Copy-Item (Join-Path "$installPath\defaults" "*") "$path" -Exclude (Get-ChildItem "$path") -verbose

$path = "$projectPath\Coree.NuBuild.Output"
If(!(test-path -PathType container $path))
{
      New-Item -ItemType Directory -Path $path
}

Copy-Item (Join-Path "$installPath\output" "*") "$path" -Exclude (Get-ChildItem "$path") -verbose