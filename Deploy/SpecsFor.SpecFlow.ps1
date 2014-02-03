properties {
	$BaseDir = Resolve-Path "..\"
	$SolutionFile = "$BaseDir\SpecsFor.sln"
	$SpecsForOutput = "$BaseDir\SpecsFor.SpecFlow\bin\Debug"
	$ProjectPath = "$BaseDir\SpecsFor.SpecFlow\SpecsFor.SpecFlow.csproj"	
	$ArchiveDir = "$BaseDir\Deploy\Archive"
	
	$NuGetPackageName = "SpecsFor.SpecFlow"
	$ZipFiles =  @("$SpecsForOutput\ExpectedObjects.dll",
		"$SpecsForOutput\Moq.dll",
		"$SpecsForOutput\nunit.framework.dll",
		"$SpecsForOutput\SpecsFor.dll",
		"$SpecsForOutput\SpecsFor.SpecFlow.dll",
		"$SpecsForOutput\SpecsFor.SpecFlow.pdb",
		"$SpecsForOutput\StructureMap.AutoMocking.dll",
		"$SpecsForOutput\StructureMap.dll",
		"$SpecsForOutput\TechTalk.SpecFlow.dll")
	$ZipName = "SpecsFor.SpecFlow.zip"
}

. .\common.ps1