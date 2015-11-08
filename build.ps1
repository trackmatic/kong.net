param($task = "default", $parameters = @{ "output"="/trackmatic-1-0" })
get-module psake | remove-module
import-module psake
$psake.use_exit_on_error = $true
.nuget\NuGet.exe restore .nuget\packages.config -OutputDirectory packages
exec { 
    invoke-psake "default.ps1" -task $task -parameters $parameters
}
