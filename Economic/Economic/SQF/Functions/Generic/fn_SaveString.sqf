/*
	Author: Hadwig

	Description:
	Execute SaveString DLL function. Need to be executed on server (because of server-side-only dll)

	Parameter(s):
	0: STRING - string to save

	Returns:
	Nothing
*/

params["_string"];

//"Economic" callExtension format["[%1]SaveString", _string];

//Return
true