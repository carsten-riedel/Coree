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

Write-Output "+++++++++++++++++++++++++++++++++++++++++++++++"
Write-Output "init.ps1 called"

Write-Output "InstallPath $installPath"
Write-Output "ToolsPath $toolsPath"
Write-Output "Package $package"

Write-Output $project.GetType().FullName
Write-Output $package.GetType().FullName

Write-Output "ProjectName: $($project.ProjectName)"
$fpath = GetProperty $project.Properties 'FullPath'
Write-Output "FullPath: $fpath"


if (Test-Path -Path "$fpath\FolderPut") {
    "Path exists!"
} else {
    $project.ProjectItems.AddFolder("FolderPut",$null) 
}

Copy-Item "$installPath\README.md" -Destination "$fpath\FolderPut"

#$item.Properties.Item("ItemType").Value = "Content"

$itemx = $project.ProjectItems.AddFromFile("$fpath\FolderPut\README.md");
$ppp = GetProperty $itemx.Properties 'BuildAction'

Write-Output "BuildAction $ppp"

#$itemx.Properties.Item("BuildAction").Value = "Compile"
$itemx.Properties.Item("ItemType").Value = "Content"

