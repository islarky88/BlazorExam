window['ShowAlert'] = (message) => {
  alert('asdasd' + message);
}

window['SaveToLocalStorage'] = (type: string, message: JsonData) => {

  let data: JsonData[] = [];

  // cgeck if there is already and entry
  if (localStorage.getItem(type)) {
    data = JSON.parse(localStorage.getItem(type));
  }

  data.push(message);
  
  localStorage.setItem(type, JSON.stringify(data));

}

interface JsonData {
  id: number;
  title: string;
  userId?: number;
  body?: string;
  completed?: boolean;
}