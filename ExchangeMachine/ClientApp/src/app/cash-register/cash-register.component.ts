import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Coin } from './coin/coin';

@Component({
  selector: 'app-cash-register',
  templateUrl: './cash-register.component.html',
  styleUrls: ['./cash-register.component.css']
})
export class CashRegisterComponent implements OnInit {
  headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  }
  
  public coins: ICoin[];
  public exchanged: IExchanged;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    http.get<ICoin[]>(baseUrl + 'cashRegister').subscribe(result => {
      this.coins = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

  supply(coin1, coin5, coin10, coin25, coin50, coin100) {
    const coins = new Coin().newCoins(coin1, coin5, coin10, coin25, coin50, coin100);

    this.http.post<ICoin[]>(this.baseUrl + 'cashRegister/IncreaseQuantity', JSON.stringify(coins), this.headers).subscribe(result => {
        this.coins = result;
      }, error => console.error(error));
  }

  bloodletting(coin1, coin5, coin10, coin25, coin50, coin100){
    const coins = new Coin().newCoins(coin1, coin5, coin10, coin25, coin50, coin100);

    this.http.post<ICoin[]>(this.baseUrl + 'cashRegister/DecreaseQuantity', JSON.stringify(coins), this.headers).subscribe(result => {
      this.coins = result;
    }, error => console.error(error));
  }

  toExchange(cents){
    this.http.post<IExchanged>(this.baseUrl + 'cashRegister/ToExchange/' + cents.value, null).subscribe(result => {
      this.exchanged = result;
      this.coins = result.coinsBox;
    }, error => console.error(error));
  }
}

interface ICoin {
  value: number;
  quantity: number;
  total: number;
}

interface IExchanged {
  coins: string;
  message: string;
  coinsBox: ICoin[];
}
