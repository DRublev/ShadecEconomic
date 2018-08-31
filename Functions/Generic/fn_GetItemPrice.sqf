/*
	Author: Hadwig

	Description:
	Execute GetItemPrice DLL function. Need to be executed on server (because of server-side-only dll)

	Parameter(s):
	0: STRING - item class name

	Returns:
	NUMBER - price of item
*/

params["_item"];

//_price = "Economic" callExtension format["[%1]GetItemPrice", _item];
_price = 123; //For testing purposes. TODO: Remove and write normal call to dll.

//Return
_price