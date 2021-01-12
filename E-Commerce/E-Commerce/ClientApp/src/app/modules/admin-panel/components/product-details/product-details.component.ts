import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductModel } from '../../models/product.model';
import { AdminPanelService } from '../../services/admin-panel.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { consts } from '../../../../CONST';
@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private adminService: AdminPanelService,
    private formBuilder: FormBuilder
  ) {
    const id = this.route.snapshot.paramMap.get('id');

    this.adminService.getProductById(+id).subscribe((response) => {
      this.productForm.patchValue({
        id: response.id,
        name: response.name,
        price: response.price,
        quantity: response.quantity,
        description: response.description,
        specification: response.specification,
        productPhoto: 'data:image/jpeg;base64,' + response.productPhoto,
      });
      this.photo = 'data:image/jpeg;base64,' + response.productPhoto;
      this.basephoto = 'data:image/jpeg;base64,' + response.productPhoto;
    });
  }

  productForm = this.formBuilder.group({
    id: ['', Validators.required],
    name: ['', Validators.required],
    price: ['', Validators.required],
    quantity: ['', Validators.required],
    description: ['', Validators.required],
    specification: ['', Validators.required],
    productPhoto: ['', Validators.required],
  });

  photo: any;
  basephoto: any;
  ngOnInit(): void {}

  submit() {
    if (this.basephoto == this.photo) {
      this.productForm.value.productPhoto = null;
    }

    this.adminService
      .putProduct(consts.toFormData(this.productForm.value))
      .subscribe();
  }

  deleteProduct() {
    this.adminService.deleteProduct(this.productForm.value.id).subscribe();
    this.router.navigateByUrl('admin/produkty');
  }

  changephoto() {
    let photo = this.productForm.value.productPhoto;
    var reader = new FileReader();
    reader.readAsDataURL(photo);
    reader.onload = (_event) => {
      this.photo = reader.result;
    };
  }
}
