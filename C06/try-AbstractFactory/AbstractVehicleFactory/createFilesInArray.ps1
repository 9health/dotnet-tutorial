[array]$files= ("IVehicleFactory.cs", "LowGradeVehicleFactory.cs", "HighGradeVehicleFactory.cs") 

foreach ($file in $files) 
{
	New-Item -Path .\src\Vehicles\ -Name $file -ItemType "file"
}
