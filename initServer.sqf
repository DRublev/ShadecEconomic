// Server initialization

//Player disconnect handler
_EH_HandleDisconnect = addMissionEventHandler ["HandleDisconnect",
{
    params ["_unit", "_id", "_uid", "_name"];
    _gear = str (getUnitLoadout _unit);
    [_uid, _gear] call Shadec_fnc_SetPlayerSavedLoadout;
    false
}];

//Player connect handler
EH_PlayerConnected = addMissionEventHandler ["PlayerConnected",
{
    params["_id", "_uid", "_name", "_jip", "_owner"];
    "Player connected " + _uid remoteExec["systemChat"];
    
    missionNamespace setVariable [str _uid + "_cash", str ([_uid] call Shadec_fnc_GetPLayerCash), true];
    missionNamespace setVariable [str _uid + "_loadout", [_uid] call Shadec_fnc_GetPlayerSavedLoadout, true];
    publicVariable (_uid + "_loadout");    
    publicVariable (str _uid + "_cash");
}];

missionNamespace setVariable ["cash", str ([123] call Shadec_fnc_GetPLayerCash), true];
publicVariable ("cash");

"Hello world, it's ur server!" remoteExec["systemChat"];

str ([123] call Shadec_fnc_GetPLayerCash) remoteExec["systemChat"];

// Add PRICE stat at Page 2
[[[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14], [0,1,2,3,4,5,6,7]], "priceStat", ["price"], "Price", [false, true], [{}, {
        params["_stats", "_config"];
        _price = [configName(_config)] call Shadec_fnc_GetItemPrice;
        if (_price isEqualTo 0) then {_price = "No price"};
        _price        
    }, {true}], 99999] call ACE_arsenal_fnc_addStat;

// Add CASH stat at Page 2
[[[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14], [0,1,2,3,4,5,6,7]], "playerCash", ["cash"], "Cash", [false, true], [{}, {
       params ["_stats", "_config"];
        _uid = getPlayerUID player;
        _cash = missionNamespace getVariable [str _uid + "_cash", "ErrorUp"];
        _cash;
    }, {true}]] call ACE_arsenal_fnc_addStat;
