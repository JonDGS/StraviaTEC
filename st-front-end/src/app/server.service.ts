import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ServerService {

  constructor(private http:HttpClient) {

    
   }
   /**
    * 
    * login test object
    */
    public loginTest = {
      "username":"Dxnium",
      "passwordHash":"hola1asd234"
  }

    /******************** */
/**
 * Register post 
 */
   httpRegister(athlete){
     console.log(athlete);
          this.http.post(`http://jongs.mynetgear.com:27799/api/athletes`,athlete).subscribe(
      res=>{
        console.log(res);
      }
    );
  }

  httpLogin(){
    this.http.post(`http://jongs.mynetgear.com:27799/api/OnlineUser/LogIn`,this.loginTest).subscribe(
      res=>{
        console.log(res);
      }
    );
  }
}
