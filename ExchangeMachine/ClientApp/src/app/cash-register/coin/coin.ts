import { CashRegisterConst } from "../cash-register-const";

export class Coin {

    newCoins(coin1, coin5, coin10, coin25, coin50, coin100) {
        let coins = [];

        if (coin1.value)
            coins.push({ value: CashRegisterConst.Coins.C1, quantity: coin1.value });

        if (coin5.value)
            coins.push({ value: CashRegisterConst.Coins.C5, quantity: coin5.value });

        if (coin10.value)
            coins.push({ value: CashRegisterConst.Coins.C10, quantity: coin10.value });

        if (coin25.value)
            coins.push({ value: CashRegisterConst.Coins.C25, quantity: coin25.value });

        if (coin50.value)
            coins.push({ value: CashRegisterConst.Coins.C50, quantity: coin50.value });

        if (coin100.value)
            coins.push({ value: CashRegisterConst.Coins.C100, quantity: coin100.value });

            return coins;
    }
}
  