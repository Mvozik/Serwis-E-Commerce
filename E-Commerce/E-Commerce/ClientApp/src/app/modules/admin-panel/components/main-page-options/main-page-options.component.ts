import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AddMainPageItemModel } from '../../models/add-mainpage-item.model';
import { ProductModel } from '../../models/product.model';
import { AdminPanelService } from '../../services/admin-panel.service';
@Component({
  selector: 'app-main-page-options',
  templateUrl: './main-page-options.component.html',
  styleUrls: ['./main-page-options.component.scss'],
})
export class MainPageOptionsComponent implements OnInit {
  constructor(private adminService: AdminPanelService) {
    this.itemlist = new Array();
    for (let index = 0; index < 9; index++) {
      this.itemlist.push(this.emptyItem);
    }
    this.adminService.getMainPageProducts().subscribe((response) => {
      response.forEach((element) => {
        for (let index = 0; index < this.itemlist.length; index++) {
          if (element.order == index + 1) {
            this.itemlist[index] = element.product;
          }
        }
      });
      this.finished = true;
    });
  }
  finished = false;
  itemlist: ProductModel[];
  emptyItem: ProductModel = {
    id: 0,
    name: '',
    price: 0,
    quantity: 0,
    description: '',
    specification: '',
    productPhoto: '',
  };
  productForm: FormGroup;

  ngOnInit(): void {
    this.productForm = new FormGroup({
      productId: new FormControl('', Validators.required),
      order: new FormControl('', Validators.required),
    });
  }

  submit() {
    let model: AddMainPageItemModel = {
      productId: this.productForm.get('productId').value,
      order: this.productForm.get('order').value,
    };
    this.adminService.postMainPageItem(model).subscribe();
    window.location.reload();
  }
}
