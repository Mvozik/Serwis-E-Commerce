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
    }
   
    
}