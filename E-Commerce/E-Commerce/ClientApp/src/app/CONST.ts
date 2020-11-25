export const consts={

    roles :
      {
        Client: "Client",
        Admin: "Admin",
      },


    toFormData<T>( formValue: T )
    {
    
    const formData = new FormData();
    for ( const key of Object.keys(formValue) ) {
      const value = formValue[key];
      formData.append(key, value);
    }
    return formData;
    },
   
    sections:
    [
      {id:1,value:"Laptopy i komputery",matIcon:"devices"},
      {id:2,value:"Smartfony i smartwatche",matIcon:"smartphone"},
      {id:3,value:"Gaming i streaming",matIcon:"videogame_asset"},
      {id:4,value:"Podzespoły komputerowe",matIcon:"memory"},
      {id:5,value:"Urządzenia peryferyjne",matIcon:"print"},
      {id:6,value:"Tv i audio",matIcon:"tv"},
      {id:7,value:"Smarthome i lifestyle",matIcon:"home"},
      {id:8,value:"Akcesoria",matIcon:"settings_input_hdmi"}
    ]
    
} 