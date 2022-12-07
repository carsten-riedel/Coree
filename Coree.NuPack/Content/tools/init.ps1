param($installPath, $toolsPath, $package, $project)

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

$path = "$projectPath\Coree.NuPack.Nupkg"
If(!(test-path -PathType container $path))
{
      New-Item -ItemType Directory -Path $path
}

Copy-Item (Join-Path "$installPath\Coree.NuPack.Nupkg" "*") "$path" -Exclude (Get-ChildItem "$path") -verbose

$path = "$projectPath\Coree.NuPack"
If(!(test-path -PathType container $path))
{
      New-Item -ItemType Directory -Path $path
}

Copy-Item (Join-Path "$installPath\Coree.NuPack" "*") "$path" -Exclude (Get-ChildItem "$path") -verbose
