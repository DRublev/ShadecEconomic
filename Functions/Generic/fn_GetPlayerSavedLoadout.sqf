/*
	Author: Hadwig

	Description:
	Execute GetPlayerSavedLoadout DLL function. Need to be executed on server (because of server-side-only dll)

	Parameter(s):
	0: STRING - player SteamID

	Returns:
	ARRAY - player saved loadout in getUnitLoadout/setUnitLoadout format
*/

params["_uid"];

_gear = "Economic" callExtension format["[%1]GetPlayerSavedLoadout", _uid];

//Return
_gear