//Player initialization (client-side)
params ["_player", "_didJIP"];
_EH_ArsenalOpen = ["ace_arsenal_displayOpened", {
    _return = "Economic" callExtension "Huita ili da?";
    hint format["Return: %1 << Huita", _return]    //("Return: " + (_return select 0) + " <<< Here");
}] call CBA_fnc_addEventHandler;


/*
_EH_ArsenalOpen = _player addEventHandler ["ace_arsenal_displayOpened", {
    _return = "what" callExtension "";
}];
*/

_return = "test" callExtension "";