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
window['DeleteSavedItem'] = (type, item) => {
    console.log("DeleteSavedItem", type, item);
    let data = [];
    console.log('delete item', type, item);
    // cgeck if there is already and entry
    if (localStorage.getItem(type)) {
        console.log('delete item found');
        data = JSON.parse(localStorage.getItem(type));
        data = data.filter(i => +i.id !== +item.id);
    }
    // update localstage with delete item from list
    localStorage.setItem(type, JSON.stringify(data));
};
window['SaveToLocalStorage'] = (type, item) => {
    let data = [];
    // cgeck if there is already and entry
    if (localStorage.getItem(type)) {
        data = JSON.parse(localStorage.getItem(type));
    }
    const index = data.findIndex(i => +i.id === +item.id);
    // show alert if already saved
    if (index >= 0) {
        alert('Item already saved.');
        return;
    }
    // finally save to localstorage
    data.push(item);
    localStorage.setItem(type, JSON.stringify(data));
};
