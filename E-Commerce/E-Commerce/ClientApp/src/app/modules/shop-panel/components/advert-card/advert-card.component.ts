import { Component, OnInit, Input } from '@angular/core';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { AddProductToCartModel } from '../../models/add-product-to-cart.model'
@Component({
  selector: 'app-advert-card',
  templateUrl: './advert-card.component.html',
  styleUrls: ['./advert-card.component.scss']
})
export class AdvertCardComponent implements OnInit {

  @Input() name:string;
  @Input() photoUrl:string;
  @Input() price:number;
  @Input() id:number;

  constructor(private shoppingService:ShoppingCartService) { }

  convertedUrl:string;
  
  ngOnInit(): void {
    if(this.photoUrl=="data:image/jpeg;base64,null")
    {
      this.photoUrl = "../../../../../assets/photos/default.svg";
    }
    console.log(this.photoUrl);
    
  }

  addProduct()
  {
      let model : AddProductToCartModel = {
        productId : this.id,
        shoppingCardId:2
      }
      this.shoppingService.addProductToCart(model).subscribe(response=>console.log(response));

  }
}
