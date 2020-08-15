window['ShowAlert'] = (message) => {
  alert('asdasd' + message);
}

window['GetHeaders'] = (message) => {
  alert('GetHeaders: ' + message);
  return "GetHeaders Message: " + message;
}


window['FetchSavedItems'] = (type) => {

  let data: JsonData[] = [];

  // cgeck if there is already and entry
  if (localStorage.getItem(type)) {
    data = JSON.parse(localStorage.getItem(type));
  }
  return JSON.stringify(data)
}

window['DeleteSavedItem'] = (type: string, message: JsonData) => {

  let data: JsonData[] = [];

  // cgeck if there is already and entry
  if (localStorage.getItem(type)) {
    
    data = JSON.parse(localStorage.getItem(type));

    data = data.filter(item => item.id !== message.id);

  }

}

window['SaveToLocalStorage'] = (type: string, message: JsonData) => {

  let data: JsonData[] = [];

  // cgeck if there is already and entry
  if (localStorage.getItem(type)) {
    data = JSON.parse(localStorage.getItem(type));
  }
  
  const index = data.findIndex(item => item.id === message.id);

  // add only items that are not yet saved
  if (index === -1) {
    data.push(message);
  } 

  // finally save to localstorage
  localStorage.setItem(type, JSON.stringify(data));

}

interface JsonData {
  id: number;
  title: string;
  userId?: number;
  body?: string;
  completed?: boolean;
}