import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from '../../services/shopping-cart.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  constructor(private shoppingCartService:ShoppingCartService) { }

  ngOnInit(): void {
  }
  photoUrl = "./../../../../../assets/photos/samsungs20.jpg"
  sum: number = 2137

  onClick()
  {
    this.shoppingCartService.activeShoppingCard().subscribe(response => console.log(response));
  }
}
