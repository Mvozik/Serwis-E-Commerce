import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { consts } from '../../../../CONST';
import { AddProductModel } from '../../models/add-product.model';
import { ProductModel } from '../../models/product.model';
import { AdminPanelService } from '../../services/admin-panel.service';

@Component({
  selector: 'app-add-advert-form',
  templateUrl: './add-advert-form.component.html',
  styleUrls: ['./add-advert-form.component.scss']
})
export class AddAdvertFormComponent implements OnInit {

  constructor(private adminService:AdminPanelService) { }

  ngOnInit(): void {
    this.productForm = new FormGroup({
      name:new FormControl('',Validators.required),
      price:new FormControl('',Validators.required),
      quantity:new FormControl('',Validators.required),
      description:new FormControl('',Validators.required),
      specification:new FormControl('',Validators.required),
      productPhoto:new FormControl('',Validators.required),
    })
  }
  
  productForm:FormGroup;
  productModel:AddProductModel;
  file:File;
  photo:any;
  submit()
  {
    this.adminService.addProduct(consts.toFormData(this.productForm.value)).subscribe(response => console.log(response));
  }

  data : ProductModel[];
  
  
  changephoto()
  {
    let photo = this.productForm.value.productPhoto;
    var reader = new FileReader();
    reader.readAsDataURL(photo);
    reader.onload = (_event) => { 
      this.photo = reader.result; 
    }
  }
}
