/*
	Author: Hadwig

	Description:
	Execute SetPlayerSavedLoadout DLL function. Need to be executed on server (because of server-side-only dll)

	Parameter(s):
	0: STRING - player SteamID
    1: ARRAT - player current loadout in getUnitLoadout/setUnitLoadout format

	Returns:
	Nothing
*/

params["_uid", "_gear"];

"Economic" callExtension format["[%1,%2]SetPlayerSavedLoadout", _uid, _gear];

//Return
true