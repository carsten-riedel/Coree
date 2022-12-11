param($installPath, $toolsPath, $package, $project)

$projectPath = $project.Properties.Item('FullPath').Value
$projectName = $project.ProjectName
$packageId = $package.Id
$packageVersion = $package.Version

Write-Output "********************************************************************"
Write-Output "********************** Coree.NuPack init.ps1 **********************"
Write-Output ""
Write-Output "PackageId:      $packageId"
Write-Output "PackageVersion: $packageVersion"
Write-Output "InstallPath:    $installPath"
Write-Output "ToolsPath:      $toolsPath"
Write-Output "ProjectName:    $projectName"
Write-Output "ProjectPath:    $projectPath"

$Source = "$installPath\ProjectPath"
$Destination = "$projectPath".TrimEnd('\')

Get-ChildItem $Source -Recurse | ForEach {
    $ModifiedDestination = $($_.FullName).Replace("$Source","$Destination")
    If ((Test-Path $ModifiedDestination) -eq $False) {
            Copy-Item $_.FullName $ModifiedDestination
            Write-Output "Copyed $($_.FullName) to $($ModifiedDestination)"
        } else {
            Write-Output "Skip $($_.FullName) to $($ModifiedDestination)"
        }
    }
