import { Component, OnInit } from '@angular/core';
import { MainPageItem } from '../../../admin-panel/models/mainpage-item.model';
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
    this.products=new Array();
    this.adminService.getMainPageProducts().subscribe(response=> {
      
      
      response.forEach(element => {
          this.products.push(element.product);
      });
      this.finished=true;
    });
    
    
  }

  finished=false;
  products:ProductModel[]
  slides = [{'image': "./../../../../../assets/photos/baner1.jpg"},{'image': "./../../../../../assets/photos/baner2.jpg"},{'image': "./../../../../../assets/photos/baner3.jpg"},];


}
