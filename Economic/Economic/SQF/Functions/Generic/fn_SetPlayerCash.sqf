/*
	Author: Hadwig

	Description:
	Execute SetPlayerCash DLL function. Need to be executed on server (because of server-side-only dll)

	Parameter(s):
	0: STRING - player SteamID
    1: NUMBER - new player cash value

	Returns:
	Nothing
*/

params["_uid", "_cash"];

//"Economic" callExtension format["[%1,%2]SetPlayerCash", _uid, _cash];

//Return
true