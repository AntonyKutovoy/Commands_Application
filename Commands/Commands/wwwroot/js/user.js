function onSelectedIndexChanged(divId) {
    var command = document.querySelector("#command");
    var parametersCount = command.options[command.selectedIndex].getAttribute('parametersCount');
    document.getElementById(divId).style.display = parametersCount == 1 ? 'block' : 'none';
}