import { Component, OnInit } from '@angular/core';
import { ProductModel } from '../../../admin-panel/models/product.model';
import { AdminPanelService } from '../../../admin-panel/services/admin-panel.service';

@Component({
  selector: 'app-mainpage',
  templateUrl: './mainpage.component.html',
  styleUrls: ['./mainpage.component.scss']
})
export class MainpageComponent implements OnInit {

  constructor(private adminService:AdminPanelService) { }

  ngOnInit(): void 
  {
    this.adminService.getMainPageProducts().subscribe(response=> {
      this.products=response;
      this.products.forEach(d=>{
        d.productPhoto="data:image/jpeg;base64,"+d.productPhoto;
      })
      
      
    });
    
    
  }

  products:ProductModel[]
  slides = [{'image': "./../../../../../assets/photos/baner1.jpg"},{'image': "./../../../../../assets/photos/baner2.jpg"},{'image': "./../../../../../assets/photos/baner3.jpg"},];


}
