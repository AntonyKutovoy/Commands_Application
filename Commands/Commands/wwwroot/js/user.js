function onSelectedIndexChanged(divId3, divId2, divId1) {
    var command = document.querySelector("#command");
    var parametersCount = command.options[command.selectedIndex].getAttribute('parametersCount');
    document.getElementById(divId1).style.display = parametersCount == 1 ? 'flex' : 'none';
    document.getElementById(divId2).style.display = parametersCount == 2 ? 'flex' : 'none';
    document.getElementById(divId3).style.display = parametersCount == 3 ? 'flex' : 'none';
}