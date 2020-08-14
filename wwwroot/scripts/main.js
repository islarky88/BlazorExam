window['ShowAlert'] = function (message) {
    alert('asdasd' + message);
};
alert('asdasd');
window['SaveToLocalStorage'] = function (type, message) {
    var data = [];
    // cgeck if there is already and entry
    if (localStorage.getItem(type)) {
        data = JSON.parse(localStorage.getItem(type));
    }
    data.push(message);
    localStorage.setItem(type, JSON.stringify(data));
};
//# sourceMappingURL=main.js.map