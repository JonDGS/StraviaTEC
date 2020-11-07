import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

/***********************************************
 * this data object is only for test porpuses 
 */
 
  public data = {
    username:"Dxnium",
    passwordHash:"hola1234",
    name:"Daniel",
    lastname_1:"Umana",
    lastname_2:"Monge",
    country:"Costa Rica",
    state:"SJ",
    city:"SJ",
    nationality:"Costa Rican",
    birhtday:"19-19-19"
}
/********************************************** */


  constructor(private http : HttpClient) { }

  httpGET(){
    return this.http.get(`http://jongs.mynetgear.com:45457/api/athletes`)
  }

  httpPost(){
    this.http.post(`http://jongs.mynetgear.com:45457/api/athletes`,this.data).subscribe(
      res=>{
        console.log(res);
      }
    );
  }
}