# Mod for Lycans, randomizing the number of some roles and NightFog #

The number of players having some roles is randomized every new game (no need to create a new lobby).

## Randomized values ##
- Traitors
- Solo Roles
- Secondary Roles
- Power Roles
- NightFog

## Traitors & Solo, Secondary and Power roles ##

The number of these roles will be in the range 0 to the number of this role you selected in the settings.
For example, if you select 2 solo roles, there will be a random number between 0 and 2 of solo roles.
It's working the same for traitors, secondary roles and power roles.

## NightFog ##

The Night Fog intensity wil also be randomized every game as [0%,100%]

## Prerequisites ##

You must have LycansNewRoles working with your game such as described here : https://thunderstore.io/c/lycans/p/Nales/LycansNewRoles/

## Installation ##

- Go to your Lycans folder
- Open BepInEx folder
- Open plugins folder
- Copy/Paste the file MyLycansMod\bin\Debug\net471\MyLycansMod.dll into the plugins folder

You should now have LycansNewRoles and MyLycansMod.dll into your folder (+ whatever mod you are using).

Notice that only the one creating the lobby needs the mod

