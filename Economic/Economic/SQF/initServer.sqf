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
_EH_PlayerConnected = addMissionEventHandler ["PlayerConnected",
{
    params["_id", "_uid", "_name", "_jip", "_owner"];
    missionNamespace SetVariable [_uid + "_cash", ([_uid] call Shadec_fnc_GetPlayerCash), true];
    missionNamespace SetVariable [_uid + "_loadout", [_uid] call Shadec_fnc_GetPlayerSavedLoadout, true];
    publicVariable (_uid + "_cash");
    publicVariable (_uid + "_loadout");
}];


[[[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14], [0,1,2,3,4,5,6,7]], "priceStat", ["price"], "Price", [false, true], [{}, {
        params["_stats", "_config"];
        _price = [configName(_config)] call Shadec_fnc_GetItemPrice;
        if (_price isEqualTo 0) then {_price = "No price"};
        _price        
    }, {true}], 99999] call ACE_arsenal_fnc_addStat;