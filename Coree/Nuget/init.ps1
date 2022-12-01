param($installPath, $toolsPath, $package, $project)


function GetProperty($properties, $propertyName)
{
    try
    {
        return $properties.Item($propertyName).Value
    }
    catch
    {
        return $null
    }
}

function Display
{
  Param
  (
    [parameter(Mandatory=$true)][String] $NugetRootPackagePath,
    [parameter(Mandatory=$true)][String] $NugetToolsPackagePath,
    [parameter(Mandatory=$true)][NuGet.PackageManagement.VisualStudio.ScriptPackage] $packagex,
    [parameter(Mandatory=$true)][Microsoft.VisualStudio.ProjectSystem.VS.Implementation.Package.Automation.OAProject] $EnvDTEproject

  )
    $solution = Get-Interface $dte.Solution ([EnvDTE80.Solution2])
    

        Write-Output "+++++++++++++++++++++++++++++++++++++++++++++++"
        $ProjectFullPath = $EnvDTEproject.Properties.Item('FullPath').Value
        $ProjectName = $EnvDTEproject.ProjectName
        
        Write-Output $EnvDTEproject.GetType().FullName
        Write-Output $EnvDTEproject.GetType().FullName
        Write-Output "NugetRootPackagePath $NugetRootPackagePath"
        Write-Output "NugetToolsPackagePath $NugetToolsPackagePath"
        Write-Output "ProjectName: $ProjectName"
        Write-Output "ProjectFullPath: $ProjectFullPath"

        Write-Host ($EnvDTEproject | Format-Table | Out-String)
        Write-Host ($package | Format-Table | Out-String)

        $solution | Get-Member  -Force
        $EnvDTEproject | Get-Member  -Force
        $package | Get-Member  -Force

        ConvertTo-Json $solution -Depth 2
        ConvertTo-Json $EnvDTEproject -Depth 2
        ConvertTo-Json $package -Depth 2

}

function Sample($NugetRootPackagePath, $NugetToolsPackagePath,$package,$EnvDTEproject)
{
    try
    {
        if (Test-Path -Path "$fpath\FolderPut") {
            "Path exists!"
        } else {
            $project.ProjectItems.AddFolder("FolderPut",$null) 
        }

        Copy-Item "$installPath\README.md" -Destination "$fpath\FolderPut"
        $itemx = $project.ProjectItems.AddFromFile("$fpath\FolderPut\README.md");
        $ppp = GetProperty $itemx.Properties 'BuildAction'
        Write-Output "BuildAction $ppp"
        $itemx.Properties.Item("ItemType").Value = "Content"
    }
    catch
    {
        return $null
    }
}


Display -NugetRootPackagePath $installPath -NugetToolsPackagePath $toolsPath -packagex $package -EnvDTEproject $project







