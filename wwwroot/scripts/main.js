window['ShowAlert'] = (message) => {
    alert('asdasd' + message);
};
window['GetHeaders'] = (message) => {
    alert('GetHeaders: ' + message);
    return "GetHeaders Message: " + message;
};
window['FetchSavedItems'] = (type) => {
    let data = [];
    // cgeck if there is already and entry
    if (localStorage.getItem(type)) {
        data = JSON.parse(localStorage.getItem(type));
    }
    return JSON.stringify(data);
};
window['SaveToLocalStorage'] = (type, message) => {
    let data = [];
    // cgeck if there is already and entry
    if (localStorage.getItem(type)) {
        data = JSON.parse(localStorage.getItem(type));
    }
    const index = data.findIndex(item => item.id === message.id);
    if (index >= 0) {
        data.splice(index, 1);
    }
    else {
        data.push(message);
    }
    localStorage.setItem(type, JSON.stringify(data));
};
