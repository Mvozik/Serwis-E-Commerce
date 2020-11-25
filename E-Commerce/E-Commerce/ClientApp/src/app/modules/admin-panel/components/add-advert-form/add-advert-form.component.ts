import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { consts } from '../../../../CONST';
import { AddProductModel } from '../../models/add-product.model';
import { CategoryModel } from '../../models/category.model';
import { ProductModel } from '../../models/product.model';
import { SectionModel } from '../../models/section.model';
import { AdminPanelService } from '../../services/admin-panel.service';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-add-advert-form',
  templateUrl: './add-advert-form.component.html',
  styleUrls: ['./add-advert-form.component.scss']
})
export class AddAdvertFormComponent implements OnInit {

  constructor(private adminService:AdminPanelService,private categoryService:CategoryService) { }

  ngOnInit(): void {
    this.productForm = new FormGroup({
      name:new FormControl('',Validators.required),
      price:new FormControl('',Validators.required),
      quantity:new FormControl('',Validators.required),
      description:new FormControl('',Validators.required),
      specification:new FormControl('',Validators.required),
      productPhoto:new FormControl('',Validators.required),
      subCategoryId:new FormControl('',Validators.required)
    })
    this.categoryService.getSections().subscribe(response=>this.sections=response);
  }


  
  sections:SectionModel[];
  productForm:FormGroup;
  productModel:AddProductModel;
  file:File;
  photo:any;
  selectedSection:SectionModel;
  selectedCategory:CategoryModel;
  changeSection(event:any)
  {
    this.productForm.patchValue({subCategoryId:null});
    this.selectedSection = this.sections.find(x=>x.id==event.value);
  }
  changeCategory(event:any)
  {
    this.productForm.patchValue({subCategoryId:null});
    this.selectedCategory = this.selectedSection.categories.find(x=>x.id==event.value);
  }
  changeSubCategory(event:any)
  {
    this.productForm.patchValue({subCategoryId:event.value});
  }
  submit()
  {
    this.adminService.addProduct(consts.toFormData(this.productForm.value)).subscribe();
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
