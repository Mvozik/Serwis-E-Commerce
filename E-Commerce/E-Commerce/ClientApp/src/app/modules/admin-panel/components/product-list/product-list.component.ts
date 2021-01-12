import { Component, OnInit } from '@angular/core';
import { ProductModel } from '../../models/product.model';
import { AdminPanelService } from '../../services/admin-panel.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  constructor(private adminService:AdminPanelService) { }

  ngOnInit(): void {
    this.adminService.getAllProducts().subscribe(response =>   this.products = response);
  }



  products:ProductModel[];
  product: ProductModel;
}
