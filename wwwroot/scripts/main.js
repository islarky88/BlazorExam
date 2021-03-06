function ShowAlert(message) {
    alert('asdasd' + message);
}
function GetHeaders(message) {
    alert('GetHeaders: ' + message);
    return "GetHeaders Message: " + message;
}
function FetchSavedItems(type) {
    let data = [];
    // cgeck if there is already and entry
    if (localStorage.getItem(type)) {
        data = JSON.parse(localStorage.getItem(type));
    }
    return JSON.stringify(data);
}
function DeleteSavedItem(type, itemId) {
    console.log("DeleteSavedItem", type, itemId);
    let data = [];
    console.log('delete itemId', type, itemId);
    // cgeck if there is already and entry
    if (localStorage.getItem(type)) {
        console.log('delete item found');
        data = JSON.parse(localStorage.getItem(type));
        data = data.filter(i => +i.id !== +itemId);
    }
    // update localstage with delete item from list
    localStorage.setItem(type, JSON.stringify(data));
}
function SaveToLocalStorage(type, item) {
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
    alert('Item saved to LocalStorage.');
}
